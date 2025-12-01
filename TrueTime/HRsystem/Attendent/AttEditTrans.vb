Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class AttEditTrans
    Private Sub AttEditTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.CheckTypes' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)

        '    LoadAttData()
        LookUpEdit2.Properties.ValueMember = "CheckType"
        If GlobalVariables._SystemLanguage = "Arabic" Then
            LookUpEdit2.Properties.DisplayMember = "InArabic"
            LookUpEdit2.Properties.Columns("InEnglish").Visible = False
            RepositoryItemLookUpEdit1.Columns("InEnglish").Visible = False
            RepositoryItemLookUpEdit1.DisplayMember = "InArabic"
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            LookUpEdit2.Properties.DisplayMember = "InEnglish"
            LookUpEdit2.Properties.Columns("InArabic").Visible = False
            RepositoryItemLookUpEdit1.Columns("InArabic").Visible = False
            RepositoryItemLookUpEdit1.DisplayMember = "InEnglish"
        End If

        '  LookUpEdit2.Properties.PopulateColumns()

        LookUpEdit2.EditValue = "I"
        Me.CheckTypesTableAdapter.Fill(Me.TrueTimeDataSet.CheckTypes)
        If CheckIfHasAccessToAddAttendanceTrans() = False Then
            BtnAddAttTrans.Visible = False
            LayoutGroupAddAttTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        If CheckIfHasAccessToEditAttendanceTrans() = False Then
            ColAttEdit.Visible = False
        End If
        If CheckIfHasAccessToDeleteAttendanceTrans() = False Then
            ColAttDelete.Visible = False
        End If
    End Sub

    'Private Sub AddOrEditTrans()
    '    Try


    '        Dim sql As New SQLControl
    '        Dim EmpNmaeValu As String = SearchLookUpEdit1.EditValue
    '        Dim EmpNmae As String = SearchLookUpEdit1.Text
    '        Dim AttDateTimeIN As String = Format(DateEdit1.DateTime, "yyyy-MM-dd") & " " & Format(TimeEdit1.Time, "HH:mm")
    '        Dim AttDateTimeOUT As String = Format(DateEdit1.DateTime, "yyyy-MM-dd") & " " & Format(TimeEdit2.Time, "HH:mm")
    '        If Format(TimeEdit1.Time, "HH:mm") > Format(TimeEdit2.Time, "HH:mm") Then XtraMessageBox.Show(" وقت الدخول اكبر من وقت الخروج ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
    '        Dim MsgString As String = EmpNmae & " : " & AttDateTimeIN & " : " & AttDateTimeOUT
    '        Dim AttIN As String = ""
    '        Dim AttOut As String = ""



    '        If ComboBoxEdit1.SelectedIndex.ToString = "0" Then
    '            AttIN = "I"
    '            AttOut = "O"
    '        ElseIf ComboBoxEdit1.SelectedIndex.ToString = "1" Then
    '            AttIN = "i"
    '            AttOut = "o"
    '        End If

    '        If EmpNmaeValu = "" Then XtraMessageBox.Show("الموظف فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    '        If AttDateTimeIN = "" Then XtraMessageBox.Show(" وقت  حركة الدخول فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    '        If AttDateTimeOUT = "" Then XtraMessageBox.Show(" وقت  حركة الخروج فارع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
    '        If AttIN = "" Or AttOut = "" Then XtraMessageBox.Show(" يجب تحديد نوع الحركة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub


    '        '     Dim Msg As DialogResult = XtraMessageBox.Show("  هل تريد حفظ الحركة   " & MsgString, "تأكيد", MessageBoxButtons.YesNo)
    '        '     If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub



    '        Dim InsertAttStringIN As String = "Insert Into AttCHECKINOUT (USERID,CHECKTIME,CHECKTYPE,EditedDate,EditedType,Edited) Values
    '                                          (" & EmpNmaeValu & " , '" & AttDateTimeIN & "' , '" & AttIN & "' , GETDATE() , 'Insert',1)"

    '        Dim UpdateAttStringIn As String = "Update [AttCHECKINOUT] set EditedType = 'Update', CHECKTIME ='" & AttDateTimeIN & "'  , 
    '                                          Edited=1,   [EditedDate]=GETDATE() where [ID]=" & TransIDINTextEdit.Text

    '        Dim InsertAttStringOUT As String = "Insert Into AttCHECKINOUT (USERID,CHECKTIME,CHECKTYPE,EditedDate,EditedType,Edited) Values
    '                                          (" & EmpNmaeValu & " , '" & AttDateTimeOUT & "' , '" & AttOut & "' , GETDATE() , 'Insert',1)"

    '        Dim UpdateAttStringOut As String = "Update [AttCHECKINOUT] set EditedType = 'Update',  CHECKTIME ='" & AttDateTimeOUT & "'  , 
    '                                          Edited=1,  [EditedDate]=GETDATE() where [ID]=" & TransIDOutTextEdit.Text

    '        Dim Result As String = ""
    '        Select Case TransIDINTextEdit.Text
    '            Case > 0
    '                ArchiveTrans(TransIDINTextEdit.Text, AttDateTimeIN, AttIN, "Edit")
    '                sql.SqlTrueTimeRunQuery(UpdateAttStringIn)
    '                Result = Result + " تم تعديل حركة الدخول "
    '            Case = 0
    '                sql.SqlTrueTimeRunQuery(InsertAttStringIN)
    '                Result = Result + " تم ادخال حركة الدخول "
    '        End Select

    '        Select Case TransIDOutTextEdit.Text
    '            Case > 0
    '                ArchiveTrans(TransIDOutTextEdit.Text, AttDateTimeOUT, AttOut, "Edit")
    '                sql.SqlTrueTimeRunQuery(UpdateAttStringOut)
    '                Result = Result + " تم تعديل حركة الخروج "
    '            Case = 0
    '                sql.SqlTrueTimeRunQuery(InsertAttStringOUT)
    '                Result = Result + " تم ادخال حركة الخروج "
    '        End Select






    '        XtraMessageBox.Show("" & Result, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Catch ex As Exception
    '        MsgBox(ex.ToString)
    '        MsgBox("خطا :  لم يتم ادخال الحركة")
    '    End Try
    'End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        Try

            '  Dim i As Integer
            If Me.SearchLookUpEdit1.EditValue = "0" Then Exit Sub
            '  If Me.SearchLookUpEdit1.EditValue = 0 Then Exit Sub

            Dim sql As New SQLControl
            Dim SQLString As String = "  Select  [EmployeesData].EmployeeName,[EmployeesData].[PictureEmp]  as EmpImage 
                                         FROM [EmployeesData]
                                         where EmployeeID= '" & SearchLookUpEdit1.EditValue & "'"



            sql.SqlTrueTimeRunQuery(SQLString)

            If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
            'If sql.SQLDS.Tables(0).Rows(i).Item("EmpImage").ToString <> "" Then
            '    Dim bytes As [Byte]() = CType(sql.SQLDS.Tables(0).Rows(i).Item("EmpImage"), Byte())
            '    Dim ms As New MemoryStream(bytes)
            '    PictureEdit1.Image = Image.FromStream(ms)
            'End If

            LoadAttDataWhithoutMachine()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub LoadAttData()

        Dim DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd HH:mm")
        Dim DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd HH:mm")

        If DateFrom = "0001-01-01 00:00" Or DateTo = "0001-01-01 00:00" Or DateFrom = "2000-01-01 00:10" Or DateTo = "2000-01-01 00:10" Then
            Exit Sub
        End If
        Try
            If String.IsNullOrWhiteSpace(SearchLookUpEdit1.EditValue) Or SearchLookUpEdit1.EditValue = "0" Then Exit Sub
            Dim Sql As New SQLControl
            Dim SQLString2 As String = " Select AttCHECKINOUT.[ID],USERID,EmployeeName, 
CHECKTIME,CHECKTYPE , Edited , EditedDate  ,
EditedType,EditedUser,EditNote,Machines.[MachineAlias],Latitude,Longitude
                                    From AttCHECKINOUT
                                    left join EmployeesData on  AttCHECKINOUT.UserID = EmployeesData.UserIDInAttFile
                                    left join [Machines] on AttCHECKINOUT.[SENSORID]= [Machines].[sn] 
                                    where  CHECKTIME between '" & DateFrom & "' and '" & DateTo & "' and USERID='" & SearchLookUpEdit1.EditValue & "'  order by CHECKTIME,ID "
            Sql.SqlTrueTimeRunQuery(SQLString2)
            GridControl2.DataSource = Sql.SQLDS.Tables(0)
            GridView2.BestFitColumns()
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try

        Try
            Dim AttTable As New DataTable
            Dim con = New System.Data.OleDb.OleDbConnection()
            con.ConnectionString = AttConectionString()

            con.Open()
            Dim SelectCase As String = " Case
                                     when CHECKTYPE='I' COLLATE Latin1_General_CS_AS then 'دخول'
                                     when CHECKTYPE='O' COLLATE Latin1_General_CS_AS then 'خروج'
                                     when CHECKTYPE='i' COLLATE Latin1_General_CS_AS then 'دخول مهمة'  
                                     when CHECKTYPE='o' COLLATE Latin1_General_CS_AS then 'خروج مهمة' "
            Dim SQLString As String = " SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE
                                    FROM  CHECKINOUT,USERINFO 
                                    where CHECKINOUT.USERID =USERINFO.USERID AND  
                                          Badgenumber='" & SearchLookUpEdit1.EditValue & "' 
                                          and CHECKINOUT.CHECKTIME between #" & (DateFrom) & "# and #" & (DateTo) & "#"
            Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
            da.Fill(AttTable)
            con.Close()
            GridControl1.DataSource = AttTable
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub GetAttOriginalData()
        Dim fromDate As String = Format(Me.DateFrom.DateTime, "yyyy-MM-dd HH:mm")
        Dim toDate As String = Format(Me.DateTo.DateTime, "yyyy-MM-dd HH:mm")
        If fromDate = "0001-01-01 00:00" Or toDate = "0001-01-01 00:00" Or fromDate = "2000-01-01 00:10" Or toDate = "2000-01-01 00:10" Then
            Exit Sub
        End If

        Try
            Dim AttTable As New DataTable
            Dim con = New System.Data.OleDb.OleDbConnection()
            con.ConnectionString = AttConectionString()

            con.Open()
            Dim SelectCase As String = " Case
                                     when CHECKTYPE='I' COLLATE Latin1_General_CS_AS then 'دخول'
                                     when CHECKTYPE='O' COLLATE Latin1_General_CS_AS then 'خروج'
                                     when CHECKTYPE='i' COLLATE Latin1_General_CS_AS then 'دخول مهمة'  
                                     when CHECKTYPE='o' COLLATE Latin1_General_CS_AS then 'خروج مهمة' "
            Dim SQLString As String = " SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE
                                    FROM  CHECKINOUT,USERINFO 
                                    where CHECKINOUT.USERID =USERINFO.USERID AND  
                                          Badgenumber='" & SearchLookUpEdit1.EditValue & "' 
                                          and CHECKINOUT.CHECKTIME between #" & (fromDate) & "# and #" & (toDate) & "#"
            Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
            da.Fill(AttTable)
            con.Close()
            GridControl1.DataSource = AttTable
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LoadAttDataWhithoutMachine()
        ' If Me.IsHandleCreated = False Then Exit Sub
        Try
            Dim DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd HH:mm")
            Dim DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd HH:mm")

            If DateFrom = "0001-01-01 00:00" Or DateTo = "0001-01-01 00:00" Or DateFrom = "2000-01-01 00:10" Or DateTo = "2000-01-01 00:10" Then
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(SearchLookUpEdit1.EditValue) Or SearchLookUpEdit1.EditValue = "0" Then
                ' XtraMessageBox.Show("خطأ: يجب اختيار الموظف")
                Exit Sub
            End If

            Dim Sql As New SQLControl
            Dim SQLString2 As String = " Select AttCHECKINOUT.[ID],USERID,EmployeeName, CHECKTIME,CHECKTYPE ,
Edited , EditedDate  ,EditedType,EditedUser,EditNote,Latitude,[Longitude]
                                    From AttCHECKINOUT
                                    left join EmployeesData on  AttCHECKINOUT.UserID = EmployeesData.UserIDInAttFile
                                    where  CHECKTIME between '" & DateFrom & "' and '" & DateTo & "' and USERID='" & SearchLookUpEdit1.EditValue & "'  order by CHECKTIME,ID "
            Sql.SqlTrueTimeRunQuery(SQLString2)
            GridControl2.DataSource = Sql.SQLDS.Tables(0)
            GridView2.BestFitColumns()

            Dim AttTable As New DataTable
            Dim con = New System.Data.OleDb.OleDbConnection()
            con.ConnectionString = AttConectionString()

            con.Open()
            Dim SelectCase As String = " Case
                                     when CHECKTYPE='I' COLLATE Latin1_General_CS_AS then 'دخول'
                                     when CHECKTYPE='O' COLLATE Latin1_General_CS_AS then 'خروج'
                                     when CHECKTYPE='i' COLLATE Latin1_General_CS_AS then 'دخول مهمة'  
                                     when CHECKTYPE='o' COLLATE Latin1_General_CS_AS then 'خروج مهمة' "
            Dim SQLString As String = " SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE
                                    FROM  CHECKINOUT,USERINFO 
                                    where CHECKINOUT.USERID =USERINFO.USERID AND  
                                          Badgenumber='" & SearchLookUpEdit1.EditValue & "' 
                                          and CHECKINOUT.CHECKTIME between #" & (DateFrom) & "# and #" & (DateTo) & "#"
            Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
            da.Fill(AttTable)
            con.Close()
            GridControl1.DataSource = AttTable
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try






    End Sub


    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged
        LoadAttDataWhithoutMachine()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        LoadAttDataWhithoutMachine()
    End Sub

    Private Sub RepositoryItemButtonDelet_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonDelet.ButtonClick
        Try
            '  MsgBox(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTIME"))
            Dim USERID As String = CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "USERID"), String)
            Dim CHECKTYPE As String = CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTYPE"), String)
            Dim CHECKTime As String = Format(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTIME"), "yyyy-MM-dd HH:mm")
            '   MsgBox(CHECKTime)

            If GlobalVariables._SystemLanguage = "Arabic" Then
                Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد حذف الحركة", "تأكيد", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                Dim Msg As DialogResult = XtraMessageBox.Show("Delete Trans.?", "Are You Sure", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            End If




            ArchiveTrans(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID"), CHECKTime, CHECKTYPE, "Delete", CInt(USERID))
            Dim DeleteString As String = " Delete from  [AttCHECKINOUT]  where [ID]=" & CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID"), String)

            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(DeleteString)
            LoadAttDataWhithoutMachine()
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("لم يتم حذف الحركة")
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit.ButtonClick
        Try
            'If GlobalVariables._AttAllowEditAttTrans = False Then
            '    XtraMessageBox.Show("لا يوجد صلاحية لتعديل الحركة")
            '    Exit Sub
            'End If

            If GlobalVariables._SystemLanguage = "Arabic" Then
                Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد تعديل الحركة", "تأكيد", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                Dim Msg As DialogResult = XtraMessageBox.Show("Are You Want Edit Tans?", " ", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            End If



            Dim CHECKTYPE As String = CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTYPE"), String)
            Dim CHECKTime As String = Format(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTIME"), "yyyy-MM-dd HH:mm")
            Dim CurrDateTime As String = Format(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "CHECKTIME"), "yyyy-MM-dd HH:mm")
            Dim EditNote As String = ""

            If GlobalVariables._AttNoteRequiredforAttTrans = True Then
                If IsDBNull(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EditNote")) Then
                    XtraMessageBox.Show("يجب وضع ملاحظة عند التعديل")
                    Exit Sub
                Else
                    EditNote = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EditNote")
                End If
                If String.IsNullOrEmpty(EditNote) Then
                    XtraMessageBox.Show("يجب وضع ملاحظة عند التعديل")
                    Exit Sub
                End If
            End If


            If Len(EditNote) >= 50 Then
                MsgBox("نص تعديل الملاحظة طويل ")
                Exit Sub
            End If
            If Not IsDBNull(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EditNote")) Then
                EditNote = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "EditNote")
            Else
                EditNote = ""
            End If

            Dim USERID As String = CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "USERID"), String)
            ArchiveTrans(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID"), CHECKTime, CHECKTYPE, "Update", CInt(USERID))

            Dim UpdateString As String = " Update [AttCHECKINOUT] set EditedType = 'Update',
                                           CHECKTIME ='" & CurrDateTime & "' ,
                                           CHECKTYPE= '" & CHECKTYPE & "' ,
                                           EditNote=N'" & EditNote & "',
                                           [EditedDate]=GETDATE(), 
                                           [EditedUser]='" & GlobalVariables.CurrUser & "' 
                                           where [ID]=" & CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID"), String)
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(UpdateString)
            LoadAttDataWhithoutMachine()
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("خطا : لم يتم تعديل الحركة")
        End Try
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles BtnAddAttTrans.Click
        'If GlobalVariables._AllowAddAttTrans = False Then
        '    XtraMessageBox.Show("لا يوجد صلاحية لاضافة الحركة")
        '    Exit Sub
        'End If
        Try
            Dim EmpNmaeValu As String = SearchLookUpEdit1.EditValue
            Dim EmpNmae As String = SearchLookUpEdit1.Text
            Dim AttDateTime As String = Format(DateEdit3.DateTime, "yyyy-MM-dd HH:mm")
            Dim AttType As String = LookUpEdit2.Text
            Dim AttTypeValue As String = LookUpEdit2.EditValue
            Dim _TransNote As String = TextTransNote.Text
            '   Dim MsgString As String = EmpNmae & " : " & AttDateTime & " : " & AttType

            If GlobalVariables._SystemLanguage = "Arabic" Then
                If EmpNmaeValu = String.Empty Then XtraMessageBox.Show("الموظف فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If AttDateTime = String.Empty Then XtraMessageBox.Show(" وقت الحركة فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If AttTypeValue = String.Empty Then XtraMessageBox.Show(" نوع الحركة فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                If EmpNmaeValu = String.Empty Then XtraMessageBox.Show("Empty Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If AttDateTime = String.Empty Then XtraMessageBox.Show(" Empty Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
                If AttTypeValue = String.Empty Then XtraMessageBox.Show(" Trans. Type Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If


            If GlobalVariables._AttNoteRequiredforAttTrans = True Then
                If String.IsNullOrEmpty(Me.TextTransNote.Text) Then
                    XtraMessageBox.Show("خطأ: يجب ادخال ملاحظة لاعتماد الحركة")
                    Exit Sub
                End If
            End If

            If Format(CDate(AttDateTime), "HH:mm") = "00:00" Then
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    Dim Msg As DialogResult = XtraMessageBox.Show(" الوقت المدخل 00:00 هل تريد الاستمرار؟ ", "تأكيد", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                ElseIf GlobalVariables._SystemLanguage = "English" Then
                    Dim Msg As DialogResult = XtraMessageBox.Show(" Time is 00:00 ", "Are you Sure?", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                End If
            End If



            Dim InsertAttString As String = "Insert Into AttCHECKINOUT (USERID,CHECKTIME,CHECKTYPE,EditedDate,EditedType,Edited,EditNote) Values
                                            (" & EmpNmaeValu & " , '" & AttDateTime & "' , '" & AttTypeValue & "' , GETDATE() , 'Insert',1,N'" & _TransNote & "')"

            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(InsertAttString)

            LoadAttDataWhithoutMachine()


            If AttTypeValue = "I" Then DateEdit2.DateTime = CDate(AttDateTime).AddHours(23.59)


            If LookUpEdit2.EditValue = "I" Then
                LookUpEdit2.EditValue = "O"
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("خطا : لم يتم ادخال الحركة")
        End Try

    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        LoadAttDataWhithoutMachine()
    End Sub

    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub LookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit2.EditValueChanged

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryGPSLocation.ButtonClick
        Dim Latitude As String = GridView2.GetFocusedRowCellValue("Latitude")
        Dim Longitude As String = GridView2.GetFocusedRowCellValue("Longitude")
        If Not IsDBNull(GridView2.GetFocusedRowCellValue("Latitude")) AndAlso
            Not IsDBNull(GridView2.GetFocusedRowCellValue("Longitude")) Then
            If Latitude <> "0.000000" And Latitude <> "0.000000" Then
                Dim f As New AttGetMap
                With f
                    If CDec(Longitude) > CDec(Latitude) Then
                        .teLatitude.Text = GridView2.GetFocusedRowCellValue("Latitude")
                        .teLongitude.Text = GridView2.GetFocusedRowCellValue("Longitude")
                    Else
                        .teLatitude.Text = GridView2.GetFocusedRowCellValue("Longitude")
                        .teLongitude.Text = GridView2.GetFocusedRowCellValue("Latitude")
                    End If
                    .ShowDialog()
                End With
            Else
                MsgBoxShowError(" لا يوجد احداثيات ")
            End If
        End If



    End Sub

    Private Sub AttEditTrans_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            If Not String.IsNullOrWhiteSpace(txtPlaneID.Text) Then
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " Update [AttPlaneForPeriod] set 
                        StartTime='" & TimeSpanEdit1.EditValue.ToString & "',
                        EndTime='" & TimeSpanEdit2.EditValue.ToString & "' 
                        where [ID]=" & txtPlaneID.Text
                'MsgBox(sqlstring)
                If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
                    MsgBoxShowSuccess(" تم تعديل الوردية بنجاح ")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RepositoryAttLog_Click(sender As Object, e As EventArgs) Handles RepositoryAttLog.Click
        Dim _Id As Integer
        _Id = GridView2.GetFocusedRowCellValue("ID")
        Dim F As New AttEditLog(_Id)
        F.ShowDialog()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " select * from [DeletedEditedTrans] where EmployeeID='" & SearchLookUpEdit1.EditValue & "'"
        sql.SqlTrueTimeRunQuery(sqlString)
        GridControl3.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub BtnRefreshOrigionalData_Click(sender As Object, e As EventArgs) Handles BtnRefreshOrigionalData.Click
        GetAttOriginalData()
    End Sub
End Class