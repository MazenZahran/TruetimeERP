Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class InsuranceDocsList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Declare @DateFrom datetime;
Set @DateFrom =GETDATE();
SELECT [DocID],[DocDate],
                             [DateFrom],[DateTo],R.RefName, 
                             RR.RefName as  [InsuranceCompany],C.[CarNo],
                             T.CarType,CT.[CoverType],[CarInsuranceAmount],
                             [CarCost], IT.ItemName as  [CarInsuranceService],
                             IsNull(VoucherNo,0) as VoucherNo,[DocAmount] ,Y.InsuranceTypeName,
                             R.RefMobile,Y.InsuranceTypeName,
							 DATEDIFF(day,@dateFrom,DateTo ) as RemainingDays,BeneficiaryName,
                             ManualDocNo,DocStatus,DocCode,InsurancePlace,InsuranceExpense,
                             IsNull(RelatedJournal,0) as RelatedJournal,(DocAmount-InsuranceExpense) as NetAmount
                      FROM [dbo].[InsuranceDoc] I
                          left join Referencess R on R.RefNo=I.Referance
                          left join CarsRent C on C.CarID=I.CarNo 
                          left join InsuranceCarsTypes T on T.ID=I.CarType 
                          left join Referencess RR on RR.RefNo=I.InsuranceCompany 
                          left join InsuranceCarsCoverTypes CT on CT.ID=I.CarCoverType 
                          left join Items IT on IT.ItemNo=I.CarInsuranceService
                          left join InsuranceTypes Y on Y.TypeID=I.InsuranceDocType "
            If RemainingDays.EditValue > 0 Then SqlString += " where 
                           DATEDIFF(day,@dateFrom,DateTo ) <= " & RemainingDays.EditValue
            SqlString += " And (DocDate between '" & Format(DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                           And '" & Format(DateEditTo.DateTime, "yyyy-MM-dd") & "')"
            If Not String.IsNullOrEmpty(InsuranceCompany.Text) Then SqlString += " 
                           And InsuranceCompany='" & InsuranceCompany.EditValue & "'"

            SqlString += " Order By DocID desc "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            BandedGridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim F As New InsuranceDoc
        With F
            F.TextDocNewOld.Text = "New"
            .ReferanceID.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                LoadData()
            End If
        End With
    End Sub

    Private Sub InsuranceDocsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today
        'lll
        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        RepositoryDocStatus.DataSource = CreateInsuranceDocumentsStatusTable()
        LoadData()
        TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        OpenDocument()
    End Sub
    Private Sub OpenDocument()
        My.Forms.InsuranceDoc.DocCode.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocCode")
        My.Forms.InsuranceDoc.TextDocNewOld.Text = "Old"
        If InsuranceDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            LoadData()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click


        If BandedGridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If BandedGridView1.SelectedRowsCount = 0 And BandedGridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
            Exit Sub
        End If

        Dim Sql As New SQLControl
        Dim _SMSMessage As String
        Sql.SqlTrueAccountingRunQuery("Select [SMSFields],SMSMessage from Messages where ID=" & 1)
        _SMSMessage = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage"))

        Dim i As Integer
        Dim _RemainingDays As Integer = 0
        Dim _MobileNo As String = 0
        Dim _DateTo As String
        Dim _Referance As String = " "
        Dim _CarNo As String = " "
        Dim _DocAmount As Decimal = 0
        Dim _InsuranceType As String = " "
        Dim _ManualDocNo As String = ""
        Dim J As Integer
        For i = 0 To BandedGridView1.RowCount - 1
            _DateTo = BandedGridView1.GetRowCellValue(i, "DateTo")
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "RemainingDays")) Then
                _RemainingDays = BandedGridView1.GetRowCellValue(i, "RemainingDays")
            End If
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "RefMobile")) Then
                _MobileNo = BandedGridView1.GetRowCellValue(i, "RefMobile")
            End If
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "DateTo")) Then
                _Referance = BandedGridView1.GetRowCellValue(i, "RefName")
            End If

            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "CarNo")) Then
                _CarNo = BandedGridView1.GetRowCellValue(i, "CarNo")
            End If
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "DocAmount")) Then
                _DocAmount = BandedGridView1.GetRowCellValue(i, "DocAmount")
            End If
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "InsuranceTypeName")) Then
                _InsuranceType = BandedGridView1.GetRowCellValue(i, "InsuranceTypeName")
            End If

            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "ManualDocNo")) Then
                _ManualDocNo = BandedGridView1.GetRowCellValue(i, "ManualDocNo")
            End If

            _SMSMessage = _SMSMessage.Replace("#CarNo#", _CarNo)
            _SMSMessage = _SMSMessage.Replace("#Referenace#", _Referance)
            _SMSMessage = _SMSMessage.Replace("#Amount#", _DocAmount)
            _SMSMessage = _SMSMessage.Replace("#RemainingDays#", _RemainingDays)
            _SMSMessage = _SMSMessage.Replace("#FinishDate#", _DateTo)
            _SMSMessage = _SMSMessage.Replace("#InsuranceType#", _InsuranceType)
            _SMSMessage = _SMSMessage.Replace("#ManualDocNo#", _ManualDocNo)
            If FunSendSmS2(_MobileNo, _SMSMessage) <> "False" Then
                J = J + 1
            End If
        Next
        XtraMessageBox.Show("تم ارسال مسجات عدد : " & J)
    End Sub


    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged

        If CheckEdit1.Checked = True Then
            TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            BandedGridView1.OptionsSelection.MultiSelect = True
            BandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Else
            TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            BandedGridView1.OptionsSelection.MultiSelect = False
            BandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click


        My.Forms.BuildMessages.ShowDialog()
        My.Forms.BuildMessages.SearchIMessagesTypes.EditValue = 1
    End Sub

    Private Sub RemainingDays_EditValueChanged(sender As Object, e As EventArgs) Handles RemainingDays.EditValueChanged
        LoadData()
    End Sub
    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink

        OpenDocument()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
    Private Sub RepositoryIssueVoucher_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryIssueVoucher.ButtonClick
        Dim _DocStatus As String = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocStatus")
        Dim _DocID As String = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocID")
        Dim _DocCode As String = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocCode")
        Select Case _DocStatus
            Case 1
                With My.Forms.InsuranceDoc
                    .DocCode.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocCode")
                    .TextDocNewOld.Text = "Old"
                    .ButtonAddAttachment.Visible = False
                    .ButtonSave.Visible = False
                    .ButtonDelete.Visible = False
                    ' .ButtonIssueVoucher.Visible = True
                    ' .ButtonIssueJournal.Visible = True
                    If .ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    Else
                        LoadData()
                    End If
                End With
            Case 2
                If OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name) <> "Success" Then
                    XtraMessageBox.Show("لا يمكن فتح السند")
                End If
        End Select
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        InsuranceLists.ShowDialog()
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            Me.BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub
End Class