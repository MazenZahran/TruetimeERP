Imports Microsoft.Office.Interop.Outlook

Public Class OrpakCardAddEdit
    Private _mode As String
    Private fleetepository As New FleetRepository()
    Private _LastData As String
    Public Sub New(ByVal mode As String)
        InitializeComponent()
        _mode = mode
    End Sub
    Private Sub CardAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_LastData = ""
        If _mode = "Add" Then
            Me.Text = " اضافة زبون جديد "
            BtnSave.Text = " حفظ البيانات "
            txtFleetCode.ReadOnly = True
            Me.StatusBar.Visible = False
            tglFleetStatus.ReadOnly = True
            tglCardStatus.IsOn = True
            tglCardStatus.ReadOnly = True
            btnGetMeanTrans.Enabled = False
            btnGetLogs.Enabled = False
            SearchRule.EditValue = "200000000"
        ElseIf _mode = "Edit" Then
            Me.Text = " تعديل بيانات زبون "
            BtnSave.Text = " تعديل البيانات "
            txtFleetCode.ReadOnly = True
            tglFleetStatus.ReadOnly = True
            SearchFleetCode.ReadOnly = True
            txtBalance.ReadOnly = True
            btnGetMeanTrans.Enabled = True
            btnGetLogs.Enabled = True
        End If
        SearchFleetCode.Properties.DataSource = GetReferences(-1, -1, -1)
        SearchRule.Properties.DataSource = GetOrpakGoupRules()
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroup1
        Me.GridControl1.DataSource = ""
        Me.GridControl2.DataSource = ""

    End Sub

    Private Sub txtCardID_EditValueChanged(sender As Object, e As EventArgs) Handles txtCardID.EditValueChanged
        Dim _CardData = GetCardData(txtCardID.Text)
        With _CardData
            _LastData = ""
            txtCardNo.Text = ._CardNo
            If ._CardStatus = 2 Then tglCardStatus.IsOn = True : Else tglCardStatus.IsOn = False
            txtCardCode.Text = ._CardCode
            txtPlate.Text = ._Plate
            SearchRule.EditValue = ._Rule
            SearchFleetCode.EditValue = ._FleetCode
            txtFleetID.Text = ._FleetID
            txtBalance.Text = ._FleetBalance
            txtFleetCode.Text = ._FleetCode
            If ._FleetStatus = 2 Then tglFleetStatus.IsOn = True : Else tglFleetStatus.IsOn = False
            barLastUpdate.Caption = "LastUpdate: " & ._LastUpdate
            barIssueDate.Caption = "IssueDate: " & ._IssueDate
            barCardID.Caption = "ID:" & ._CardID
            txtMonthlyLit.Text = ._MonthLit
            txtMonthlyNIS.ToolTipTitle = ._MonthNIS
            _LastData = "LastData(" & "CardNo:" & ._CardNo & " " & "Car:" & ._Plate & " " & "Status:" & ._CardStatus & " " & "Code:" & " " & ._CardCode & " " & "Rule:" & ._RuleName & ")"
        End With


    End Sub

    Private Sub SearchRule_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchRule.Properties.BeforePopup
        SearchRule.Properties.DataSource = GetOrpakGoupRules()
    End Sub

    Private Sub SearchFleetCode_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchFleetCode.Properties.BeforePopup
        SearchFleetCode.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnGetMeanTrans.Click
        GridControl1.DataSource = GetOrpakCardTransactions(txtCardID.Text)
    End Sub

    Private Sub btnChargeFleet_Click(sender As Object, e As EventArgs) Handles btnChargeFleet.Click
        If txtFleetID.Text = "" Then Exit Sub
        Dim fleetID As Integer
        fleetID = txtFleetID.Text
        Dim f As New ChargeFleet(fleetID)
        With f
            If .ShowDialog <> DialogResult.OK Then
                Dim fleet As Fleet = fleetepository.GetFleet(fleetID, 1)
                txtBalance.EditValue = fleet.Available_amount
            End If
        End With
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim _CardStatus As Integer
        If Me.tglCardStatus.IsOn Then _CardStatus = 2 : Else _CardStatus = 1
        If SearchRule.Text = "" Then MsgBoxShowError(" يجب اختيار السقف ") : Exit Sub
        If SearchFleetCode.Text = "" Then MsgBoxShowError(" يجب اختيار زبون ") : Exit Sub
        If txtCardNo.Text = "" Then MsgBoxShowError(" رقم الكرت فارغ ") : Exit Sub
        If txtCardCode.Text = "" Then MsgBoxShowError(" كود البطاقة فارغ ") : Exit Sub
        If txtPlate.Text = "" Then MsgBoxShowError(" رقم المركبة فارغ ") : Exit Sub
        Dim sql As New SQLControl
        Select Case _mode
            Case "Edit"
                If CheckIfCardNo(txtCardNo.Text, txtCardID.Text) = True Then
                    MsgBoxShowError(" الكرت معرف  ")
                    txtCardNo.Select()
                    Exit Sub
                End If
                'If CheckIfPlateExist(txtPlate.Text, txtCardID.Text) = True Then
                '    MsgBoxShowError(" المركبة معرفة من قبل ")
                '    txtPlate.Select()
                '    Exit Sub
                'End If
                If CheckIfCardCodeExist(txtCardCode.Text, txtCardID.Text) = True Then
                    MsgBoxShowError(" كود البطاقة معرف من قبل ")
                    txtCardCode.Select()
                    Exit Sub
                End If
                Dim sqlstring As String
                sqlstring = " Update [dbo].[means] Set 
                                     [name]='" & txtCardNo.Text & "',
                                     [string]='" & Me.txtCardCode.Text & "',
                                     [status]=" & _CardStatus & ",
                                     [rule]=" & SearchRule.EditValue & ",
                                     [plate]='" & txtPlate.Text & "',
                                     [update_timestamp]=GetDate() 
                                     Where [id]=" & txtCardID.Text
                If sql.SqlOrpakRunQuery(sqlstring, 1) Then
                    sql.SqlTrueAccountingRunQuery(" Insert into [dbo].[OrpakMeansLog] ([CardID],[CardNo],[UpdateNote],[LastData],InputDateTime,UserNo) Values 
                                                                                      (" & txtCardID.Text & "," & txtCardNo.Text & ",N'" & txtNotes.Text & "',
                                                                                      N'" & _LastData & "',GetDate(),'" & GlobalVariables.CurrUser & "' ) ")
                    MsgBoxShowSuccess(" تم تعديل بيانات البطاقة بنجاح ")
                    Me.Close()
                End If
            Case "Add"
                If txtFleetID.Text = "" Then MsgBoxShowError(" Fleet ID empty ") : Exit Sub
                Dim _dep As Integer = fleetepository.DefaultDepForFleet(txtFleetID.Text)
                If _dep = 0 Then MsgBoxShowError(" الدائرة خطا يرجى اعادة المحاولة ") : Exit Sub
                Dim sqlstring As String
                sqlstring = " BEGIN TRANSACTION
                              SET DEADLOCK_PRIORITY HIGH
                              update indexes set id=id+1 where name='means'
                              Declare @meanID int; Set @meanId=( select id from indexes where name='means'  );
                              INSERT INTO means (id,name, string,string2,string3,string4,string5, type,status,[rule],  hardware_type, pump, employee_type, model_id, address,fleet_id, dept_id,[year], odometer, consumption,consumption2,plate, cust_id, capacity, fcc_bos_cleared,acctyp, available_amount, update_timestamp,pin_code, auth_pin_from, nr_pin_retries, max_odo_delta_allowed, nr_odo_retries, use_pin_code, block_if_pin_retries_fail,opos_prompt_for_plate, opos_prompt_for_odometer, driver_id_type_required, do_odo_reasonability_check, auttyp, price_list_id, opos_prompt_for_engine_hours,address2, city, state, zip, phone,user_data1, user_data2, user_data3, user_data4, user_data5, start_odometer, is_burned, viu_serial, allow_id_replacement, num_of_strings,day_volume,week_volume,month_volume,day_money,week_money,month_money,day_visits,week_visits,month_visits,opos_plate_check_type,nr_plate_retries,block_if_plate_retries_fail,chassis_number,issued_date,last_used,prompt_always_for_viu, disable_viu_two_stage,discovered,year_volume,year_money, expire, expire_date,do_eh_reasonability_check, max_eh_delta_allowed, nr_eh_retries, reject_if_eh_check_fails, engine_hours)						  
                                          values (@meanID,'" & txtCardNo.Text & "','" & txtCardCode.Text & "','','','','', 2, 2," & SearchRule.EditValue & ",1,  0,1,0,'', " & txtFleetID.Text & "," & _dep & ",0,0.000000,0.000000,0.000000,'" & txtPlate.Text & "','',0.000000,0,  0,0.000000,CURRENT_TIMESTAMP,'0',2, 0,0,0,0,0, 0,0,0, 1,14,0,0,'', '', '', '', '','', '', '', '', '', 0.000000, 1, 'undefined', 0, 1,0.000000,0.000000,0.000000, 0.000000,0.000000,0.000000, 0,0,0, 0,0,0,'','" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "','',0,0,0,0.000000,0.000000,0,'0000',0,0,0,0,0.000000)

                              COMMIT "
                If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
                    MsgBoxShowSuccess(" تم تعريف البطاقة بنجاح ")
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnGetLogs.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select * from OrpakMeansLog where [CardID]=" & txtCardID.Text)
        GridControl2.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SearchFleetCode_EditValueChanged(sender As Object, e As EventArgs) Handles SearchFleetCode.EditValueChanged
        If _mode = "Add" Then
            Dim _fleet = fleetepository.GetFleetByFleetCode(SearchFleetCode.EditValue, 1)
            Me.txtFleetID.Text = _fleet.ID
            Me.txtFleetCode.Text = _fleet.fleetCode
            txtBalance.Text = _fleet.Available_amount
            If _fleet.Status = 2 Then
                tglFleetStatus.IsOn = True
            Else
                tglFleetStatus.IsOn = False
            End If
        End If
    End Sub
    Private Function CheckIfCardNo(_CardNo As String, Optional _id As Integer = 0) As Boolean
        Dim _result As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(*) as _count from Means where [status]<>0 and  [name]='" & _CardNo & "'"
        If _id <> 0 Then sqlstring += " and id<>" & _id
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            If sql.SQLDS.Tables(0).Rows(0).Item("_count") > 0 Then
                _result = True
            Else
                _result = False
            End If
        End If
        Return _result
    End Function
    Private Function CheckIfPlateExist(_Plate As String, Optional _id As Integer = 0) As Boolean
        Dim _result As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(*) as _count from Means where [status]<>0 and  [plate]='" & _Plate & "'"
        If _id <> 0 Then sqlstring += " and id<>" & _id
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            If sql.SQLDS.Tables(0).Rows(0).Item("_count") > 0 Then
                _result = True
            Else
                _result = False
            End If
        End If
        Return _result
    End Function
    Private Function CheckIfCardCodeExist(_CardCode As String, Optional _id As Integer = 0) As Boolean
        Dim _result As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(*) as _count from Means where [status]<>0 and [string]='" & _CardCode & "'"
        If _id <> 0 Then sqlstring += " and id<>" & _id
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            If sql.SQLDS.Tables(0).Rows(0).Item("_count") > 0 Then
                _result = True
            Else
                _result = False
            End If
        End If
        Return _result
    End Function

    Private Sub txtPlate_EditValueChanged(sender As Object, e As EventArgs) Handles txtPlate.EditValueChanged

    End Sub
    Private Sub FleetName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlate.KeyPress, txtCardNo.KeyPress, txtCardCode.KeyPress
        If e.KeyChar <> " " Then
            If Not (Asc(e.KeyChar) = 8) Then
                Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz1234567890"
                If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                    e.KeyChar = ChrW(0)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub txtCardNo_EditValueChanged(sender As Object, e As EventArgs) Handles txtCardNo.EditValueChanged

    End Sub

    Private Sub txtCardCode_EditValueChanged(sender As Object, e As EventArgs) Handles txtCardCode.EditValueChanged

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl3.DataSource = fleetepository.GetFleetChargesLog(txtFleetID.Text, 1)
    End Sub
End Class