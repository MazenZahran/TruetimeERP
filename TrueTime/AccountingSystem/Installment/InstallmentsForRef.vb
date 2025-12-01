Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports GMap.NET

Public Class InstallmentsForRef
    Private Sub InstallmentsForRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchReferance.Properties.DataSource = GetReferences(1, -1, -1)
        Me.RepositoryItemLookUpEdit1.DataSource = GetDocPaidStatus(False)
        LookDocStatus.Properties.DataSource = GetDocPaidStatus(True)
        LookDocStatus.EditValue = -1
    End Sub
    Public Sub GetInstallmentsForRef()
        Try
            If SearchReferance.EditValue = Nothing Then
                GridControl1.DataSource = ""
                Exit Sub
            End If
            Dim Sql As New SQLControl
            Dim sqlString As String
            sqlString = "   Select ID,Amount,[status],DueDate,Note,R.RefName,R.RefMobile,
                                   I.InstallmentRef As RefNo,P.PaidDate,P.PaidAmount,
                                  (P.Amount-P.PaidAmount) As RemainingAmount 
	                              , CASE 
                                    WHEN PaidDate > DueDate THEN DATEDIFF(day, DueDate, PaidDate) 
                                    ELSE 0
                                  END AS LateDays
                        From [InstallmentsPayments] P 
                        Left Join [dbo].[Installments] I on I.InstallmentID=P.InstallmentID
                        Left Join Referencess R on R.RefNo=I.InstallmentReferance 
                        Where I.InstallmentRef=" & SearchReferance.EditValue & ""
            If LookDocStatus.EditValue <> -1 Then sqlString += "  And [status]=" & LookDocStatus.EditValue
            sqlString += "  Order By DueDate "
            Sql.SqlTrueTimeRunQuery(sqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "status" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("status"))
            If category = "غير مسدد" Then
                e.DisplayText = String.Format(PaidStatus.Unpaid)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مسدد جزئي" Then
                e.DisplayText = String.Format(PaidStatus.PaidPartial)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مسدد" Then
                e.DisplayText = String.Format(PaidStatus.Paid)
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetInstallmentsForRef()
    End Sub

    Private Sub LookDocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LookDocStatus.EditValueChanged

    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        If IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("RefNo")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("Amount")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("DueDate")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("status")) Then Exit Sub
        InstallmentsFunctions.PayInstallmentByID(GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("RefNo"), GridView1.GetFocusedRowCellValue("Amount"), GridView1.GetFocusedRowCellValue("DueDate"), GridView1.GetFocusedRowCellValue("status"))
        GetInstallmentsForRef()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
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
(" " & "كشف الأقساط   ")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        'Dim _FromToDate As String = " من تاريخ:   " & DateEdit1.EditValue & " الى تاريخ: " & " " & DateEdit2.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(SearchReferance.Text)
    End Sub
End Class