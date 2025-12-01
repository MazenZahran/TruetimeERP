Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class Tasks
    Dim _UserID As String = GlobalVariables.CurrUserForTasks

    Dim CurrFilter As Integer = 0
    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.TileBarItem1.Elements(1).Text = "100"
        'Me.TileBarItem2.Elements(1).Text = "100"
        'Me.TileBarItem3.Elements(1).Text = "100"
        'Me.GridView1.Appearance.Row.Font = New Font("Tahoma", 12.0F)
        GetTasksCount()
        GetTasks(1)
        LabelControl1.Text = GetEmpData(_UserID).Item1
    End Sub
    Private Sub GetTasks(_Action)
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        GetTasksCount()
        Dim SqlString As String
        Dim Sql As New SQLControl
        Select Case _Action
            Case 1
                SqlString = " SELECT  [UniqueID]
                     ,[Type] ,[StartDate] ,[EndDate]
                     ,[QueryStartDate] ,[QueryEndDate] ,[AllDay]
                     ,[Subject] ,A.[Location] ,[Description]
                     ,[Status] ,[Label] ,[ResourceID]
                     ,[ResourceIDs] ,[ReminderInfo] ,[RecurrenceInfo]
                     ,[TimeZoneId] ,[CustomField1] ,[CreationUser] As CreationUserID
                     ,E.EmployeeName as CreationUser
                     ,[TaskStatus] ,[CreationDate] ,[AssignedTo] as AssignedToID,EE.EmployeeName as AssignedTo
                     ,[Referance] ,[LastUserUpdate] ,[LastUpdateDate]
                     ,[DocCode] ,S.[Step] as Step,S.[StatusName] as StatusName
                      FROM [Appointments] A 
                      Left Join [CRMTaskStatuses] S on A.TaskStatus=S.[StatusID]
                      left join EmployeesData E on E.EmployeeID=A.CreationUser 
                      left join EmployeesData EE on EE.EmployeeID=A.AssignedTo 
                      Where AssignedTo='" & _UserID & "' And (TaskStatus= 1 or TaskStatus= 2)"
                CurrFilter = 1
                Sql.SqlTrueTimeRunQuery(SqlString)
                GridControl1.DataSource = Sql.SQLDS.Tables(0)
            Case 2
                SqlString = " SELECT  [UniqueID]
                     ,[Type] ,[StartDate] ,[EndDate]
                     ,[QueryStartDate] ,[QueryEndDate] ,[AllDay]
                     ,[Subject] ,A.[Location] ,[Description]
                     ,[Status] ,[Label] ,[ResourceID]
                     ,[ResourceIDs] ,[ReminderInfo] ,[RecurrenceInfo]
                     ,[TimeZoneId] ,[CustomField1] ,[CreationUser] As CreationUserID
                     ,E.EmployeeName as CreationUser
                     ,[TaskStatus] ,[CreationDate] ,[AssignedTo] as AssignedToID,EE.EmployeeName as AssignedTo
                     ,[Referance] ,[LastUserUpdate] ,[LastUpdateDate]
                     ,[DocCode] ,S.[Step] as Step,S.[StatusName] as StatusName
                      FROM [Appointments] A 
                      Left Join [CRMTaskStatuses] S on A.TaskStatus=S.[StatusID]
                      left join EmployeesData E on E.EmployeeID=A.CreationUser 
                      left join EmployeesData EE on EE.EmployeeID=A.AssignedTo 
                      Where AssignedTo='" & _UserID & "' And (TaskStatus= 3 or TaskStatus= 4)"
                Sql.SqlTrueTimeRunQuery(SqlString)
                GridControl1.DataSource = Sql.SQLDS.Tables(0)
                CurrFilter = 2
            Case 3
                SqlString = " SELECT  [UniqueID]
                     ,[Type] ,[StartDate] ,[EndDate]
                     ,[QueryStartDate] ,[QueryEndDate] ,[AllDay]
                     ,[Subject] ,A.[Location] ,[Description]
                     ,[Status] ,[Label] ,[ResourceID]
                     ,[ResourceIDs] ,[ReminderInfo] ,[RecurrenceInfo]
                     ,[TimeZoneId] ,[CustomField1] ,[CreationUser] As CreationUserID
                     ,E.EmployeeName as CreationUser
                     ,[TaskStatus] ,[CreationDate] ,[AssignedTo] as AssignedToID,EE.EmployeeName as AssignedTo
                     ,[Referance] ,[LastUserUpdate] ,[LastUpdateDate]
                     ,[DocCode] ,S.[Step] as Step,S.[StatusName] as StatusName
                      FROM [Appointments] A 
                      Left Join [CRMTaskStatuses] S on A.TaskStatus=S.[StatusID]
                      left join EmployeesData E on E.EmployeeID=A.CreationUser 
                      left join EmployeesData EE on EE.EmployeeID=A.AssignedTo 
                      Where AssignedTo<>CreationUser 
                            And CreationUser='" & _UserID & "' And (TaskStatus= 1 or TaskStatus=2 )"
                Sql.SqlTrueTimeRunQuery(SqlString)
                GridControl1.DataSource = Sql.SQLDS.Tables(0)
                CurrFilter = 3
            Case 4
                SqlString = " SELECT  [UniqueID]
                     ,[Type] ,[StartDate] ,[EndDate]
                     ,[QueryStartDate] ,[QueryEndDate] ,[AllDay]
                     ,[Subject] ,A.[Location] ,[Description]
                     ,[Status] ,[Label] ,[ResourceID]
                     ,[ResourceIDs] ,[ReminderInfo] ,[RecurrenceInfo]
                     ,[TimeZoneId] ,[CustomField1] ,[CreationUser] As CreationUserID
                     ,E.EmployeeName as CreationUser
                     ,[TaskStatus] ,[CreationDate] ,[AssignedTo] as AssignedToID,EE.EmployeeName as AssignedTo
                     ,[Referance] ,[LastUserUpdate] ,[LastUpdateDate]
                     ,[DocCode] ,S.[Step] as Step,S.[StatusName] as StatusName
                      FROM [Appointments] A 
                      Left Join [CRMTaskStatuses] S on A.TaskStatus=S.[StatusID]
                      left join EmployeesData E on E.EmployeeID=A.CreationUser 
                      left join EmployeesData EE on EE.EmployeeID=A.AssignedTo 
                      Where  AssignedTo='" & _UserID & "'"
                Sql.SqlTrueTimeRunQuery(SqlString)
                GridControl1.DataSource = Sql.SQLDS.Tables(0)
                CurrFilter = 4
        End Select
        GridView1.Focus()
        GridView1.FocusedRowHandle = focusedRow

    End Sub


    Private Sub TileBar1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBar1.ItemClick
        Dim itemTag As Integer = Convert.ToInt32(e.Item.Tag)
        Select Case itemTag
            Case 1
                GetTasks(1)
            Case 2
                GetTasks(2)
            Case 3
                GetTasks(3)
            Case 4
                GetTasks(4)
            Case Else
                XtraMessageBox.Show(e.Item.Text & " clicked")
        End Select
    End Sub
    Private Sub GetTasksCount()
        Dim SqlString As String
        Dim Sql As New SQLControl
        SqlString = "    Select count(UniqueID) as TasksCount1 from Appointments 
                            Where AssignedTo='" & _UserID & "' And (TaskStatus= 1 or TaskStatus= 2);
                         Select count(UniqueID) as TasksCount2 from Appointments 
                            Where AssignedTo='" & _UserID & "' And (TaskStatus= 3 or TaskStatus= 4);
                         Select count(UniqueID) as TasksCount3 from Appointments 
                            Where AssignedTo<>CreationUser And CreationUser='" & _UserID & "' And (TaskStatus= 1 or TaskStatus=2 ) 
                         Select count(UniqueID) as TasksCount4 from Appointments 
                            Where  AssignedTo='" & _UserID & "' "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Me.TileBarItem1.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("TasksCount1")
        Me.TileBarItem2.Elements(1).Text = Sql.SQLDS.Tables(1).Rows(0).Item("TasksCount2")
        Me.TileBarItem3.Elements(1).Text = Sql.SQLDS.Tables(2).Rows(0).Item("TasksCount3")
        Me.TileBarItem4.Elements(1).Text = Sql.SQLDS.Tables(3).Rows(0).Item("TasksCount4")
    End Sub

    Private Function GetTaskTrans(_TaskID As Integer) As Integer
        Dim _Count As Integer
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select count(ID) as Count  from AppointmentClosing where TaskID=" & _TaskID
            Sql.SqlTrueTimeRunQuery(SqlString)
            _Count = Sql.SQLDS.Tables(0).Rows(0).Item("Count")

        Catch ex As Exception
            _Count = 0
        End Try
        Return _Count
    End Function



    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim _TaskID = GridView1.GetFocusedRowCellValue("UniqueID")
        Me.TileBarItem6.Elements(1).Text = GetTaskTrans(_TaskID)
        Me.TileBarItem6.Elements(2).Text = "TaskID:" & _TaskID
    End Sub

    Private Sub TileBar2_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBar2.ItemClick
        Dim itemTag As Integer = Convert.ToInt32(e.Item.Tag)
        Select Case itemTag
            Case 1
                GetTasks(CurrFilter)
                GetTasksCount()
            Case 2
                Dim _TaskID = GridView1.GetFocusedRowCellValue("UniqueID")
                If GetTaskTrans(_TaskID) = 0 Then Exit Sub
                My.Forms.CRMTaskTrans.TextTaskID.EditValue = GridView1.GetFocusedRowCellValue("UniqueID")
                My.Forms.CRMTaskTrans.TrackBarControl1.EditValue = GridView1.GetFocusedRowCellValue("Step")
                My.Forms.CRMTaskTrans.ShowDialog()
            Case 3
                Dim f As New ReferancessList
                With f
                    .ColReferanceCode.Visible = False
                    .ShowDialog()
                End With

        End Select
    End Sub
    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        Dim _TaskID = GridView1.GetFocusedRowCellValue("UniqueID")
        Me.TileBarItem6.Elements(1).Text = GetTaskTrans(_TaskID)
        Me.TileBarItem6.Elements(2).Text = "TaskID:" & _TaskID
    End Sub
End Class