Imports System.Data.SqlTypes
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSpreadsheet.Import.Xls

Public Class InstallmentsHeaderList
    Private _Status As Integer
    Private Sub InstallmentsHeaderList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Status = 0
        GetInstallments()
        Me.RepositoryItemLookUpEdit1.DataSource = GetDocPaidStatus(False)
    End Sub

    Private Sub TileBarUnPaid_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarUnPaid.ItemClick
        _Status = 0
        GetInstallments()
    End Sub
    Private Sub TileBarPartialPaid_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarPartialPaid.ItemClick
        _Status = 1
        GetInstallments()
    End Sub

    Private Sub TileBarPaid_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarPaid.ItemClick
        _Status = 2
        GetInstallments()
    End Sub
    Private Sub TileBarAll_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarAll.ItemClick
        _Status = -1
        GetInstallments()
    End Sub

    Private Sub GetInstallments()
        Try
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
                        Left Join Referencess R on R.RefNo=I.InstallmentReferance "
            If _Status <> -1 Then
                sqlString += " Where P.[status]= " & _Status
            End If
            sqlString += "  Order By DueDate "
            Sql.SqlTrueTimeRunQuery(sqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            Sql.SqlTrueAccountingRunQuery("select count(*) As Unpaid      from [InstallmentsPayments] where [Status]=0")
            Me.TileBarUnPaid.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("Unpaid")
            Sql.SqlTrueAccountingRunQuery("select count(*) As PartialPaid from [InstallmentsPayments] where [Status]=1")
            Me.TileBarPartialPaid.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("PartialPaid")
            Sql.SqlTrueAccountingRunQuery("select count(*) As Paid        from [InstallmentsPayments] where [Status]=2")
            Me.TileBarPaid.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("Paid")
            Sql.SqlTrueAccountingRunQuery("select count(*) As AllItems         from [InstallmentsPayments] ")
            Me.TileBarAll.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("AllItems")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Select Case _Status
            Case 0
                TileBarUnPaid.Checked = True
                TileBarPaid.Checked = False
                TileBarPartialPaid.Checked = False
                TileBarAll.Checked = False
            Case 1
                TileBarUnPaid.Checked = False
                TileBarPaid.Checked = False
                TileBarPartialPaid.Checked = True
                TileBarAll.Checked = False
            Case 2
                TileBarUnPaid.Checked = False
                TileBarPaid.Checked = True
                TileBarPartialPaid.Checked = False
                TileBarAll.Checked = False
            Case -1
                TileBarUnPaid.Checked = False
                TileBarPaid.Checked = False
                TileBarPartialPaid.Checked = False
                TileBarAll.Checked = True
        End Select

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

    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HtmlContentControl1_ElementMouseClick(sender As Object, e As DevExpress.Utils.Html.DxHtmlElementMouseEventArgs) Handles HtmlContentControl1.ElementMouseClick
        Select Case e.ElementId
            Case "table"
                GoTable()
            Case ""
        End Select

    End Sub
    Private Sub GoTable()
        Me.NavigationFrame1.SelectedPage = tablePage
    End Sub
    Private Sub Chart()
        Me.NavigationFrame1.SelectedPageIndex = 2
    End Sub
    Private Sub Report()
        Me.NavigationFrame1.SelectedPageIndex = 0
    End Sub

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem2.ItemClick
        Me.NavigationFrame1.SelectedPage = mainPage
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        If IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("RefNo")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("Amount")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("DueDate")) Then Exit Sub
        If IsDBNull(GridView1.GetFocusedRowCellValue("status")) Then Exit Sub
        InstallmentsFunctions.PayInstallmentByID(GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("RefNo"), GridView1.GetFocusedRowCellValue("Amount"), GridView1.GetFocusedRowCellValue("DueDate"), GridView1.GetFocusedRowCellValue("status"))
    End Sub

    Private Sub WindowsUIButtonPanel1_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Refresh"
                GetInstallments()
            Case "OpenRef"
                ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefNo")
                ReferancessAddNew.TextRefName.Select()
                ReferancessAddNew.ShowDialog()
            Case "Close"
                If GlobalVariables._UserAccessType = 92 Then
                    Application.Exit()
                Else
                    Me.Close()
                End If
            Case "Print"
                Me.GridControl1.ShowPrintPreview()
        End Select
    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Dim F As New InstallmentEdit
        With F
            Dim _ID As Integer = GridView1.GetFocusedRowCellValue("ID")
            ._NewOld = "Old"
            ._ID = _ID
            If .ShowDialog() <> DialogResult.OK Then
                GetInstallments()
            End If
        End With

    End Sub

End Class