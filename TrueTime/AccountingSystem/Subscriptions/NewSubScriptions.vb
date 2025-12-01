Imports System.ComponentModel
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class NewSubScriptions
    Private _StartDateFromSubscriberDate
    Private _ConnectWithVoucher As Boolean

    Private Sub NewSubScriptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.
        _ConnectWithVoucher = False
        GetTables()
        GetSettings()
        SubStatus.Properties.DataSource = CreatSubscriptionTypesTable()
        TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup3
        If GlobalVariables._UseSalesMan = True Then
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select EmployeeID,EmployeeName from EmployeesData;")
            Me.SalesPerson.Properties.DataSource = Sql.SQLDS.Tables(0)
            Me.LayoutControlSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub
    Private Sub GetTables()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select ItemNo,ItemName from Items Where [Type]=1;
SELECT [RefNo],[RefName],[DateStart],[RefImage] FROM [Referencess]  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        SubscriptionType.Properties.DataSource = Sql.SQLDS.Tables(0)
        GridControl1.DataSource = Sql.SQLDS.Tables(1)
    End Sub
    Private Sub GetSettings()
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='IssueVoucherInSubscriptionsSystem'")
            Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='SubScriptions_ShowLayoutMonthsInNewOrEditSubScriptionForm'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                LayoutMonths.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                LayoutMonths.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        Catch ex As Exception
            LayoutMonths.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='SubScriptions_LockEndDate'")
            EndDate.Enabled = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True
        Catch ex As Exception
            EndDate.Enabled = True
        End Try


        Select Case GlobalVariables._AccessType
            Case "User"
                CheckIssueVoucherInSubscriptionsSystem.Enabled = False
                SubStatus.Enabled = False
            Case "Admin"
                CheckIssueVoucherInSubscriptionsSystem.Enabled = True
                SubStatus.Enabled = True
        End Select


    End Sub
    Private Sub GetReferencesForList()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [RefID]      ,[RefName]
      ,[RefNo]      ,[RefType]      ,[RefMobile]
      ,[RefPhone]      ,[RefAccID]      ,[PriceCategory]
      ,[RefEmail]      ,[SearchCity]      ,[SubscribeAmount]
      ,[RefSort]      ,[RefBirthDate]      ,[RefMemo]
      ,[Active]      ,[DateStart]      ,[Address]
      ,[ReferanceCode]      ,[RefImage]
  FROM [Referencess]  "
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub



    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'GetReferencesForList()
        GetTables()
    End Sub

    Private Sub WindowsUIButtonPanel1_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Save"
                Saving()
            Case "Close"
                Me.Close()
            Case "Delete"
                DeleteSubscription()
            Case "SendMessage"
                SendSubscriptionMessage()
        End Select
    End Sub
    Private Sub SendSubscriptionMessage()

        If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & ReferanceName.Text & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Select Case TextNewOld.Text
            Case "New"
                Try
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

                    Dim _ReferanceNo As String
                    Dim _RefMobile, _RefName As String
                    Dim _DocAmount As Decimal = 0
                    Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
                    Dim _FromDate As String = Format(Me.StartDate.DateTime, "yyyy-MM-dd")
                    Dim _ToDate As String = Format(Me.EndDate.DateTime, "yyyy-MM-dd")
                    Dim _RefBalance As Decimal = 0
                    Dim _OrigionalSMSMessage, _SMSMessage As String
                    sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=10")
                    _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")


                    _ReferanceNo = ReferanceNo.Text
                    If Not String.IsNullOrEmpty(_ReferanceNo) Then
                        Dim _RefData = GetRefranceData(_ReferanceNo)
                        _RefBalance = GetReferanceBalance(_ReferanceNo)
                        _RefMobile = _RefData.RefMobile
                        _RefName = _RefData.RefName

                        _SMSMessage = _OrigionalSMSMessage
                        _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                        _SMSMessage = _SMSMessage.Replace("#FromDate#", _FromDate)
                        _SMSMessage = _SMSMessage.Replace("#ToDate#", _ToDate)
                        _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)

                        Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                        dr("SMSType") = 10
                        dr("SMSDetails") = _SMSMessage
                        dr("RefNo") = _ReferanceNo
                        dr("RefMobile") = _RefMobile
                        dr("RefName") = _RefName
                        dr("AccrualDateTime") = _DocDate
                        dr("Sent") = "0"
                        dr("DocName") = "0"
                        dr("DocID") = "0"
                        dr("DocCode") = "0"
                        dr("DocData") = "0"
                        dr("Sent") = 0
                        dr("SmsID") = 0
                        dr("SMSStatus") = ""
                        If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                        _SMSMessagesTempTable.Rows.Add(dr)
                    End If

                    Dim f As New SmsSendingForm
                    With f
                        .GetUnsentMessages(_BulkNo)
                        .ShowDialog()
                    End With

                Catch ex As Exception
                    XtraMessageBox.Show(ex.ToString)
                End Try
            Case "ReSub"
                Try
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

                    Dim _ReferanceNo As String
                    Dim _RefMobile, _RefName As String
                    Dim _DocAmount As Decimal = 0
                    Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
                    Dim _FromDate As String = Format(Me.StartDate.DateTime, "yyyy-MM-dd")
                    Dim _ToDate As String = Format(Me.EndDate.DateTime, "yyyy-MM-dd")


                    Dim _OrigionalSMSMessage, _SMSMessage As String
                    sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=13")
                    _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")


                    _ReferanceNo = ReferanceNo.Text
                    Dim _RefBalance As Decimal = GetReferanceBalance(_ReferanceNo)
                    If Not String.IsNullOrEmpty(_ReferanceNo) Then
                        Dim _RefData = GetRefranceData(_ReferanceNo)
                        _RefMobile = _RefData.RefMobile
                        _RefName = _RefData.RefName

                        _SMSMessage = _OrigionalSMSMessage
                        _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                        _SMSMessage = _SMSMessage.Replace("#FromDate#", _FromDate)
                        _SMSMessage = _SMSMessage.Replace("#ToDate#", _ToDate)
                        _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)

                        Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                        dr("SMSType") = 13
                        dr("SMSDetails") = _SMSMessage
                        dr("RefNo") = _ReferanceNo
                        dr("RefMobile") = _RefMobile
                        dr("RefName") = _RefName
                        dr("AccrualDateTime") = _DocDate
                        dr("Sent") = "0"
                        dr("DocName") = "0"
                        dr("DocID") = "0"
                        dr("DocCode") = "0"
                        dr("DocData") = "0"
                        dr("Sent") = 0
                        dr("SmsID") = 0
                        dr("SMSStatus") = ""
                        If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                        _SMSMessagesTempTable.Rows.Add(dr)
                    End If

                    Dim f As New SmsSendingForm
                    With f
                        .GetUnsentMessages(_BulkNo)
                        .ShowDialog()
                    End With

                Catch ex As Exception
                    XtraMessageBox.Show(ex.ToString)
                End Try
        End Select

    End Sub

    Private Sub Saving()
        If TextDaysCount.Text = "" Then
            MsgBox("الفترة خطا")
            Exit Sub
        End If

        If TextDaysCount.Text <= 0 Then
            MsgBox("الفترة خطا")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(ReferanceNo.Text) Then
            XtraMessageBox.Show("يجب تعبئة المشترك")
            ReferanceNo.Select()
            ReferanceNo.BackColor = Color.Red
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(SubscriptionType.Text) Then
            XtraMessageBox.Show("خطأ: نوع الاشتراك فارغ")
            SubscriptionType.Select()
            SubscriptionType.BackColor = Color.Red
            Exit Sub
        End If
        If String.IsNullOrEmpty(ReferanceName.Text) Then
            XtraMessageBox.Show("يجب تعبئة اسم المشترك")
            ReferanceNo.Select()
            ReferanceNo.BackColor = Color.Red
            Exit Sub
        End If

        Select Case TextNewOld.Text
            Case "New"
                InsertNewData()
            Case "Old"
                UpdateData()
            Case "ReSub"
                UpdateData()
                InsertNewData()
        End Select
    End Sub

    Private Sub ReferanceID_EditValueChanged(sender As Object, e As EventArgs) Handles ReferanceNo.EditValueChanged
        If Not IsDBNull(ReferanceNo.Text) Then
            ReferanceNo.BackColor = DefaultBackColor
            Dim _RefData = GetRefranceData(ReferanceNo.EditValue)
            Me.ReferanceName.Text = _RefData.RefName
            If _RefData.RefBirthDate <> "" Then Me.RefBirthDate.Text = CalcAge(_RefData.RefBirthDate)
            Me.SalesPerson.EditValue = _RefData.SalesMan
            Select Case TextNewOld.Text
                Case "New"
                    GetLastStartDate()
            End Select

            SubscriptionType.Select()
        End If


    End Sub

    Private Sub TileView1_DoubleClick(sender As Object, e As EventArgs) Handles TileView1.ItemPress
        Try
            If IsDBNull(Me.TileView1.GetRowCellValue(TileView1.FocusedRowHandle, "RefNo")) Then Exit Sub
            Me.ReferanceNo.EditValue = Me.TileView1.GetRowCellValue(TileView1.FocusedRowHandle, "RefNo")
            'Me.ReferanceName.Text = Me.TileView1.GetRowCellValue(TileView1.FocusedRowHandle, "RefName")

            'If Me.TextDocForWhat.Text = "ReceiveCar" Then
            '    Dim SQl As New SQLControl
            '    SQl.SqlTrueAccountingRunQuery(" SELECT top 1 [DocID],[DocStatus] 
            '                                FROM [dbo].[CarRentDocuments] R 
            '                                WHERE   [DocStatus]=1  and R.CarID=" & Me.CarID.Text & "  ORDER BY [DocID] desc  ")
            '    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocID")) Then
            '        Me.DocID.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocID")
            '        Me.DocEndDate.DateTime = Now
            '    End If
            '    If SQl.SQLDS.Tables(0).Rows(0).Item("DocStatus") = 3 Then
            '        'SimpleButton3.Visible = False
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NewSubScriptions_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub ReferanceName_EditValueChanged(sender As Object, e As EventArgs) Handles ReferanceName.EditValueChanged
        ReferanceNo.BackColor = DefaultBackColor
        WriteHeader()
    End Sub

    Private Sub SubID_EditValueChanged(sender As Object, e As EventArgs) Handles SubID.EditValueChanged
        Select Case TextNewOld.Text
            Case "Old"
                If Me.SubID.EditValue = 0 Then Exit Sub
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select [Subscriber],[SubscriberName],[StartDate],
                                     [EndDate],[Amount],CONVERT(INT, [SubStatus]) as SubStatus ,[DocNotes],[SubscriptionType],RelatedVoucherCode,VoucherNo,DocCode,IsNull(SalesPerson,0) As SalesPerson
                              From [SubscriptionDoc] Where SubId=" & Me.SubID.EditValue
                Sql.SqlTrueAccountingRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0)) Then
                    With Sql.SQLDS.Tables(0).Rows(0)
                        ReferanceNo.Text = .Item("Subscriber")
                        ReferanceName.Text = .Item("SubscriberName")
                        StartDate.DateTime = .Item("StartDate")
                        EndDate.DateTime = .Item("EndDate")
                        Amount.EditValue = .Item("Amount")
                        SubStatus.EditValue = CInt(.Item("SubStatus"))
                        SubscriptionType.EditValue = .Item("SubscriptionType")
                        VoucherNo.EditValue = .Item("VoucherNo")
                        DocCode.Text = .Item("DocCode")
                        If Not IsDBNull(.Item("DocNotes")) Then DocNotes.EditValue = .Item("DocNotes")
                        Me.TextDaysCount.Text = DateDiff(DateInterval.Day, StartDate.DateTime, EndDate.DateTime)
                        Me.SalesPerson.EditValue = .Item("SalesPerson")
                    End With
                End If
                If Not String.IsNullOrEmpty(VoucherNo.Text) Then
                    LayoutIssueVoucher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                End If
            Case "ReSub"
                If Me.SubID.EditValue = 0 Then Exit Sub
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select [Subscriber],[SubscriberName],[StartDate],
                                     [EndDate],[Amount],CONVERT(INT, [SubStatus]) as SubStatus,[DocNotes],[SubscriptionType],RelatedVoucherCode,VoucherNo,DocCode,IsNull(SalesPerson,0) As SalesPerson
                              From [SubscriptionDoc] Where SubId=" & Me.SubID.EditValue
                Sql.SqlTrueAccountingRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0)) Then
                    With Sql.SQLDS.Tables(0).Rows(0)
                        ReferanceNo.Text = .Item("Subscriber")
                        ReferanceName.Text = .Item("SubscriberName")
                        StartDate.DateTime = CDate(.Item("EndDate")).AddDays(1)
                        'EndDate.DateTime = .Item("EndDate")
                        Amount.EditValue = .Item("Amount")
                        SubStatus.EditValue = CInt(.Item("SubStatus"))
                        SubscriptionType.EditValue = .Item("SubscriptionType")
                        VoucherNo.EditValue = .Item("VoucherNo")
                        DocCode.Text = .Item("DocCode")
                        Me.SalesPerson.EditValue = .Item("SalesPerson")
                        'If Not IsDBNull(.Item("DocNotes")) Then DocNotes.EditValue = .Item("DocNotes")
                        DocNotes.EditValue = " تجديد الاشتراك "
                        Me.TextDaysCount.Text = DateDiff(DateInterval.Day, StartDate.DateTime, EndDate.DateTime)
                        CalcSubscriptionPerdio()
                    End With
                    LayoutIssueVoucher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    VoucherNo.Text = ""
                End If
        End Select
        WriteHeader()
    End Sub



    Private Sub InsertNewData()
        Dim _DocCode As String = CreateRandomCode()
        Me.DocCode.Text = _DocCode
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " INSERT INTO [dbo].[SubscriptionDoc]
           ([Subscriber]
           ,[SubscriberName]
           ,[StartDate]
           ,[EndDate]
           ,[Amount]
           ,[SubStatus]
           ,[DocNotes]
           ,[SubscriptionType]
           ,DocCode,RelatedVoucherCode,[SalesPerson],[DocStatus])
     VALUES
           (" & ReferanceNo.EditValue & "
           , N'" & ReferanceName.Text & "'
           , '" & Format(StartDate.DateTime, "yyyy-MM-dd") & "'
           ,'" & Format(EndDate.DateTime, "yyyy-MM-dd") & "'
           , " & Amount.EditValue & "
           , " & 1 & "
           , N'" & DocNotes.Text & "'
           ,'" & SubscriptionType.EditValue & "'
           ,'" & _DocCode & "'
           ,'" & _DocCode & "'
           ,'" & Me.SalesPerson.EditValue & "'
           ,1) "
        If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
            CreateUpdateVoucher()
            XtraMessageBox.Show("تم حفظ السند")
            CreateDocLog("Document", Me.DocCode.Text, 99, Me.SubID.EditValue, "Insert", LabelFormName.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"))
            SendSubscriptionMessage()
            Me.Dispose()
        End If
    End Sub
    Private Sub UpdateData()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _DocStatus As Integer
        If Me.TextNewOld.Text = "ReSub" Then
            _DocStatus = 2
            SqlString = " UPDATE [dbo].[SubscriptionDoc]
                           SET  [SubStatus] = " & _DocStatus & ", [DocNotes]=N' تم تجديد الاشتراك ' 
                           WHERE SubID=" & SubID.EditValue
        Else
            _DocStatus = SubStatus.EditValue

            SqlString = " UPDATE [dbo].[SubscriptionDoc]
                      SET [Subscriber] = " & ReferanceNo.EditValue & "
                          ,[SubscriberName] = N'" & ReferanceName.Text & "'
                          ,[StartDate] = '" & Format(StartDate.DateTime, "yyyy-MM-dd") & "'
                          ,[EndDate] = '" & Format(EndDate.DateTime, "yyyy-MM-dd") & "'
                          ,[Amount] =  " & Amount.EditValue & "
                          ,[SubStatus] = " & _DocStatus & "
                          ,[DocNotes] = N'" & DocNotes.Text & "'
                          ,[SubscriptionType] = " & SubscriptionType.EditValue & "
                          ,[SalesPerson] = " & Me.SalesPerson.EditValue & "
                      WHERE SubID=" & SubID.EditValue
        End If
        If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then


            If Me.TextNewOld.Text <> "ReSub" Then
                CreateUpdateVoucher()
                CreateDocLog("Document", Me.DocCode.Text, 99, Me.SubID.EditValue, "Update", " تعديل " & LabelFormName.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                XtraMessageBox.Show("تم حفظ السند")
                Me.Dispose()
            Else
                CreateDocLog("Document", Me.DocCode.Text, 99, Me.SubID.EditValue, "Update", LabelFormName.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"))
            End If


        End If
    End Sub

    Private Sub WriteHeader()
        Select Case TextNewOld.Text
            Case "ReSub"
                Try
                    Dim _HeaderString As String
                    _HeaderString = " تجديد سند  اشتراك  "
                    If Not String.IsNullOrEmpty(ReferanceName.Text) Then
                        _HeaderString += "(" & ReferanceName.Text & ")"
                    End If
                    _HeaderString += " رقم :  " & SubID.Text
                    LabelFormName.Text = _HeaderString
                Catch ex As Exception

                End Try
            Case "New"
                Try
                    Dim _HeaderString As String
                    _HeaderString = " سند اشتراك جديد  "
                    If Not String.IsNullOrEmpty(ReferanceName.Text) Then
                        _HeaderString += "(" & ReferanceName.Text & ")"
                    End If
                    _HeaderString += " رقم :  " & SubID.Text
                    LabelFormName.Text = _HeaderString
                Catch ex As Exception

                End Try
            Case Else
                Try
                    Dim _HeaderString As String
                    _HeaderString = " سند اشتراك  "
                    If Not String.IsNullOrEmpty(ReferanceName.Text) Then
                        _HeaderString += "(" & ReferanceName.Text & ")"
                    End If
                    _HeaderString += " رقم :  " & SubID.Text
                    LabelFormName.Text = _HeaderString
                Catch ex As Exception

                End Try
        End Select

    End Sub

    Private Sub SubscriptionType_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SubscriptionType.Properties.AddNewValue

    End Sub

    Private Sub StartDate_EditValueChanged(sender As Object, e As EventArgs) Handles StartDate.EditValueChanged
        CalcSubscriptionPerdio()
    End Sub
    Private Sub CalcSubscriptionPerdio()
        ' If Me.IsHandleCreated Then
        Try
            If StartDate.DateTime.ToString("yyyy-MM-dd") = "0001-01-01" Then Exit Sub
            If IsNothing(SubscriptionType.EditValue) Then Exit Sub
            TextDaysCount.BackColor = DefaultBackColor
            Dim _ItemData = GetItemsData(SubscriptionType.EditValue, False)
            Select Case _ItemData.PeriodType
                Case "شهر"
                    EndDate.DateTime = StartDate.DateTime.AddMonths(CDec(_ItemData.PeriodCount))
                Case "سنة"
                    EndDate.DateTime = StartDate.DateTime.AddYears(CDec(_ItemData.PeriodCount))
            End Select
            TextDaysCount.EditValue = DateDiff(DateInterval.Day, StartDate.DateTime, EndDate.DateTime)
        Catch ex As Exception

        End Try
        ' End If
    End Sub

    Private Sub EndDate_EditValueChanged(sender As Object, e As EventArgs) Handles EndDate.EditValueChanged
        CalcSubscriptionPerdio()
    End Sub

    Private Sub SubscriptionType_EditValueChanged(sender As Object, e As EventArgs) Handles SubscriptionType.EditValueChanged
        If Me.IsHandleCreated Then
            Dim _ItemData = GetItemsData(SubscriptionType.EditValue, False)
            '   If TextNewOld.Text = "New" Then
            Amount.EditValue = _ItemData._Price1
            '  End If
            SubscriptionType.BackColor = DefaultBackColor
            If TextNewOld.Text = "New" Or TextNewOld.Text = "ReSub" Then
                Select Case _ItemData.PeriodType
                    Case "شهر"
                        EndDate.DateTime = StartDate.DateTime.AddMonths(CDec(_ItemData.PeriodCount))
                        EndDate.DateTime = EndDate.DateTime.AddDays(-1)
                    Case "سنة"
                        EndDate.DateTime = StartDate.DateTime.AddYears(CDec(_ItemData.PeriodCount))
                        EndDate.DateTime = EndDate.DateTime.AddDays(-1)
                End Select
            End If
        End If
    End Sub

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        Select Case TextNewOld.Text
            Case "New"
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select IsNull(Max(SubID),0) as MaxID From [SubscriptionDoc] "
                Sql.SqlTrueAccountingRunQuery(SqlString)
                SubID.Text = Sql.SQLDS.Tables(0).Rows(0).Item("MaxID") + 1
                SubStatus.EditValue = 1
                '  StartDate.DateTime = Today
                EndDate.DateTime = Today
                GetLastStartDate()
                HyperlinkLabelVoucherNo.Text = "لا يوجد فاتورة "
                'MsgBox(WindowsUIButtonPanel1.Buttons.Item(4).Properties.Tag)
                WindowsUIButtonPanel1.Buttons.Item(4).Properties.Enabled = False
                'Me.TextOpenFor.Text = "NewSub"
                '   WindowsUIButtonPanel1.Buttons.Item("Delete").Properties.Enabled = False
        End Select
    End Sub
    Private Sub GetLastStartDate()
        If ReferanceNo.Text = "" Then Exit Sub
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = " Select DateStart from Referencess where [RefNo]= " & ReferanceNo.Text
            sql.SqlTrueTimeRunQuery(sqlString)
            If sql.SQLDS.Tables(0).Rows(0).Item("DateStart") = "1900-01-01" Then
                StartDate.DateTime = Today()
            Else
                StartDate.DateTime = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DateStart"))
            End If
        Catch ex As Exception
            StartDate.DateTime = Today()
        End Try
    End Sub


    Private Sub CreateUpdateVoucher()
        If _ConnectWithVoucher = True Then
            Dim sql2 As New SQLControl
            sql2.SqlTrueAccountingRunQuery(" Update [dbo].[SubscriptionDoc] 
                                                    Set VoucherNo= " & Me.VoucherNo.EditValue & ", [DocStatus]= " & 2 & " 
                                                    where DocCode='" & DocCode.Text & "';
                                                    Update [dbo].[Journal] 
                                                    Set DocCode= N'" & DocCode.Text & "'
                                                    where DocName=2 And DocID='" & VoucherNo.Text & "'")


        End If
        If CheckIssueVoucherInSubscriptionsSystem.EditValue = False Then
            Exit Sub
        End If
        ' If XtraMessageBox.Show("هل تريد اصدار فاتورة ؟", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
        Dim _DebitAcc As String
        Dim _CreditAcc As String
        Dim _ReferanceID As String
        Dim _ReferanceName As String
        Dim _HasVoucher As Boolean
        If String.IsNullOrEmpty(VoucherNo.Text) Then
            _HasVoucher = False
        Else
            _HasVoucher = True
        End If
        If Me.TextNewOld.Text = "ReSub" Then
            _HasVoucher = False
        End If
        Dim _CostCenter As Integer
        _ReferanceID = Me.ReferanceNo.EditValue
        _DebitAcc = GetRefranceData(_ReferanceID).RefAccID
        _CreditAcc = GetItemsData(Me.SubscriptionType.EditValue, False).AccSales
        _CostCenter = "1"
        _ReferanceName = ReferanceName.Text
        Dim _DocNote As String
        If Me.TextNewOld.Text = "ReSub" Then
            _DocNote = DocNotes.Text & "/" & " من تاريخ: " & Me.StartDate.DateTime & " الى تاريخ " & Me.EndDate.DateTime & " /  " & SubscriptionType.Text & " / " & ReferanceName.Text
        Else
            _DocNote = DocNotes.Text & "/" & " من تاريخ: " & Me.StartDate.DateTime & " الى تاريخ " & Me.EndDate.DateTime & " /  " & SubscriptionType.Text & " / " & ReferanceName.Text
        End If

        Dim _DocID As Integer
        If String.IsNullOrEmpty(VoucherNo.Text) Then
            _DocID = GetDocNo(2, False)
            VoucherNo.EditValue = _DocID
        Else
            _DocID = VoucherNo.EditValue
        End If

        Dim Sql As New SQLControl
        Dim SqlInsertDetials As String


        Select Case _HasVoucher
            Case False
                'Insert Debit Account
                SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode,SalesPerson ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(Today, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 1 & "',
                                      '" & _CostCenter & "',
                                      '" & _DebitAcc & "',
                                      '" & "0" & "',
                                      '" & GetFinancialAccountsData(_DebitAcc).Currency & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & Amount.EditValue * 1 & "',
                                      '" & 0 & "',
                                       N'" & _DocNote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & 0 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & Amount.EditValue & "',
                                      '" & "0" & "',
                                      '" & "0" & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceNo.EditValue & "',
                                      N'" & ReferanceName.Text & "',
                                      N'" & "0" & "',
                                      '" & DocCode.Text & "',
                                      '" & SalesPerson.EditValue & "'
                                            )"
                If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                    XtraMessageBox.Show("خطا بعملية اصدار الفاتورة", "Error", MessageBoxButtons.OK)
                    DeleteFromJournalTemp(2, DocCode.Text)
                    Exit Sub
                End If
                'Insert Credit Account
                SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode,SalesPerson ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(Today, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 1 & "',
                                      '" & _CostCenter & "',
                                      '" & "0" & "',
                                      '" & _CreditAcc & "',
                                      '" & GetFinancialAccountsData(_CreditAcc).Currency & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & Amount.EditValue * 1 & "',
                                      '" & 0 & "',
                                       N'" & _DocNote & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & Me.SubscriptionType.EditValue & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & Amount.EditValue & "',
                                      '" & Amount.EditValue & "',
                                      '" & "0" & "',
                                      '" & GetDefaultWharehouse() & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceNo.EditValue & "',
                                      N'" & ReferanceName.Text & "',
                                      N'" & SubscriptionType.Text & "',
                                      '" & DocCode.Text & "',
                                      '" & SalesPerson.EditValue & "'
                                            )"
                If Sql.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                    XtraMessageBox.Show("خطا بعملية اصدار الفاتورة", "Error", MessageBoxButtons.OK)
                    DeleteFromJournalTemp(2, DocCode.Text)
                    Exit Sub
                End If

                If InsertFromTempToJournal(2, _DocID) = "True" Then
                    DeleteFromJournalTemp(2, DocCode.Text)
                    VoucherNo.EditValue = _DocID
                    Sql.SqlTrueAccountingRunQuery(" Update [dbo].[SubscriptionDoc] 
                                                    Set VoucherNo= " & _DocID & ", [DocStatus]= " & 2 & " 
                                                    where DocCode='" & DocCode.Text & "'")
                    CreateDocLog("Document", Me.DocCode.Text, 2, _DocID, "Insert", "اصدار فاتورة تابعة لسند اشتراك", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    '  XtraMessageBox.Show("تم اصدار فاتورة", "", MessageBoxButtons.OK)
                    '  PrintDoc(False)
                Else
                    XtraMessageBox.Show("خطأ: لم يتم اصدار فاتورة", "", MessageBoxButtons.OK)
                    DeleteFromJournalTemp(2, DocCode.Text)
                End If
            Case True
                Dim SqlString As String
                SqlString = "  Update [dbo].[Journal]
                           Set CredAcc='" & _CreditAcc & "',DocAmount=" & Amount.EditValue & ",
                           BaseAmount=" & Amount.EditValue & ",BaseCurrAmount=" & Amount.EditValue & ",
                           Referance ='" & ReferanceNo.EditValue & "' ,DocNotes=N'" & _DocNote & "',
                           StockID='" & Me.SubscriptionType.EditValue & "',StockPrice=" & Amount.EditValue & ",
                           ReferanceName=N'" & _ReferanceName & "',ItemName=N'" & SubscriptionType.Text & "',SalesPerson=" & Me.SalesPerson.EditValue & "
                           where DebitAcc ='0' and DocCode='" & DocCode.Text & "';
                       Update [dbo].[Journal] Set DebitAcc='" & _DebitAcc & "',DocAmount=" & Amount.EditValue & ",
                           BaseAmount=" & Amount.EditValue & ",BaseCurrAmount=" & Amount.EditValue & ",
                           Referance ='" & ReferanceNo.EditValue & "' ,DocNotes=N'" & _DocNote & "',
                           ReferanceName=N'" & _ReferanceName & "' ,SalesPerson=" & Me.SalesPerson.EditValue & "
                           where DocCode='" & DocCode.Text & "' And CredAcc='0'"
                If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                    CreateDocLog("Document", Me.DocCode.Text, 2, _DocID, "Update", "تعديل فاتورة تابعة لسند اشتراك", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                End If
        End Select







        ' End If
    End Sub

    Private Sub SubscriptionType_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles SubscriptionType.AddNewValue
        Dim _ItemNo As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT IsNull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items")
            _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
        Catch ex As Exception
            _ItemNo = 0
        End Try

        Dim F As New Items
        With F
            .ItemNo.EditValue = _ItemNo
            If .ShowDialog() = DialogResult.OK Then
                F.Type.EditValue = 1
                MsgBox("ok")
            Else
                GetTables()
            End If
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim F As New ReferancessAddNew
        With F
            ReferancessAddNew.TextRefNo.Text = GetMax() + 1
            ReferancessAddNew.TextRefName.Text = ""
            ReferancessAddNew.TextRefMobile.Text = ""
            ReferancessAddNew.TextRefPhone.Text = ""
            ReferancessAddNew.PriceCategory.EditValue = 1
            ReferancessAddNew.TextRefName.Select()
            ReferancessAddNew._AddNewOrSave = "AddNew"
            ReferancessAddNew.CheckActive.Checked = True
            ReferancessAddNew.LookRefType.EditValue = 2
            If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                GetTables()
            End If
        End With
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

    Private Sub TextVoucherNo_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub VoucherNo_EditValueChanged(sender As Object, e As EventArgs) Handles VoucherNo.EditValueChanged
        Select Case TextNewOld.Text
            Case "ReSub"
                HyperlinkLabelVoucherNo.Text = ""
            Case Else
                HyperlinkLabelVoucherNo.Text = " صدرت فاتورة مبيعات رقم :  " & VoucherNo.EditValue
        End Select


    End Sub

    Private Sub HyperlinkLabelVoucherNo_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles HyperlinkLabelVoucherNo.HyperlinkClick
        If Me.VoucherNo.Text = "" Then
            If XtraMessageBox.Show(" السند ليس له فاتورة هل تريد ربط السند بفاتورة ؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                ConnectSubWithVoucher()
            End If
        Else
            OpenDocumentsByDocCode(Me.DocCode.Text, "Journal", 2)
        End If
    End Sub
    Private Sub ConnectSubWithVoucher()

        Dim _VoucherNo As String = InputBox("ادخل رقم الفاتورة")
        If _VoucherNo = "" Then Exit Sub
        Dim _VoucherDocCode As String = GetVoucherCode(_VoucherNo)
        If _VoucherDocCode = "" Then
            MsgBoxShowError(" لا يوجد فاتورة لهذا الرقم ")
            Exit Sub
        End If

        Me.VoucherNo.Text = _VoucherNo
        _ConnectWithVoucher = True

        'Dim Sql As New SQLControl
        'Dim SqlString As String
        'SqlString = " Update [dbo].[SubscriptionDoc] Set RelatedVoucherCode='" & _VoucherDocCode & "', VoucherNo=" & _VoucherNo & " where SubID=" & SubID.EditValue
        'If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
        '    Me.VoucherNo.EditValue = _VoucherNo
        '    XtraMessageBox.Show("تم ربط الفاتورة بالسند")
        '    CreateDocLog("Document", Me.DocCode.Text, 2, Me.VoucherNo.EditValue, "Update", "ربط فاتورة بسند اشتراك", Format(Now, "yyyy-MM-dd HH:mm:ss"))
        '    LayoutIssueVoucher.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'Else
        '    MsgBoxShowError(" خطا، لم يتم ربط الفاتورة بالسند ")
        'End If
    End Sub
    Private Function GetVoucherCode(_VoucherNo As Integer) As String
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select top(1) DocCode from Journal where DocName=2 And DocID=" & _VoucherNo
        Sql.SqlTrueAccountingRunQuery(SqlString)
        If Sql.SQLDS.Tables(0).Rows.Count = 0 Then Return ""
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")) Then
            Return Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
        Else
            Return ""
        End If
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckIssueVoucherInSubscriptionsSystem_CheckedChanged(sender As Object, e As EventArgs) Handles CheckIssueVoucherInSubscriptionsSystem.CheckedChanged

    End Sub
    Private Sub DeleteSubscription()
        If SubID.Text = "" Then Exit Sub
        If XtraMessageBox.Show("هل تريد حذف السند ؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Try
                Dim sql As New SQLControl
                Dim sqlstring As String
                Dim sqldeletestring As String = ""
                Dim _voucherno As Integer
                If Me.VoucherNo.Text = "" Then
                    _voucherno = 0
                Else
                    _voucherno = VoucherNo.EditValue
                End If
                sqlstring = " delete from  [dbo].[SubscriptionDoc] where [SubID]=" & SubID.EditValue & ""
                If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                    sqldeletestring = " تم حذف الاشتراك "
                End If
                If _voucherno <> 0 Then
                    If DeleteFromJournal(2, _voucherno, Format(Now(), "yyyy-MM-dd HH:mm:ss")) = True Then
                        sqldeletestring += " وتم حذف الفاتورة أيضا "
                        CreateDocLog("Document", Me.DocCode.Text, 2, Me.VoucherNo.EditValue, "Delete", "حذف فاتورة تابعة لسند اشتراك", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                    End If
                End If
                XtraMessageBox.Show(sqldeletestring)
                CreateDocLog("Document", Me.DocCode.Text, 99, Me.SubID.EditValue, "Delete", "حذف سند اشتراك", Format(Now, "yyyy-MM-dd HH:mm:ss"))
                Me.Dispose()
            Catch ex As Exception
                XtraMessageBox.Show(" لم يتم حذف السند ")
            End Try
        End If

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        EndDate.DateTime = StartDate.DateTime.AddMonths(RadioGroup1.EditValue).AddDays(-1)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim F As New DocumentLogs
        With F
            ._DocCode = Me.DocCode.Text
            .GridControl1.DataSource = GetDocumentsLogs(Me.DocCode.Text, -1)
            .ColDeviceName.Visible = False
            .ColDocName.Visible = False
            '.ColDocID.Visible = False
            .ColUserID.Visible = False
            .ShowDialog()
        End With
    End Sub

    Private Sub SubStatus_EditValueChanged(sender As Object, e As EventArgs) Handles SubStatus.EditValueChanged

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        'If Me.VoucherNo.Text = "" Then
        '    If XtraMessageBox.Show(" السند ليس له فاتورة هل تريد ربط السند بفاتورة ؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '        ConnectSubWithVoucher()
        '    End If
        'Else
        '    If XtraMessageBox.Show(" سيتم تعديل رقم الفاتورة ، هل تريد الاستمرار ", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '        ConnectSubWithVoucher()
        '    End If
        'End If
    End Sub

    Private Sub HyperlinkLabelVoucherNo_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelVoucherNo.Click

    End Sub
End Class