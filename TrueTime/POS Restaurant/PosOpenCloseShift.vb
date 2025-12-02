Imports System.Data.SqlClient
Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraReports.UI
Imports GMap.NET

Public Class PosOpenCloseShift
    Dim _ShiftNo As Integer
    Dim _CashAmount As Decimal
    Dim _NetSales As Decimal
    Dim _EmployeeName As String
    Dim _POSName As String

    Private Sub PosOpenCloseShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TextBegBalance.Properties.Mask.EditMask = "#,##0.0 NIS"
        'TextEndBalance.Properties.Mask.EditMask = "#,##0.0 NIS"
        '  TextEndBalance.Select()
        TextEndBalance.Text = ""
        SwitchKeyboardLayout("en")
    End Sub

    Private Sub TextShiftID_EditValueChanged(sender As Object, e As EventArgs) Handles TextShiftID.EditValueChanged
        Select Case TextOpenOrClose.Text
            Case "Open"
                '  OpenShift()
                Me.TextBegBalance.Select()
            Case "Close"
                GetShiftData()
                TextEndBalance.Text = ""
                Me.TextEndBalance.Select()
        End Select
    End Sub
    Private Sub GetShiftData()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [ShiftID],[ShiftName],[StartDateTime]
                      ,[EndDateTime],[UserID],[UserName],[ShiftStatus] ,[PosNumber]
                      ,[DeviceName],[BegBalance],[CashAmount] ,[CardAmount]
                      ,[DebitAmount],[EndBalance],[TotalSales]
                     FROM [dbo].[PosShifts] where ShiftID= " & TextShiftID.EditValue
        sql.SqlTrueAccountingRunQuery(SqlString)
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StartDateTime")) Then DateEditFrom.DateTime = CDate(sql.SQLDS.Tables(0).Rows(0).Item("StartDateTime"))
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("UserID")) Then TextEmployee.Text = (sql.SQLDS.Tables(0).Rows(0).Item("UserID"))
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("UserName")) Then TextUserName.Text = (sql.SQLDS.Tables(0).Rows(0).Item("UserName"))
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BegBalance")) Then TextBegBalance.Text = (sql.SQLDS.Tables(0).Rows(0).Item("BegBalance"))
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("EndBalance")) Then TextEndBalance.Text = (sql.SQLDS.Tables(0).Rows(0).Item("EndBalance"))
    End Sub

    Private Sub OpenShift()
        If TextBegBalance.Text = "" Then TextBegBalance.Text = "0"
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim NewShiftID As Integer = 0
        sql.SqlTrueAccountingRunQuery("select isnull(max([ShiftID])+1,1) as ShiftID from [dbo].[PosShifts] ")
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")) Then NewShiftID = sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")
        SqlString = " Insert into [dbo].[PosShifts] ([ShiftID],[ShiftName],[StartDateTime],[UserID],[UserName],[ShiftStatus],
                                                     [PosNumber],[DeviceName],
                                                     [BegBalance],[CashAmount],CardAmount,DebitAmount,EndBalance,[TotalSales]) Values (" & NewShiftID & ",
                                                    0,getdate(),'" & GlobalVariables.CurrUser & "', N'" & GlobalVariables.EmployeeName & "',
                                                    'Opening'," & My.Settings.POSNo & ",'" & GlobalVariables.CurrDevice & "',
                                                    " & TextBegBalance.EditValue & ",0,0,0,0,0) "
        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
            My.Forms.POSRestCashier.TextShiftStatus.Text = "Opening"
            GlobalVariables._ShiftID = NewShiftID
            My.Forms.POSRestCashier.BarStaticShiftID.Caption = NewShiftID
            My.Forms.POSRestCashier.SidePanel1.Enabled = True
            My.Forms.POSRestCashier.SidePanel5.Enabled = True
            SendWhatsAppWhenOpen()
        End If


        'My.Forms.PosOpenCloseShift.TextShiftID.Text = _ShiftID
        'My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Open"
        'PosOpenCloseShift.ShowDialog()

    End Sub

    Private Sub CloseShift()
        If TextEndBalance.Text = "" Then TextEndBalance.Text = "0"
        If TextEndBalance.EditValue = 0 Then
            If XtraMessageBox.Show(" مبلغ اغلاق الشفت فارغ هل تريد الاستمرار ", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If
        If CheckIfShiftIsOpen() = False Then
            XtraMessageBox.Show("هذه الوردية مغلقة من قبل او غير موجودة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim _StartDateTime, _EndDateTime As String
        Dim _PrinterSize As Integer
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " DECLARE @ShiftID AS INT
        SET @ShiftID = " & TextShiftID.Text & " 
        Update [dbo].[PosShifts]
        Set 
          [EndDateTime]=GETDATE(),
          [ShiftStatus]='Closed',
          [EndBalance]=" & TextEndBalance.EditValue & " ,
          [CashAmount]= IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='Cash' And DocName in (2,12) ),0) ,
	      [ReceiptsCash]= IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='Cash' And DocName =4 ),0) ,
          [ReceiptsCard]= IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='Card' And DocName =4 ),0) ,
		  [PaymentsCash]= -1 * IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='Cash' And DocName =3 ),0) ,
          [CardAmount]= IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='Card' And DocName=2  ),0) ,
          [DebitAmount]=IsNull((select sum([VoucherAmount]) from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID and [VoucherPayType]='CSTMR' ),0) ,
          [TotalSales]= IsNull((select sum([VoucherAmount])  from [dbo].[PosVouchers] where  [ShiftID]=@ShiftID And DocName in (2,12) ),0)  ,
          [DeletedItemsCount]=IsNull((select count(StockID) from [dbo].[POSDeletedJournal] where [ShiftID]=@ShiftID ),0),
          [DeletedItemsAmount]=IsNull((select TRY_CAST (Sum(DocAmount) as  decimal(18,2) ) from [dbo].[POSDeletedJournal] where [ShiftID]=@ShiftID ),0),
          [DiscountAmountForCash] =(Select IsNull(sum([VoucherDiscount]),0)+IsNull(sum([VoucherDiscount2]),0) from [dbo].[PosVouchers] where ShiftID=@ShiftID and [VoucherPayType]='Cash'),
          [DiscountAmountForCards]=(Select IsNull(sum([VoucherDiscount]),0)+IsNull(sum([VoucherDiscount2]),0) from [dbo].[PosVouchers] where ShiftID=@ShiftID and [VoucherPayType]='Card'),
          [DiscountAmountForCSTMR]=(Select IsNull(sum([VoucherDiscount]),0)+IsNull(sum([VoucherDiscount2]),0) from [dbo].[PosVouchers] where ShiftID=@ShiftID and [VoucherPayType]='CSTMR'),
          [GiftAmount]= IsNull((select Sum(VoucherAmountAfterDiscount) from [dbo].[PosVouchers] where DocName=18 and VoucherNote like N'%هدية%' And [ShiftID]=@ShiftID ),0),
          [ItlafAmount]=IsNull((select Sum(VoucherAmountAfterDiscount) from [dbo].[PosVouchers] where DocName=18 and VoucherNote like N'%اتلاف%' And [ShiftID]=@ShiftID ),0)
         Where ShiftID=@ShiftID;  
         Update [dbo].[PosShifts] Set [Diff]=  [EndBalance]- ([BegBalance]+[CashAmount]-[DiscountAmountForCash]+[ReceiptsCash]-[PaymentsCash]);
         UPDATE AccountingPOSNames Set VouchersCounter=0 WHERE ID = " & My.Settings.POSNo & ";
		 Insert Into PosShiftsByUsers (ShiftID,CashAmount,UserID,UserName)
		 select  @ShiftID,sum([VoucherAmount]),UserNo,E.EmployeeName
		 from [dbo].[PosVouchers] P
		 left Join EmployeesData E on E.EmployeeID=P.UserNo
		 where  [ShiftID]=@ShiftID and [VoucherPayType]='Cash' 
		 group by UserNo , EmployeeName"

        'sql.SqlTrueAccountingRunQuery(SqlString)
        '    report.EndBalance.Text - (Val(report.CashAmount.Text) + Val(report.BegBalance.Text) - Val(report.DiscountAmountForCash.Text) + Val(report.XrReceiptsCash.Text) - Val(report.XrPaymentsCash.Text))
        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
            SqlString = " SELECT  [ShiftID]
      ,[ShiftName]      ,[StartDateTime]
      ,[EndDateTime]      ,[UserID]
      ,[ShiftStatus]      ,[PosNumber]
      ,[DeviceName]      ,[BegBalance] ,[GiftAmount],[ItlafAmount]
      ,Cast([CashAmount] as decimal(10, 2)) as  CashAmount    ,Cast([CardAmount] as decimal(10, 2)) as CardAmount
      ,Cast ([DebitAmount]as decimal(10, 2) )   as DebitAmount   ,Cast([EndBalance] as decimal(10, 2)) as EndBalance
      ,Cast([TotalSales] as decimal(10, 2) ) as TotalSales, UserName,Cast([DiscountAmountForCash] as decimal(10, 2) ) as DiscountAmountForCash ,Cast ([ReceiptsCash] as decimal(10, 2) ) as ReceiptsCash,Cast ([ReceiptsCash] as decimal(10, 2) ) as ReceiptsCard ,Cast ([PaymentsCash] as decimal(10, 2) ) as PaymentsCash,
       Cast ([DiscountAmountForCards] as decimal(10, 2) ) as DiscountAmountForCards ,Cast([DiscountAmountForCSTMR] as decimal(10, 2) ) as DiscountAmountForCSTMR ,A.POSName As POSName ,
       [DeletedItemsCount],[DeletedItemsAmount],Cast((DiscountAmountForCash+DiscountAmountForCards+DiscountAmountForCSTMR) as decimal(10, 2) ) As TotalDiscount,Cast (TotalSales-(DiscountAmountForCash+DiscountAmountForCards+DiscountAmountForCSTMR) as decimal(10, 2) ) As NetSales
      FROM [dbo].[PosShifts] P left join AccountingPOSNames A on P.PosNumber=A.ID Where ShiftID=" & TextShiftID.Text & " "

            sql.SqlTrueAccountingRunQuery(SqlString)

            Dim sql2 As New SQLControl
            sql2.SqlTrueAccountingRunQuery("SELECT *  FROM [dbo].[PosShiftsByUsers] where ShiftID=" & TextShiftID.Text)
            GridControl1.DataSource = sql2.SQLDS.Tables(0)

            _StartDateTime = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("StartDateTime")), "yyyy-MM-dd dddd HH:mm:ss")
            _EndDateTime = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("EndDateTime")), "yyyy-MM-dd dddd HH:mm:ss")

            _PrinterSize = PosPrinterSize()
            If _PrinterSize = 200 Then
                Dim report As New CloseShiftReportThin()
                With sql.SQLDS.Tables(0).Rows(0)
                    report.ShiftID.Text = .Item("ShiftID")
                    report.StartDateTime.Text = Format(CDate(.Item("StartDateTime")), "yyyy-MM-dd dddd HH:mm")
                    report.EndDateTime.Text = Format(CDate(.Item("EndDateTime")), "yyyy-MM-dd dddd HH:mm")
                    report.UserID.Text = "(" & .Item("UserID") & ")"
                    If Not IsDBNull(.Item("UserName")) Then
                        report.UserName.Text = .Item("UserName")
                        _EmployeeName = .Item("UserName")
                    End If
                    If Not IsDBNull(.Item("POSName")) Then
                        _POSName = .Item("POSName")
                    End If
                    report.BegBalance.Text = .Item("BegBalance")
                    report.CashAmount.Text = .Item("CashAmount")
                    If Not IsDBNull(.Item("CardAmount")) Then report.CardAmount.Text = .Item("CardAmount")
                    If Not IsDBNull(.Item("EndBalance")) Then report.EndBalance.Text = .Item("EndBalance")
                    If Not IsDBNull(.Item("TotalSales")) Then report.TotalSales.Text = .Item("TotalSales")
                    If Not IsDBNull(.Item("PaymentsCash")) Then report.XrPaymentsCash.Text = .Item("PaymentsCash")
                    If Not IsDBNull(.Item("ReceiptsCash")) Then report.XrReceiptsCash.Text = .Item("ReceiptsCash")
                    If Not IsDBNull(.Item("ReceiptsCard")) Then report.XrReceiptsCard.Text = .Item("ReceiptsCard")
                    If Not IsDBNull(.Item("DebitAmount")) Then report.DebitAmount.Text = .Item("DebitAmount")
                    If Not IsDBNull(.Item("DiscountAmountForCash")) Then report.DiscountAmountForCash.Text = .Item("DiscountAmountForCash")
                    If Not IsDBNull(.Item("DiscountAmountForCards")) Then report.DiscountAmountForCards.Text = .Item("DiscountAmountForCards")
                    If Not IsDBNull(.Item("DiscountAmountForCSTMR")) Then report.DiscountAmountForCSTMR.Text = .Item("DiscountAmountForCSTMR")
                    If Not IsDBNull(.Item("DeletedItemsCount")) Then report.DeletedItemsCount.Text = .Item("DeletedItemsCount") & " " & " حركة "
                    If Not IsDBNull(.Item("TotalDiscount")) Then report.TotalDiscount.Text = .Item("TotalDiscount")
                    If Not IsDBNull(.Item("NetSales")) Then
                        report.NetSales.Text = .Item("NetSales")
                        _NetSales = .Item("NetSales")
                    End If

                    report.XrLabelDiff.Text = report.EndBalance.Text - (Val(report.CashAmount.Text) + Val(report.BegBalance.Text) - Val(report.DiscountAmountForCash.Text) + Val(report.XrReceiptsCash.Text) - Val(report.XrPaymentsCash.Text))
                End With

                Try
                    Dim cn As SqlConnection
                    cn = New SqlConnection
                    cn.ConnectionString = My.Settings.TrueTimeConnectionString
                    Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo,CompanyName from [dbo].[CompanyData]  ")
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                    report.XrPictureBox1.Image = Image.FromStream(ImgStream)
                    ImgStream.Dispose()
                    cmd.Connection.Close()
                    cn.Close()
                Catch ex As Exception

                End Try

                SendCloseShiftToSMS()
                report.ExportToPdf("ShiftReport.pdf")
                SendDailyReport(_StartDateTime, _EndDateTime)

                report.Print()
                'report.ShowPreview()
                '    Application.Restart()

                Try
                    Dim processes As Process() = Process.GetProcessesByName("TrueTime")
                    For Each p As Process In processes
                        p.Kill()
                    Next
                Catch ex As Exception

                End Try


            Else
                Dim report As New CloseShiftReport()
                'report.PageWidth = _PrinterSize
                With sql.SQLDS.Tables(0).Rows(0)
                    report.ShiftID.Text = .Item("ShiftID")
                    report.StartDateTime.Text = Format(CDate(.Item("StartDateTime")), "yyyy-MM-dd dddd HH:mm")
                    report.EndDateTime.Text = Format(CDate(.Item("EndDateTime")), "yyyy-MM-dd dddd HH:mm")
                    report.UserID.Text = "(" & .Item("UserID") & ")"
                    If Not IsDBNull(.Item("UserName")) Then
                        report.UserName.Text = .Item("UserName")
                        _EmployeeName = .Item("UserName")
                    End If
                    report.BegBalance.Text = .Item("BegBalance")
                    report.CashAmount.Text = .Item("CashAmount")
                    If Not IsDBNull(.Item("CardAmount")) Then report.CardAmount.Text = .Item("CardAmount")
                    If Not IsDBNull(.Item("EndBalance")) Then report.EndBalance.Text = .Item("EndBalance")
                    If Not IsDBNull(.Item("TotalSales")) Then report.TotalSales.Text = .Item("TotalSales")
                    If Not IsDBNull(.Item("PaymentsCash")) Then report.XrPaymentsCash.Text = .Item("PaymentsCash")
                    If Not IsDBNull(.Item("ReceiptsCash")) Then report.XrReceiptsCash.Text = .Item("ReceiptsCash")
                    If Not IsDBNull(.Item("ReceiptsCard")) Then report.XrReceiptsCard.Text = .Item("ReceiptsCard")
                    If Not IsDBNull(.Item("DebitAmount")) Then report.DebitAmount.Text = .Item("DebitAmount")
                    If Not IsDBNull(.Item("DiscountAmountForCash")) Then report.DiscountAmountForCash.Text = .Item("DiscountAmountForCash")
                    If Not IsDBNull(.Item("DiscountAmountForCards")) Then report.DiscountAmountForCards.Text = .Item("DiscountAmountForCards")
                    If Not IsDBNull(.Item("DiscountAmountForCSTMR")) Then report.DiscountAmountForCSTMR.Text = .Item("DiscountAmountForCSTMR")
                    If Not IsDBNull(.Item("GiftAmount")) Then report.XrLabelGift.Text = .Item("GiftAmount")
                    If Not IsDBNull(.Item("ItlafAmount")) Then report.XrLabelItlaf.Text = .Item("ItlafAmount")
                    If Not IsDBNull(.Item("DeletedItemsCount")) Then report.DeletedItemsCount.Text = .Item("DeletedItemsCount") & " " & " حركة "
                    If Not IsDBNull(.Item("TotalDiscount")) Then report.TotalDiscount.Text = .Item("TotalDiscount")
                    If Not IsDBNull(.Item("NetSales")) Then
                        report.NetSales.Text = .Item("NetSales")
                        _NetSales = .Item("NetSales")
                    End If
                    If Not IsDBNull(.Item("POSName")) Then
                        _POSName = .Item("POSName")
                    End If
                    'report.XrTableShiftByUsers.da
                    'report.XrLabelDiff.Text = report.EndBalance.Text - (Val(report.CashAmount.Text) + Val(report.BegBalance.Text) - Val(report.DiscountAmountForCash.Text))
                    report.XrLabelDiff.Text = report.EndBalance.Text - (Val(report.CashAmount.Text) + Val(report.BegBalance.Text) - Val(report.DiscountAmountForCash.Text) + Val(report.XrReceiptsCash.Text) - Val(report.XrPaymentsCash.Text))
                    'report.Parameters("ShiftIDParameter").Value = .Item("ShiftID")
                    report.PrintableComponentContainer1.PrintableComponent = GridControl1
                End With

                Try
                    Dim cn As SqlConnection
                    cn = New SqlConnection
                    cn.ConnectionString = My.Settings.TrueTimeConnectionString
                    Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo,CompanyName from [dbo].[CompanyData]  ")
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                    report.XrPictureBox1.Image = Image.FromStream(ImgStream)
                    ImgStream.Dispose()
                    cmd.Connection.Close()
                    cn.Close()
                Catch ex As Exception

                End Try

                SendCloseShiftToSMS()

                Try
                    sql.SqlTrueAccountingRunQuery("Select CompanyName from [dbo].[CompanyData]  ")
                    report.XrLabelCompanyName.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
                Catch ex As Exception

                End Try
                report.ExportToPdf("ShiftReport.pdf")
                SendDailyReport(_StartDateTime, _EndDateTime)

                If PrintPosReport() Then
                    report.Print()
                End If

                'report.ShowPreview()
                ' Application.Restart()

                Dim processes As Process() = Process.GetProcessesByName("TrueTime")
                For Each p As Process In processes
                    p.Kill()
                Next
            End If


        Else
            MsgBox("Error")
        End If


        ' If p.Count > 0 Then Att = Process.GetProcessesByName("att")(0) : GoTo ReadAtt


    End Sub
    Private Sub SendDailyReport(_fromDate As String, _toDate As String)
        'ارسال التقرير اليومي 
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSCheckSendClosedShiftToMobile'")
            If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                Dim CloseReportCharts As New PosShiftReportForPrint
                Dim _ReportTitle As String
                _ReportTitle = " تقرير المبيعات اليومي  " & " " & Format(DateEditFrom.DateTime, "dddd") & " -  " & Format(DateEditFrom.DateTime, "dd/MM/yyyy")
                With CloseReportCharts
                    .XrLabelBranch.Text = " مبيعات نقطة البيع - الرئيسي "
                    .XrLabelReportName.Text = _ReportTitle
                    ' Fill DailySales Chart
                    POSRestCashier.GetSalesForChart(_fromDate, _toDate)
                    .XrChartSalesByGroup.DataSource = POSRestCashier.ChartControlSalesByGroups.DataSource
                    .XrChartSalesByHours.DataSource = POSRestCashier.ChartControlSalesByHoures.DataSource
                    .XrChartDailySalesThisMonth.DataSource = POSRestCashier.ChartControlDailySalesThisMonth.DataSource
                    .ChartControlMonthly.DataSource = POSRestCashier.ChartControlMonthly.DataSource

                    'Dim _GetSalesSummery = GetSalesSummery()
                    '.XrLabelTotalSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Total & "</b></u>" & " مجموع المبيعات: "
                    '.XrLabelCashSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Cash & "</b></u>" & " نقدا: "
                    '.XrLabelVISASales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Visa & "</b></u>" & " فيزا: "
                    '.XrLabelCustomersSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Customers & "</b></u>" & " دين: "

                    sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSNumbersToSendClosedShift'")
                    If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                        CloseReportCharts.ExportToPdf("DailySalesReport.pdf")
                        Dim wordsArray As String() = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").Split("-"c)
                        For Each word As String In wordsArray
                            SendFileToWhatsApp(word, "DailySalesReport.pdf", "المبيعات اليومي", "", "")
                            SendFileToWhatsApp(word, "ShiftReport.pdf", "تقرير اغلاق الوردية", "", "")
                        Next
                    End If
                End With



                'POSRestCashier.GetSalesForChart(Format(Today(), "yyyy-MM-dd") & " 00:00:00.000", Format(Today(), "yyyy-MM-dd") & " 23:59:59.999")
                'POSRestCashier.ChartControlSalesByHoures.ExportToPdf("DailyReport.pdf")
                'Dim DateFrom As New DateTime(Format(Today, "yyyy"), Format(Today, "MM"), 1)
                'POSRestCashier.GetSalesForChart(Format(DateFrom, "yyyy-MM-dd") & " 00:00:00.000", Format(Today(), "yyyy-MM-dd") & " 23:59:59.999")
                'POSRestCashier.ChartControlMonthlySales.ExportToPdf("MonthlyReport.pdf")
                'sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSNumbersToSendClosedShift'")
                'If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                '    report.ExportToPdf("CloseShift.pdf")
                '    Dim wordsArray As String() = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").Split("-"c)
                '    For Each word As String In wordsArray
                '        SendFileToWhatsApp(word, "CloseShift.pdf", "اغلاق الوردية", "")
                '        SendFileToWhatsApp(word, "DailyReport.pdf", "مبيعات اليوم حسب الساعة", "")
                '        SendFileToWhatsApp(word, "MonthlyReport.pdf", "المبيعات الشهرية", "")
                '    Next
                'End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleOpenCloseShift_Click(sender As Object, e As EventArgs) Handles SimpleOpenCloseShift.Click
        Select Case TextOpenOrClose.Text
            Case "Open"
                OpenShift()
            Case "Close"
                CloseShift()
        End Select
        Me.Dispose()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If TextOpenOrClose.Text = "Open" Then
            Application.Exit()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub TextOpenOrClose_EditValueChanged(sender As Object, e As EventArgs) Handles TextOpenOrClose.EditValueChanged
        If TextOpenOrClose.Text = "Open" Then
            Me.Text = "فتح وردية عمل"
            Me.TextDevice.Text = GlobalVariables.CurrDevice
            TextBegBalance.EditValue = 0
            TextEndBalance.EditValue = 0
            DateEditFrom.EditValue = Now
            TextEmployee.Text = GlobalVariables.CurrUser
            TextUserName.Text = GlobalVariables.EmployeeName
            SimpleOpenCloseShift.Text = "فتح وردية عمل"
            SimpleOpenCloseShift.ImageOptions.Image = My.Resources.ResourceManager.GetObject("open_sign_48px")
            TextShiftID.Text = GetShiftMax()
            LayoutEndShitDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutEndBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            TextBegBalance.BackColor = Color.PowderBlue
            'TextBegBalance.Select()
            TextBegBalance.SelectAll()
            TextBegBalance.Focus()
        Else
            Me.Text = "اغلاق وردية عمل"
            SimpleOpenCloseShift.Text = "اغلاق وردية عمل"
            TextUserName.Text = GlobalVariables.EmployeeName
            DateEditTo.EditValue = Now
            SimpleOpenCloseShift.ImageOptions.Image = My.Resources.ResourceManager.GetObject("close_sign_48px")
            TextBegBalance.ReadOnly = True
            GetShiftData()
            'TextBegBalance.Select()
            TextEndBalance.SelectAll()
            TextEndBalance.Focus()
        End If
    End Sub
    Private Function GetShiftMax() As Integer
        Dim ShitID As Integer
        Dim sql As New SQLControl
        Try
            sql.SqlTrueAccountingRunQuery(" select isnull(max([ShiftID])+1,1) as ShiftID from [dbo].[PosShifts] ")
            ShitID = sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")
        Catch ex As Exception
            ShitID = 0
        End Try
        Return ShitID
    End Function

    Private Sub SendCloseShiftToSMS()
        Dim sql As New SQLControl
        Dim _MobileNo As String = ""
        Dim _SendSMS As Boolean


        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosSendSMSMobileWhenClosePosShift' ")
            _SendSMS = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _SendSMS = False
        End Try

        If _SendSMS = False Then Exit Sub

        Try
            sql.SqlTrueAccountingRunQuery("Select IsNull([SettingValue],'') as SettingValue
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosMobileNoToSendCloseShiftSMS' ")
            _MobileNo = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _MobileNo = ""
        End Try




        Try
            Dim SMSDetails As String
            SMSDetails = " تم اغلاق وردية رقم  " & Me.TextShiftID.Text & " للموظف  " & _EmployeeName & " بفرع " & _POSName & " وبلغت صافي المبيعات " & _NetSales
            If _MobileNo <> "" And SMSDetails <> "" Then
                SendSMSMessage(_MobileNo, SMSDetails, CStr(Me.RadioGroupSendType.EditValue), False, "")
            End If
        Catch ex As Exception

        End Try



    End Sub


    Private Sub TextEndBalance_MouseUp(sender As Object, e As MouseEventArgs) Handles TextEndBalance.MouseUp
        TextEditSelectText(TextEndBalance)
    End Sub
    Private Sub TextBegBalance_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBegBalance.MouseUp
        TextEditSelectText(TextBegBalance)
    End Sub
    Private Sub SendWhatsAppWhenOpen()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSCheckSendClosedShiftToMobile'")
            If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSNumbersToSendClosedShift'")
                If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                    Dim wordsArray As String() = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").Split("-"c)
                    For Each word As String In wordsArray
                        SendSMSMessage(word, " تم فتح وردية " & " / " & GlobalVariables.EmployeeName, "WhatsApp", False, "")
                    Next
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumericButton_Click(sender As Object, e As EventArgs)
        ' Get the button that was clicked
        Dim clickedButton As SimpleButton = CType(sender, SimpleButton)

        Dim number As String = clickedButton.Text

        '   Dim activeTextBox As TextEdit = CType(Me.ActiveControl, TextEdit)




        Select Case TextOpenOrClose.Text
            Case "Open"
                TextBegBalance.Text &= number
                TextBegBalance.SelectionStart = TextBegBalance.Text.Length
            Case "Close"
                TextEndBalance.Text &= number
                TextEndBalance.SelectionStart = TextEndBalance.Text.Length
        End Select

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        Select Case TextOpenOrClose.Text
            Case "Open"
                TextBegBalance.Text = ""
            Case "Close"
                TextEndBalance.Text = ""
        End Select
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ShowKeyboard()
    End Sub
    Private Function GetLastMaxShiftID() As Integer
        Dim sql As New SQLControl
        Dim ShiftID As Integer = 0
        Try
            sql.SqlTrueAccountingRunQuery(" Select top 1 ShiftID 
                                        from [dbo].[PosShifts] 
                                        where [PosNumber]=" & My.Settings.POSNo & " And ShiftStatus='Opening'  order by ShiftID desc")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")) Then ShiftID = sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")
        Catch ex As Exception
            ShiftID = 0
        End Try
        Return ShiftID
    End Function
    Private Function CheckIfShiftIsOpen() As Boolean
        Dim sql As New SQLControl
        Dim sqlString As String
        Dim _IsOpen As Boolean = False
        Try
            sqlString = " Select ShiftStatus 
                          From [dbo].[PosShifts] 
                          Where [PosNumber]=" & My.Settings.POSNo & " And ShiftStatus='Opening'  And ShiftID=" & TextShiftID.Text
            sql.SqlTrueAccountingRunQuery(sqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _IsOpen = True
            Else
                _IsOpen = False
            End If
        Catch ex As Exception
            _IsOpen = False
        End Try
        Return _IsOpen
    End Function
    Private Function PrintPosReport() As Boolean
        Dim sql As New SQLControl
        Dim _PrintPosReport As Boolean
        Try
            sql.SqlTrueAccountingRunQuery(" Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POS_PrintClosedShiftReport' ")
            _PrintPosReport = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _PrintPosReport = False
        End Try
        Return _PrintPosReport
    End Function
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        PosPrintVoucherEmpty()
    End Sub
End Class