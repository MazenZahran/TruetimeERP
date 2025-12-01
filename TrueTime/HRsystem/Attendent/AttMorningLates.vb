Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

Public Class AttMorningLates
    Private Sub AttMorningLates_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub PrintMultipleGrids(_PrintOrWhats As String)
        ' Create a Printing System
        Dim printingSystem As New PrintingSystem()

        ' Create a CompositeLink
        Dim compositeLink As New CompositeLink(printingSystem)

        ' Create PrintableComponentLink for each GridControl
        Dim link1 As New PrintableComponentLink(printingSystem) With {
            .Component = GridControlLates  ' Replace with your first GridControl
        }
        Dim link2 As New PrintableComponentLink(printingSystem) With {
            .Component = GridControlAbsent  ' Replace with your second GridControl
        }
        Dim link3 As New PrintableComponentLink(printingSystem) With {
            .Component = GridControlVacation  ' Replace with your third GridControl
        }
        Dim link4 As New PrintableComponentLink(printingSystem) With {
            .Component = GridControlOff  ' Replace with your fourth GridControl
        }

        ' Add the links to the CompositeLink
        compositeLink.Links.AddRange(New Object() {link1, link2, link3, link4})
        compositeLink.BreakSpace = 100
        ' Create the document
        compositeLink.CreateDocument()

        ' Show the preview or print
        If _PrintOrWhats = "Print" Then
            compositeLink.ShowPreview()
        Else
            compositeLink.CreateDocument()
            compositeLink.ExportToPdf("Report.pdf")
        End If
    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PrintMultipleGrids("Print")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrintMultipleGrids("Whats")
                SendFileToWhatsApp(MobileNo, "Report.pdf", "كشف حساب", "", "")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridViewTotalLates_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridViewTotalLates.CustomSummaryCalculate
        Try
            ' Check if this is the summary we want to customize (assuming it's for TotalLateTime)
            If TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem).FieldName = "TotalLateTime" Then

                ' Different calculation stages
                Select Case e.SummaryProcess
                    Case DevExpress.Data.CustomSummaryProcess.Start
                        ' Initialize the total seconds when starting calculation
                        e.TotalValue = 0

                    Case DevExpress.Data.CustomSummaryProcess.Calculate
                        ' For each row, add the time value (convert to seconds for calculation)
                        Dim timeValue As Object = GridViewTotalLates.GetRowCellValue(e.RowHandle, "TotalLateTime")

                        If timeValue IsNot Nothing AndAlso TypeOf timeValue Is TimeSpan Then
                            ' Add the total seconds to our running total
                            e.TotalValue = CDbl(e.TotalValue) + CType(timeValue, TimeSpan).TotalSeconds
                        ElseIf timeValue IsNot Nothing AndAlso TypeOf timeValue Is String Then
                            ' Try to parse the string value as TimeSpan
                            Dim timeParts As String() = timeValue.ToString().Split(":"c)
                            If timeParts.Length >= 2 Then
                                Dim hours As Integer = 0, minutes As Integer = 0, seconds As Integer = 0

                                If Integer.TryParse(timeParts(0), hours) AndAlso Integer.TryParse(timeParts(1), minutes) Then
                                    If timeParts.Length > 2 Then
                                        Integer.TryParse(timeParts(2), seconds)
                                    End If
                                    ' Convert to total seconds and add to running total
                                    e.TotalValue = CDbl(e.TotalValue) + (hours * 3600) + (minutes * 60) + seconds
                                End If
                            End If
                        End If

                    Case DevExpress.Data.CustomSummaryProcess.Finalize
                        ' Convert the total seconds back to a formatted time value
                        Dim totalSeconds As Double = CDbl(e.TotalValue)
                        Dim timeSpan As TimeSpan = TimeSpan.FromSeconds(totalSeconds)
                        e.TotalValueReady = True

                        ' Format the result as hh:mm:ss
                        ' For displaying only hours and minutes: String.Format("{0}:{1:00}", Math.Floor(timeSpan.TotalHours), timeSpan.Minutes)
                        ' For full format including seconds:
                        e.TotalValue = String.Format("{0}:{1:00}:{2:00}", Math.Floor(timeSpan.TotalHours), timeSpan.Minutes, timeSpan.Seconds)
                End Select
            End If
        Catch ex As Exception
            ' Handle any exceptions that might occur
            e.TotalValue = "Error"
        End Try
    End Sub


    Private Sub BtnPrintDetailsLates_Click(sender As Object, e As EventArgs) Handles BtnPrintDetailsLates.Click
        GridControlLates.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridViewTotalLates.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = False
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
{"  ", Now(), "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
(" " & " تقرير اجمالي التاخير   ")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ:   " & DateEdit1.EditValue & " الى تاريخ: " & " " & DateEdit2.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub
    Private Sub BtnPrintLatesSummery_Click(sender As Object, e As EventArgs) Handles BtnPrintLatesSummery.Click
        GridControlTotalLates.ShowPrintPreview()
    End Sub

    Private Sub GridView1_PrintInitialize_1(sender As Object, e As Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = False
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
{"  ", Now(), "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
(" " & " تقرير تفاصيل التاخير   ")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ:   " & DateEdit1.EditValue & " الى تاريخ: " & " " & DateEdit2.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub
End Class