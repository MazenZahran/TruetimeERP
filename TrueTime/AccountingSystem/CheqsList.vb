Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPrinting
Imports System

Public Class CheqsList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetCheks()
    End Sub
    Private Sub GetCheks()
        GridControlList.DataSource = GetCheques(ComboBoxInOut.Text, -1, -1, -1)
        If ComboBoxInOut.Text = "Out" Then
            ColRelatedReferanceName.Visible = False
        End If
        GridView1.BestFitColumns()
        GetCheksForPivotTable()
    End Sub

    Private Sub ComboBoxInOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxInOut.TextChanged
        '  If ComboBoxInOut.IsHandleCreated = True Then
        GetCheks()
        '  End If
    End Sub
    Private Sub GetCheksForPivotTable()
        Select Case ComboBoxInOut.Text
            Case "-1"
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " SELECT  [CheckInOut],[CheckNo],
                              [CheckDueDate],Ba.[BankName] as [CheckBank],[CheckBranch],B.BankName as BankAccountName,
                              S.CheckStatus,
                      Case when [CheckInOut]='OUT' then 1*[CheckAmount] else [CheckAmount] end as [CheckAmount] ,
                      Case when CheckInOut='OUT' then 1* [CheckBaseAmount] else [CheckBaseAmount] end as [CheckBaseAmount],
                      S.CheckStatus as StatusName,C.Code as CurrCode,R.RefName, RR.RefName As  RelatedReferanceName
                     FROM [Checks] A
					  left join ChecksStatus S on A.CheckStatus=S.ID
					  left join Currency C on C.CurrID=A.CheckCurr 
                      left join Referencess R on R.RefNo=A.Referance
                      left join Referencess RR on RR.RefNo=A.RelatedReferance  
                      left join BanksAccounts B on B.ID=A.[AccountBank]
                      left join [dbo].[Bank] Ba on Ba.[ID]=A.CheckBank
                      Where A.CheckStatus <> 0 "
                sql.SqlTrueAccountingRunQuery(sqlstring)
                PivotGridControl1.DataSource = sql.SQLDS.Tables(0)
        End Select

    End Sub

    Private Sub CheqsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _DefaultCurrencyCode As String = GetCurrencyCode(GetDefaultCurrency())
        Me.KeyPreview = True
        ColCheckBaseAmount.Caption = " <size=-3> " & _DefaultCurrencyCode & " </size> المبلغ "
        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = "CheckBaseAmount"
        'item.ShowInGroupColumnFooter = group
        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Dim _text As String = " ( " & "المجموع:" & "" & " {0:N0} " & _DefaultCurrencyCode & " ) "
        item.DisplayFormat = _text
        GridView1.GroupSummary.Add(item)
        TabbedControlGroup1.SelectedTabPage = AllCheksGroup
        PivotGridField7.Caption = " <size=-3> " & _DefaultCurrencyCode & " </size> المبلغ "
        ' If GlobalVariables._ShowColNoteInMoneyTransDoc = False Then
        ColNotes.Visible = GlobalVariables._ShowColNoteInMoneyTransDoc
        ' End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "CheckInOut" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("CheckInOut"))
            If category = "OUT" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  صادر  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "IN" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  وارد  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub
    Protected Sub TabbedGroup_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                                   ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "AllCheksGroup" Then
            GridControlList.ShowPrintPreview()
        ElseIf e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "PivotGroup" Then
            PivotGridControl1.ShowPrintPreview()
        ElseIf e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "ChartGroup" Then
            ChartControl1.ShowPrintPreview()
        ElseIf e.Button.Tag = "Copy" AndAlso TabbedControlGroup1.SelectedTabPageName = "AllCheksGroup" Then
            GridView1.CopyToClipboard()
            GridView1.SelectAll()
            XtraMessageBox.Show("تم نسخ البيانات")
        ElseIf e.Button.Tag = "Copy" AndAlso TabbedControlGroup1.SelectedTabPageName = "PivotGroup" Then
            Me.PivotGridControl1.Cells.CopySelectionToClipboard()
            XtraMessageBox.Show("تم نسخ البيانات")
        Else
            GridControlList.ShowPrintPreview()
        End If
    End Sub
    Private Sub BandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = "  "
        Dim Tawqe3_2 As String = " "

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3_2, Tawqe3, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)




        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {" استعلام الشيكات ", "", " "})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetCheks()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControlList.ShowPrintPreview()
    End Sub

    Private serverMode As Boolean = False
    Private Sub PivotGridControl1_CellDoubleClick(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles PivotGridControl1.CellDoubleClick
        Dim drillDownDataSource As PivotDrillDownDataSource
        If serverMode Then
            drillDownDataSource = e.CreateDrillDownDataSource(100000, New List(Of String) From {"CheckInOut"})
        Else
            drillDownDataSource = e.CreateDrillDownDataSource(100000)
        End If
        Dim dataform As XtraForm = CreateDrillDownForm(drillDownDataSource)
        dataform.ShowDialog()
        dataform.Dispose()
    End Sub
    Private Function CreateDrillDownForm(ByVal dataSource As PivotDrillDownDataSource) As XtraForm
        Dim form As New XtraForm()
        Dim grid As New GridControl()
        grid.Parent = form
        grid.Dock = DockStyle.Fill
        grid.DataSource = dataSource
        form.Bounds = New Rectangle(100, 100, 800, 400)
        grid.DataSource = form.Bounds
        Dim gridView1 As New GridView()
        grid.MainView = gridView1
        gridView1.Columns("CheckDueDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        gridView1.OptionsView.ShowFooter = True
        form.Text = String.Format("Underlying Data - {0} Records", dataSource.RowCount)
        Return form
    End Function


    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim drillDownDataSource As PivotDrillDownDataSource = PivotGridControl1.CreateDrillDownDataSource()
        Dim dataform As Form = CreateDrillDownForm(drillDownDataSource)
        dataform.ShowDialog()
        dataform.Dispose()
    End Sub

    Private Sub ComboBoxInOut_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBoxInOut.SelectedIndexChanged
        Select Case ComboBoxInOut.Text
            Case "Out"
                PivotGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ChartGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "In"
                PivotGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ChartGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "-1"
                PivotGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ChartGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColCheckInOut.Visible = True
                ColCheckInOut.VisibleIndex = 1
        End Select
    End Sub

    Private Sub كشفبحركةالشيكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفبحركةالشيكToolStripMenuItem.Click
        Try
            Dim _CheckCode As String = GridView1.GetFocusedRowCellValue("CheckCode")
            Dim _CheckNo As String = GridView1.GetFocusedRowCellValue("CheckNo")
            My.Forms.CheksTrans.TextCheckCode.Text = _CheckCode
            My.Forms.CheksTrans.CheckNo.Text = _CheckNo
            My.Forms.CheksTrans.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub GridControlList_Click(sender As Object, e As EventArgs) Handles GridControlList.Click

    End Sub

    Private Sub PivotGridControl1_Click(sender As Object, e As EventArgs) Handles PivotGridControl1.Click

    End Sub

    Private Sub تغييرحالةشيكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تغييرحالةشيكToolStripMenuItem.Click
        Try
            Dim _CheckID As Integer = GridView1.GetFocusedRowCellValue("CheckID")
            Dim F As New ChangeCheqStatus(_CheckID)
            With F
                If .ShowDialog <> DialogResult.OK Then
                    Me.GridView1.SetFocusedRowCellValue("CheckDueDate", GetChequeData(_CheckID).ChequeDueDate)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
    Dim _ShowChartControls As Boolean = False
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If _ShowChartControls = True Then
            _ShowChartControls = False
        Else
            _ShowChartControls = True
        End If
        If _ShowChartControls = True Then
            ChartTypeBar1.Visible = True
            ChartAppearanceBar1.Visible = True
            ChartFinancialSeriesBar1.Visible = True
            ChartDesignerBar1.Visible = True
            ChartTemplatesBar1.Visible = True
            ChartPrintExportBar1.Visible = True
            ChartFinancialIndicatorsBar1.Visible = True
            ChartAnnotationsBar1.Visible = True
            ChartFinancialAxisBar1.Visible = True
            ChartAnnotationsBar2.Visible = True
        Else
            ChartTypeBar1.Visible = False
            ChartAppearanceBar1.Visible = False
            ChartFinancialSeriesBar1.Visible = False
            ChartDesignerBar1.Visible = False
            ChartTemplatesBar1.Visible = False
            ChartPrintExportBar1.Visible = False
            ChartFinancialIndicatorsBar1.Visible = False
            ChartAnnotationsBar1.Visible = False
            ChartFinancialAxisBar1.Visible = False
            ChartAnnotationsBar2.Visible = False
        End If
    End Sub

End Class