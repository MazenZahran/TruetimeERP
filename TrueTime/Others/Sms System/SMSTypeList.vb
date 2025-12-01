Imports DevExpress.Utils.VisualEffects
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class SMSTypeList
    Dim WithImages As Boolean
    Private Sub TileBar1_Click(sender As Object, e As EventArgs) Handles TileBar1.Click

    End Sub

    Private Sub SubScriptionsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CreateSmsStatusTable()
        CreateSmsTypeStatusTable()
        RefreshData("SmsTypes")
        Me.NavigationPane1.SelectedPage = NavigationPage1
        '   RepositorySmsStatus.DataSource = CreateSmsStatusTable()
        'Dim b As Badge = New Badge()
        'b.TargetElement = TileBarSmSTypes
        'b.Properties.Text = 10
        'b.Visible = True
        'adornerUIManager1.Elements.Add(b)
    End Sub
    Private Sub CreateSmsStatusTable()
        ' Create new DataTable instance.
        Dim table As New DataTable
        ' Create 3 typed columns in the DataTable.
        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Sent", GetType(String))
        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add("0", "Pending")
        table.Rows.Add("1", "Sent")
        RepositoryItemLookUpStatus.DataSource = table
        RepositoryItemLookSmsStatus2.DataSource = table
    End Sub
    Private Sub CreateSmsTypeStatusTable()
        ' Create new DataTable instance.
        Dim table As New DataTable
        ' Create 3 typed columns in the DataTable.
        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Active", GetType(String))
        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add("1", "Active")
        table.Rows.Add("0", "Unactive")
        RepositorySmsStatus.DataSource = table
    End Sub
    Private Sub CreateMessageStatusTable()
        ' Create new DataTable instance.
        Dim table As New DataTable
        ' Create 3 typed columns in the DataTable.
        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Status", GetType(String))
        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add("0", "فعال")
        table.Rows.Add("1", "موقوف")
        ' RepositoryItemLookUpStatus.DataSource = table
        '  RepositoryItemLookSmsStatus2.DataSource = table
    End Sub
    Private Sub WindowsUIButtonPanel2_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel2.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "BuildMessage"
                Dim F As New BuildMessages
                With F
                    .SearchIMessagesTypes.EditValue = GridView1.GetFocusedRowCellValue("ID")
                    If .ShowDialog <> DialogResult.OK Then
                        RefreshData("SmsTypes")
                    End If
                End With
            Case "Close"
                Me.Close()
            Case "Refresh"
                RefreshData("SmsTypes")
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "Copy"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.SelectAll()
                GridView1.CopyToClipboard()
                GridView1.OptionsSelection.MultiSelect = False
        End Select
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Close"
                Me.Close()
            Case "Refresh"
                RefreshData("SentSms")
            Case "Print"
                GridControl2.ShowPrintPreview()
            Case "Copy"
                GridView2.OptionsSelection.MultiSelect = True
                GridView2.SelectAll()
                GridView2.CopyToClipboard()
                GridView2.OptionsSelection.MultiSelect = False
        End Select
    End Sub
    Private Sub WindowsUIButtonPanel3_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel3.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "SendSMS"
                SendPendingMessages()
            Case "AddSms"
                Dim f As New SmsSendSingle
                With f
                    If .ShowDialog <> DialogResult.OK Then
                        RefreshData("PendingSms")
                    End If
                End With
            Case "Close"
                Me.Close()
            Case "Refresh"
                RefreshData("PendingSms")
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "Copy"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.SelectAll()
                GridView1.CopyToClipboard()
                GridView1.OptionsSelection.MultiSelect = False
        End Select
    End Sub


    Private Sub RefreshData(_Action As String)
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim sql As New SQLControl
        Dim sqlstring As String
        Select Case _Action
            Case "SmsTypes"

                sqlstring = "  SELECT  [ID] ,[SMSName] ,[SMSMessage] ,[SMSFields], '1' As [Active]  FROM [dbo].[Messages] order by ID  "
                sql.SqlTrueAccountingRunQuery(sqlstring)
                GridControl1.DataSource = sql.SQLDS.Tables(0)
                GridView1.BestFitColumns()
            Case "SentSms"
                sqlstring = "  select SMSType,S.ID, M.SMSName, SMSDetails,SMSDatetime,SMSUser,
                              SMSStatus,BulkNo,RefMobile,RefNo,RefName,AccrualDateTime,DocName,DocID,DocCode,DocData,
                              [Sent] 
                       from SmsSentMessages  S 
                       left join Messages M on S.SMSType=M.ID order by S.ID desc  "
                sql.SqlTrueAccountingRunQuery(sqlstring)
                GridControl2.DataSource = sql.SQLDS.Tables(0)
            Case "PendingSms"
                sqlstring = "  select SMSType,S.ID as SmsID, M.SMSName, SMSDetails,SMSUser,
                              SMSStatus,BulkNo,RefMobile,RefNo,RefName,AccrualDateTime,DocName,DocID,DocCode,DocData,
                              [Sent] 
                       from SmsPendingMessages  S 
                       left join Messages M on S.SMSType=M.ID 
                       Where [Sent]=0 order by S.ID desc"
                sql.SqlTrueAccountingRunQuery(sqlstring)
                GridControl3.DataSource = sql.SQLDS.Tables(0)
        End Select

        sqlstring = " SELECT Count([ID]) As SmsTypeCount From [dbo].[Messages];
                      SELECT Count([ID]) As SmsSentCount From [dbo].[SmsSentMessages];
                      SELECT Count([ID]) As SmsPendingMessages From [dbo].[SmsPendingMessages]"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.TileBarSmSTypes.Elements(1).Text = sql.SQLDS.Tables(0).Rows(0).Item("SmsTypeCount")
        Me.TileBarItemSmsSent.Elements(1).Text = sql.SQLDS.Tables(1).Rows(0).Item("SmsSentCount")
        Me.TileBarItemSmsPending.Elements(1).Text = sql.SQLDS.Tables(2).Rows(0).Item("SmsPendingMessages")


        GridView1.BestFitColumns()
        GridView1.FocusedRowHandle = focusedRow

    End Sub
    'Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
    '    Const _Active As String = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
    '    Const _UnActive As String = "<backcolor=@Danger><b><color=255, 255, 255>  غير فعال  </b>"
    '    Dim View As GridView = CType(sender, GridView)
    '    If e.Column.FieldName = "EmplStatus" Then
    '        Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EmplStatus"))
    '        If category = "فعال" Then
    '            e.DisplayText = String.Format(_Active)
    '        ElseIf category = "غير فعال" Then
    '            e.DisplayText = String.Format(_UnActive)
    '        End If
    '    End If
    'End Sub
    Private Sub GridView2_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell, GridViewPendingMessages.CustomDrawCell
        Const _Sent As String = "<backcolor=@Success><b><color=255, 255, 255>  Sent  </b>"
        Const _Pending As String = "<backcolor=@Danger><b><color=255, 255, 255>  Pending  </b>"
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "Sent" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Sent"))
            If category = "Sent" Then
                e.DisplayText = String.Format(_Sent)
            ElseIf category = "Pending" Then
                e.DisplayText = String.Format(_Pending)
            End If
        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Const _Sent As String = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
        Const _Pending As String = "<backcolor=@Danger><b><color=255, 255, 255>  موقوف  </b>"
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "Active" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Active"))
            If category = "Active" Then
                e.DisplayText = String.Format(_Sent)
            ElseIf category = "Unactive" Then
                e.DisplayText = String.Format(_Pending)
            End If
        End If
    End Sub

    Private Sub TileBarSmSTypes_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBarSmSTypes.ItemClick
        Me.NavigationPane1.SelectedPage = NavigationPage1
        RefreshData("SmsTypes")
    End Sub

    Private Sub TileBarItem1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBarItemSmsSent.ItemClick
        Me.NavigationPane1.SelectedPage = NavigationPage2
        RefreshData("SentSms")
    End Sub
    Private Sub TileBarItem2_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBarItemSmsPending.ItemClick
        Me.NavigationPane1.SelectedPage = NavigationPage3
        RefreshData("PendingSms")
    End Sub
    Private Sub SendPendingMessages()
        Try
            If GridViewPendingMessages.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridViewPendingMessages.SelectedRowsCount = 0 And GridViewPendingMessages.RowCount > 0 Then
                XtraMessageBox.Show("لم يتم اختيار رسائل من القائمة")
                Exit Sub
            End If


            'If XtraMessageBox.Show(" هل تريد ارسال رسائل الى  " & GridViewPendingMessages.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            '    Exit Sub
            'End If

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
            Dim _SMSMessage, _RefMobile, _RefName, _AccrualDateTime, _DocCode, _DocData As String
            Dim _ReferanceNo, _SMSType, _DocName, _DocID, _SmsID As Integer
            With GridViewPendingMessages
                For i As Integer = 0 To .DataRowCount - 1
                    If .IsRowSelected(i) = True Then
                        _SMSMessage = .GetRowCellValue(i, "SMSDetails")
                        _ReferanceNo = .GetRowCellValue(i, "RefNo")
                        _RefMobile = .GetRowCellValue(i, "RefMobile")
                        _RefName = .GetRowCellValue(i, "RefName")
                        _SMSType = .GetRowCellValue(i, "SMSType")
                        _DocName = .GetRowCellValue(i, "DocName")
                        _DocID = .GetRowCellValue(i, "DocID")
                        _DocCode = .GetRowCellValue(i, "DocCode")
                        _SmsID = .GetRowCellValue(i, "SmsID")
                        _DocData = "Journal"

                        _AccrualDateTime = Format(CDate(.GetRowCellValue(i, "AccrualDateTime")), "yyyy-MM-dd HH:mm")
                        If Not String.IsNullOrEmpty(_SMSMessage) Then
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = _SMSType
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = _AccrualDateTime
                            dr("Sent") = 0
                            dr("DocName") = _DocName
                            dr("DocID") = _DocID
                            dr("DocCode") = _DocCode
                            dr("DocData") = _DocData
                            dr("SMSStatus") = ""
                            dr("Action") = 1
                            dr("SmsID") = _SmsID
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridViewPendingMessages.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridViewPendingMessages.SelectedRowsCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                If .ShowDialog() <> DialogResult.OK Then
                    RefreshData("PendingSms")
                End If
            End With

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class