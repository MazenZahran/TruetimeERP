Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class ReadClock
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnRead.Click
        Try
            Dim p() As Process
            Dim Att As Process
            '  Att.Kill()
            p = Process.GetProcessesByName("att")
            If p.Count > 0 Then Att = Process.GetProcessesByName("att")(0) : GoTo ReadAtt
            Dim SqlString As String = "Select SettingValue from Settings where SettingName = 'AttAplicationPath'"
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SqlString)

            Att = Process.Start(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
ReadAtt:
            Att.WaitForExit()
            TextTotalReads.Text = String.Empty
            TextUnProcessedTrans.Text = String.Empty
            TextNewEmployees.Text = 0
            Dim AttTable As New DataTable

            Select Case GlobalVariables._AttConnectionType
                Case "Access"
                    Dim con = New System.Data.OleDb.OleDbConnection()
                    con.ConnectionString = AttConectionString()
                    con.Open()
                    Dim da = New System.Data.OleDb.OleDbDataAdapter("SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE,SENSORID,sn FROM  CHECKINOUT,USERINFO  where CHECKINOUT.USERID =USERINFO.USERID  AND [AttProcess] is null", con)
                    da.Fill(AttTable)
                    con.Close()
                Case "Sql"
                    Dim Sql0 As New SQLControl
                    Sql0.SqlTrueTimeRunQuery("SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE,SENSORID,sn FROM  CHECKINOUT,USERINFO  where CHECKINOUT.USERID =USERINFO.USERID  AND [AttProcess] is null")
                    AttTable = Sql0.SQLDS.Tables(0)
            End Select
            If AttTable.Rows.Count = 0 Then
                TextTotalReads.Text = 0

                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBox("لا يوجد حركات جديدة")
                ElseIf GlobalVariables._SystemLanguage = "English" Then
                    MsgBox("There is no new data")
                End If

                Exit Sub
            End If
            TextTotalReads.Text = AttTable.Rows.Count
            Dim i As Integer
            NewUsers = 0

            Dim SQLString2 As String = " SELECT  distinct  USERID FROM [AttCHECKINOUT]
                                         where Edited Is Null order by USERID "
            Dim sql2 As New SQLControl
            sql2.SqlTrueTimeRunQuery(SQLString2)
            Dim z As Integer = (sql2.SQLDS.Tables(0).Rows.Count)
            For i = 0 To z - 1
                Dim UserID As String = sql2.SQLDS.Tables(0).Rows(i).Item("USERID")
                Dim sql3 As New SQLControl
                Dim Name As String = "NewEmployee"
                Dim SQLInsertingCheckEmp As String = " select UserIDInAttFile from EmployeesData where UserIDInAttFile= " & UserID
                sql3.SqlTrueTimeRunQuery(SQLInsertingCheckEmp)
                If sql3.SQLDS.Tables(0).Rows.Count = 0 Then
                    NewUsers = NewUsers + 1
                End If
            Next
            TextUnProcessedTrans.Text = GetCountUnProcessedTrans()
            TextNewEmployees.Text = NewUsers

            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم قراءة الحركات")
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                MsgBox("Done")
            End If


        Catch ex As Exception
            TextTotalReads.Text = 0

            XtraMessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Me.Dispose()

    End Sub

    Private Sub ReadClock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAttFilePath()
        If GlobalVariables._EndDate < Today Then
            Me.BtnRead.Enabled = False
            Me.BtnSave.Enabled = False
            Me.BtnRead.Text = "  .... النسخة انتهت ولا يمكن قراءة الساعة ....  "
        End If

    End Sub

    Private Sub GetAttFilePath()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery("select SettingValue  from Settings where SettingName='AttFilePath'")
            BarAttFilePath.Caption = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")

            sql.SqlTrueTimeRunQuery("select SettingValue  from Settings where SettingName='AttAplicationPath'")
            BarAttAplicationPath.Caption = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")

            sql.SqlTrueTimeRunQuery("select SettingValue  from Settings where SettingName='AttConnectionType'")
            BarAttConnectionType.Caption = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            GlobalVariables._AttConnectionType = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SaveData()
    End Sub
    Private Sub SaveData()

        Try
            TextTotalReads.Text = String.Empty
            TextUnProcessedTrans.Text = String.Empty
            TextNewEmployees.Text = 0
            ReadAttTransByRow()
            TextTotalReads.Text = MyGlobalString
            GetUsersTable()
            TextUnProcessedTrans.Text = GetCountUnProcessedTrans()
            TextNewEmployees.Text = NewUsers
        Catch ex As Exception
            TextTotalReads.Text = 0
            XtraMessageBox.Show("خطأ في حفظ الحركات")
        End Try


        Try
            Dim AttTable As New DataTable
            Dim con = New System.Data.OleDb.OleDbConnection()
            con.ConnectionString = AttConectionString()
            con.Open()
            '     Dim SQLString As String = " SELECT USERID,CHECKTIME,CHECKTYPE,SENSORID,sn FROM  CHECKINOUT where [AttProcess] is null  "
            Dim SQLString As String = " SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE,SENSORID,sn FROM  CHECKINOUT,USERINFO  where CHECKINOUT.USERID =USERINFO.USERID  AND [AttProcess] is null  "
            Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
            da.Fill(AttTable)
            con.Close()
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count > 0 Then


                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBox("حركات غير مقروءة عدد:" & " " & MyGlobalString,, "خطا")
                ElseIf GlobalVariables._SystemLanguage = "English" Then
                    MsgBox("UnRead Data : " & " " & MyGlobalString,, "Error")
                End If


                '   InsertLogs("حركات غير مقروءة", Me.Text, "لم يتم قراءة حركات عدد" & MyGlobalString)
                InsertLogs(GlobalVariables.CurrUser, "قراءة الساعة", Me.Text, Now, String.Empty, "لم يتم قراءة حركات عدد" & MyGlobalString, String.Empty, SQLString)
            Else

                If GlobalVariables._SystemLanguage = "Arabic" Then
                    XtraMessageBox.Show("تم حفظ الحركات")
                ElseIf GlobalVariables._SystemLanguage = "English" Then
                    XtraMessageBox.Show("Data Saved")
                End If



            End If

            If GlobalVariables._AttConnectionType = "Access" Then UpdateMachineName()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  select SettingValue from Settings where SettingName='AlqudsCig'")
            If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = False Then
                sql.SqlTrueAccountingRunQuery(" Update [dbo].[AttCHECKINOUT] set [CHECKTYPE]='I' where [CHECKTYPE]='0';Update [dbo].[AttCHECKINOUT] set [CHECKTYPE]='O' where [CHECKTYPE]='1'  ")
            ElseIf CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                sql.SqlTrueAccountingRunQuery(" Update [dbo].[AttCHECKINOUT] set [CHECKTYPE]='i' where [CHECKTYPE]='1';Update [dbo].[AttCHECKINOUT] set [CHECKTYPE]='o' where [CHECKTYPE]='0'  ")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Function ReadAttTransByRow() As Integer
        Dim _count As Integer = 0
        My.Forms.Main.ItemElapseTime.Caption = "0"
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        start_time = Now
        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)


        If GlobalVariables._SystemLanguage = "Arabic" Then
            SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            SplashScreenManager.Default.SetWaitFormCaption("Please Wait ")
        End If





        Dim SQLString As String = " SELECT  Badgenumber AS USERID,CHECKINOUT.USERID AS _ID,CHECKTIME,CHECKTYPE,SENSORID,sn 
                                    FROM  CHECKINOUT,USERINFO  
                                    Where CHECKINOUT.USERID =USERINFO.USERID  AND [AttProcess] is null order by CHECKTIME"
        Dim _USERID, _CHECKTYPE, _SENSORID, _ID As String
        Dim _sn As String = ""
        Dim _CHECKTIME As String
        Try
            Dim AttTable As New DataTable
            Dim SqlCon As New SqlConnection
            Dim Sqlcmd As New SqlCommand
            If IsNothing(GlobalVariables._AttConnectionType) Then GlobalVariables._AttConnectionType = "Access"
            Select Case GlobalVariables._AttConnectionType
                Case "Access"
                    '  Get CheckInOut Table from Access Data 
                    Dim con = New System.Data.OleDb.OleDbConnection With {.ConnectionString = AttConectionString()}
                    con.Open()
                    Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
                    da.Fill(AttTable)
                    ' Open SqlConnection
                    SqlCon.ConnectionString = My.Settings.TrueTimeConnectionString
                    SqlCon.Open()
                    Sqlcmd.Connection = SqlCon
                    ' Loop Through Temp Table
                    For i = 0 To AttTable.Rows.Count - 1
                        _USERID = AttTable.Rows(i).Item("USERID")
                        _CHECKTIME = Format(CDate(AttTable.Rows(i).Item("CHECKTIME")), "yyyy-MM-dd HH:mm:ss")
                        _CHECKTYPE = AttTable.Rows(i).Item("CHECKTYPE")
                        If Not IsDBNull(AttTable.Rows(i).Item("SENSORID")) Then _SENSORID = AttTable.Rows(i).Item("SENSORID") Else _SENSORID = "0"
                        _ID = AttTable.Rows(i).Item("_ID")
                        If Not IsDBNull(AttTable.Rows(i).Item("sn")) Then _sn = AttTable.Rows(i).Item("sn") Else _sn = "0"
                        Try
                            Dim SqlStringInsert As String = " Insert into [dbo].[AttCHECKINOUT] 
                                                              (USERID,CHECKTIME,CHECKTYPE,SENSORID,[sn]) 
                                                              Values
                                                              ('" & _USERID & "','" & _CHECKTIME & "','" &
                                                              _CHECKTYPE & "','" & _SENSORID & "','" & _sn & "') "
                            Sqlcmd.CommandText = (SqlStringInsert)
                            Sqlcmd.ExecuteNonQuery() ' Insert Row To SQL
                        Catch ex As Exception

                        End Try
                        Try
                            Dim _CHECKTIME_ As String = Format(CDate(_CHECKTIME), "MM-dd-yyyy HH:mm:ss")
                            Dim SqlStringUpdate As String = " Update  [CHECKINOUT] 
                                                         Set [AttProcess]=1 where USERID=" & _ID & " and
                                                         CHECKTIME=#" & _CHECKTIME_ & "#"
                            Dim AccessCmd As OleDbCommand = New OleDbCommand(SqlStringUpdate, con)
                            AccessCmd.ExecuteNonQuery() ' Update Row in Access
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                        If AttTable.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (AttTable.Rows.Count)) & "%")
                    Next
                    SqlCon.Close()
                    con.Close()
            End Select
            'Return AttTable.Rows.Count
            _count = AttTable.Rows.Count
        Catch ex As Exception
            MsgBox(ex.ToString)
            _count = 0
        End Try
        SplashScreenManager.CloseForm(False)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
        Return _count
        '     
    End Function ' قراءة حركات الساعة وادخالها الى البرنامج دفعة واحدة

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs)
        'InsertLogs("تم قراءة الساعة", "ReadAttTrans", "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers)
        '  InsertLogs(GlobalVariables.CurrUser, "loname", "formname", Now, "lastvalue", "logdetails", "error", SQLString)
    End Sub

    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub SimpleButton4_Click_2(sender As Object, e As EventArgs)
        UnEditProcess()
    End Sub

    Public Sub UnEditProcess()
        Dim SQLString As String = " Update CHECKINOUT set AttProcess = 1   "
        Try
            Select Case GlobalVariables._AttConnectionType
                Case "Access"
                    Dim con = New System.Data.OleDb.OleDbConnection With {.ConnectionString = AttConectionString()}
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand(SQLString, con)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    con.Close()
                Case "Sql"
                    Dim Sql As New SQLControl
                    Sql.SqlTrueTimeRunQuery(SQLString)
            End Select
            InsertLogs(GlobalVariables.CurrUser, "EditProcess", "EditProcess", Now, String.Empty, "تم تعديل عمود Processed", String.Empty, SQLString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            InsertLogs(GlobalVariables.CurrUser, "EditProcess", "EditProcess", Now, String.Empty, "خطا في تعديل عمود Processed", ex.ToString, String.Empty)
        End Try
    End Sub ' تعديل عمودالقراءة من فراغ الى قيمة 1
End Class