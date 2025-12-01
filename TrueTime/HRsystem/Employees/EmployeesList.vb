Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class EmployeesList
    Dim WithImages As Boolean
    Private Sub TileBar1_Click(sender As Object, e As EventArgs) Handles TileBar1.Click

    End Sub

    Private Sub SubScriptionsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GetEmplStatusTable()
        GetSubscritions("TileBarActive")
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
                Dim F As New EmployeesEdit
                With F
                    ._New = True
                    '.ClearingEditEmployeeForm()
                    .TextOpenFrom.Text = "EmployeesList"
                    If .ShowDialog() <> DialogResult.OK Then
                        GetSubscritions(TileBar1.SelectedItem.Name)
                    End If
                End With
            Case "NewSubscription"

            Case "Close"
                Me.Close()
            Case "OpenSubscription"


            Case "OpenSubscriber"
                My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
                My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
                My.Forms.EmployeesEdit.TextOpenFrom.Text = "EmployeesList"
                If EmployeesEdit.ShowDialog() <> DialogResult.OK Then
                    GetSubscritions(TileBar1.SelectedItem.Name)
                End If
            Case "Refresh"
                GetSubscritions(TileBar1.SelectedItem.Name)
            Case "out"
                If TileBar1.SelectedItem.Name = "TileBarEnd" Then
                    XtraMessageBox.Show("الموظف باجازة، لا يمكن انهاء عمله")
                    Exit Sub
                End If
                If GridView1.GetFocusedRowCellValue("EmplStatus") = "NotActive" Then
                    XtraMessageBox.Show("الموظف غير فعال، لا يمكن انهاء خدماته")
                    Exit Sub
                End If
                If GridView1.GetFocusedRowCellValue("EmplStatus") = "Invocation" Then
                    XtraMessageBox.Show("الموظف مجاز، لا يمكن انهاء خدماته")
                    Exit Sub
                End If

                Dim _SubID As Integer
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("EmployeeID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("EmployeeID")) Then
                    Dim F As New EmployeeOut
                    With F
                        _SubID = GridView1.GetFocusedRowCellValue("EmployeeID")
                        .EmployeeIDTextEdit.EditValue = _SubID
                        .LabelControl8.Text = " مضى على بداية العمل :  " & " " & GridView1.GetFocusedRowCellValue("PeriodFromStart")
                        If .ShowDialog() <> DialogResult.OK Then
                            GetSubscritions(TileBar1.SelectedItem.Name)
                        End If
                    End With
                End If
            Case "NewVocation"
                Try
                    If TileBar1.SelectedItem.Name = "TileBarEnd" Then
                        Exit Sub
                    End If
                    If GridView1.GetFocusedRowCellValue("EmplStatus") = "NotActive" Then
                        XtraMessageBox.Show("الموظف غير فعال، لا يمكن عمل اجازة ")
                        Exit Sub
                    End If
                    If GridView1.GetFocusedRowCellValue("EmplStatus") = "Invocation" Then
                        XtraMessageBox.Show("الموظف مجاز، لا يمكن عمل اجازة")
                        Exit Sub
                    End If
                    'My.Forms.AddVocation.TextNewOrOld.Text = "Old"
                    'My.Forms.AddVocation.LookUpEditEmployees.EditValue = GridView1.GetFocusedRowCellValue("EmployeeID")
                    'My.Forms.AddVocation.DateEditTo.DateTime = Today
                    'My.Forms.AddVocation.DateEditFrom.DateTime = Today
                    'My.Forms.AddVocation.TextVocationDate.DateTime = Today
                    'AddVocation.TextID.EditValue = GetMaxVocationID() + 1
                    'AddVocation.TextNewOrOld.EditValue = -1
                    'AddVocation.LookUpEditVocations.EditValue = 1
                    'AddVocation.LookVocationSource.EditValue = "vocation"
                    'My.Forms.AddVocation.MemoDetails.Select()
                    'If AddVocation.ShowDialog() <> DialogResult.OK Then
                    '    GetSubscritions(TileBar1.SelectedItem.Name)
                    'End If
                    Dim f As New AddVocation
                    With f
                        .Show()
                        .TextNewOrOld.Text = "New"
                        .LookUpEditEmployees.EditValue = GridView1.GetFocusedRowCellValue("EmployeeID")
                        .DateEditFrom.DateTime = Today
                        .DateEditTo.DateTime = Today
                        .TextDayNo.EditValue = 1
                        .MemoDetails.Select()
                        'If AddVocation.ShowDialog() <> DialogResult.OK Then
                        '    GetSubscritions(TileBar1.SelectedItem.Name)
                        'End If
                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "Copy"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.SelectAll()
                GridView1.CopyToClipboard()
                GridView1.OptionsSelection.MultiSelect = False
        End Select
    End Sub


    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarActive.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarEnd.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem3.ItemClick
        WithImages = True
        GetSubscritions(TileBar1.SelectedItem.Name)
        GridControl1.MainView = TileView1

    End Sub
    Private Sub GetSubscritions(_Action As String)
        Try
            Dim focusedRow As Integer = GridView1.FocusedRowHandle

            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "   Declare @Temp as DECIMAL(18,2)
                        Set @Temp=(Select top(1)  DATEDIFF(day,E.DateOfStart,getdate() ) as RemainingPrcentage  from  [dbo].[EmployeesData] E where Active=1  )
                        Select PictureEmp,EmployeeID,Birthday,EmployeeName,RefMobile,Mobile2,PhoneNo,Indenty,ManagerName,JobName,Department,Branch,EmployeeType,DateOfStart,DateOfEnd,RemainingPrcentage,
                               Convert(nvarchar(50) ,PeriodYear)+Convert(nvarchar(50) ,N'سنة ')+Convert(nvarchar(50) ,N'و ') +Convert(nvarchar(50) ,PeriodMonth)  +Convert(nvarchar(50) ,N'شهر ') As PeriodFromStart,
                               Active,Case When InVocation is null then 1 else 0 end as InVocation,IsNull(A.SectionName,'') as SectionName,
                               Case when Active=0 then 'NotActive'  when Active=1 and InVocation is null then 'Active' when Active=1 and InVocation Is Not  Null then 'Invocation' end as EmplStatus,HasWebPass 
                        From 
                        (SELECT E.[EmployeeID],
                                E.[EmployeeName] ,S.SectionName ,E.[Mobile1] as RefMobile,E.Mobile2,E.PhoneNo,E.Indenty,E.Birthday,E.Address,M.EmployeeName as ManagerName,
                                E.JobName,E.[Department],E.[Branch],T.EmployeesType As EmployeeType,E.DateOfStart,E.DateOfEnd,E.[Active], 
                                Case When E.DateOfStart <> '1900-01-01' then (DATEDIFF(yy, E.DateOfStart, GETDATE()) - CASE WHEN (MONTH(E.DateOfStart) > MONTH(GETDATE())) OR (MONTH(E.DateOfStart) = MONTH(GETDATE()) AND DAY(E.DateOfStart) > DAY(GETDATE())) THEN 1 ELSE 0 END) Else '0' End as PeriodYear,
		                        Case When E.DateOfStart <> '1900-01-01' then DATEDIFF(m, DATEADD(yy, (DATEDIFF(yy, E.DateOfStart, GETDATE()) - CASE WHEN (MONTH(E.DateOfStart) > MONTH(GETDATE())) OR (MONTH(E.DateOfStart) = MONTH(GETDATE()) AND DAY(E.DateOfStart) > DAY(GETDATE())) THEN 1 ELSE 0 END), E.DateOfStart), GETDATE()) - CASE WHEN DAY(E.DateOfStart) > DAY(GETDATE()) THEN 1 ELSE 0 END else 0 end  As PeriodMonth, 
                                Case When E.DateOfStart <> '1900-01-01' then  case when @Temp > 1 then CAST(DATEDIFF(day,E.DateOfStart,getdate())* 100/@Temp  AS DECIMAL(18,2)) end else 0 end as RemainingPrcentage,Case when E.[WebPassEnc] Is Null Then 'False' else 'True' end as HasWebPass "
            If WithImages = True Then SqlString += ",E.PictureEmp " Else SqlString += ",'' As PictureEmp "
            SqlString += "  FROM [dbo].[EmployeesData] E 
                        Left join [dbo].[EmployeesTypes] T on E.EmployeeType=T.[ID] 
                        Left join EmployeesData M on E.ManagerID=M.EmployeeID Left Join EmployeesSections S on E.SectionsID=S.ID  where E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888  )  A

                        Left join 

                        (select EmployeeID as InVocation from Vocations where getdate() between FromDate and  DATEADD(hour,23,cast(cast(ToDate as date) as datetime))) B
                        On A.EmployeeID=B.InVocation "



            Select Case _Action
                Case "TileBarAll"
                    SqlString += " Where  2=2  "
                    TileBarAll.Checked = True
                    TileBarActive.Checked = False
                    TileBarEnd.Checked = False
                    TileBarFreeze.Checked = False
                Case "TileBarActive"
                    SqlString += "  where Active=1"
                    TileBarAll.Checked = False
                    TileBarActive.Checked = True
                    TileBarEnd.Checked = False
                    TileBarFreeze.Checked = False
                Case "TileBarFreeze"
                    SqlString += "  where  Active=0 "
                    TileBarAll.Checked = False
                    TileBarActive.Checked = False
                    TileBarEnd.Checked = False
                    TileBarFreeze.Checked = True
                Case "TileBarEnd"
                    SqlString += " where  Active=1 and InVocation Is Not  Null "
                    TileBarAll.Checked = False
                    TileBarActive.Checked = False
                    TileBarEnd.Checked = True
                    TileBarFreeze.Checked = False
            End Select
            SqlString += " Order By EmployeeID"
            Sql.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
            GridView1.FocusedRowHandle = focusedRow

            SqlString = " SELECT Count([EmployeeID]) As AllSub From [dbo].[EmployeesData] E where E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888;
                          SELECT Count([EmployeeID]) As Active From [dbo].[EmployeesData] E Where Active=1 and E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888;
                          SELECT Count([EmployeeID]) As NotActive From [dbo].[EmployeesData] E Where Active=0 and E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 ;
                          SELECT Count(EmployeeID)   As Invocation From  Vocations  where getdate() between FromDate and  DATEADD(hour,23,cast(cast(ToDate as date) as datetime)) ;"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Me.TileBarAll.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("AllSub")
            Me.TileBarActive.Elements(1).Text = Sql.SQLDS.Tables(1).Rows(0).Item("Active")
            Me.TileBarFreeze.Elements(1).Text = Sql.SQLDS.Tables(2).Rows(0).Item("NotActive")
            Me.TileBarEnd.Elements(1).Text = Sql.SQLDS.Tables(3).Rows(0).Item("Invocation")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarAll.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarFreeze.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub
    Private Sub GetEmplStatusTable()
        ' Create new DataTable instance.
        Dim table As New DataTable

        ' Create 3 typed columns in the DataTable.
        table.Columns.Add("EmplStatus", GetType(String))
        table.Columns.Add("ArStatus", GetType(String))
        table.Columns.Add("EnStatus", GetType(String))

        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add("Active", "فعال", "Active")
        table.Rows.Add("NotActive", "غير فعال", "NotActive")
        table.Rows.Add("Invocation", "مجاز", "Invocation")

        RepositoryEmplStatus.DataSource = table
    End Sub

    Private Sub TileBarItem1_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem1.ItemClick
        WithImages = False
        GridControl1.MainView = GridView1
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Const _Active As String = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
        Const _UnActive As String = "<backcolor=@Danger><b><color=255, 255, 255>  غير فعال  </b>"
        Const _InVocation As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  مجاز  </b>"
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "EmplStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EmplStatus"))
            If category = "فعال" Then
                e.DisplayText = String.Format(_Active)
            ElseIf category = "غير فعال" Then
                e.DisplayText = String.Format(_UnActive)
            ElseIf category = "مجاز" Then
                e.DisplayText = String.Format(_InVocation)
            End If
        End If
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub RepositoryItemHyperLinkEmployee_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEmployee.OpenLink
        'My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
        'My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
        'If EmployeesEdit.ShowDialog() = DialogResult.OK Then
        '    MsgBox("ok")
        'Else
        '    GetSubscritions("TileBarActive")
        'End If

        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Dim F As New EmployeesEdit
        F.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
        F.EmployeeNameTextEdit.Select()
        Dim child As Form = Nothing
        If child Is Nothing Then
            child = F
            child.MdiParent = My.Forms.Main
            child.Show()
        Else
            child.Activate()
        End If
        CloseProgressPanel(handle)
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
        My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
        If EmployeesEdit.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetSubscritions("TileBarActive")
        End If
    End Sub

    Private Sub RepositorySendWatsAppMessage_Click(sender As Object, e As EventArgs) Handles RepositorySendWatsAppMessage.Click

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
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

            Dim _WebSite As String
            Try
                sql.SqlTrueAccountingRunQuery("   select top(1) IsNull(CompanyWebSite,0) as [CompanyWebSite] from [dbo].[CompanyData]  ")
                _WebSite = sql.SQLDS.Tables(0).Rows(0).Item("CompanyWebSite")
            Catch ex As Exception
                _WebSite = 0
            End Try

            Dim J As Integer
            J = 1
            Dim _EmployeeID As String
            Dim _Mobile, _Name As String
            Dim _OrigionalSMSMessage, _SMSMessage As String


            _OrigionalSMSMessage = GlobalVariables._ReferancesMessage
            If _OrigionalSMSMessage = "-1" Then
                MsgBoxShowError(" تم الغاء العملية ")
                Exit Sub
            End If
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _EmployeeID = .GetRowCellValue(i, "EmployeeID")
                        If Not String.IsNullOrEmpty(_EmployeeID) Then
                            Dim _EmpData = GetEmployeeData(_EmployeeID)
                            _Mobile = _EmpData.Mobile
                            _Name = .GetRowCellValue(i, "EmployeeName")

                            Dim newLine As String = "\n" ' Use literal newline
                            _SMSMessage = _Name & newLine
                            _SMSMessage += " نرجو من حضرتكم الدخول على الرابط التالي لتفعيل الخدمة الذاتية " & newLine
                            _SMSMessage += _WebSite & newLine
                            _SMSMessage += " واستخدام الرقم الوظيفي "
                            _SMSMessage += " ( " & _EmployeeID & " ) " & newLine
                            _SMSMessage += "  وعمل اعادة ضبط لكلمة المرور "

                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 9
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _EmployeeID
                            dr("RefMobile") = _Mobile
                            dr("RefName") = _Name
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
End Class