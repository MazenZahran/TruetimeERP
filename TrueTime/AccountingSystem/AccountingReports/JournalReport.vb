Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid.Helpers
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class JournalReport
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            GetTrans1()
            GetTrans2()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GetTrans1()
        Dim Sql As New SQLControl
        Dim SqlString As String

        Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim _DOCNAME As String = SearchDocName.EditValue
        Dim _DocCostCenter As String = LookCostCenter.EditValue
        SqlString = "   SELECT    J.[ID],[DocID],[DocDate],N.Name as DocName ,
                                  Case when [DebitAcc]<> '0' then A.AccName End as DebitAcc,
                                  Case when [CredAcc]<> '0' then AA.AccName End as CredAcc  ,C.Code as DocCurrency,
                                  DocAmount,[ExchangePrice],J.DocCode,
                                  BaseCurrAmount ,
                                  ReferanceName,[DocManualNo],[InputUser],Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes,X.[CostName] as DocCostCenter
	                              from [Journal] J
	                              left join [FinancialAccounts] A	  on A.AccNo=J.DebitAcc
	                              left join [FinancialAccounts] AA	  on AA.AccNo=J.CredAcc
	                              left Join [DocNames] N on N.id=J.DocName 
	                              Left Join [Referencess] R on R.RefNo=J.Referance 
	                              left Join [Currency] C on C.CurrID=J.DocCurrency 
                                  left Join [CostCenter] X on X.CostID=J.DocCostCenter 
                        Where DocStatus<>0 and DocDate between '" & _DateFrom & "' and '" & _DateTo & "'  "
        If Not String.IsNullOrEmpty(SearchDocName.Text) Then
            SqlString += " AND J.DocName=" & _DOCNAME
        End If
        If Not String.IsNullOrEmpty(LookCostCenter.Text) Then
            SqlString += " AND DocCostCenter=" & _DocCostCenter
        End If
        SqlString += " Order By OrderID "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub
    Private Sub GetTrans2()
        Dim Sql As New SQLControl
        Dim SqlString As String

        Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim _DOCNAME As String = SearchDocName.EditValue
        Dim _DocCostCenter As String = LookCostCenter.EditValue
        SqlString = "   SELECT    J.[ID],J.[DocID],[DocDate],N.Name as DocName ,InputDateTime,J.ModifiedDateTime,J.ModifiedUser,E.EmployeeName as SalesMan,
                                  Case when [DebitAcc]<> '0' then A.AccName Else AA.AccName End as AccName,
								  Case when [DebitAcc]<> '0' then A.AccNo Else AA.AccNo End as AccNo,
                                  Case when [DebitAcc]<> '0' then DocAmount Else -1*DocAmount End as DocAmount,
                                  Case when [DebitAcc]<> '0' then BaseCurrAmount Else -1*BaseCurrAmount End as BaseCurrAmount,
                                  C.Code as DocCurrency,DocTags,J.DocCode,
                                  [ExchangePrice],R.RefName,
                                  Ch.CheckNo,Ch.CheckAmount,Ch.CheckBaseAmount,Ch.CheckDueDate
                                  ReferanceName,[DocManualNo],[InputUser],Case when J.DocNoteByAccount is null or J.DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',J.DocNoteByAccount,')') end as DocNotes,X.[CostName] as DocCostCenter
	                              from [Journal] J
	                              left join [FinancialAccounts] A	  on A.AccNo=J.DebitAcc
	                              left join [FinancialAccounts] AA	  on AA.AccNo=J.CredAcc
	                              left Join DocNames N on N.id=J.DocName 
	                              Left Join Referencess R on R.RefNo=J.Referance 
	                              left Join Currency C on C.CurrID=J.DocCurrency 
                                  left Join [CostCenter] X on X.CostID=J.DocCostCenter 
								  Left Join EmployeesData E on E.EmployeeID=J.SalesPerson
								  Left Join Checks Ch on Ch.CheckCode=J.CheckCode
                        Where DocStatus<>0 and DocDate between '" & _DateFrom & "' and '" & _DateTo & "'  "
        If Not String.IsNullOrEmpty(SearchDocName.Text) Then
            SqlString += " AND J.DocName=" & _DOCNAME
        End If
        If Not String.IsNullOrEmpty(LookCostCenter.Text) Then
            SqlString += " AND DocCostCenter=" & _DocCostCenter
        End If
        SqlString += " Order By OrderID "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl2.DataSource = Sql.SQLDS.Tables(0)
        Me.PivotGridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub

    Private Sub JournalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchDocName.Properties.DataSource = GetDocNames()
        Me.DateEditTo.DateTime = Today
        Me.DateEditFrom.DateTime = New Date(Today.Year, Today.Month, 1)
        Me.KeyPreview = True
        LoadSettings()
    End Sub
    Private Sub LoadSettings()


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                Me.LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColDocCostCenter.Visible = True
                Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
            Else
                Me.LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        Catch ex As Exception
            Me.LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Select Case TabbedControlGroup1.SelectedTabPageName
            Case "TabDocuments"
                GridControl1.ShowPrintPreview()
            Case "TabDetails"
                GridControl2.ShowPrintPreview()
            Case "TabPivotTable"
                PivotGridControl1.ShowPrintPreview()
            Case ""
                GridControl1.ShowPrintPreview()
        End Select
        ' GridControl1.ShowPrintPreview()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetTrans1()
            GetTrans2()
        End If
    End Sub
    Private Sub GridView3_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView3.CustomDrawCell
        'Dim View As GridView = CType(sender, GridView)
        'If e.Column.FieldName = "DocTags" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocTags"))
        '    If category <> "" Then
        '        e.DisplayText = SetTagsColor(category)
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If
    End Sub

    Private Sub RepositoryDocID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryDocID.OpenLink
        Dim _DocCode As String
        _DocCode = Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "DocCode")
        OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name)
    End Sub
    'Private Sub GridView1_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridView1.CustomDrawGroupRow

    '    If e.RowHandle <> GridView1.GetVisibleRowHandle(0) Then
    '        Using cache As New GraphicsCache(e.Graphics)
    '            e.Graphics.DrawLine(GridView1.PaintAppearance.HorzLine.GetBackPen(cache), e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y)
    '        End Using
    '    End If

    'End Sub
    'Private Sub GridView1_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell

    '    e.Appearance.FillRectangle(e.Cache, e.Bounds)
    '    CType(GridControl1, IViewController).EditorHelper.DrawCellEdit(New GridViewDrawArgs(e.Cache, TryCast(GridView1.GetViewInfo(), GridViewInfo), e.Bounds), (TryCast(e.Cell, GridCellInfo)).Editor, (TryCast(e.Cell, GridCellInfo)).ViewInfo, e.Appearance, (TryCast(e.Cell, GridCellInfo)).CellValueRect.Location)

    '    Using cache As New GraphicsCache(e.Graphics)
    '        Dim objBounds As Rectangle = New Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 2, e.Bounds.Height + 1)
    '        e.Graphics.DrawRectangle(GridView1.PaintAppearance.HorzLine.GetBackPen(cache), objBounds)
    '    End Using

    '    e.Handled = True

    'End Sub
    'Private Sub gridControl1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles GridControl1.Paint
    '    If GridView1.GroupCount <> 0 Then
    '        Dim viewInfo As GridViewInfo = TryCast(GridView1.GetViewInfo(), GridViewInfo)
    '        Dim x1 As Integer = viewInfo.ViewRects.EmptyRows.X
    '        Dim x2 As Integer = viewInfo.ViewRects.EmptyRows.Right
    '        Dim y As Integer = viewInfo.ViewRects.EmptyRows.Y + GridView1.RowSeparatorHeight
    '        Using cache As New GraphicsCache(e.Graphics)
    '            e.Graphics.DrawLine(GridView1.PaintAppearance.HorzLine.GetBackPen(cache), New Point(x1, y), New Point(x2, y))
    '        End Using
    '    End If
    'End Sub
End Class