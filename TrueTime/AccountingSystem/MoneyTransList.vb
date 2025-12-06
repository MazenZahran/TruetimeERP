Imports DevExpress
Imports DevExpress.CodeParser
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class MoneyTransList

    Public Property InitialDocName As Integer = 0

    Private Sub NewDocument()

        Select Case TextEditDocName.EditValue
            Case 1, 17, 8
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = TextEditDocName.EditValue
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .Show()
                    .DocName.EditValue = TextEditDocName.EditValue
                    .DocName.Text = TextEditDocName.EditValue
                    .DocStatus.Text = -1
                    .LoadDefault()
                    If TextEditDocName.EditValue = 1 Then .Text = "فاتورة مشتريات"
                    If TextEditDocName.EditValue = 17 Then .Text = "سند ادخال بضاعة"
                    If TextEditDocName.EditValue = 8 Then .Text = "ارسالية مشتريات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(TextEditDocName.EditValue, True)
                    If TextEditDocName.EditValue = 17 Then .AccountForRefranace.EditValue = "4020000000"
                    If TextEditDocName.EditValue = 8 Then
                        .ColStockDiscount.Visible = False
                        .ColStockPrice.Visible = False
                        .colDocAmount.Visible = False
                        .ColLastPurchasePrice.Visible = False
                    End If
                End With

               ' f.Show()

            Case 2, 18, 9
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = TextEditDocName.EditValue
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 1
                    .DocName.Text = TextEditDocName.EditValue
                    .Show()
                    .LoadDefault()
                    If TextEditDocName.EditValue = 2 Then .Text = "فاتورة مبيعات"
                    If TextEditDocName.EditValue = 18 Then .Text = "سند اخراج بضاعة"
                    If TextEditDocName.EditValue = 9 Then .Text = "ارسالية مبيعات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(TextEditDocName.EditValue, True)
                    If TextEditDocName.EditValue = 18 Then .AccountForRefranace.EditValue = "4020000000"
                    If TextEditDocName.EditValue = 9 Then
                        .ColStockDiscount.Visible = False
                        .ColStockPrice.Visible = False
                        .colDocAmount.Visible = False
                        .ColLastPurchasePrice.Visible = False
                    End If
                End With



            Case 12
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 12
                    .DocName.Text = 12
                    .Show()
                    .LoadDefault()
                    .Text = "مردودات مبيعات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(12, True)

                End With

            Case 13
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 13
                    .Show()
                    .LoadDefault()
                    .Text = "مردودات مشتريات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(13, True)

                End With

            Case 16
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 16
                    .DocName.Text = 16
                    .Show()
                    .LoadDefault()
                    .Text = "ارسالية داخلية"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LayoutDebitHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    .LayoutCreditHouse.Text = "من مستودع"
                    .LayoutCreditHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    .LayoutDebitHouse.Text = "الى مستودع"
                    If GlobalVariables._WareHouseUseShelf = False Then
                        .ColStockDebitShelve.Visible = False
                        .ColStockCreditShelve.Visible = False
                    Else
                        .ColStockDebitShelve.VisibleIndex = 10
                        .ColStockCreditShelve.VisibleIndex = 9
                    End If
                    .ColStockDiscount.Visible = False
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(16, True)
                End With

            Case 19
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As ProductionDocument = New ProductionDocument()
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .Show()
                    .Text = "سند انتاج"
                    .TextNewOld.Text = "new"
                End With

            Case 3
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As MoneyTrans = New MoneyTrans()
                f.TextDocID.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 3
                    .DocName.Text = 3
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "سند صرف"
                    .TextDocIDQuery.EditValue = -1
                    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .TextDocID.EditValue = GetDocNo(3, True)
                End With
                ' f.Show()
                f.TextMultiCurrency.Text = MultiCurrencyCheck.CheckState
            Case 4
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As MoneyTrans = New MoneyTrans()
                f.TextDocID.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 4
                    .DocName.Text = 4
                    .Show()
                    .DocStatus.Text = -1
                    .TextDocIDQuery.EditValue = -1
                    .Text = "سند قبض"
                    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .TextDocID.EditValue = GetDocNo(4, True)
                End With
                ' f.Show()
                f.TextMultiCurrency.Text = MultiCurrencyCheck.CheckState
            Case 5
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As Journal = New Journal()
                f.TextDocID.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .Show()
                    .DocName.EditValue = 5
                    .DocName.Text = 5
                    .DocStatus.Text = -1
                    .TextDocIDQuery.EditValue = -1
                    .Text = "سند قيد"
                    .TextDocID.EditValue = GetDocNo(5, True)
                    .BarButtonMaximize.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonMinimize.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonRestore.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonMDI.Visibility = XtraBars.BarItemVisibility.Never
                    '  .LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                End With
               ' f.Show()
            Case 6
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As CreditDebitNotes = New CreditDebitNotes()
                f.TextDocName.EditValue = TextEditDocName.EditValue
                ctr = ctr + 1
                With f
                    .TextDocStatus.EditValue = -1
                    .TextDocName.EditValue = TextEditDocName.EditValue
                    If .ShowDialog <> DialogResult.OK Then
                        RefreshList()
                    End If
                    '  .TextDocID.EditValue = GetDocNo(TextEditDocName.EditValue)
                End With
            Case 7
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As CreditDebitNotes = New CreditDebitNotes()
                f.TextDocName.EditValue = TextEditDocName.EditValue
                ctr = ctr + 1
                With f
                    .TextDocStatus.EditValue = -1
                    .TextDocName.EditValue = TextEditDocName.EditValue
                    If .ShowDialog <> DialogResult.OK Then
                        RefreshList()
                    End If
                    '  .TextDocID.EditValue = GetDocNo(TextEditDocName.EditValue)
                End With

            Case 10
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 10
                    .DocName.Text = 10
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "طلبية مشتريات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .SearchOrderStatus.EditValue = 0
                    .SearchOrderStatus.ReadOnly = True
                    .LoadDefault()
                    .DocID.EditValue = GetDocNo(10, True)
                End With
            Case 11
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 11
                    .DocName.Text = 11
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "طلبية مبيعات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .SearchOrderStatus.EditValue = 0
                    .SearchOrderStatus.ReadOnly = True
                    .LoadDefault()
                    .DocID.EditValue = GetDocNo(11, True)
                End With

        End Select

        'DeleteFromJournalTemp(TextEditDocName.EditValue, -1)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()
        RefreshList()
        stopwatch.Stop()
        My.Forms.Main.ItemElapseTime.Caption = $"Query time: {stopwatch.ElapsedMilliseconds} ms"
    End Sub
    Private Sub RefreshList()
        Select Case TextEditDocName.Text
            Case 11, 10
                Me.GridControl1.DataSource = RefreshLOrdersTransList(TextEditDocName.EditValue, False)
                'GridView1.BestFitColumns()
                RepositoryDebitAcc.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
                RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
                ColDocManualNo.Visible = True
                ColOrderStatus.Visible = True
                RepositoryOrdersStatus.DataSource = GetOrdersStatus()
                ColDocCode.Visible = False
                ColPaidStatus.Visible = False
                ColDocStatusID.Visible = False
            Case Else
                'GridControl1.BeginInvoke(New Action(Sub()
                '                                        GridControl1.DataSource = RefreshMoneyTransList(TextEditDocName.EditValue, False)
                '                                    End Sub))
                Me.GridControl1.DataSource = RefreshMoneyTransList(TextEditDocName.EditValue, chkShowDletedDocuments.CheckState, RadioGroup1.EditValue)
                'GridView1.BestFitColumns()
                RepositoryDebitAcc.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
                RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
                ColDocManualNo.Visible = True
                ColDocCode.Visible = False
                ColOrderStatus.Visible = False
                If TextEditDocName.Text = 8 Or TextEditDocName.Text = 9 Then
                    RepositoryOrdersStatus.DataSource = GetOrdersStatus()
                    ColOrderStatus.Visible = True
                    ColOrderStatus.Caption = "حالة الارسالية"
                End If
        End Select
        If TextEditDocName.Text <> "2" Then
            BarPrintClaims.Visibility = XtraBars.BarItemVisibility.Never
        End If
        If TextEditDocName.Text <> "2" And TextEditDocName.Text <> "12" And TextEditDocName.Text <> "1" And TextEditDocName.Text <> "13" Then
            ColPaidStatus.Visible = False
        End If
        If GlobalVariables._UseSalesMan = True Then
            ColSalesMan.Visible = True
        Else
            ColSalesMan.Visible = False
        End If
        If Me.TextEditDocName.EditValue = 19 Then
            ColSalesMan.Visible = False
            ColStockID.VisibleIndex = 6
            ColItemName.VisibleIndex = 7
            ColStockPrice.VisibleIndex = 8
        End If
        If TextEditDocName.Text = 3 Then
            ColCredAcc.VisibleIndex = 5
            ColSalesMan.Visible = False
        End If
        If TextEditDocName.Text = 5 Then
            ColSalesMan.Visible = False
        End If

        If TextEditDocName.Text <> 1 And TextEditDocName.Text <> 2 And
            TextEditDocName.Text <> 6 And TextEditDocName.Text <> 7 And
            TextEditDocName.Text <> 12 And TextEditDocName.Text <> 13 Then
            ColPaidStatus.Visible = False
            BarPaidVoucher.Visibility = XtraBars.BarItemVisibility.Never
            BarUnPaidVoucher.Visibility = XtraBars.BarItemVisibility.Never
        End If
        'GridView1.BestFitColumns()
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "DocStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocStatus"))
            If category = "محفوظ" Then
                e.DisplayText = String.Format(DocumentsStatus.Saved)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مرحل" Then
                e.DisplayText = String.Format(DocumentsStatus.Posted)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "الي" Then
                e.DisplayText = String.Format(DocumentsStatus.Auto)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مدقق" Then
                e.DisplayText = String.Format(DocumentsStatus.Audited)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "ملغي" Then
                e.DisplayText = String.Format(DocumentsStatus.Cancelled)
                e.Appearance.Options.CancelUpdate()
            End If
        ElseIf e.Column.FieldName = "PaidStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PaidStatus"))
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
        ElseIf e.Column.FieldName = "OrderStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OrderStatus"))
            If category = "محفوظ" Then
                e.DisplayText = String.Format(OrderStatus.Saved)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "قيد التجهيز" Then
                e.DisplayText = String.Format(OrderStatus.VoucherdPartial)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مفوترة" Then
                e.DisplayText = String.Format(OrderStatus.Voucherd)
                e.Appearance.Options.CancelUpdate()
            End If
        ElseIf e.Column.FieldName = "DocTags" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocTags"))
            If category <> "" Then
                e.DisplayText = SetTagsColor(category)
                e.Appearance.Options.CancelUpdate()
            End If

        End If
    End Sub




    Private Sub MoneyTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), Format(Today, "MM"), 1)
        'Me.DateEditFrom.DateTime = DateFrom
        'Me.DateEditTo.DateTime = New DateTime(Format(Today, "yyyy"), 12, 31)

        If InitialDocName <> 0 Then
            TextEditDocName.EditValue = InitialDocName
        End If

        RadioGroup1.EditValue = 100
        RefreshList()
        'Me.RepositoryItemTextEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True
        Me.RepositoryItemLookUpEditDocStatus.DataSource = GetDocStatus(False)
        Me.RepositoryItemPaidStatus.DataSource = GetDocPaidStatus(False)
        '  GridView1.BestFitColumns()
        GetSettings()
        Me.KeyPreview = True
        If GlobalVariables._Shalash = True Then
            BarButtonSendToShalash.Visibility = XtraBars.BarItemVisibility.Always
        End If



        ColCostName.Visible = _ShowCostCenter


    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshList()
        ElseIf e.KeyCode = Keys.Insert Then
            NewDocument()
        ElseIf e.KeyCode = Keys.F12 Then
            ' ShowPrint()
        ElseIf e.KeyCode = Keys.F6 Then
            OpenDoc()
        ElseIf e.KeyCode = 17 AndAlso e.KeyCode = 80 Then
            PostDocs()
        End If

        'MsgBox(e.KeyCode)

    End Sub
    'Private Sub GridView2_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell

    '    Dim ImageSaved As Image = My.Resources.rectangle_24px
    '    Dim ImagePosted As Image = My.Resources.rectangular_24px
    '    Dim View As GridView = CType(sender, GridView)


    '    If e.Column.FieldName = "DocStatus" Then
    '        Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocStatus"))
    '        If category = "محفوظ" Then
    '            e.Graphics.DrawImage(ImageSaved, e.Bounds.Location)
    '            ' e.DisplayText = "محفوظ"
    '            e.Appearance.Options.CancelUpdate()
    '        End If
    '        If category = "الي" Then
    '            e.Graphics.DrawImage(ImagePosted, e.Bounds.Location)
    '            '  e.DisplayText = "مرحل"
    '        End If
    '    End If




    'End Sub


    Private Sub OpenDoc()

        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName"))
        Dim DocStatus As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocStatus"))
        If DocStatus = 0 Then
            MsgBoxShowError(" السند ملغي ")
            Exit Sub
        End If
        Dim DocCode As String
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")) Then
            MsgBox("لا يمكن فتج السند DocCode is Empty")
            Exit Sub
        Else
            DocCode = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
        End If
        Select Case DocName
            Case 1, 2, 3, 4, 5, 12, 13, 6, 7, 16, 17, 18, 19, 8, 9
                OpenDocumentsByDocCode(DocCode, "Journal", Me.Name)
            Case 10, 11
                OpenDocumentsByDocCode(DocCode, "OrdersJournal", Me.Name)
        End Select

    End Sub
    Private Sub TextEditDocName_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditDocName.EditValueChanged
        Select Case TextEditDocName.EditValue
            Case 1
                Me.Text = "قائمة فواتير المشتريات"
                SimpleButtonAddNewDoc.Text = " فاتورة مشتريات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColDebitAcc.Visible = False
            Case 2
                Me.Text = "قائمة فواتير المبيعات "
                SimpleButtonAddNewDoc.Text = " فاتورة مبيعات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 3
                Me.Text = "قائمة سندات الصرف"
                SimpleButtonAddNewDoc.Text = " سند صرف    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 4
                Me.Text = "قائمة سندات القبض"
                SimpleButtonAddNewDoc.Text = " سند قبض    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 5
                Me.Text = "قائمة سندات القيد"
                SimpleButtonAddNewDoc.Text = " سند قيد    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColReferance.Visible = False
                ColReferanceName.Visible = False
                ColCredAcc.Visible = False
                ColDocCurrency.Visible = False
                ColDocAmount.Visible = False
                ColDocNotes.Visible = True
                ColBaseCurrAmount.Visible = True
            Case 6
                Me.Text = "قائمة اشعار المدين"
                SimpleButtonAddNewDoc.Text = " اشعار مدين    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 7
                Me.Text = "قائمة اشعار الدائن"
                SimpleButtonAddNewDoc.Text = " اشعار دائن    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case 8
                Me.Text = "قائمة ارساليات المشتريات"
                SimpleButtonAddNewDoc.Text = " ارسالية مشتريات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColDebitAcc.Visible = False
            Case 9
                Me.Text = "قائمة ارساليات المبيعات "
                SimpleButtonAddNewDoc.Text = " ارسالية مبيعات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never


            Case 12
                Me.Text = "قائمة مردودات المبيعات "
                SimpleButtonAddNewDoc.Text = " مردودات مبيعات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 13
                Me.Text = "قائمة مردودات المشتريات "
                SimpleButtonAddNewDoc.Text = " مردودات مشتريات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 10
                Me.Text = "قائمة طلبيات المشتريات"
                SimpleButtonAddNewDoc.Text = "  طلبية مشتريات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
            Case 11
                Me.Text = "قائمة طلبيات المبيعات"
                SimpleButtonAddNewDoc.Text = "  طلبية مبيعات    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
            Case 16
                Me.Text = "قائمة الارساليات الداخلية"
                SimpleButtonAddNewDoc.Text = "  ارسالية داخلية    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
            Case 17
                Me.Text = "قائمة سندات ادخال البضاعة"
                SimpleButtonAddNewDoc.Text = "  سند ادخال بضاعة    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
            Case 18
                Me.Text = "قائمة سندات اخراج البضاعة"
                SimpleButtonAddNewDoc.Text = "  سند اخرج بضاعة    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
            Case 19
                Me.Text = "قائمة سندات الانتاج"
                SimpleButtonAddNewDoc.Text = "  سند انتاج    Insert"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColOrderStatus.Visible = True
        End Select
        Me.GridView1.ViewCaption = Me.Text
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
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
(" " & Me.GridView1.ViewCaption)
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        ' Dim _FromToDate As String = " من تاريخ:   " & DateEdit1.EditValue & " الى تاريخ: " & " " & DateEdit2.EditValue
        ' TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub

    'Private Function GetWhareHouse(DocName As Integer, DocID As Integer) As Integer
    '    Dim sql As New SQLControl
    '    Dim SqlString As String
    '    Dim _OtherAccount As Integer = 0

    '    Select Case DocName
    '        Case 1
    '            SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [Journal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and DebitAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
    '        Case 2
    '            SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [Journal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and CredAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")

    '        Case 11
    '            SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [OrdersJournal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and CredAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
    '    End Select

    '    Return _OtherAccount
    'End Function

    Private Sub SimpleButtonAddNewDoc_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddNewDoc.Click
        Me.MultiCurrencyCheck.Checked = False
        NewDocument()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.MultiCurrencyCheck.Checked = True
        NewDocument()
    End Sub

    Private Sub RepositoryOpenDoc_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpenDoc.ButtonClick
        OpenDoc()
    End Sub

    Private Sub RepositoryDocID_OpenLink(sender As Object, e As XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryDocID.OpenLink
        OpenDoc()
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
        If e.Column.FieldName = "DocID" Or e.Column.FieldName = "BaseCurrAmount" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs)
        'GridControl1.panel
    End Sub

    Private Sub CheckShowCurrencyDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowCurrencyDetails.CheckedChanged
        If Me.CheckShowCurrencyDetails.Checked = True Then
            ColDocAmount.VisibleIndex = GridView1.Columns.Count - 2
            ColDocCurrency.VisibleIndex = GridView1.Columns.Count - 3
            ColExchangePrice.VisibleIndex = GridView1.Columns.Count - 4
        Else
            ColDocAmount.Visible = False
            ColDocCurrency.Visible = False
            ColExchangePrice.Visible = False
        End If
    End Sub

    Private Sub BarButtonSendAccrualVoucherSMS_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonSendAccrualVoucherSMS.ItemClick

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")

            _SMSMessagesTempTable.Clear()
            CeateMessagesTempTable()

            Dim sql As New SQLControl
            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try

            Dim J As Integer
            J = 1
            Dim _ReferanceNo As String
            Dim _RefMobile, _RefName, _DocCurrency As String
            Dim _DocAmount As Decimal = 0
            Dim _DocDate, _DocCode, _DocData As String
            Dim _DocName, _DocID As Integer
            Dim _OrigionalSMSMessage, _SMSMessage As String
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=4")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "Referance")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "ReferanceName")
                            _DocAmount = .GetRowCellValue(i, "DocAmount")
                            _DocCurrency = .GetRowCellValue(i, "DocCurrency")

                            _DocName = .GetRowCellValue(i, "DocName")
                            _DocID = .GetRowCellValue(i, "DocID")
                            _DocCode = .GetRowCellValue(i, "DocCode")
                            _DocData = "Journal"
                            _DocDate = Format(CDate(.GetRowCellValue(i, "DocDate")), "yyyy-MM-dd")
                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#DocAmount#", _DocAmount)
                            _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                            _SMSMessage = _SMSMessage.Replace("#DocCurrency#", _DocCurrency)
                            'SendSMSMessage(_RefMobile, _SMSMessage, 4, _BulkNo)
                            '  SMSSendMessageToWaitList(4, _SMSMessage, "Pending", _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 4
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = _DocDate
                            dr("Sent") = 0
                            dr("DocName") = _DocName
                            dr("DocID") = _DocID
                            dr("DocCode") = _DocCode
                            dr("DocData") = _DocData
                            dr("Sent") = 0
                            dr("SmsID") = 0
                            dr("SMSStatus") = ""
                            If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                .ShowDialog()
            End With

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.ToString)
        End Try



    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect Then
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            BarButtonItem5.Caption = " اظهار عمود التحديد "
        Else
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
            BarButtonItem5.Caption = " اخفاء عمود التحديد "
        End If

    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItemReceiveMoney.ItemClick

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")

            _SMSMessagesTempTable.Clear()
            CeateMessagesTempTable()

            Dim sql As New SQLControl
            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try

            Dim J As Integer
            J = 1
            Dim _ReferanceNo As String
            Dim _RefMobile, _RefName, _DocCurrency As String
            Dim _DocAmount As Decimal = 0
            Dim _DocDate, _DocCode, _DocData As String
            Dim _DocName, _DocID As Integer
            Dim _OrigionalSMSMessage, _SMSMessage As String
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=3")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "Referance")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "ReferanceName")
                            _DocAmount = .GetRowCellValue(i, "DocAmount")
                            _DocCurrency = .GetRowCellValue(i, "DocCurrency")

                            _DocName = .GetRowCellValue(i, "DocName")
                            _DocID = .GetRowCellValue(i, "DocID")
                            _DocCode = .GetRowCellValue(i, "DocCode")
                            _DocData = "Journal"
                            _DocDate = Format(CDate(.GetRowCellValue(i, "DocDate")), "yyyy-MM-dd")
                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#DocAmount#", _DocAmount)
                            _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                            _SMSMessage = _SMSMessage.Replace("#DocCurrency#", _DocCurrency)
                            'SendSMSMessage(_RefMobile, _SMSMessage, 4, _BulkNo)
                            '  SMSSendMessageToWaitList(4, _SMSMessage, "Pending", _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 3
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = _DocDate
                            dr("Sent") = 0
                            dr("DocName") = _DocName
                            dr("DocID") = _DocID
                            dr("DocCode") = _DocCode
                            dr("DocData") = _DocData
                            dr("Sent") = 0
                            dr("SmsID") = 0
                            dr("SMSStatus") = ""
                            If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                .ShowDialog()
            End With

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub RepositoryRefNo_OpenLink(sender As Object, e As XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryRefNo.OpenLink
        ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Referance")
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub
    Private Sub GetSettings()
        Try
            Select Case TextEditDocName.EditValue
                Case "11"
                    GridView1.OptionsView.ShowFooter = False
                Case Else
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowSummeryInDocumentList'")
                    GridView1.OptionsView.ShowFooter = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            End Select
        Catch ex As Exception
            MsgBox("Err: ShowSummeryInDocumentList")
        End Try
    End Sub

    Private Sub BarButtonItem6_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        AuditDocs()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        PostDocs()
    End Sub
    Private Sub PostDocs()
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار السندات من القائمة")
            Exit Sub
        End If
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد ترحيل السندات؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                    Dim _DocName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
                    PostDocument(_DocCode, "Journal")
                    GridView1.SetRowCellValue(selectedRowHandles(i), "DocStatus", 3)
                    CreateDocLog("Document", _DocCode, _DocName, _DocID, "Update", "Post Document No." & _DocID, _LogDateTime)
                Next
            End If
            'RefreshList()
        End If
    End Sub
    Private Sub AuditDocs()
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار السندات من القائمة")
            Exit Sub
        End If


        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد تدقيق السندات؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    Dim _DocName As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                    Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
                    AuditDocument(_DocCode, _DocID, _DocName, "Journal")
                    GridView1.SetRowCellValue(selectedRowHandles(i), "DocStatus", 2)
                    CreateDocLog("Document", _DocCode, _DocName, _DocID, "Audit", "Audit Document No." & _DocID, _LogDateTime)
                Next
            End If

        End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        MsgBoxShowSuccess("تم نسخ البيانات")
    End Sub

    Private Sub PrintClaim(_withOldBalance As Boolean)
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار السندات من القائمة")
            Exit Sub
        End If


        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد طباعة مطالبة مالية؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    ' Dim _DocID As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                    PrintFinancialClaim(_DocID, 2, _withOldBalance)
                Next
            End If

        End If
    End Sub
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        PrintClaim(True)
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        PrintClaim(False)
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarPaidVoucher.ItemClick
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد تسديد الفواتير؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                'Dim _PaidByDoc = InputBox(" اكتب رقم السند ")
                Dim _PaidByDoc = XtraInputBox.Show(" اكتب رقم السند ", "رقم السند", "-1")
                If _PaidByDoc = "" Then _PaidByDoc = -1
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    Dim _DocName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                    Dim _PaidStatus As Integer = 2
                    Dim _PaidAmount As Decimal = GridView1.GetRowCellValue(selectedRowHandles(i), "BaseCurrAmount")
                    'If _PaidAmount <> 0 Then
                    PaidVoucher(_DocID, _DocName, _PaidStatus, _PaidAmount, _PaidByDoc)
                    'End If
                    'GridView1.SetRowCellValue(selectedRowHandles(i), "DocStatus", 2)
                Next
                RefreshList()
            End If
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarUnPaidVoucher.ItemClick
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد الغاء تسديد الفواتير؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    Dim _DocName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                    UnPaidVoucher(_DocID, _DocName)
                Next
                RefreshList()
            End If
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick_2(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarShowTasdeedColumns.ItemClick
        Try
            If ColPaidAmount.Visible = True Then
                ColPaidAmount.Visible = False
                ColRemainAmount.VisibleIndex = False
            Else
                Dim i As Integer = 0
                i = ColPaidStatus.VisibleIndex
                ColPaidAmount.VisibleIndex = i + 1
                ColRemainAmount.VisibleIndex = i + 2
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarSubItem4_Popup(sender As Object, e As EventArgs) Handles BarSubItem4.Popup
        If ColPaidAmount.Visible = True Then
            BarShowTasdeedColumns.Caption = " اخفاء عمود المبلغ المتبقي والمسددد "
        Else
            BarShowTasdeedColumns.Caption = " عرض عمود المبلغ المتبقي والمسدد "
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show("هل تريد طباعة السندات؟ (" & " عدد " & selectedRowHandles.Length & ")", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID").ToString()
                    Dim _DocName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName").ToString()
                    Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode").ToString()

                    Dim docNameInt As Integer
                    If Integer.TryParse(_DocName, docNameInt) Then
                        Select Case docNameInt
                            Case 1, 2, 3, 4, 12, 13, 8, 9, 16
                                PrintDoc(False, _DocCode, "Journal", False, False)
                            Case 10, 11
                                PrintDoc(False, _DocCode, "OrdersJournal", False, False)
                                ' يمكنك إضافة حالات أخرى هنا إذا لزم الأمر
                        End Select
                    Else
                        ' إذا لم يكن DocName رقماً، يمكن تجاهله أو التعامل معه حسب الحاجة
                        ' MsgBox("قيمة DocName غير رقمية: " & _DocName)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub BarSendDocumentsByWhatsApp_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarSendDocumentsByWhatsApp.ItemClick
        Debug.WriteLine($"HasWhatsAppPackage - inside function: {LogInMenue.HasWhatsAppPackage}")
        Dim myControl As New SendToWhatsAppNo()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد ارسال السندات واتس اب؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                    Dim MobileNo As String = myControl.Mobile
                    If String.IsNullOrEmpty(MobileNo) Then
                        Exit Sub
                    End If
                    For i As Integer = 0 To selectedRowHandles.Length - 1
                        Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                        Dim _DocName As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                        Dim _DocNameText As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocNameText")
                        Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                        Dim _ReferanceName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "ReferanceName")
                        Dim _DocNames As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 16, 17, 18, 19}
                        If _DocNames.Contains(_DocName) Then
                            PrintDoc(False, _DocCode, "Journal", False, True)
                            SendFileToWhatsApp(MobileNo, "Document.pdf", _DocNameText, _DocNameText & ":" & _DocID & "-" & _ReferanceName, _ReferanceName)
                        End If
                        If _DocName = 11 Or _DocName = 11 Then
                            PrintDoc(False, _DocCode, "OrdersJournal", False, True)
                            SendFileToWhatsApp(MobileNo, "Document.pdf", _DocNameText, _DocNameText & ":" & _DocID & "-" & _ReferanceName, _ReferanceName)
                        End If
                    Next
                    MsgBoxShowSuccess(" تم ارسال السندات ")
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonSendToShalash_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonSendToShalash.ItemClick
        '  Dim _DocCode As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
        '  Dim _DocName As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocNameText"))
        ' Dim _ReferanceName As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ReferanceName"))
        ' PrintDoc(False, _DocCode, "Journal", False, True)
        ' SendFileToWhatsAppGroup(CStr("120363313491308599"), "Document.pdf", 1, _DocName & ":" & "-" & _ReferanceName)
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                Dim _DocName As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                Dim _DocNameText As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocNameText")
                Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                Dim _ReferanceName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "ReferanceName")

                PrintDoc(False, _DocCode, "Journal", False, True)
                'SendFileToWhatsAppGroup(CStr("120363418370742684"), "Document.pdf", 1, _DocName & ":" & "-" & _ReferanceName)
                SendFileToWhatsApp(CStr("120363418370742684"), "Document.pdf", 1, _DocName & ":" & "-" & _ReferanceName, "")

            Next
        End If


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub BarButtonItem11_ItemClick_3(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarInstallmentVoucher.ItemClick
        Dim _Ref As String = CStr(GridView1.GetFocusedRowCellValue("Referance"))
        If _Ref = "" Then
            MsgBoxShowError(" الفاتورة نقدية ولا يمكن تقسيطها ")
            Exit Sub
        End If
        Dim _Amount As Decimal = CDec(GridView1.GetFocusedRowCellValue("DocAmount"))
        If _Amount = 0 Then
            MsgBoxShowError(" الفاتورة صفر ولا يمكن تقسيطها ")
            Exit Sub
        End If
        Dim _DocNo As Integer = CInt(GridView1.GetFocusedRowCellValue("DocID"))
        Dim f As New InstallmentForm("New")
        With f
            .InstallmentReferance.EditValue = GridView1.GetFocusedRowCellValue("Referance")
            .InstallmentsAmount.EditValue = _Amount
            Select Case TextEditDocName.EditValue
                Case "1"
                    .Text = " تقسيط فاتورة مشتريات "
                    .InstallmentInOut.EditValue = "OUT"
                    .VoucherNo.Text = _DocNo
                    .ShowDialog()
                Case "2"
                    .Text = " تقسيط فاتورة مبيعات "
                    .InstallmentInOut.EditValue = "IN"
                    .VoucherNo.Text = _DocNo
                    .ShowDialog()
            End Select

        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        With GridView1
            Dim _DocTags As String, _DocID As Integer, _DocName As Integer
            Select Case .FocusedColumn.FieldName
                Case "DocTags"
                    If IsDBNull(.GetFocusedRowCellValue("DocTags")) Then
                        _DocTags = ""
                    Else
                        _DocTags = .GetFocusedRowCellValue("DocTags")
                    End If
                    _DocID = CInt(.GetFocusedRowCellValue("DocID"))
                    _DocName = CInt(.GetFocusedRowCellValue("DocName"))

                    Dim f As New TagsNames
                    _PublicDocumentTags = _DocTags
                    With f
                        .DocID = _DocID
                        .DocName = _DocName
                        .TableName = "Journal"
                        If .ShowDialog <> DialogResult.OK Then
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "DocTags", _PublicDocumentTags)
                        End If
                    End With
                    _PublicDocumentTags = ""
                Case Else
                    Exit Sub
            End Select
        End With
    End Sub

    Private Sub BarButtonRecCalculate_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonRecCalculate.ItemClick


        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim docName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
                Dim docCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")

                Dim Sql As New SQLControl
                Dim sqlString As String = "   Declare @DocCode varchar(50)
                                      Declare @DocName int
                                      Declare @DocID int
                                      Set @DocCode='" & docCode & "'
                                      Set @DocName=" & docName & "
                                      Set @DocID= " & GetDocNo(docName, False) & "
                                      Update Journal Set DocID = @DocID  Where DocCode=@DocCode And DocName=@DocName  
                                      Update Checks Set DocID=@DocID Where DocCode=@DocCode
                                      EXEC	 [dbo].[UpdateSequences] "
                Sql.SqlTrueTimeRunQuery(sqlString)
            Next
        End If


    End Sub
End Class