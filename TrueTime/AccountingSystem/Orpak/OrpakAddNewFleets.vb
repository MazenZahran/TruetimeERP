Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Graph

Public Class OrpakAddNewFleets
    Private _mode As String
    Private fleetepository As New FleetRepository()
    Public Sub New(ByVal mode As String)
        InitializeComponent()
        _mode = mode
    End Sub
    Private Sub OrpakAddNewFleets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _mode = "Add" Then
            Me.Text = " اضافة زبون جديد "
            BtnSave.Text = " حفظ البيانات "
            Dim _code As Integer = fleetepository.GetMaxCode
            If _code = 0 Then
                MsgBoxShowError(" خطا برقم الزبون ")
                Exit Sub
            End If
            Me.FleetCode.EditValue = _code + 1
            LayoutControlStatus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.StatusBar.Visible = False
        ElseIf _mode = "Edit" Then
            Me.Text = " تعديل بيانات زبون "
            BtnSave.Text = " تعديل البيانات "
            Me.FleetCode.ReadOnly = True
            RefName.ReadOnly = True
            Me.txtCurrentBalance.ReadOnly = True
            GetFleetData()
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SaveData()
    End Sub
    Private Sub SaveData()
        If FleetCode.Text = "" Then
            MsgBoxShowError(" رقم الزبون فارغ ")
            FleetCode.Select()
            Exit Sub
        End If
        If FleetName.Text = "" Then
            MsgBoxShowError(" اسم الزبون فارغ ")
            FleetName.Select()
            Exit Sub
        End If
        If RefName.Text = "" Then
            MsgBoxShowError(" اسم الزبون فارغ ")
            RefName.Select()
            Exit Sub
        End If

        If RefMobile.Text = "" Then
            MsgBoxShowError(" رقم الموبايل فارغ ")
            RefMobile.Select()
            Exit Sub
        End If

        Dim _Status As Integer
        If ToggleStatus.IsOn = True Then
            _Status = 2
        Else
            _Status = 1
        End If

        If _mode <> "Edit" Then
            If CheckIfFleetCodeIsFoundInFinancialSystem(FleetCode.Text) = True Then
                MsgBoxShowError(" الزبون معرف بالنظام المالي ")
                Exit Sub
            End If
            If CheckIfFleetCodeIsFound(FleetCode.Text, FleetName.Text) = True Then
                MsgBoxShowError(" الزبون معرف ")
                Exit Sub
            End If
        End If


        Dim _Prepaid As Integer
        If CheckPrepaid.Checked = True Then
            _Prepaid = 1
        Else
            _Prepaid = 0
        End If

        Dim _SmsWithBalance As Integer
        If CheckSmsWithBalance.Checked = True Then
            _SmsWithBalance = 1
        Else
            _SmsWithBalance = 0
        End If


        Dim _CurrentAmount As Integer = 0

        Dim _MonthVoucher As Integer
        Select Case Me.CheckMonthlyVoucher.EditValue
            Case True
                _MonthVoucher = 1
            Case False
                _MonthVoucher = 0
        End Select
        Dim _SendSMS As Integer
        Select Case Me.CheckSendSMS.EditValue
            Case True
                _SendSMS = 1
            Case False
                _SendSMS = 0
        End Select

        If _mode = "Add" Then
            Dim Sqlstring As String
            Sqlstring = "BEGIN TRANSACTION
                            SET DEADLOCK_PRIORITY HIGH
                            update indexes set id=id+1 where name='fleets'
                            Declare @FleetdID int;
                            Set @FleetdID = ( select id from indexes where name='fleets' )
                            INSERT INTO fleets
                                (id, name, status, code, default_rule, address, phone, fax,email, contact, acctyp, available_amount,min_allowed, update_timestamp, use_pin_code, opos_prompt_for_plate, opos_prompt_for_odometer, block_if_pin_retries_fail, do_odo_reasonability_check, auth_pin_from, nr_pin_retries, max_odo_delta_allowed, nr_odo_retries, line_of_credit, opos_prompt_for_engine_hours, address2,city,state,zip,user_data1,user_data2,user_data3,user_data4,user_data5,price_list_id, last_sequence,prompt_always_for_viu,discovered,do_eh_reasonability_check, max_eh_delta_allowed, nr_eh_retries, reject_if_eh_check_fails , single_fuel)
                            values(@FleetdID, '" & FleetName.Text & "', 2, '" & FleetCode.Text & "', 200000000, '', '" & Me.RefMobile.Text & "', '', '', '', " & _Prepaid & ", 0.000000, 0.000000, '', 0, 0, 0, 0, 1, 2, 0, 0, 0, " & _CurrentAmount & ", 0, '', '" & _SmsWithBalance & "', '" & _MonthVoucher & "', '" & _SendSMS & "', '', '', '', '', '', 0, 0, 0, 0, 1, 0, 0, 0, 0.000000)
                         COMMIT

                         BEGIN TRANSACTION
                            SET DEADLOCK_PRIORITY HIGH
                            update indexes set id=id+1 where name='depts'
                         COMMIT

                         BEGIN TRANSACTION
                            SET DEADLOCK_PRIORITY HIGH
                            Declare @DepID int;
                            Set @DepID= ( select id from indexes where name='depts' )
                            delete from depts where id=@DepID
                            insert into depts
                                (id, name, fleet_id, status, code, default_rule, address,phone, fax,email, contact, use_pin_code, opos_prompt_for_plate, opos_prompt_for_odometer, block_if_pin_retries_fail, do_odo_reasonability_check, auth_pin_from,nr_pin_retries, max_odo_delta_allowed, nr_odo_retries, black_white_type, opos_prompt_for_engine_hours, address2, city, state, zip, user_data1, user_data2, user_data3, user_data4, user_data5,price_list_id,prompt_always_for_viu,discovered, do_eh_reasonability_check, max_eh_delta_allowed, nr_eh_retries, reject_if_eh_check_fails)
                            values
                                (@DepID, 'Default', @FleetdID, 2, 1, 200000000, '', '', '', '', '', 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 0, '', '', '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0)
                         COMMIT "


            Dim sql As New SQLControl
            If sql.SqlOrpakRunQuery(Sqlstring, Me.TextPosNo.EditValue) = True Then
                Sqlstring = "  Insert into Referencess (RefNo,RefName,RefType,RefMobile,
                                                   RefPhone,RefAccID,PriceCategory,RefEmail,
                                                   SearchCity,SubscribeAmount,RefSort,RefBirthDate,
                                                   RefMemo,[Active],[DateStart],[Address],[ReferanceCode],[IdentityNo])
                          Values ( " & FleetCode.Text & ",N'" & RefName.Text & "','" & 2 & "',
                                   '" & Me.RefMobile.Text & "','','1104010000',
                                   '1',N'',
                                   ''," & 0 & ",
                                    " & 1 & ",'1900-01-01',N'" & Me.MemoEdit1.Text & "',
                                    " & 1 & ",GetDate(),N'','','') "
                If sql.SqlTrueAccountingRunQuery(Sqlstring) = True Then
                    Me.Close()
                Else
                    MsgBoxShowError(" لم يتم تعريف الزبون على النظام المالي ")
                End If
            Else
                MsgBoxShowError(" لم يتم تعريف الزبون على نظام اورباك ")
            End If
        End If
        If _mode = "Edit" Then
            If String.IsNullOrEmpty(TextFleetID.Text) Then
                MsgBoxShowError("empty id")
                Exit Sub
            End If
            Using connection As New SqlConnection(GetOrpakConnectionString(1)._Cstring)
                Dim command As New SqlCommand("UPDATE [dbo].[fleets] SET 
                                                      [name] = @name, [status] = @status,[phone]=@phone,[acctyp]=@acctyp, 
                                                      [update_timestamp]=GetDate(),[state]=@state,[zip]=@zip,[city]=@city 
                                               WHERE id = @id", connection)
                command.Parameters.AddWithValue("@name", Me.FleetName.Text)
                command.Parameters.AddWithValue("@status", _Status)
                command.Parameters.AddWithValue("@phone", Me.RefMobile.Text)
                command.Parameters.AddWithValue("@acctyp", _Prepaid)
                command.Parameters.AddWithValue("@state", _MonthVoucher)
                command.Parameters.AddWithValue("@zip", _SendSMS)
                command.Parameters.AddWithValue("@city", _SmsWithBalance)
                command.Parameters.AddWithValue("@id", TextFleetID.Text)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
            Using connection As New SqlConnection(My.Settings.TrueTimeConnectionString)
                Dim command As New SqlCommand("UPDATE [dbo].[Referencess] SET 
                                                      [RefMobile] = @RefMobile,[RefMemo]=@RefMemo 
                                               WHERE [RefNo] = @RefNo", connection)
                'command.Parameters.AddWithValue("@RefName", Me.FleetName.Text)
                command.Parameters.AddWithValue("@RefMobile", Me.RefMobile.Text)
                command.Parameters.AddWithValue("@RefMemo", Me.MemoEdit1.Text)
                command.Parameters.AddWithValue("@RefNo", Me.FleetCode.Text)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
            Me.Close()
        End If

    End Sub
    Private Function CheckIfFleetCodeIsFound(_Code As String, _Name As String) As Boolean
        Dim _result As Boolean
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = " select id from Fleets where [code]='" & _Code & "' Or [name]='" & _Name & "'"
            sql.SqlOrpakRunQuery(sqlstring, Me.TextPosNo.EditValue)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _result = True
            End If
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function
    Private Function CheckIfFleetCodeIsFoundInFinancialSystem(_Code As String) As Boolean
        Dim _result As Boolean
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = " select RefNo from [dbo].[Referencess] where [RefNo]='" & _Code & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _result = True
            End If
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function



    Private Sub FleetName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FleetName.KeyPress
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

    Private Sub RefMobile_EditValueChanged(sender As Object, e As EventArgs) Handles RefMobile.EditValueChanged

    End Sub

    Private Sub RefMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RefMobile.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            If Not Regex.IsMatch(e.KeyChar.ToString(), "[0-9]") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GetFleetData()
        Dim id As Integer = TextFleetID.EditValue
        Dim fleet As Fleet = fleetepository.GetFleet(id, 1)
        FleetCode.Text = fleet.fleetCode
        FleetName.Text = fleet.FleetName
        CheckSendSMS.Checked = fleet.SendMessage
        RefMobile.Text = fleet.Mobile
        Dim _RefData = GetRefranceData(fleet.fleetCode)
        RefName.Text = _RefData.RefName
        MemoEdit1.Text = _RefData.RefMemo
        CheckPrepaid.Checked = fleet.Prepaid
        CheckMonthlyVoucher.Checked = fleet.MonthlyVoucher
        CheckSmsWithBalance.Checked = fleet.SmsWithBalance
        txtCurrentBalance.Text = fleet.Available_amount
        TextFleetID.Text = fleet.ID
        If fleet.Status = 2 Then
            ToggleStatus.IsOn = True
        Else
            ToggleStatus.IsOn = False
        End If
        fleetIdBar.Caption = " ID: " & fleet.ID
        BarLastUpdate.Caption = " LastUpdate: " & fleet.LastUpdate
    End Sub

    Private Sub FleetName_EditValueChanged(sender As Object, e As EventArgs) Handles FleetName.EditValueChanged

    End Sub
End Class