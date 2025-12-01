Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI



Public Class PosShiftsReport
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()

        Dim FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm")
        Dim ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm")

        GridControl1.DataSource = Nothing
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select [ShiftID],[ShiftName],StartDateTime, case when [EndDateTime] Is Null then [StartDateTime] else [EndDateTime] end as [EndDateTime],
	                             case when [EndDateTime] is Not Null then datediff (HH, [StartDateTime], [EndDateTime]) else 0 end as ShiftPeriod 
                                ,[UserID],[ShiftStatus],[PosNumber],[DeviceName],[BegBalance],[CashAmount]
                                ,[CardAmount],[DebitAmount],[EndBalance],([TotalSales]-IsNull(P.DiscountAmountForCards,0)-IsNull(P.DiscountAmountForCash,0)-IsNull(P.DiscountAmountForCSTMR,0)) As TotalSales
                                ,[UserName],[DeletedItemsCount],[DeletedItemsAmount],[DiscountAmountForCash]
                                ,[DiscountAmountForCards],[DiscountAmountForCSTMR],[VoucherCounter],[ReceiptsCash]
                                ,[PaymentsCash],[Diff],
                                 E.EmployeeName,IsNull(P.DiscountAmountForCash,0)+IsNull(P.DiscountAmountForCSTMR,0) as Discount
                                ,P2.PosName
                                ,P.BegBalance+ P.CashAmount+P.ReceiptsCash-P.PaymentsCash-P.DiscountAmountForCash As CashReq
                          FROM [dbo].[PosShifts] P 
                                Left join [dbo].[EmployeesData] E on P.[UserID] = E.EmployeeID 
                                Left join AccountingPOSNames P2 on P2.ID = P.PosNumber
                          where  StartDateTime  between '" & FromDate & "' and '" & ToDate & "'"

            If SearchEmployees.EditValue IsNot Nothing Then
                SqlString += " And UserID ='" & SearchEmployees.EditValue & "'"
            End If

            If SearchPOSNames.EditValue IsNot Nothing Then
                SqlString += " And P.PosNumber ='" & SearchPOSNames.EditValue & "'"
                ColPOSName.Visible = True
            End If

            SqlString += " order by ShiftID desc  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        If CheckAutoFit.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub
    Private Sub GetUsers()
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " Select distinct [UserID] as EmployeeID, [EmployeeName] 
                                    from [dbo].[PosShifts] P 
                                    left join  [dbo].[EmployeesData] E on P.[UserID] = E.EmployeeID "
            sql.SqlTrueAccountingRunQuery(SqlString)
            SearchEmployees.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        SearchLookUpEdit1View.BestFitColumns()
    End Sub

    Private Sub PosShiftsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt
        Me.KeyPreview = True
        GetUsers()
        Me.SearchPOSNames.Properties.DataSource = GetAccountingPosNamesTable()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoFit.CheckedChanged
        If CheckAutoFit.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        BandedGridView1.OptionsSelection.MultiSelect = True
        BandedGridView1.SelectAll()
        BandedGridView1.CopyToClipboard()
        BandedGridView1.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub RepositoryPreview_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryPreview.ButtonClick
        Dim _ShiftID As Integer
        _ShiftID = BandedGridView1.GetFocusedRowCellValue("ShiftID")
        If BandedGridView1.GetFocusedRowCellValue("ShiftStatus") = "Opening" Then
            MsgBox("لا يمكن طباعة تقرير الوردية المفتوحة")
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [ShiftID]
      ,[ShiftName]      ,[StartDateTime]
      ,[EndDateTime]      ,[UserID]
      ,[ShiftStatus]      ,[PosNumber]
      ,[DeviceName]      ,[BegBalance]
      ,Cast([CashAmount] as decimal(10, 2)) as  CashAmount    ,Cast([CardAmount] as decimal(10, 2)) as CardAmount
      ,Cast ([DebitAmount]as decimal(10, 2) )   as DebitAmount   ,Cast([EndBalance] as decimal(10, 2)) as EndBalance
      ,Cast([TotalSales] as decimal(10, 2) ) as TotalSales, UserName,Cast([DiscountAmountForCash] as decimal(10, 2) ) as DiscountAmountForCash ,Cast ([ReceiptsCash] as decimal(10, 2) ) as ReceiptsCash ,Cast ([PaymentsCash] as decimal(10, 2) ) as PaymentsCash,
       Cast ([DiscountAmountForCards] as decimal(10, 2) ) as DiscountAmountForCards ,Cast([DiscountAmountForCSTMR] as decimal(10, 2) ) as DiscountAmountForCSTMR ,A.POSName As POSName ,
       [DeletedItemsCount],[DeletedItemsAmount],Cast((DiscountAmountForCash+DiscountAmountForCards+DiscountAmountForCSTMR) as decimal(10, 2) ) As TotalDiscount,Cast (TotalSales-(DiscountAmountForCash+DiscountAmountForCards+DiscountAmountForCSTMR) as decimal(10, 2) ) As NetSales
      FROM [dbo].[PosShifts] P left join AccountingPOSNames A on P.PosNumber=A.ID Where ShiftID=" & _ShiftID & " "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Dim report As New CloseShiftReport()
        With sql.SQLDS.Tables(0).Rows(0)
            report.ShiftID.Text = .Item("ShiftID")
            report.StartDateTime.Text = Format(CDate(.Item("StartDateTime")), "yyyy-MM-dd dddd HH:mm")
            report.EndDateTime.Text = Format(CDate(.Item("EndDateTime")), "yyyy-MM-dd dddd HH:mm")
            report.UserID.Text = "(" & .Item("UserID") & ")"
            If Not IsDBNull(.Item("UserName")) Then
                report.UserName.Text = .Item("UserName")
            End If
            report.BegBalance.Text = .Item("BegBalance")
            report.CashAmount.Text = .Item("CashAmount")
            If Not IsDBNull(.Item("CardAmount")) Then report.CardAmount.Text = .Item("CardAmount")
            If Not IsDBNull(.Item("EndBalance")) Then report.EndBalance.Text = .Item("EndBalance")
            If Not IsDBNull(.Item("TotalSales")) Then report.TotalSales.Text = .Item("TotalSales")
            If Not IsDBNull(.Item("PaymentsCash")) Then report.XrPaymentsCash.Text = .Item("PaymentsCash")
            If Not IsDBNull(.Item("ReceiptsCash")) Then report.XrReceiptsCash.Text = .Item("ReceiptsCash")
            If Not IsDBNull(.Item("DebitAmount")) Then report.DebitAmount.Text = .Item("DebitAmount")
            If Not IsDBNull(.Item("DiscountAmountForCash")) Then report.DiscountAmountForCash.Text = .Item("DiscountAmountForCash")
            If Not IsDBNull(.Item("DiscountAmountForCards")) Then report.DiscountAmountForCards.Text = .Item("DiscountAmountForCards")
            If Not IsDBNull(.Item("DiscountAmountForCSTMR")) Then report.DiscountAmountForCSTMR.Text = .Item("DiscountAmountForCSTMR")
            If Not IsDBNull(.Item("DeletedItemsCount")) Then report.DeletedItemsCount.Text = .Item("DeletedItemsCount") & " " & " حركة "
            If Not IsDBNull(.Item("TotalDiscount")) Then report.TotalDiscount.Text = .Item("TotalDiscount")
            If Not IsDBNull(.Item("NetSales")) Then
                report.NetSales.Text = .Item("NetSales")
            End If
            If Not IsDBNull(.Item("POSName")) Then
            End If
            report.XrLabelDiff.Text = report.EndBalance.Text - (Val(report.CashAmount.Text) + Val(report.BegBalance.Text) - Val(report.DiscountAmountForCash.Text) + Val(report.XrReceiptsCash.Text) - Val(report.XrPaymentsCash.Text))
            '  report.PrintableComponentContainer1.PrintableComponent = GridControl1
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
        report.ShowPreview()
    End Sub
End Class