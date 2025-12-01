Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class ReferancessList
    'Dim _ShowVerticalLines As Boolean = False
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()
        RefreshList()
        stopwatch.Stop()
        My.Forms.Main.ItemElapseTime.Caption = $"Query time: {stopwatch.ElapsedMilliseconds} ms"


        'GridView1.OptionsBehavior.Editable = False
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub

    Private Sub ReferancessList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RepositoryAccounts.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryRefTypes.DataSource = GetReferancessTypes(False)
        SearchSort.Properties.DataSource = GetRefSorts(False)
        LookRefType.Properties.DataSource = GetReferancessTypes(False)
        RepositoryPriceCategory.DataSource = GetPriceCategory()
        LookUpActiveNotActive.Properties.DataSource = ActiveNotActive()
        If GlobalVariables._SystemLanguage = "Arabic" Then
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusName"
            GridColumn3.Visible = True
            GridColumn4.Visible = False
        Else
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusNameE"
            GridColumn3.Visible = False
            GridColumn4.Visible = True
        End If
        LookUpActiveNotActive.EditValue = "2"
        RefreshList()
        Me.KeyPreview = True
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        RepositoryDays.DataSource = GetWeekDaysNames()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshList()
        ElseIf e.KeyCode = Keys.Insert Then
            AddNew()
            'ElseIf Keys.Control AndAlso e.KeyCode = Keys.P Then
            '    GridControl1.ShowPrintPreview()
            'ElseIf Keys.Control AndAlso e.KeyCode = Keys.C Then
            '    GridView1.CopyToClipboard()
            XtraMessageBox.Show("تم نسخ البيانات")
        End If
    End Sub
    Private Sub RefreshList()
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " Select RefID,RefName,RefNo,RefType,RefMobile,RefPhone,RefAccID,IdentityNo,
                      PriceCategory,ReferanceCode,R.Active,RefEmail,C.[CITY] as SearchCity,S.SortName,R.Address,IsNull(E.EmployeeName,'') as [SalesManName],IsNull(SalesManDay,0) as SalesManDay
                      from Referencess R"
            SqlString += " left join [dbo].[RefCities] C on R.SearchCity=C.[ID]"
            SqlString += " left join [dbo].[RefSorts] S on R.RefSort=S.[ID]"
            SqlString += " left join [dbo].[EmployeesData] E on E.EmployeeID=R.[SalesMan]"
            SqlString += "  where 1 =1  "
            If Not String.IsNullOrEmpty(Me.SearchSort.Text) Then
                SqlString += "  and [RefSort]=  " & SearchSort.EditValue
            End If
            If Not String.IsNullOrEmpty(Me.LookRefType.Text) Then
                SqlString += "  and [RefType]=  " & LookRefType.EditValue
            End If
            If Not String.IsNullOrEmpty(Me.LookUpActiveNotActive.Text) And Me.LookUpActiveNotActive.EditValue <> "2" Then
                SqlString += "  and [Active]=  " & LookUpActiveNotActive.EditValue
            End If
            SqlString += "  Order by RefNo  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            CloseProgressPanel(handle)
        End Try

        GridView1.FocusedRowHandle = focusedRow
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AddNew()
    End Sub
    Private Sub AddNew()
        ReferancessAddNew.TextRefNo.Text = GetReferanceMax() + 1
        ReferancessAddNew.TextRefName.Text = ""
        ReferancessAddNew.TextRefMobile.Text = ""
        ReferancessAddNew.TextRefPhone.Text = ""
        ReferancessAddNew.PriceCategory.EditValue = 1
        ReferancessAddNew.TextRefName.Select()
        ReferancessAddNew._AddNewOrSave = "AddNew"
        ReferancessAddNew.CheckActive.Checked = True
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub
    Private Sub OpenRefForm()

        ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefNo")
        ' ReferancessAddNew.TextRefName.Select()
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub
    Private Function GetMax() As Integer
        Dim _No As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select max(RefNo) as NO from [Referencess]")
            _No = Sql.SQLDS.Tables(0).Rows(0).Item("NO")
        Catch ex As Exception
            _No = 0
        End Try
        Return _No
    End Function
    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        UpdateReferances()
    End Sub
    Private Sub UpdateReferances()
        Dim RefNo As Integer
        RefNo = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefID")

        'If GlobalVariables.ConnectedWithTrueAccounting = True Then
        '    If CheckIfFoundInTrueTime(RefNo) = True Then
        '        XtraMessageBox.Show("الحساب معرف بقائمة الموظفين")
        '        Exit Sub
        '    End If
        'End If

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Update Referencess Set RefName=N'" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefName") & "' ,
                                                 RefType=N'" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefType") & "' , 
                                                 RefMobile=N'" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefMobile") & "' ,
                                                 RefPhone=N'" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefPhone") & "' ,
                                                 PriceCategory='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PriceCategory") & "' ,
                                                 RefAccID=N'" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefAccID") & "' 
                                  Where [RefID]='" & RefNo & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            XtraMessageBox.Show("تم تعديل البيانات")
        Catch ex As Exception
            XtraMessageBox.Show("لم يتم تعديل البيانات", "Error")
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        GridControl1.ShowPrintPreview()
        GridView1.Columns("RefMobile").ColumnEdit = RepositoryItemMobile1
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.ShowMarginsWarning = False
        pb.PageSettings.LeftMargin = 50
        pb.PageSettings.RightMargin = 50
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select  CompanyName from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        GridView1.Columns("RefMobile").ColumnEdit = Nothing

        pb.PageSettings.TopMargin = 50
        pb.PageSettings.BottomMargin = 50


        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {"", "", "Pages: [Page # of Pages #]"})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & " قائمة الذمم ")


        'Else
        '    If GlobalVariables._SystemLanguage = "English" Then
        '        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "Hourly employee time report " & " From  " & DateEdit1.DateTime & " To  " & DateEdit2.DateTime)
        '    Else
        '        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "تقرير دوام الموظف بالساعة " & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
        '    End If

        '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        'End If


    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)
        OpenRefForm()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub LookUpActiveNotActive_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpActiveNotActive.EditValueChanged

    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        OpenRefForm()
    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        Dim Sql As New SQLControl
        Dim _Status As Boolean = CBool(GridView1.GetFocusedRowCellValue("Active"))
        Dim _RefNo As Integer = CInt(GridView1.GetFocusedRowCellValue("RefNo"))
        Select Case _Status
            Case False
                If XtraMessageBox.Show("هل تريد تفعيل الذمة؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[Referencess] Set Active =1 where RefNo=" & _RefNo)
                    GridView1.SetFocusedRowCellValue("Active", True)
                Else
                    GridView1.SetFocusedRowCellValue("Active", False)
                End If
            Case True
                If XtraMessageBox.Show("هل تريد ايقاف الحركة على الذمة؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[Referencess] Set Active =0 where RefNo=" & _RefNo)
                    GridView1.SetFocusedRowCellValue("Active", False)
                Else
                    GridView1.SetFocusedRowCellValue("Active", True)
                End If
        End Select
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
        If e.Column.FieldName = "RefName" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        AddNew()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        GridControl1.Print()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        RefreshList()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        'Select Case _ShowVerticalLines
        '    Case True
        '        GridView1.OptionsView.ShowVerticalLines = DefaultBoolean.False
        '        _ShowVerticalLines = False
        '    Case False
        '        GridView1.OptionsView.ShowVerticalLines = DefaultBoolean.True
        '        _ShowVerticalLines = True
        'End Select
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If GridView1.OptionsView.ShowAutoFilterRow = True Then
            GridView1.OptionsView.ShowAutoFilterRow = DefaultBoolean.True
        Else
            GridView1.OptionsView.ShowAutoFilterRow = DefaultBoolean.False
        End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If Me.ColSortName.Visible = True Then
            Me.ColSortName.VisibleIndex = -1
        Else
            Me.ColSortName.VisibleIndex = 5
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If Me.ColAddress.Visible = True Then
            Me.ColAddress.VisibleIndex = -1
        Else
            Me.ColAddress.VisibleIndex = 5
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
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
            Dim _RefMobile, _RefName As String
            Dim _OrigionalSMSMessage, _SMSMessage As String

            Dim FF As New ReferancesMessageWrite
            FF.ShowDialog()
            _OrigionalSMSMessage = GlobalVariables._ReferancesMessage
            If _OrigionalSMSMessage = "-1" Then
                MsgBoxShowError(" تم الغاء العملية ")
                Exit Sub
            End If
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "RefNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "RefName")

                            _SMSMessage = _OrigionalSMSMessage

                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 9
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = Format(Today(), "yyyy-MM-dd")
                            dr("Sent") = "0"
                            dr("DocName") = "0"
                            dr("DocID") = "0"
                            dr("DocCode") = "0"
                            dr("DocData") = "0"
                            dr("Sent") = 0
                            dr("SmsID") = 0
                            dr("SMSStatus") = ""
                            dr("Action") = 1
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J += 1
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

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim _TextFilePath, _TextFileName, _MobileNo As String
        Dim res As DialogResult = XtraOpenFileDialog1.ShowDialog()
        Dim fileName As String = Path.GetFileName(XtraOpenFileDialog1.FileName)
        Dim fileExtension As String = Path.GetExtension(XtraOpenFileDialog1.FileName)
        If String.IsNullOrEmpty(fileExtension) Then
            Return
        End If
        Dim fileLocation As String = XtraOpenFileDialog1.FileName
        _TextFilePath = XtraOpenFileDialog1.FileName
        _TextFileName = Path.GetFileName(XtraOpenFileDialog1.FileName)

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


        With GridView1
            For i As Integer = 0 To .DataRowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    _MobileNo = .GetRowCellValue(i, "RefMobile")
                    If Not String.IsNullOrEmpty(_MobileNo) Then
                        SendFileToWhatsApp(_MobileNo, _TextFilePath, _TextFileName, "", .GetRowCellValue(i, "RefName"))
                    End If
                End If
            Next i
        End With
        SplashScreenManager.CloseForm(False)

    End Sub
End Class