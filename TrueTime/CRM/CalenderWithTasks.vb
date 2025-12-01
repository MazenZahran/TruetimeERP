Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.UI
Imports System.ComponentModel
Imports System.Linq

Public Class CalenderWithTasks
    Private Sub CalenderWithTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.Resources' table. You can move, or remove it, as needed.
        ' Me.ResourcesTableAdapter.Fill(Me.TrueAccountingDataSet.Resources)
        'TODO: This line of code loads data into the 'TrueAccountingDataSet1.Resources' table. You can move, or remove it, as needed.
        '  Me.ResourcesTableAdapter.Fill(Me.TrueAccountingDataSet1.Resources)
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.Resources' table. You can move, or remove it, as needed.
        '  Me.ResourcesTableAdapter.Fill(Me.TrueAccountingDataSet.Resources)
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.Appointments' table. You can move, or remove it, as needed.
        If GlobalVariables._UserAccessType <> 94 Then
            Me.AppointmentsTableAdapter.Fill(Me.TrueAccountingDataSet.Appointments, 4, GlobalVariables.CurrUser)
        End If

        Me.KeyPreview = True
        'SearchLookUpEdit1.EditValue = GlobalVariables.CurrUser
        Timer1.Interval = 10000 * 600 ' Evry One Minitues
        Timer1.Start()
        SchedulerControl1.GoToToday()
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        getemployees()
        SearchEmployees.EditValue = CInt(GlobalVariables.CurrUser)
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Try
                If GlobalVariables._UserAccessType <> 94 Then
                    Me.AppointmentsTableAdapter.Fill(Me.TrueAccountingDataSet.Appointments, 4, SearchEmployees.EditValue)
                End If
                Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
                Me.SchedulerDataStorage1.RefreshData()
            Catch ex As Exception
                MsgBoxShowError(" لا يمكن تحميل البيانات " & ex.ToString)
            End Try
        End If
    End Sub



    Private Sub SchedulerDataStorage1_AppointmentsChanged(sender As Object, e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerDataStorage1.AppointmentsInserted, SchedulerDataStorage1.AppointmentsDeleted, SchedulerDataStorage1.AppointmentsChanged
        AppointmentsTableAdapter.Update(TrueAccountingDataSet)

        TrueAccountingDataSet.AcceptChanges()

    End Sub

    Private Sub SchedulerControl1_EditAppointmentFormShowing(sender As Object, e As DevExpress.XtraScheduler.AppointmentFormEventArgs) Handles SchedulerControl1.EditAppointmentFormShowing
        Dim scheduler As DevExpress.XtraScheduler.SchedulerControl = CType(sender, DevExpress.XtraScheduler.SchedulerControl)
        Dim form As TrueTime.OutlookAppointmentForm = New TrueTime.OutlookAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm)
        Try
            e.DialogResult = form.ShowDialog
            If GlobalVariables._UserAccessType <> 94 Then
                Me.AppointmentsTableAdapter.Fill(Me.TrueAccountingDataSet.Appointments, 4, SearchEmployees.EditValue)
            End If

            e.Handled = True
        Finally
            form.Dispose()
        End Try



    End Sub

    Private Sub SchedulerControl1_Click(sender As Object, e As EventArgs) Handles SchedulerControl1.Click

    End Sub

    Private Sub SwitchToTimelineViewItem1_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub CreateNewAppointmentbycode()
        ' SchedulerControl1.DataStorage.Appointments.Clear()
        SchedulerControl1.ActiveView.SetSelection(New TimeInterval(DateTime.Now, New TimeSpan(2, 40, 0)), ResourceEmpty.Resource)
        SchedulerControl1.GroupType = SchedulerGroupType.Resource
        Dim apt As Appointment = SchedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal)
        apt.Start = SchedulerControl1.SelectedInterval.Start
        apt.[End] = SchedulerControl1.SelectedInterval.[End]
        apt.Subject = "test code"
        apt.CustomFields("TaskStatus") = 50
        ' OutlookAppointmentForm.DoneButton.Enabled = False
        '   apt.ResourceId = SchedulerControl1.SelectedResource.Id
        SchedulerControl1.DataStorage.Appointments.Add(apt)
    End Sub
    Private Shared Sub Storage_FilterAppointment(ByVal sender As Object, ByVal e As PersistentObjectCancelEventArgs)
        e.Cancel = CType(e.Object, Appointment).CustomFields("PropertyOne").ToString() = "Hidden"
    End Sub

    Private Sub SchedulerControl1_InitNewAppointment(sender As Object, e As AppointmentEventArgs) Handles SchedulerControl1.InitNewAppointment
        e.Appointment.Subject = " "
        e.Appointment.CustomFields("CreationUser") = GlobalVariables.CurrUserForTasks
        e.Appointment.CustomFields("TaskStatus") = 1
        e.Appointment.CustomFields("CreationDate") = Today
        e.Appointment.CustomFields("AssignedTo") = SearchEmployees.EditValue
        ' e.Appointment.CustomFields("ServiceNo") = SearchEmployees.EditValue

        '  OutlookAppointmentForm.DoneButton.Enabled = True
        ' SchedulerControl1.Start = System.DateTime.Now
    End Sub


    Private Sub OnPreparePopupMenu(sender As Object, e As PopupMenuShowingEventArgs) Handles SchedulerControl1.PopupMenuShowing

        ' Check if it's the default menu of a Scheduler.  
        If e.Menu.Id = SchedulerMenuItemId.DefaultMenu Then

            ' Disable the "New Recurring Appointment" menu item.  
            e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment)
            e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringEvent)
            e.Menu.DisableMenuItem(SchedulerMenuItemId.NewAllDayEvent)

            ' Hide the "New Recurring Event" menu item.  
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment)
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent)

            ' Enable the "Go To Today" menu item.  
            e.Menu.EnableMenuItem(SchedulerMenuItemId.GotoToday)

            ' Find the "New Appointment" menu item and rename it.  
            Dim Item As SchedulerMenuItem = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment)
            If Not (Item Is Nothing) Then Item.Caption = "&اضافة مهمة"

            ' Find the "New All Day Event" menu item and rename it.  
            'Item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent)
            'If Not (Item Is Nothing) Then Item.Caption = "&Perform a Maintenance"

        End If


    End Sub

    Private Sub schedulerControl1_AllowAppointmentDrag(ByVal sender As Object,
ByVal e As AppointmentOperationEventArgs)
        ' If user_id = "Sam" Then
        ' to READ ONLY 
        ' e.Allow = False
        '  End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.SchedulerControl1.BeginUpdate()
        If GlobalVariables._UserAccessType <> 94 Then
            Me.AppointmentsTableAdapter.Fill(Me.TrueAccountingDataSet.Appointments, 4, SearchEmployees.EditValue)
        End If

        Me.SchedulerControl1.EndUpdate()
    End Sub
    Private Sub getemployees()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "Select EmployeeID,EmployeeName From [dbo].[EmployeesData] where [Active]=1  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            SearchEmployees.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchLookUpEdit1_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchEmployees.Properties.BeforePopup
        'getemployees()
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchEmployees.EditValueChanged
        Try
            If Me.IsHandleCreated = True Then
                Me.SchedulerControl1.BeginUpdate()
                If GlobalVariables._UserAccessType <> 94 Then
                    Me.AppointmentsTableAdapter.Fill(Me.TrueAccountingDataSet.Appointments, 4, SearchEmployees.EditValue)
                End If
                Me.SchedulerControl1.EndUpdate()
                GlobalVariables.CurrUserForTasks = SearchEmployees.EditValue
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalenderWithTasks_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class