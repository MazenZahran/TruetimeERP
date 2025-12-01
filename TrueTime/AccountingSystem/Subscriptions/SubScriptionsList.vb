Imports System.Data.SqlTypes
Imports System.Runtime.InteropServices.ComTypes
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen


Public Class SubScriptionsList
    Private refBalanceInReceipt As Boolean
    Private allowEditSubscription As Boolean
    Private Sub TileBar1_Click(sender As Object, e As EventArgs) Handles TileBar1.Click

    End Sub

    Private Sub SubScriptionsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GetSubscritions("TileBarActive")
        Me.GridView1.OptionsView.ShowPreview = False
        TileBar1.SelectedItem = TileBarActive
        Me.RepositoryPaidStatus.DataSource = GetDocPaidStatus(False)
        GetSettings()
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='SubscriptionWhenCreateNewReceiptSetAmountFromRefBalance' ")
            refBalanceInReceipt = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            refBalanceInReceipt = True
        End Try

        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='SubScriptions_ShowTasdeedMenueInSubScriptionsList' ")
            If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                BarSubItemTasdeed.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                BarSubItemTasdeed.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If
        Catch ex As Exception
            BarSubItemTasdeed.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End Try

        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='SubScriptions_AllowEditSubscription' ")
            allowEditSubscription = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            allowEditSubscription = True
        End Try


    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetSubscritions(TileBar1.SelectedItem.Name)
        End If
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "NewPerson"
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
                    End If
                End With
            Case "NewSubscription"
                Dim F As New NewSubScriptions
                With F
                    .TextNewOld.Text = "New"
                    If .ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    Else
                        GetSubscritions(TileBar1.SelectedItem.Name)
                    End If
                End With
            Case "Close"

                If GlobalVariables._UserAccessType = 5 Then
                    Application.Exit()
                Else
                    Me.Close()
                End If
            Case "OpenSubscription"
                If allowEditSubscription = True Then
                    Dim _SubID As Integer
                    If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SubID")) Then
                        Dim F As New NewSubScriptions
                        With F
                            .TextNewOld.Text = "Old"
                            _SubID = GridView1.GetFocusedRowCellValue("SubID")
                            .SubID.EditValue = _SubID
                            If .ShowDialog() = DialogResult.OK Then
                                MsgBox("ok")
                            Else
                                GetSubscritions(TileBar1.SelectedItem.Name)
                            End If
                        End With
                    End If
                Else
                    MsgBoxShowError(" لا يوجد صلاحية ")
                End If


            Case "OpenSubscriber"
                ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Subscriber")
                ReferancessAddNew.TextRefName.Select()
                If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
                    MsgBox("ok")
                Else
                    GetSubscritions(TileBar1.SelectedItem.Name)
                End If
            Case "Refresh"
                GetSubscritions(TileBar1.SelectedItem.Name)
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "ReSub"
                Dim _SubID As Integer
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SubID")) Then
                    Dim F As New NewSubScriptions
                    With F
                        .Text = " تجديد الاشتراك "

                        .TextNewOld.Text = "ReSub"

                        _SubID = GridView1.GetFocusedRowCellValue("SubID")
                        .SubID.EditValue = _SubID
                        ' .StartDate.DateTime = CDate(GridView1.GetFocusedRowCellValue("EndDate")).AddDays(1)
                        '.EndDate.DateTime = CDate(GridView1.GetFocusedRowCellValue("EndDate")).AddDays(1)
                        '.TextDaysCount.EditValue = 0
                        If .ShowDialog() = DialogResult.OK Then
                            MsgBox("ok")
                        Else
                            GetSubscritions(TileBar1.SelectedItem.Name)
                        End If
                    End With
                End If
            Case "FreezSub"
                Dim _SubID As Integer = 0
                Dim _SubName As String = ""
                Dim _DocCode As String = ""
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SubID")) Then
                    _SubID = GridView1.GetFocusedRowCellValue("SubID")
                    _SubName = GridView1.GetFocusedRowCellValue("SubscriberName")
                    _DocCode = GridView1.GetFocusedRowCellValue("DocCode")
                    If XtraMessageBox.Show(" هل تريد تجميد الاشتراك ؟ " & "  ( " & _SubName & " ) ", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " UPDATE [dbo].[SubscriptionDoc]
                                      SET  [SubStatus] = " & 0 & ", 
                                      [DocNotes]=N' تم تجميد الاشتراك بتاريخ    " & Format(Today, "dd/MM/yyyy") & " '
                                      WHERE SubID=" & _SubID
                        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                            MsgBox(" تم تجميد الاشتراك ")
                            GetSubscritions(TileBar1.SelectedItem.Name)
                            CreateDocLog("Document", _DocCode, 99, _SubID, "Insert", "تجميد سند اشتراك (" & " " & _SubName & ")" & " رقم: " & _SubID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        End If
                    End If
                End If

            Case "InActive"
                Dim _SubID As Integer = 0
                Dim _SubName As String = ""
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SubID")) Then
                    _SubID = GridView1.GetFocusedRowCellValue("SubID")
                    _SubName = GridView1.GetFocusedRowCellValue("SubscriberName")
                    If XtraMessageBox.Show(" هل تريد الغاء الاشتراك ؟ " & "  ( " & _SubName & " ) ", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " UPDATE [dbo].[SubscriptionDoc]
                                      SET  [SubStatus] = " & 3 & ", 
                                      [DocNotes]=N' تم الغاء الاشتراك بتاريخ    " & Format(Today, "dd/MM/yyyy") & " '
                                      WHERE SubID=" & _SubID
                        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                            MsgBox(" تم الغاء الاشتراك ")
                            GetSubscritions(TileBar1.SelectedItem.Name)
                        End If
                    End If
                End If
            Case "Rec"
                Dim _SubSubscriber As Integer = 0
                Dim _SubName As String = ""
                Dim _SubNote As String = ""
                Dim _SubAmount As Decimal = 0
                Dim _RefBalance As Decimal = 0
                Dim _FromDate As String
                Dim _ToDate As String
                Dim _SubscriptionID As Integer = 0
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("SubID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SubID")) Then
                    _SubSubscriber = GridView1.GetFocusedRowCellValue("Subscriber")
                    _SubName = GridView1.GetFocusedRowCellValue("SubscriberName")
                    If IsDBNull(GridView1.GetFocusedRowCellValue("Amount")) Then
                        _SubAmount = 0
                    Else
                        _SubAmount = GridView1.GetFocusedRowCellValue("Amount")
                    End If
                    If IsDBNull(GridView1.GetFocusedRowCellValue("Balance")) Then
                        _RefBalance = 0
                    Else
                        _RefBalance = GridView1.GetFocusedRowCellValue("Balance")
                    End If

                    _FromDate = GridView1.GetFocusedRowCellValue("StartDate")
                    _ToDate = GridView1.GetFocusedRowCellValue("EndDate")
                    _SubscriptionID = GridView1.GetFocusedRowCellValue("SubID")
                    _SubNote = " دفعة اشتراك   " & " ، " & " الفترة من  " & _FromDate & " الى " & _ToDate
                    Dim _RefData = GetRefranceData(_SubSubscriber)
                    Dim f As New PosDirectReceipt
                    With f
                        ._CostCenter = GetDefaultCostCenter(GlobalVariables.CurrUser)
                        ._ShiftID = 0
                        ._PosName = 0
                        ._DefaultCashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
                        ._InputUser = GlobalVariables.CurrUser
                        .Referance.EditValue = _SubSubscriber
                        .Referance.ReadOnly = True
                        .MemoEdit1.Text = _SubNote
                        If refBalanceInReceipt = True Then
                            .TextAmount.EditValue = _RefBalance
                            ._RequiredAmount = _RefBalance
                        Else
                            .TextAmount.EditValue = _SubAmount
                            ._RequiredAmount = _SubAmount
                        End If
                        ._SubscriptionID = _SubscriptionID
                        If .ShowDialog() <> DialogResult.OK Then
                            GetSubscritions(TileBar1.SelectedItem.Name)
                        End If
                    End With
                End If
            Case "Payment"
                Dim f As New PosPaymentDirect
                With f
                    ._CostCenter = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    ._ShiftID = 0
                    ._PosName = 0
                    ._DefaultCashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
                    ._InputUser = GlobalVariables.CurrUser
                    .ShowDialog()
                End With
        End Select
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
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
               (" " & "كشف الاشتراكات   ")

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        'Dim _FromToDate As String = " لغاية تاريخ:   " & DateEdit1.EditValue
        'TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
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

    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarActive.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarEnd.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem3.ItemClick
        Me.Close()
    End Sub
    Private Sub GetSubscritions(_Action As String)
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select * from  
(SELECT [SubID]
                      ,[Subscriber]  ,[SubscriberName]
                      ,R.RefMobile as RefMobile,RS.[SortName] as RefSort
                      ,[StartDate]          ,[EndDate],IsNull(E.EmployeeName,'') as SalesMan,IsNull(PaidStatus,0) as PaidStatus
                      ,[Amount]           
                      ,Case When (DATEDIFF(day,getdate(),EndDate )) < = 0 and [SubStatus] =1   then N'منتهي'  When (DATEDIFF(day,getdate(),EndDate ))> 0 and [SubStatus] =1 then N'فعال' when  [SubStatus] =0 then N'مجمد' when  [SubStatus] =3 then N'غير فعال'  when [SubStatus]=2 then N'تم تجديده' end as SubStatus
                      ,[DocNotes],        I.ItemName as SubscriptionName
                      ,DATEDIFF(day,StartDate,EndDate ) as DaysCount
                      ,(DATEDIFF(day,getdate(),EndDate ))  as RemainingDays,DocCode
                      , Case when DATEDIFF(day,StartDate,EndDate ) > 0 then (DATEDIFF(day,getdate(),EndDate )*100/(DATEDIFF(day,StartDate,EndDate ))) Else 0 End as RemainingPrcentage 
                       FROM    [dbo].[SubscriptionDoc] S
                       Left join [dbo].[Referencess] R on R.RefNo=S.Subscriber  
                       Left join [dbo].[Items] I on I.ItemNo=S.SubscriptionType  
                       Left Join [dbo].[RefSorts] RS on RS.ID=R.RefSort
                       Left join [dbo].[EmployeesData] E on E.EmployeeID=R.SalesMan
                       Where 1=1"
        Select Case _Action
            Case "TileBarAll"
                SqlString += " And 2=2  ) A "
                TileBarAll.Checked = True
                TileBarActive.Checked = False
                TileBarEnd.Checked = False
                TileBarFreeze.Checked = False
                ColDescription.Visible = False
            Case "TileBarActive"
                '   SqlString += " And GetDate() Between [StartDate] And [EndDate] and [SubStatus] =1  ) A"
                SqlString += " And GetDate() <= [EndDate] and [SubStatus] =1  ) A"
                TileBarAll.Checked = False
                TileBarActive.Checked = True
                TileBarEnd.Checked = False
                TileBarFreeze.Checked = False
                ColDescription.Visible = False
            Case "TileBarEnd"
                SqlString += " And GetDate() > [EndDate] and [SubStatus] =1 ) A"
                TileBarAll.Checked = False
                TileBarActive.Checked = False
                TileBarEnd.Checked = True
                TileBarFreeze.Checked = False
                ColDescription.Visible = False
            Case "TileBarFreeze"
                SqlString += " And [SubStatus]=0 ) A "
                TileBarAll.Checked = False
                TileBarActive.Checked = False
                TileBarEnd.Checked = False
                TileBarFreeze.Checked = True
                ColDescription.Visible = False
            Case "TileBarInActive"
                SqlString += " And ([SubStatus]=3 or [SubStatus]=2 ) ) A "
                TileBarAll.Checked = False
                TileBarActive.Checked = False
                TileBarEnd.Checked = False
                TileBarFreeze.Checked = True
                ColDescription.Visible = False
        End Select

        SqlString += " Left Join 
					  (Select J.Referance as AccNo ,
					  CONVERT(DECIMAL(16,2), SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0 End )- SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0 End ) )   Balance 
					  from journal J 
					  left join Referencess R on R.RefNo=J.Referance 
					  where j.DocStatus<>0  AND  (j.DebitAcc= R.RefAccID or j.CredAcc= R.RefAccID)      
					  Group by Referance) B
                      On A.Subscriber=B.AccNo"

        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)

        SqlString = " SELECT Count([SubID]) As AllSub From [dbo].[SubscriptionDoc];
                      SELECT Count([SubID]) As Active From [dbo].[SubscriptionDoc] Where [SubStatus] = 1 And GetDate() <= [EndDate] and [SubStatus] =1 ;
                      SELECT Count([SubID]) As NotActive From [dbo].[SubscriptionDoc] Where  GetDate() > [EndDate] and  [SubStatus] = 1  ;
                      SELECT Count([SubID]) As Freezed From [dbo].[SubscriptionDoc] Where [SubStatus]=0 ;
                      SELECT Count([SubID]) As InActive From [dbo].[SubscriptionDoc] Where [SubStatus]=3 or [SubStatus]=2 ;"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Me.TileBarAll.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("AllSub")
        Me.TileBarActive.Elements(1).Text = Sql.SQLDS.Tables(1).Rows(0).Item("Active")
        Me.TileBarEnd.Elements(1).Text = Sql.SQLDS.Tables(2).Rows(0).Item("NotActive")
        Me.TileBarFreeze.Elements(1).Text = Sql.SQLDS.Tables(3).Rows(0).Item("Freezed")
        Me.TileBarInActive.Elements(1).Text = Sql.SQLDS.Tables(4).Rows(0).Item("InActive")

        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False
        WindowsUIButtonPanel1.Buttons.Item(1).Properties.Visible = False

        GridView1.BestFitColumns()
    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarAll.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarFreeze.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem1_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarInActive.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub
    'RepositoryItemHyperLinkEdit1
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "SubStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("SubStatus"))
            If category = "غير فعال" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  غير فعال  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "فعال" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مجمد" Then
                e.DisplayText = "<backcolor=@Primary><b><color=255, 255, 255>  مجمد  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "منتهي" Then
                e.DisplayText = "<backcolor=@WarningFill><b><color=255, 255, 255>  منتهي  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "تم تجديده" Then
                e.DisplayText = "<backcolor=@QuestionFill><b><color=255, 255, 255>  تم تجديده  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        If e.Column.FieldName = "PaidStatus" Then
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
        End If

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShowSelectColumn.ItemClick
        GetSubscritions("TileBarEnd")
        If GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect Then
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            GridView1.OptionsSelection.MultiSelect = False
            WindowsUIButtonPanel1.Visible = True
            BarButtonItemShowSelectColumn.Caption = " اظهار عمود التحديد "
        Else
            GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
            GridView1.OptionsSelection.MultiSelect = True
            WindowsUIButtonPanel1.Visible = False
            BarButtonItemShowSelectColumn.Caption = " اخفاء عمود التحديد "
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
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
            Dim _DocAmount As Decimal = 0
            Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
            Dim _RemainingDays As Integer
            Dim _OrigionalSMSMessage, _SMSMessage As String
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=11")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "Subscriber")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "SubscriberName")
                            _RemainingDays = .GetRowCellValue(i, "RemainingDays")

                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#RemainingDays#", _RemainingDays)



                            'SendSMSMessage(_RefMobile, _SMSMessage, 4, _BulkNo)
                            '  SMSSendMessageToWaitList(4, _SMSMessage, "Pending", _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 11
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

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Select Case Me.GridView1.OptionsView.ShowPreview
            Case True
                Me.GridView1.OptionsView.ShowPreview = False
                BarButtonItem3.Caption = " اظهار سطر الملاحظات "
            Case False
                Me.GridView1.OptionsView.ShowPreview = True
                BarButtonItem3.Caption = " اخفاء سطر الملاحظات "
        End Select
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
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
            Dim _DocAmount As Decimal = 0
            Dim _RefBalance As Decimal = 0
            Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
            Dim _OrigionalSMSMessage, _SMSMessage As String
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=12")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "Subscriber")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "SubscriberName")
                            _RefBalance = GetReferanceBalance(_ReferanceNo)

                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)




                            'SendSMSMessage(_RefMobile, _SMSMessage, 4, _BulkNo)
                            '  SMSSendMessageToWaitList(4, _SMSMessage, "Pending", _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 12
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

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim sql As New SQLControl
        Dim _SubscriptionID As Integer = GridView1.GetFocusedRowCellValue("SubID")
        sql.SqlTrueAccountingRunQuery(" Update [dbo].[SubscriptionDoc] Set  [PaidStatus] =2 Where [SubID]=" & _SubscriptionID)
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim sql As New SQLControl
        Dim _SubscriptionID As Integer = GridView1.GetFocusedRowCellValue("SubID")
        sql.SqlTrueAccountingRunQuery(" Update [dbo].[SubscriptionDoc] Set  [PaidStatus] =0 Where [SubID]=" & _SubscriptionID)
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim sql As New SQLControl
        Dim _SubscriptionID As Integer = GridView1.GetFocusedRowCellValue("SubID")
        sql.SqlTrueAccountingRunQuery(" Update [dbo].[SubscriptionDoc] Set  [PaidStatus] =1 Where [SubID]=" & _SubscriptionID)
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If


        Dim pen = gw.PaintAppearance.HorzLine.GetBackPen(e.Cache)
        Dim startPoint = New Point(e.Bounds.Location.X, e.Bounds.Bottom - CInt(pen.Width))
        Dim endPoint = New Point(e.Bounds.Right, e.Bounds.Bottom - CInt(pen.Width))
        e.DefaultDraw()
        e.Cache.DrawLine(pen, startPoint, endPoint)
        e.Handled = True

    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        SubscriptionsExtendPeriodDays.ShowDialog()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim F As New DocumentLogs
        With F
            ._DocCode = "--1"
            .GridControl1.DataSource = GetDocumentsLogs("--1", 99)
            .ColDeviceName.Visible = False
            .ColDocName.Visible = False
            '.ColDocID.Visible = False
            .ColUserID.Visible = False
            .ShowDialog()
        End With
    End Sub
End Class