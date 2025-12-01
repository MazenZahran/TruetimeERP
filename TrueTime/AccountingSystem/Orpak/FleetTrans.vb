Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FleetTrans
    Public _OpenForPrint As Boolean
    Public _SendWhatsApp As Boolean
    Private _SendWhatsAppToNo As Boolean = False

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "last"
                Dim _fromdate, _todate As DateTime
                Dim _lastmonth, _year As Integer
                If Today.Month = 1 Then
                    _lastmonth = 12
                    _year = Today.Year - 1
                Else
                    _lastmonth = Today.Month - 1
                    _year = Today.Year
                End If
                Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
                _fromdate = New DateTime(_year, _lastmonth, 1)
                _todate = New DateTime(_year, _lastmonth, _daysCount)
                Me.DateEdit2.DateTime = _todate
                Me.DateEdit1.DateTime = _fromdate

            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt
        End Select
    End Sub

    Private Sub FleetTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If _OpenForPrint = True Then
            GetTransDataFromOrpakForFleet()
            PrintReportForFleetTrans()
            Me.Close()
        Else
            RadioGroup1.EditValue = "last"
            'Me.DateEdit2.DateTime = Today
            'Dim startDt As New Date(Today.Year, Today.Month, 1)
            'Me.DateEdit1.DateTime = startDt
        End If
        _SendWhatsAppToNo = False

    End Sub
    Public Sub GetTransDataFromOrpakForFleet()
        GridControl1.DataSource = ""
        GridControl2.DataSource = ""
        If Me.TextRefNo.Text = "" Then
            MsgBoxShowError(" يجب اختيار زبون ")
            Exit Sub
        End If

        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable
        Dim _dateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd") & " 00:00:00"
        Dim _date__To As String = Format(DateEdit2.DateTime, "yyyy-MM-dd") & " 23:59:59"

        SqlString = " select T.[timestamp] , [date] as TransDate,CONVERT(varchar(5), [time], 108) as TransTime,[plate] as Vehicle_Number ," & ProductNameCase() & ",[quantity] as Quantity,CONVERT(DECIMAL(10,2),ppv )as Price,
                         [sale] as TotalSale,receipt_d.receipt_id as Receipt,Odometer
                          From [dbo].[transactions] T
                          left join fleets ON T.fleet_id = fleets.id 
                          left join receipt_d ON T.id = receipt_d.transaction_id  AND T.stn_id = receipt_d.stn_id
                          where quantity > 0 And T.timestamp between '" & _dateFrom & "' and '" & _date__To & "'"
        If TextRefNo.Text <> "" Then SqlString += " and fleets.code='" & TextRefNo.EditValue & "'"
        SqlString += "  Order by T.[timestamp] "



        Dim Con As SqlConnection
        Dim Adapter1 As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(GetOrpakConnectionString(1)._Cstring)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "transactions")
        Con.Close()
        dataSet11.AcceptChanges()
        GridControl1.DataSource = dataSet11.Tables("transactions")




        SqlString = "select  sum(quantity) as Quantity, sum(sale) as Amount," & ProductNameCase() & ",CONVERT(DECIMAL(10,2),sum(sale)/ISNULL(sum(quantity), 1)) as Price
                          from [dbo].[transactions] T
                          left join fleets F ON T.fleet_id = F.id 
                          where quantity > 0 And T.timestamp between '" & _dateFrom & "' and '" & _date__To & "' And F.code ='" & CStr(TextRefNo.EditValue) & "'"
        SqlString += " group by product_name "
        sql.SqlOrpakRunQuery(SqlString, 1)
        GridControl2.DataSource = sql.SQLDS.Tables(0)




    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetTransDataFromOrpakForFleet()
    End Sub
    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.Properties.BeforePopup
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub
    Public Sub PrintReportForFleetTrans()
        If GridView1.RowCount = 0 Or GridView2.RowCount = 0 Then
            _SendWhatsAppToNo = False
            Exit Sub
        End If
        Dim report As New LiteCustomerTrans()
        report.PrintableComponentContainer1.PrintableComponent = GridControl1
        report.PrintableComponentContainer2.PrintableComponent = GridControl2
        report.XrLabelMonth.Text = " من " & DateEdit1.DateTime & " الى " & DateEdit2.DateTime
        report.XrLabelAccID.Text = CStr(TextRefNo.Text) & " / " & TextRefName.Text

        If CheckEditShowBalance.Checked = False Then
            report.XrLabelBegAmount.Visible = False
            report.XrLabelDebitAmount.Visible = False
            report.XrLabelRecieptAmount.Visible = False
            report.XrLabelRequirdAmount.Visible = False
            report.XrLabelBegAmountLabel.Visible = False
            report.XrLabelDebitAmountLabel.Visible = False
            report.XrLabelRecieptAmountLabel.Visible = False
            report.XrLabelRequirdAmountLabel.Visible = False
        Else
            report.XrLabelBegAmount.Visible = True
            report.XrLabelDebitAmount.Visible = True
            report.XrLabelRecieptAmount.Visible = True
            report.XrLabelRequirdAmount.Visible = True
            Dim _RefBalances = GetRefBalances(DateEdit1.DateTime, DateEdit2.DateTime, CInt(TextRefNo.Text))
            report.XrLabelBegAmount.Text = _RefBalances.BegBalance.ToString("N1") & " ₪ "
            report.XrLabelDebitAmount.Text = _RefBalances.DebitAmount.ToString("N1") & " ₪ "
            report.XrLabelRecieptAmount.Text = _RefBalances.RecieptAmount.ToString("N1") & " ₪ "
            report.XrLabelRequirdAmount.Text = _RefBalances.EndBalance.ToString("N1") & " ₪ "
        End If

        Dim preview As New ReportPrintTool(report)

        If _OpenForPrint = True Then
            If _SendWhatsApp = True Then
                report.ExportToPdf("FleetTrans.pdf")
                Dim _ReportTitle As String = " كشف سحوبات المركبات  " & " الفترة من " & Format(Me.DateEdit1.DateTime, "dd/MM/yyyy") & " الى " & Format(Me.DateEdit2.DateTime, "dd/MM/yyyy")
                If _SendWhatsAppToNo = False Then
                    Dim _RefData = GetRefranceData(Me.TextRefNo.Text)
                    SendFileToWhatsApp(_RefData.RefMobile, "FleetTrans.pdf", _ReportTitle, "", SearchReferance.Text)
                    'MsgBoxShowSuccess(" تم ارسال الكشف للزبون بنجاح ")
                Else
                    Dim myControl As New SendToWhatsAppNo()
                    myControl.textMobileNo.Select()
                    If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                        Dim MobileNo As String = myControl.Mobile
                        If String.IsNullOrEmpty(MobileNo) Then
                            _SendWhatsAppToNo = False
                            Exit Sub
                        Else
                            SendFileToWhatsApp(MobileNo, "FleetTrans.pdf", _ReportTitle, "", SearchReferance.Text)
                        End If
                    End If
                End If

            Else
                preview.Print()
            End If

        Else
            preview.ShowRibbonPreview()
        End If
        _SendWhatsAppToNo = False

        'Select Case CStr(RadioGroup1.EditValue)
        '    Case "Print"
        '        preview.Print()
        '    Case "Preview"
        '        preview.ShowRibbonPreview()
        '    Case "Email"
        '        'EmailDataTrans(CustEmail.Text, report, "تقرير الحركات")
        'End Select

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        _SendWhatsApp = False
        _SendWhatsAppToNo = False
        PrintReportForFleetTrans()

        'Dim _RefBalances = GetRefBalances(DateEdit1.DateTime, DateEdit2.DateTime, CInt(TextRefNo.Text))
        'MsgBox(_RefBalances._BegBalance.ToString("N1") & " ₪ ")
        'MsgBox(_RefBalances._DebitAmount.ToString("N1") & " ₪ ")
        'MsgBox(_RefBalances._RecieptAmount.ToString("N1") & " ₪ ")
        'MsgBox(_RefBalances._EndBalance.ToString("N1") & " ₪ ")

    End Sub

    Private Sub SearchReferance_EditValueChanged(sender As Object, e As EventArgs) Handles SearchReferance.EditValueChanged
        Me.TextRefNo.Text = Me.SearchReferance.EditValue
        Me.TextRefName.Text = Me.SearchReferance.Text
    End Sub

    Private Sub FleetTrans_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub FleetTrans_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        'Dim _ReportTitle As String = " كشف سحوبات المركبات  " & " الفترة من " & Format(Me.DateEdit1.DateTime, "dd/MM/yyyy") & " الى " & Format(Me.DateEdit2.DateTime, "dd/MM/yyyy")
        'Me.GridView1.ExportToPdf("FleetTrans.pdf")
        'SendToWhatsApp(_RefData.RefMobile, "FleetTrans.pdf", _ReportTitle)
        _OpenForPrint = True
        _SendWhatsApp = True
        PrintReportForFleetTrans()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick

        _OpenForPrint = True
        _SendWhatsApp = True
        _SendWhatsAppToNo = True
        PrintReportForFleetTrans()
        ' تم اضافة هذهالاكواد ل ماضي 
        _OpenForPrint = True
        _SendWhatsApp = True
        _SendWhatsAppToNo = True
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick

    End Sub
End Class