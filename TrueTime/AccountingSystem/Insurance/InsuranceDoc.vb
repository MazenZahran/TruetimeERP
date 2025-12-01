Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraSplashScreen

Public Class InsuranceDoc

    Private Sub LabelControl17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SaveInsuranceDoc()
        Dim SqlString As String
        Dim Sql As New SQLControl

        If String.IsNullOrEmpty(ReferanceID.Text) Then
            XtraMessageBox.Show("خطا: حقل الزبون فارغ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(InsuranceCompany.Text) Then
            XtraMessageBox.Show("خطا: حقل شركة التامين فارغ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(InsuranceDocType.Text) Then
            XtraMessageBox.Show("خطا:  نوع التامين فارغ")
            Exit Sub
        End If
        'If String.IsNullOrEmpty(InsuranceService.Text) Then
        '    XtraMessageBox.Show("خطا: السند لا يحتوي على خدمة")
        '    Exit Sub
        'End If
        If String.IsNullOrEmpty(ManualDocNo2.Text) Then
            XtraMessageBox.Show("خطا:  رقم وثيقة التأمين فارغ")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TextInsuranceAmount.EditValue) Or TextInsuranceAmount.EditValue = 0 Then
            XtraMessageBox.Show("مبلغ التأمين صفر، يجب تعبئة الحقول المطلوبة")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TextInsuranceFullAmount.EditValue) Or TextInsuranceFullAmount.EditValue = 0 Then
            XtraMessageBox.Show("مبلغ التأمين صفر، يجب تعبئة الحقول المطلوبة")
            Exit Sub
        End If

        If IsNothing(TextInsuranceFullAmount.EditValue) Then
            TextInsuranceFullAmount.EditValue = 0
        End If
        If IsNothing(TextInsuranceExpense.EditValue) Then
            TextInsuranceExpense.EditValue = 0
        End If



        Dim _InsuranceExpenseMethod As String
        _InsuranceExpenseMethod = InsuranceExpenseMethod.EditValue

        If TextDocNewOld.EditValue = "New" Then
            SqlString = " Insert Into InsuranceDoc (DocDate,DateFrom,DateTo,Referance,InsuranceCompany,
                                                InsuranceDocType,CarNo,CarType,CarCoverType,CarInsuranceAmount,
                                                CarCost,DocAmount,DocStatus,DocNotes,BeneficiaryName,ManualDocNo,
                                                InsuranceExpense,InsurancePlace,DocCode,InsuranceExpenseMethod) 
                                  Values 
                                  ( 
                                  '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "',
                                  '" & Format(DateFrom.DateTime, "yyyy-MM-dd") & "',
                                  '" & Format(DateTo.DateTime, "yyyy-MM-dd") & "',
                                  '" & ReferanceID.EditValue & "',
                                  '" & InsuranceCompany.EditValue & "',
                                  '" & InsuranceDocType.EditValue & "',
                                  '" & CARNO.EditValue & "',
                                  '" & CarType.EditValue & "',
                                  '" & CarCoverType.EditValue & "',
                                  '" & TextInsuranceAmount.EditValue & "',
                                  '" & TextInsuranceFullAmount.EditValue & "',
                                  '" & TextInsuranceAmount.EditValue & "',
                                  '" & 1 & "',
                                  N'" & DocNotes.Text & "',
                                  N'" & BeneficiaryName.EditValue & "',
                                  N'" & ManualDocNo2.Text & "',
                                   '" & TextInsuranceExpense.EditValue & "',
                                  N'" & InsurancePlace.Text & "',
                                   '" & Me.DocCode.Text & "',
                                   '" & _InsuranceExpenseMethod & "'
                                  ) "
            If Sql.SqlTrueAccountingRunQuery(SqlString) = "True" Then
                If CheckCreateAppointment.Checked = True Then
                    InsertToCalender(DocDate.DateTime, DateTo.DateTime, "انتهاء وثيقة تأمين", ReferanceName.Text, "", 2, 1, Now, 1, ReferanceID.EditValue, Me.DocCode.Text)
                End If
                If CheckAutoIssueDocument.Checked = True Then
                    CreateUpdateVoucher()
                    CreateUpdateJournal()
                End If
                XtraMessageBox.Show("تم حفظ السند")
                Me.Dispose()
            End If
        Else
            SqlString = " Update InsuranceDoc Set 
                          DocDate='" & Format(DocDate.DateTime, "yyyy-MM-dd") & "',
                          DateFrom ='" & Format(DateFrom.DateTime, "yyyy-MM-dd") & "',
                          DateTo ='" & Format(DateTo.DateTime, "yyyy-MM-dd") & "',
                          Referance ='" & ReferanceID.EditValue & "',
                          InsuranceCompany ='" & InsuranceCompany.EditValue & "',
                          CarNo ='" & CARNO.EditValue & "',
                          CarType ='" & CarType.EditValue & "',
                          CarCoverType ='" & CarCoverType.EditValue & "',
                          CarInsuranceAmount ='" & TextInsuranceAmount.EditValue & "',
                          CarCost ='" & TextInsuranceFullAmount.EditValue & "',
                          DocAmount ='" & TextInsuranceAmount.EditValue & "',
                          InsuranceDocType ='" & InsuranceDocType.EditValue & "',
                          DocNotes =N'" & DocNotes.EditValue & "',
                          BeneficiaryName =N'" & BeneficiaryName.EditValue & "',
                          InsuranceExpense ='" & TextInsuranceExpense.EditValue & "',
                          ManualDocNo ='" & ManualDocNo2.Text & "',
                          InsurancePlace =N'" & InsurancePlace.Text & "',
                          InsuranceExpenseMethod= " & _InsuranceExpenseMethod & "
                          Where DocID=" & Me.DocID.Text
            If Sql.SqlTrueAccountingRunQuery(SqlString) = "True" Then
                If CheckCreateAppointment.Checked = True Then
                    UpdateAppointmentByDocCode("Follow", DocCode.Text,
                                               "انتهاء وثيقة تأمين",
                                               DateTo.DateTime,
                                               ReferanceID.Text, ReferanceName.Text)
                End If
                ' XtraMessageBox.Show("تم حفظ السند")
                Me.Dispose()
            End If

            If CheckAutoIssueDocument.Checked = True Then
                CreateUpdateVoucher()
                CreateUpdateJournal()
            End If

        End If





    End Sub

    Private Sub CheckAndUpdateInsuranceExpense()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " Serlect Top (1)  "
    End Sub
    Private Sub InsuranceDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        InsuranceDocType.Properties.DataSource = GetInsuranceTypes()
        ' InsuranceDocType.Properties.DataSource = GetItems("Services")
        Dim _ReferancesTable As New DataTable
        _ReferancesTable = GetReferences(-1, -1, -1)
        ReferanceID.Properties.DataSource = _ReferancesTable
        InsuranceCompany.Properties.DataSource = _ReferancesTable
        CarType.Properties.DataSource = GetInsuranceCarsTypes()
        CarCoverType.Properties.DataSource = GetInsuranceCarsCoverTypes()
        'InsuranceService.Properties.DataSource = GetItems("Services")
        'InsuranceService.EditValue = 1
        LookDocStatus.Properties.DataSource = CreateInsuranceDocumentsStatusTable()
        Me.Currency.Properties.DataSource = GetCurrency()
        Currency.EditValue = GetDefaultCurrency()
        ExchangeRate.EditValue = 1
        ReferanceID.Select()




        'Me.TabNavigationPageCars.Visible = False
        'Me.TabNavigationPageHealth.Visible = False
        'Me.TabNavigationPageAccident.Visible = False
        'Me.TabNavigationPageFire.Visible = False
        'Me.TabNavigationPageSocial.Visible = False

    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles InsuranceDocType.EditValueChanged
        Select Case InsuranceDocType.EditValue
            Case "1"
                Me.TabNavigationPageCars.PageVisible = True
                Me.TabNavigationPageEngineering.PageVisible = False
                Me.TabNavigationPageAccident.PageVisible = False
                Me.TabNavigationPageFire.PageVisible = False
                Me.TabNavigationPageSocial.PageVisible = False
                Me.TabPane1.SelectedPage = TabNavigationPageCars
            Case "2"
                Me.TabNavigationPageCars.PageVisible = False
                Me.TabNavigationPageEngineering.PageVisible = False
                Me.TabNavigationPageAccident.PageVisible = True
                Me.TabNavigationPageFire.PageVisible = False
                Me.TabNavigationPageSocial.PageVisible = False
                Me.TabPane1.SelectedPage = TabNavigationPageAccident
            Case "3"
                Me.TabNavigationPageCars.PageVisible = False
                Me.TabNavigationPageEngineering.PageVisible = False
                Me.TabNavigationPageAccident.PageVisible = False
                Me.TabNavigationPageFire.PageVisible = True
                Me.TabNavigationPageSocial.PageVisible = False
                Me.TabPane1.SelectedPage = TabNavigationPageFire
            Case "4"
                Me.TabNavigationPageCars.PageVisible = False
                Me.TabNavigationPageEngineering.PageVisible = False
                Me.TabNavigationPageAccident.PageVisible = False
                Me.TabNavigationPageFire.PageVisible = False
                Me.TabNavigationPageSocial.PageVisible = True
                Me.TabPane1.SelectedPage = TabNavigationPageSocial
            Case "5"
                Me.TabNavigationPageCars.PageVisible = False
                Me.TabNavigationPageEngineering.PageVisible = True
                Me.TabNavigationPageAccident.PageVisible = False
                Me.TabNavigationPageFire.PageVisible = False
                Me.TabNavigationPageSocial.PageVisible = False
                Me.TabPane1.SelectedPage = TabNavigationPageEngineering
        End Select
        GetInsuranceService()
    End Sub

    Private Sub ReferanceID_EditValueChanged(sender As Object, e As EventArgs) Handles ReferanceID.EditValueChanged
        CARNO.Properties.DataSource = GetInsuranceCars(ReferanceID.EditValue)
        ReferanceName.Text = GetRefranceData(ReferanceID.EditValue).RefName
    End Sub

    Private Sub InsuranceCompany_EditValueChanged(sender As Object, e As EventArgs) Handles InsuranceCompany.EditValueChanged
        InsuranceCompanyName.Text = GetRefranceData(InsuranceCompany.EditValue).RefName
    End Sub
    Private Sub TextDocNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocNewOld.EditValueChanged
        If TextDocNewOld.EditValue = "New" Then
            DocDate.DateTime = Today
            DateFrom.DateTime = Today
            VoucherNo.EditValue = 0
            RelatedJournal.EditValue = 0
            Me.DocCode.Text = CreateRandomCode()
            TaskIDText.Visible = False
            ButtonDelete.Visible = False
            'ManualDocNo2.Text = GetLastDocManualNo()
            ManualDocNo1.Text = "21-1-55-01"
            ' ButtonIssueJournal.Visible = False
            InsuranceExpenseMethod.EditValue = "1"
        Else
            Dim Sql As New SQLControl
            Dim SqlString As String
            Try
                SqlString = " SELECT [DocID]
                                 ,[DocDate]                  ,[DateFrom]
                                 ,[DateTo]                  ,[Referance]
                                 ,[InsuranceCompany], [InsuranceDocType]
                                 ,[CarNo],[CarType],      [CarCoverType]
                                 ,[CarInsuranceAmount]        ,[CarCost]
                                 ,[InsuranceService]    ,IsNull(VoucherNo,0) as VoucherNo
                                 ,[DocAmount]               ,[DocStatus]
                                 ,[DocNotes]          ,[BeneficiaryName]
                                 ,[ManualDocNo]               ,[DocCode]
                                 ,LEFT([ManualDocNo],10) as ManualDocNo1
                                 ,Right([ManualDocNo],6) as ManualDocNo2
                                 ,InsuranceExpense,     [InsurancePlace]
                                 ,IsNull(RelatedJournal,0) as RelatedJournal
                                 ,[InsuranceExpenseMethod]
                            FROM [InsuranceDoc] Where [DocCode] ='" & DocCode.Text & "'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
                With Sql.SQLDS.Tables(0).Rows(0)
                    If Not IsDBNull(.Item("DocID")) Then DocID.EditValue = (.Item("DocID"))
                    DocDate.DateTime = CDate(.Item("DocDate"))
                    If Not IsDBNull(.Item("Referance")) Then ReferanceID.EditValue = (.Item("Referance"))
                    If Not IsDBNull(.Item("InsuranceCompany")) Then InsuranceCompany.EditValue = (.Item("InsuranceCompany"))
                    DateFrom.DateTime = CDate(.Item("DateFrom"))
                    DateTo.DateTime = CDate(.Item("DateTo"))
                    If Not IsDBNull(.Item("InsuranceDocType")) Then InsuranceDocType.EditValue = (.Item("InsuranceDocType"))
                    If Not IsDBNull(.Item("DocNotes")) Then DocNotes.Text = (.Item("DocNotes"))
                    If Not IsDBNull(.Item("CARNO")) Then CARNO.EditValue = (.Item("CARNO"))
                    If Not IsDBNull(.Item("CarType")) Then CarType.EditValue = (.Item("CarType"))
                    If Not IsDBNull(.Item("CarCoverType")) Then CarCoverType.EditValue = (.Item("CarCoverType"))
                    If Not IsDBNull(.Item("CarCost")) Then TextInsuranceFullAmount.EditValue = (.Item("CarCost"))
                    If Not IsDBNull(.Item("CarInsuranceAmount")) Then TextInsuranceAmount.EditValue = (.Item("CarInsuranceAmount"))
                    ' If Not IsDBNull(.Item("InsuranceService")) Then InsuranceService.EditValue = .Item("InsuranceService")
                    If Not IsDBNull(.Item("BeneficiaryName")) Then BeneficiaryName.EditValue = .Item("BeneficiaryName")
                    If Not IsDBNull(.Item("ManualDocNo")) Then
                        ManualDocNo1.Text = .Item("ManualDocNo1")
                        ManualDocNo2.Text = .Item("ManualDocNo2")
                    End If
                    If Not IsDBNull(.Item("DocCode")) Then DocCode.Text = .Item("DocCode")
                    If Not IsDBNull(.Item("VoucherNo")) Then VoucherNo.Text = .Item("VoucherNo")
                    If Not IsDBNull(.Item("DocStatus")) Then LookDocStatus.EditValue = .Item("DocStatus")
                    If Not IsDBNull(.Item("InsuranceExpense")) Then
                        TextInsuranceExpense.EditValue = .Item("InsuranceExpense")
                    Else
                        TextInsuranceExpense.EditValue = 0
                    End If
                    If Not IsDBNull(.Item("InsurancePlace")) Then InsurancePlace.Text = .Item("InsurancePlace")
                    If Not IsDBNull(.Item("RelatedJournal")) Then RelatedJournal.Text = .Item("RelatedJournal")
                    If Not IsDBNull(.Item("DocAmount")) Then
                        TextInsuranceAmount.EditValue = .Item("DocAmount")
                    Else
                        TextInsuranceAmount.EditValue = 0
                    End If
                    If Not IsDBNull(.Item("InsuranceExpenseMethod")) Then
                        If .Item("InsuranceExpenseMethod") = "1" Then
                            TextInsuranceExpeneseAmount.EditValue = TextInsuranceExpense.EditValue
                            LayoutInsurancePercentagePercentage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                            LayoutInsuranceExpAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        Else
                            LayoutInsurancePercentagePercentage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                            LayoutInsuranceExpAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                            If TextInsuranceAmount.EditValue <> 0 Then
                                TextInsuranceExpensePerc.EditValue = (TextInsuranceExpense.EditValue / TextInsuranceAmount.EditValue) * 100
                            Else
                                TextInsuranceExpensePerc.EditValue = 0
                            End If
                        End If
                        InsuranceExpenseMethod.EditValue = CStr(.Item("InsuranceExpenseMethod"))
                    Else
                        InsuranceExpenseMethod.EditValue = "1"
                        TextInsuranceExpeneseAmount.EditValue = TextInsuranceExpense.EditValue
                    End If

                End With
                If Me.LookDocStatus.EditValue = 2 Then
                    'DockPanel2.Enabled = False
                    TabPane1.Enabled = False
                    ButtonSave.Visible = False
                    ButtonDelete.Visible = False
                    '   ButtonIssueVoucher.Visible = False
                End If
                CheckCreateAppointment.Visible = False
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Try
                SqlString = " SELECT [UniqueID]
                          FROM [Appointments] Where [DocCode] ='" & DocCode.EditValue & "'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("UniqueID")) Then
                    TaskIDText.Text = "موعد رقم" & " : " & Sql.SQLDS.Tables(0).Rows(0).Item("UniqueID")
                    TaskID.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("UniqueID")
                End If
            Catch ex As Exception

            End Try

            Dim AttachmentCount As String = " عرض الوثائق "
            SqlString = " Select count(DocID) as Count
                                            From [dbo].[ArchiveDocs] 
                                            Where LinkDocNo ='" & DocCode.Text & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                AttachmentCount += CStr(Sql.SQLDS.Tables(0).Rows(0).Item("Count"))
            End If
            SimpleButton5.Text = AttachmentCount
        End If
    End Sub
    Private Function GetLastDocManualNo() As Integer
        Dim _ManualDoc2 As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery("  Select CAST(right([ManualDocNo],6) as int ) +1 as ManualDocNo2
                                       FROM [dbo].[InsuranceDoc]")
            _ManualDoc2 = Sql.SQLDS.Tables(0).Rows(0).Item("ManualDocNo2")
        Catch ex As Exception
            _ManualDoc2 = 1
        End Try
        Return _ManualDoc2
    End Function

    Private Sub DateFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DateFrom.EditValueChanged
        DateTo.DateTime = DateFrom.DateTime.AddYears(1).AddDays(-1)
    End Sub

    Private Sub ReferanceID_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles ReferanceID.AddNewValue
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 2
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                ReferanceID.Properties.DataSource = GetReferences(-1, -1, -1)
            End If
        End With
    End Sub

    Private Sub InsuranceCompany_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles InsuranceCompany.AddNewValue
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 1
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                ReferanceID.Properties.DataSource = GetReferences(-1, -1, -1)
            End If
        End With
    End Sub

    Private Sub ReferanceID_BeforePopup(sender As Object, e As EventArgs) Handles ReferanceID.BeforePopup
        ReferanceID.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub InsuranceCompany_BeforePopup(sender As Object, e As EventArgs) Handles InsuranceCompany.BeforePopup
        InsuranceCompany.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub DocID_EditValueChanged(sender As Object, e As EventArgs) Handles DocID.EditValueChanged

    End Sub

    Private Sub InsuranceDoc_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub CARNO_EditValueChanged(sender As Object, e As EventArgs) Handles CARNO.EditValueChanged
        GetCarData()
    End Sub
    Private Sub GetCarData()
        TextCarType.Text = ""
        TextCarModel.Text = ""
        TextYearCar.Text = ""
        TextEngine.Text = ""

        If String.IsNullOrEmpty(CARNO.Text) Then
            Exit Sub
        End If
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT top(1) [CarID]
                      ,[CARNO]      ,[ChassiNoCar]
                      ,T.CarType      ,M.CarModel
                      ,[YearCar]  ,Engine
                  FROM [dbo].[CarsRent] C
                  left join CarsTypes T on T.CarTypeID=C.CarType
                  left join CarsModel M on M.CarModelID=C.CarModel where CarID=" & CARNO.EditValue
            sql.SqlTrueAccountingRunQuery(SqlString)
            With sql.SQLDS.Tables(0).Rows(0)
                If Not IsDBNull(.Item("CarType")) Then TextCarType.Text = .Item("CarType")
                If Not IsDBNull(.Item("CarModel")) Then TextCarModel.Text = .Item("CarModel")
                If Not IsDBNull(.Item("YearCar")) Then TextYearCar.Text = .Item("YearCar")
                If Not IsDBNull(.Item("Engine")) Then TextEngine.Text = .Item("Engine")
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CARNO_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles CARNO.AddNewValue
        My.Forms.CarEdit.LabelFormName.Text = " اضافة مركبة جديدة "
        My.Forms.CarEdit.CheckActive.Checked = True
        My.Forms.CarEdit.TextSearchCarID.Text = -1
        My.Forms.CarEdit.Referance.EditValue = ReferanceID.EditValue
        If CarEdit.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        End If
    End Sub

    Private Sub CARNO_BeforePopup(sender As Object, e As EventArgs) Handles CARNO.BeforePopup
        CARNO.Properties.DataSource = GetInsuranceCars(ReferanceID.EditValue)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles ButtonAddAttachment.Click
        'Dim File As String = CheckArchiveDocNo(DocID.Text)
        'LoadPdfFile(File)
        'Dim mydialogbox As New AttachmentDispaly
        'AttachmentDispaly.ShowDialog()

        '    My.Forms.AttachmentsAdd.ShowDialog()
        AttachmentsBulkAdd.ReferanceID.EditValue = ReferanceID.EditValue
        AttachmentsBulkAdd.SearchSystemDocName.EditValue = 14
        AttachmentsBulkAdd.LinkDocNo.EditValue = Me.DocCode.Text
        AttachmentsBulkAdd.ReferanceID.ReadOnly = True
        AttachmentsBulkAdd.SearchAccount.ReadOnly = True
        AttachmentsBulkAdd.ShowDialog()

    End Sub
    Private Function CheckArchiveDocNo(DocID As String) As String
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " Select DocID from [ArchiveDocs] where LinkDocType='Vocations' and LinkDocNo='" & DocID & "' "
            Sql.SqlTrueTimeRunQuery(SqlString)
            Return CStr(Sql.SQLDS.Tables(0).Rows(0).Item("DocID").ToString)
        Catch ex As Exception
            Return "False"
        End Try
    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click


        If LookDocStatus.EditValue = 2 Then
            XtraMessageBox.Show("لا يمكن حذف السند")
            Exit Sub
        End If
        Try
            If XtraMessageBox.Show("هل تريد حذف السند ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Delete from [dbo].[InsuranceDoc] where DocID= " & DocID.EditValue
                If Sql.SqlTrueAccountingRunQuery(SqlString) = "True" Then
                    If Me.TaskID.Text <> "" Then Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Appointments] where [UniqueID]=" & Me.TaskID.EditValue)
                    If Me.VoucherNo.Text <> "" Then Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Journal] where DocName=2 and [DocID]=" & Me.VoucherNo.EditValue)
                    If Me.RelatedJournal.Text <> "" Then Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Journal] where DocName=5 and [DocID]=" & Me.RelatedJournal.EditValue)
                    Dispose()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub HyperlinkLabelControl1_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelVoucherNo.Click
        If Me.VoucherNo.Text <> "0" Then
            OpenDocumentsByDocCode(Me.DocCode.Text, "Journal", Me.Name)
        End If
    End Sub

    Private Sub TaskID_Click(sender As Object, e As EventArgs) Handles TaskIDText.Click


    End Sub

    Private Sub VoucherNo_EditValueChanged(sender As Object, e As EventArgs) Handles VoucherNo.EditValueChanged
        If Me.VoucherNo.Text = "0" Then
            HyperlinkLabelVoucherNo.Text = "لم يتم اصدار فاتورة"
        Else
            HyperlinkLabelVoucherNo.Text = "تم اصدار فاتورة رقم: " & VoucherNo.Text
        End If
    End Sub

    'Private Sub DocCode_EditValueChanged(sender As Object, e As EventArgs) Handles DocCode.EditValueChanged
    '    If Me.TextDocNewOld.Text = "Old" Then
    '        Try
    '            Dim Sql As New SQLControl
    '            Dim SqlString As String
    '            SqlString = " SELECT [DocID]
    '                             ,[DocDate]                 ,[DateFrom]
    '                             ,[DateTo]                 ,[Referance]
    '                             ,[InsuranceCompany],[InsuranceDocType]
    '                             ,[CarNo],[CarType],     [CarCoverType]
    '                             ,[CarInsuranceAmount]       ,[CarCost]
    '                             ,[InsuranceService]    ,IsNull(VoucherNo,0) as VoucherNo
    '                             ,[DocAmount]              ,[DocStatus]
    '                             ,[DocNotes]         ,[BeneficiaryName]
    '                             ,[ManualDocNo]              ,[DocCode]
    '                        FROM [InsuranceDoc] Where [DocCode] ='" & DocCode.Text & "'"
    '            Sql.SqlTrueAccountingRunQuery(SqlString)
    '            With Sql.SQLDS.Tables(0).Rows(0)
    '                DocDate.DateTime = CDate(.Item("DocDate"))
    '                If Not IsDBNull(.Item("Referance")) Then ReferanceID.EditValue = (.Item("Referance"))
    '                If Not IsDBNull(.Item("InsuranceCompany")) Then InsuranceCompany.EditValue = (.Item("InsuranceCompany"))
    '                DateFrom.DateTime = CDate(.Item("DateFrom"))
    '                DateTo.DateTime = CDate(.Item("DateTo"))
    '                If Not IsDBNull(.Item("InsuranceDocType")) Then InsuranceDocType.EditValue = (.Item("InsuranceDocType"))
    '                If Not IsDBNull(.Item("DocNotes")) Then DocNotes.Text = (.Item("DocNotes"))
    '                If Not IsDBNull(.Item("CARNO")) Then CARNO.EditValue = (.Item("CARNO"))
    '                If Not IsDBNull(.Item("CarType")) Then CarType.EditValue = (.Item("CarType"))
    '                If Not IsDBNull(.Item("CarCoverType")) Then CarCoverType.EditValue = (.Item("CarCoverType"))
    '                If Not IsDBNull(.Item("CarCost")) Then CarCost.EditValue = (.Item("CarCost"))
    '                If Not IsDBNull(.Item("CarInsuranceAmount")) Then CarInsuranceAmount.EditValue = (.Item("CarInsuranceAmount"))
    '                If Not IsDBNull(.Item("InsuranceService")) Then InsuranceService.EditValue = .Item("InsuranceService")
    '                If Not IsDBNull(.Item("BeneficiaryName")) Then BeneficiaryName.EditValue = .Item("BeneficiaryName")
    '                If Not IsDBNull(.Item("ManualDocNo")) Then ManualDocNo.Text = .Item("ManualDocNo")
    '                If Not IsDBNull(.Item("DocCode")) Then DocCode.Text = .Item("DocCode")
    '                If Not IsDBNull(.Item("VoucherNo")) Then VoucherNo.Text = .Item("VoucherNo")
    '                If Not IsDBNull(.Item("DocStatus")) Then LookDocStatus.EditValue = .Item("DocStatus")
    '            End With
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '        Try
    '            Dim Sql As New SQLControl
    '            Dim SqlString As String
    '            SqlString = " SELECT [UniqueID]
    '                      FROM [Appointments] Where [DocCode] ='" & DocCode.EditValue & "'"
    '            Sql.SqlTrueAccountingRunQuery(SqlString)
    '            TaskID.Text = Sql.SQLDS.Tables(0).Rows(0).Item("UniqueID")
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles ButtonIssueVoucher.Click
        SaveInsuranceDoc()
        CreateUpdateVoucher()



    End Sub

    Private Sub CarInsuranceAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextInsuranceAmount.EditValueChanged
        'Amount.EditValue = CarInsuranceAmount.EditValue + HealthInsuranceAmount.EditValue + TextJobAcceidantFullAmount.EditValue + TextFireFullAmount.EditValue
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        SaveInsuranceDoc()
    End Sub

    Private Sub LookDocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LookDocStatus.EditValueChanged

    End Sub

    Private Sub CarType_Properties_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles CarType.Properties.AddNewValue

        InsuranceLists.NavigationPane1.SelectedPage = InsuranceLists.NavigationPane1.Pages(0)
        If InsuranceLists.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            CarType.Properties.DataSource = GetInsuranceCarsTypes()
            CarCoverType.Properties.DataSource = GetInsuranceCarsCoverTypes()
        End If
    End Sub

    Private Sub CarCoverType_Properties_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles CarCoverType.Properties.AddNewValue

        InsuranceLists.NavigationPane1.SelectedPage = InsuranceLists.NavigationPane1.Pages(1)
        If InsuranceLists.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            CarType.Properties.DataSource = GetInsuranceCarsTypes()
            CarCoverType.Properties.DataSource = GetInsuranceCarsCoverTypes()
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        AttachmentDirectDisplay.GridControl2.DataSource = GetAttachmentsByDocCode(Me.DocCode.Text, 14)
        If AttachmentDirectDisplay.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        End If
    End Sub

    Private Sub ManualDocNo2_EditValueChanged(sender As Object, e As EventArgs)
        MergeTowNo()
    End Sub
    Private Sub MergeTowNo()
        Try
            ManualDocNo.Text = ManualDocNo1.EditValue & "-" & ManualDocNo2.Text
        Catch ex As Exception
            ManualDocNo.Text = "0"
        End Try
    End Sub

    Private Sub ManualDocNo1_EditValueChanged(sender As Object, e As EventArgs) Handles ManualDocNo1.EditValueChanged
        MergeTowNo()
    End Sub

    Private Sub CreateUpdateJournal()
        Dim _DebitAcc As String = ""
        Dim _CreditAcc As String = ""
        Dim _ReferanceID As String = ""
        Dim _ReferanceName As String = ""
        Dim _CostCenter As Integer = 1
        If TextInsuranceExpensePerc.Text <> "" Then Exit Sub
        If TextInsuranceExpensePerc.EditValue = 0 Then Exit Sub
        _ReferanceID = Me.InsuranceCompany.EditValue
        _ReferanceName = Me.InsuranceCompany.Text
        _DebitAcc = GetRefranceData(InsuranceCompany.EditValue).RefAccID
        _CreditAcc = GetItemsData(Me.InsuranceService.EditValue, False).AccSales
        _CostCenter = "1"
        Dim _DocID As Integer
        Dim Sql As New SQLControl
        Dim SqlInsertDetials As String
        Dim _DocCode As String = CreateRandomCode()
        Dim _Docnote As String = "عمولة اصدار وثيقة تأمين رقم " & Me.DocID.EditValue & " / " & BeneficiaryName.Text
        Select Case RelatedJournal.Text
            Case "0"
                'If TextInsuranceExpense.EditValue = 0 Then
                '    MsgBox("يجب ان تكون العمولة اكبر من صفر")
                '    Exit Sub
                'End If
                If XtraMessageBox.Show("هل تريد اصدار قيد العمولة ؟", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    'SaveInsuranceDoc()
                    Dim _ExpenseAccount As String
                    Try
                        Sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [dbo].[Settings] where [SettingName]='DefualtAccountForInsuranceExpense'")
                        _ExpenseAccount = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
                    Catch ex As Exception
                        _ExpenseAccount = "0"
                    End Try

                    If _ExpenseAccount = "0" Then
                        MsgBox("لا يوجد حساب افتراضي للعمولة")
                        Exit Sub
                    End If
                    _DocID = GetDocNo(5, False)
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 5 & "', 
                                      '" & 4 & "',
                                      '" & _CostCenter & "',
                                      '" & "0" & "',
                                      '" & _ExpenseAccount & "',
                                      '" & GetFinancialAccountsData(_ExpenseAccount).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & TextInsuranceExpense.Text & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetFinancialAccountsData(_ExpenseAccount).Currency, TextInsuranceExpense.Text, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & TextInsuranceExpense.Text * ExchangeRate.Text & "',
                                      '" & ManualDocNo.Text & "',
                                       N'" & _Docnote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & "0" & "',
                                      '" & "0" & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & "0" & "',
                                      N'" & "0" & "',
                                      N'" & "0" & "',
                                      '" & _DocCode & "'
                                            )"
                    If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        XtraMessageBox.Show("خطا بعملية اصدار سند العمولة", "Error", MessageBoxButtons.OK)
                        DeleteFromJournalTemp(2, _DocCode)
                        Exit Sub
                    End If
                    'Insert Credit Account
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 5 & "', 
                                      '" & 4 & "',
                                      '" & _CostCenter & "',
                                      '" & _DebitAcc & "',
                                      '" & "0" & "',
                                      '" & GetFinancialAccountsData(_DebitAcc).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & TextInsuranceExpense.Text & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetBankAccountsData(_DebitAcc)._Currency, TextInsuranceExpense.Text, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & TextInsuranceExpense.Text * ExchangeRate.Text & "',
                                      '" & ManualDocNo.Text & "',
                                       N'" & _Docnote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & "0" & "',
                                      '" & 0 & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & InsuranceCompany.EditValue & "',
                                      N'" & InsuranceCompany.Text & "',
                                      N'" & 0 & "',
                                      '" & _DocCode & "'
                                            )"
                    If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        XtraMessageBox.Show("خطا بعملية اصدار قيد العمولة", "Error", MessageBoxButtons.OK)
                        DeleteFromJournalTemp(5, _DocCode)
                        Exit Sub
                    End If
                    InsertFromTempToJournal(5, _DocID)
                    DeleteFromJournalTemp(5, _DocCode)
                    Sql.SqlTrueAccountingRunQuery(" Update [dbo].[InsuranceDoc] Set RelatedJournal= " & _DocID & " where DocCode='" & DocCode.Text & "'")
                    HyperlinkLabelJournalNo.Text = "تم اصدار قيد عمولة رقم: " & _DocID
                    XtraMessageBox.Show("تم اصدار قيد العمولة", "", MessageBoxButtons.OK)
                End If
            Case Else
                Dim SqlString As String
                SqlString = "  Update [dbo].[Journal]
                                   Set DebitAcc='" & _DebitAcc & "',DocAmount=" & TextInsuranceExpense.Text & ",
                                   BaseAmount=" & TextInsuranceExpense.Text & ",BaseCurrAmount=" & TextInsuranceExpense.Text & ",
                                   Referance ='" & ReferanceID.EditValue & "' ,DocNotes=N'" & _Docnote & "',
                                   StockID='" & Me.InsuranceService.EditValue & "',StockPrice=" & TextInsuranceExpense.Text & ",
                                   ReferanceName=N'" & Me.InsuranceService.Text & "',ItemName=N'" & InsuranceService.Text & "'
                                   where CredAcc='0' and DocName=5 and DocID=" & RelatedJournal.Text & ";
                               Update [dbo].[Journal] Set CredAcc='" & _CreditAcc & "',DocAmount=" & TextInsuranceExpense.Text & ",
                                   BaseAmount=" & TextInsuranceExpense.Text & ",BaseCurrAmount=" & TextInsuranceExpense.Text & ",
                                   DocNotes=N'" & _Docnote & "'
                                   where DocName=5 and DocID=" & RelatedJournal.Text & " And DebitAcc='0'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
        End Select



    End Sub

    Private Sub RelatedJournal_EditValueChanged(sender As Object, e As EventArgs) Handles RelatedJournal.EditValueChanged
        If Me.RelatedJournal.Text = "0" Then
            HyperlinkLabelJournalNo.Text = "لم يتم اصدار قيد عمولة"
            '  ButtonIssueJournal.Visible = True
        Else
            HyperlinkLabelJournalNo.Text = "تم اصدار قيد عمولة رقم: " & RelatedJournal.Text
            ' ButtonIssueJournal.Visible = False
        End If
    End Sub

    Private Sub HyperlinkLabelJournalNo_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelJournalNo.Click
        If Me.RelatedJournal.Text <> "0" Then
            Dim _DocCode As String
            _DocCode = GetDocCode(RelatedJournal.Text, "Journal")
            OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name)
        End If
    End Sub
    Private Function GetDocCode(DocNo As Integer, DocData As String) As String
        Dim _DocCode As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " Select DocCode from " & DocData & " where DocName=5 and [DocID]=" & DocNo
            Sql.SqlTrueTimeRunQuery(SqlString)
            _DocCode = Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
        Catch ex As Exception
            _DocCode = "0"
        End Try
        Return _DocCode
    End Function

    Private Sub ButtonIssueJournal_Click(sender As Object, e As EventArgs) Handles ButtonIssueJournal.Click
        CreateUpdateJournal()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextInsuranceExpensePerc.EditValueChanged
        CalcInsuranceExpenese()
    End Sub

    Private Sub TextInsuranceExpense_EditValueChanged(sender As Object, e As EventArgs) Handles TextInsuranceExpense.EditValueChanged

    End Sub


    Private Sub CalcInsuranceExpenese()
        If Me.IsHandleCreated Then
            Dim _Method As String
            _Method = InsuranceExpenseMethod.EditValue
            Try
                Select Case _Method
                    Case "1"
                        TextInsuranceExpense.EditValue = TextInsuranceExpeneseAmount.EditValue
                    Case "2"
                        TextInsuranceExpense.EditValue = (TextInsuranceExpensePerc.EditValue / 100) * TextInsuranceAmount.EditValue
                End Select

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InsuranceExpenseMethod.SelectedIndexChanged
        Select Case InsuranceExpenseMethod.EditValue
            Case "1"
                LayoutInsuranceExpAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutInsurancePercentagePercentage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "2"
                LayoutInsurancePercentagePercentage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutInsuranceExpAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
        CalcInsuranceExpenese()
    End Sub

    Private Sub TextInsuranceExpeneseAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextInsuranceExpeneseAmount.EditValueChanged
        CalcInsuranceExpenese()
    End Sub
    Private Sub Amount_EditValueChanged(sender As Object, e As EventArgs) Handles Amount.EditValueChanged
        CalcInsuranceExpenese()
    End Sub
    Private Sub CreateUpdateVoucher()
        ' If XtraMessageBox.Show("هل تريد اصدار فاتورة ؟", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
        Dim _DebitAcc As String
        Dim _CreditAcc As String
        Dim _ReferanceID As String
        Dim _ReferanceName As String
        Dim _CostCenter As Integer
        _ReferanceID = Me.ReferanceID.EditValue
        _DebitAcc = GetRefranceData(_ReferanceID).RefAccID
        _CreditAcc = GetItemsData(Me.InsuranceService.EditValue, False).AccSales
        _CostCenter = "1"
        _ReferanceName = ReferanceName.Text
        Dim _DocNote As String = ""
        If DocNotes.Text <> "" Then _DocNote += " " & Me.DocNotes.Text
        If BeneficiaryName.Text <> "" Then _DocNote += " / " & Me.BeneficiaryName.Text
        If CARNO.Text <> "" Then _DocNote += " / " & " مركبة رقم " & Me.CARNO.Text


        Dim _DocID As Integer
        If Me.VoucherNo.Text = "0" Then
            _DocID = GetDocNo(2, False)
            'VoucherNo.EditValue = _DocID
        Else
            _DocID = VoucherNo.EditValue
        End If
        Dim Sql As New SQLControl
        Dim SqlInsertDetials As String

        'MsgBox(TextInsuranceAmount.EditValue)
        ' Create Update Voucher
        Select Case Me.VoucherNo.EditValue
            Case 0
                If XtraMessageBox.Show("هل تريد اصدار فاتورة ؟", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    _ReferanceID = Me.ReferanceID.EditValue
                    _DebitAcc = GetRefranceData(_ReferanceID).RefAccID
                    _CreditAcc = GetItemsData(Me.InsuranceService.EditValue, False).AccSales
                    _CostCenter = "1"
                    _ReferanceName = ReferanceName.Text
                    'Insert Debit Account
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 4 & "',
                                      '" & _CostCenter & "',
                                      '" & _DebitAcc & "',
                                      '" & "0" & "',
                                      '" & GetFinancialAccountsData(_DebitAcc).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetFinancialAccountsData(_DebitAcc).Currency, TextInsuranceAmount.EditValue, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & TextInsuranceAmount.EditValue * ExchangeRate.Text & "',
                                      '" & ManualDocNo.Text & "',
                                       N'" & _DocNote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & 0 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & "0" & "',
                                      '" & "0" & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceID.EditValue & "',
                                      N'" & ReferanceName.Text & "',
                                      N'" & "0" & "',
                                      '" & DocCode.Text & "'
                                            )"
                    If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        XtraMessageBox.Show("خطا بعملية اصدار الفاتورة", "Error", MessageBoxButtons.OK)
                        DeleteFromJournalTemp(2, Me.DocCode.Text)
                        Exit Sub
                    End If
                    'Insert Credit Account
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 4 & "',
                                      '" & _CostCenter & "',
                                      '" & "0" & "',
                                      '" & _CreditAcc & "',
                                      '" & GetFinancialAccountsData(_CreditAcc).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetBankAccountsData(_DebitAcc)._Currency, TextInsuranceAmount.EditValue, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & TextInsuranceAmount.EditValue * ExchangeRate.Text & "',
                                      '" & ManualDocNo.Text & "',
                                       N'" & _DocNote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & InsuranceService.EditValue & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & TextInsuranceAmount.EditValue & "',
                                      '" & "0" & "',
                                      '" & GetDefaultWharehouse() & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceID.EditValue & "',
                                      N'" & ReferanceName.Text & "',
                                      N'" & InsuranceDocType.Text & "',
                                      '" & DocCode.Text & "'
                                            )"
                    If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        XtraMessageBox.Show("خطا بعملية اصدار الفاتورة", "Error", MessageBoxButtons.OK)
                        DeleteFromJournalTemp(2, DocCode.Text)
                        Exit Sub
                    End If
                    If InsertFromTempToJournal(2, _DocID) = "True" Then
                        DeleteFromJournalTemp(2, DocCode.Text)
                        'VoucherNo.EditValue = _DocID
                        ' Sql.SqlTrueAccountingRunQuery(" Update [dbo].[InsuranceDoc] Set VoucherNo= " & _DocID & ", [DocStatus]= " & 2 & " where DocID=" & DocID.EditValue)
                        XtraMessageBox.Show("تم اصدار فاتورة", "", MessageBoxButtons.OK)
                        '  PrintDoc(False)
                        Sql.SqlTrueAccountingRunQuery("Update [dbo].[InsuranceDoc] Set [VoucherNo]=" & _DocID & " where [DocCode]='" & Me.DocCode.Text & "'")
                    Else
                        XtraMessageBox.Show("خطأ: لم يتم اصدار فاتورة", "", MessageBoxButtons.OK)
                        DeleteFromJournalTemp(2, DocCode.Text)
                    End If


                End If
            Case > 0
                ' Update Voucher
                Dim SqlString As String
                SqlString = "  Update [dbo].[Journal]
                           Set CredAcc='" & _CreditAcc & "',DocAmount=" & TextInsuranceAmount.EditValue & ",
                           BaseAmount=" & TextInsuranceAmount.EditValue & ",BaseCurrAmount=" & TextInsuranceAmount.EditValue & ",
                           Referance ='" & ReferanceID.EditValue & "' ,DocNotes=N'" & _DocNote & "',
                           StockID='" & Me.InsuranceService.EditValue & "',StockPrice=" & TextInsuranceAmount.EditValue & ",
                           ReferanceName=N'" & _ReferanceName & "',ItemName=N'" & InsuranceDocType.Text & "'
                           where DebitAcc ='0' and DocName=2 and DocID=" & VoucherNo.Text & ";
                       Update [dbo].[Journal] Set DebitAcc='" & _DebitAcc & "',DocAmount=" & TextInsuranceAmount.EditValue & ",
                           BaseAmount=" & TextInsuranceAmount.EditValue & ",BaseCurrAmount=" & TextInsuranceAmount.EditValue & ",
                           Referance ='" & ReferanceID.EditValue & "' ,DocNotes=N'" & _DocNote & "',
                           ReferanceName=N'" & _ReferanceName & "' 
                           where DocName=2 and DocID=" & VoucherNo.Text & " And CredAcc='0'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
        End Select


        ' End If
    End Sub
    Private Sub GetInsuranceService()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select InsuranceService from InsuranceTypes where TypeID=" & InsuranceDocType.EditValue)
            Me.InsuranceService.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("InsuranceService")
        Catch ex As Exception

        End Try
    End Sub
End Class