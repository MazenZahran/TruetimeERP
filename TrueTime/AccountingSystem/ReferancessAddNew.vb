Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Utils
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Data.SqlTypes


Public Class ReferancessAddNew
    Public _AddNewOrSave As String = ""
    Dim AdapterSubRef As SqlDataAdapter
    Dim dataSet11 As DataSet
    Dim Con As SqlConnection
    Private Sub GetRefSub()
        Dim sqlString As String
        sqlString = " Select * From [dbo].[ReferancesSub] Where [RefNo]='" & TextRefNo.Text & "'"
        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
        Con.Open()
        AdapterSubRef = New SqlDataAdapter(sqlString, Con)
        dataSet11 = New System.Data.DataSet()
        AdapterSubRef.Fill(dataSet11, "ReferancesSub")
        Me.GridControlSubRef.DataSource = dataSet11.Tables("ReferancesSub")
        Con.Close()
    End Sub
    Private Sub ReferancessAddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoaddefaultDataSourceforReferences()
        TextRefName.Select()
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroup1
        If GlobalVariables._UserAccessType = 98 Then
            'LayoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'LayoutControlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        Me.KeyPreview = True
        SearchEmployees.Properties.DataSource = GetEmployeesTable(-1, -1)
        LookUpEditDays.Properties.DataSource = GetWeekDaysNames()
        SwitchKeyboardLayout("ar")


    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            AddNewOrSaveReferanc()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Public Sub LoaddefaultDataSourceforReferences()
        SearchRefAccID.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        LookRefType.Properties.DataSource = GetReferancessTypes(False)
        PriceCategory.Properties.DataSource = GetPriceCategory()
        SearchCity.Properties.DataSource = GetRefCities()
        SearchSort.Properties.DataSource = GetRefSorts(False)
    End Sub
    Private Sub AddNewOrSaveReferanc()
        If String.IsNullOrEmpty(SearchRefAccID.Text) Then
            XtraMessageBox.Show("يجب تحديد نوع الذمة")
            Exit Sub
        End If
        If IsNothing(SearchRefAccID.EditValue) Then
            XtraMessageBox.Show("يجب تحديد نوع الذمة")
            Exit Sub
        End If


        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim _RefNo As Integer
        Dim _RefName, _RefType, _RefMobile, _RefPhone, _PriceCategory, _RefAccID, _TextRefEmail, _SearchCity,
            _SubscribeAmount, _SearchSort, _DateBirthDate, _RefMemo, _StartDate, _Address, _ReferanceCode,
            _IdentityNo, _ContactPerson, _SalesManDay
        Dim _SalesMan As Integer = 0
        Dim _MaxDebit As Decimal
        Dim _Active As Integer
        _RefNo = TextRefNo.EditValue
        _RefName = TextRefName.Text
        _RefType = LookRefType.EditValue
        _RefMobile = TextRefMobile.Text
        _RefPhone = TextRefPhone.Text
        _RefAccID = SearchRefAccID.EditValue
        _PriceCategory = CStr(PriceCategory.EditValue)
        _TextRefEmail = TextRefEmail.Text
        _SearchCity = SearchCity.EditValue
        _SubscribeAmount = TextSubscribeAmount.Text
        _SearchSort = SearchSort.EditValue
        _Address = TextRefAddress.EditValue
        _DateBirthDate = Format(DateBirthDate.DateTime, "yyyy-MM-dd")
        _ReferanceCode = TextReferanceCode.Text
        If _DateBirthDate = "0001-01-01" Then _DateBirthDate = String.Empty
        _RefMemo = RefMemo.Text
        _StartDate = Format(DateStart.DateTime, "yyyy-MM-dd")
        If _StartDate = "0001-01-01" Then _StartDate = String.Empty
        _Active = CheckActive.EditValue
        _IdentityNo = Me.IdentityNo.Text
        _SalesMan = Me.SearchEmployees.EditValue
        _ContactPerson = Me.ContactPerson.Text
        _MaxDebit = Me.txtMaxDebit.EditValue
        If Me.LookUpEditDays.Text = "" Then
            _SalesManDay = 0
        Else
            _SalesManDay = Me.LookUpEditDays.EditValue
        End If


        'If _AddNewOrSave = "AddNew" Then
        '    If GlobalVariables.ConnectedWithTrueAccounting = True Then
        '        If CheckIfFoundInTrueTime(_RefNo) = True Then
        '            XtraMessageBox.Show("الحساب معرف بقائمة الموظفين")
        '            Exit Sub
        '        End If
        '    End If

        '    'If IfFound() = True Then
        '    '    XtraMessageBox.Show("المرجع معرف مسبفا")
        '    '    Exit Sub
        '    'End If
        'End If


        Try
            If String.IsNullOrEmpty(_RefNo) Or _RefNo = "0" Then
                XtraMessageBox.Show("يجب تعبئة رقم المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            If String.IsNullOrEmpty(_RefName) Then
                XtraMessageBox.Show("يجب تعبئة اسم المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If String.IsNullOrEmpty(_RefType) Then
                XtraMessageBox.Show("يجب تعبئة نوع المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If String.IsNullOrEmpty(_RefType) Then
                XtraMessageBox.Show("يجب تعبئة حساب المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If String.IsNullOrEmpty(_PriceCategory) Then
                XtraMessageBox.Show("يجب تعبئة فئة السعر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If _SubscribeAmount = "" Then _SubscribeAmount = 0
            If CStr(Me.SearchSort.Text) = "" Then _SearchSort = 0
            If CStr(SearchCity.Text) = "" Then _SearchCity = 0

            If _AddNewOrSave = "AddNew" Then
                If IfFound() = True Then
                    MsgBox("الذمة معرفة مسبقا يرجى اعادة اختيار رقم ")
                    Exit Sub
                End If
                SqlString = "  Insert into Referencess (RefNo,RefName,RefType,RefMobile,
                                                   RefPhone,RefAccID,PriceCategory,RefEmail,
                                                   SearchCity,SubscribeAmount,RefSort,RefBirthDate,
                                                   RefMemo,[Active],[DateStart],[Address],[ReferanceCode],[IdentityNo],[SalesMan],[ContactPerson],MaxDebit,SalesManDay)
                          Values ( " & _RefNo & ",N'" & _RefName & "','" & _RefType & "',
                                   '" & _RefMobile & "','" & _RefPhone & "','" & _RefAccID & "',
                                   '" & _PriceCategory & "',N'" & _TextRefEmail & "',
                                   '" & _SearchCity & "'," & _SubscribeAmount & ",
                                    " & _SearchSort & ",'" & _DateBirthDate & "',N'" & _RefMemo & "',
                                    " & 1 & ",'" & _StartDate & "',N'" & _Address & "','" & _ReferanceCode & "','" & _IdentityNo & "','" & _SalesMan & "',N'" & _ContactPerson & "'," & _MaxDebit & "," & _SalesManDay & ") "

                If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                    XtraMessageBox.Show("تم اضافة " & LookRefType.Text)
                    GlobalVariables._ReferanceNoGlobal = Me.TextRefNo.Text
                    GlobalVariables._ReferanceNameGlobal = Me.TextRefName.Text
                    CreateDocLog("File", "", "0", Me.TextRefNo.Text, "Insert", "Add New Referance" & ":" & Me.TextRefName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))

                    If GlobalVariables._Shalash = True Then
                        SendSMSMessage(CStr("120363402096399877"), Me.TextRefName.Text & "  " & Me.TextRefNo.Text, "WhatsApp", True, Me.TextRefName.Text)
                    End If
                Else
                    XtraMessageBox.Show("لا يمكن اضافة المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            If _AddNewOrSave = "Save" Then
                SqlString = " Update Referencess Set 
                                                 RefName=N'" & _RefName & "',
                                                 RefType='" & _RefType & "',
                                                 RefMobile='" & _RefMobile & "',
                                                 RefPhone='" & _RefPhone & "',
                                                 RefAccID='" & _RefAccID & "',
                                                 PriceCategory='" & _PriceCategory & "',
                                                 RefEmail='" & _TextRefEmail & "',
                                                 SearchCity='" & _SearchCity & "',
                                                 SubscribeAmount='" & _SubscribeAmount & "',
                                                 RefSort='" & _SearchSort & "',
                                                 RefBirthDate='" & _DateBirthDate & "',
                                                 RefMemo =N'" & _RefMemo & "',
                                                 [Active] = " & _Active & ",
                                                 [DateStart]='" & _StartDate & "',
                                                 [Address]=N'" & _Address & "',
                                                 [ReferanceCode]=N'" & _ReferanceCode & "',
                                                 [IdentityNo]=N'" & _IdentityNo & "',
                                                 [SalesMan]=N'" & _SalesMan & "',
                                                 [ContactPerson]=N'" & _ContactPerson & "',
                                                 [MaxDebit]=N'" & _MaxDebit & "',
                                                 [SalesManDay]=N'" & _SalesManDay & "'
                               Where RefNo=" & TextRefNo.Text

                If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                    Dim SqlCommBuil As SqlCommandBuilder
                    SqlCommBuil = New SqlCommandBuilder(AdapterSubRef)
                    AdapterSubRef.Update(dataSet11, "ReferancesSub")
                    XtraMessageBox.Show("تم تعديل البيانات ")
                    CreateDocLog("File", "", "0", Me.TextRefNo.Text, "Update", "Edit Referance" & ":" & Me.TextRefName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                Else
                    XtraMessageBox.Show("لا يمكن حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

            If Not PictureEdit1.Image Is Nothing Then
                Dim m As New IO.MemoryStream
                PictureEdit1.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhoto(b, _RefNo)
            End If

            Me.Dispose()
        Catch ex As Exception
            ' XtraMessageBox.Show("لا يمكن اضافة المرجع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.ToString)
        End Try


        ' My.Forms.AccStockMove.Referance.EditValue = TextRefNo.EditValue
        SwitchKeyboardLayout("ar")
    End Sub
    Private Sub SavePhoto(ByVal bytPhoto As Byte(), _RefNo As Integer)
        Try
            Dim SQLString As String = " UPDATE Referencess "
            SQLString = SQLString + " SET RefImage = @photo "
            SQLString = SQLString + " WHERE RefNo = " & _RefNo
            Dim cn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(SQLString, cn)
                cmd.Parameters.Add("@photo", SqlDbType.Image, bytPhoto.Length).Value = bytPhoto
                Try
                    cmd.ExecuteNonQuery()
                Catch SqlExceptionErr As SqlClient.SqlException
                    MessageBox.Show(SqlExceptionErr.Message)
                End Try
            End Using
            cn.Close()
        Catch ex As Exception
            ' XtraMessageBox.Show("خطا: لم يتم حفظ الصورة")
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function IfFound() As Boolean
        Dim _IfFound As Boolean
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select RefNo from Referencess where RefNo='" & TextRefNo.Text & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _IfFound = True
            End If
        Catch ex As Exception
            _IfFound = False
        End Try
        Return _IfFound
    End Function
    Private Sub FleetName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextRefNo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "1234567890"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Or e.KeyChar = " " Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextRefNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextRefNo.EditValueChanged
        Try
            If IfFound() = True Then
                Me.Text = " تعديل ذمة " & Me.TextRefName.Text
                _AddNewOrSave = "Save"
                Dim _RefData = GetRefranceData(TextRefNo.Text)
                With _RefData
                    TextRefName.Text = .RefName
                    LookRefType.EditValue = .RefType
                    SearchSort.EditValue = .RefSort
                    TextRefMobile.Text = .RefMobile
                    TextRefPhone.Text = .RefPhone
                    TextRefEmail.Text = .RefEmail
                    SearchCity.EditValue = .SearchCity
                    SearchRefAccID.EditValue = .RefAccID
                    TextSubscribeAmount.EditValue = .SubscribeAmount
                    PriceCategory.EditValue = .PriceCategory
                    DateBirthDate.DateTime = .RefBirthDate
                    RefMemo.Text = .RefMemo
                    CheckActive.EditValue = ._IsActive
                    DateStart.DateTime = .StartDate
                    TextRefAddress.Text = ._Address
                    TextReferanceCode.Text = ._ReferanceCode
                    IdentityNo.Text = ._IdentityNo
                    GridControl2.DataSource = GetAttachmentsByReferance(TextRefNo.Text)
                    SearchEmployees.EditValue = .SalesMan
                    Me.ContactPerson.Text = .ContactPerson
                    txtMaxDebit.Text = .MaxDebit
                    Me.LookUpEditDays.EditValue = .SalesManDay
                    If Accounting_UseSubAccounts = True Then
                        Me.TabSubRef.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    End If
                    GetRefSub()
                End With

                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select RefImage From [dbo].[Referencess] where RefNo='" & TextRefNo.Text & "'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
                Me.PictureEdit1.Image = Nothing
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("RefImage")) Then
                    Dim photo_aray As Byte()
                    photo_aray = CType(Sql.SQLDS.Tables(0).Rows(0).Item("RefImage"), Byte())
                    Dim ms As MemoryStream = New MemoryStream(photo_aray)
                    PictureEdit1.Image = Image.FromStream(ms)
                End If
            Else
                _AddNewOrSave = "AddNew"
                CheckActive.Checked = True
                Me.Text = " اضافة ذمة جديدة "
                TextRefName.Text = ""
                SearchSort.Text = ""
                TextRefMobile.Text = ""
                TextRefPhone.Text = ""
                TextRefEmail.Text = ""
                SearchCity.Text = ""
                TextSubscribeAmount.EditValue = 0
                PriceCategory.EditValue = 1
                DateBirthDate.DateTime = Today
                RefMemo.Text = ""
                CheckActive.EditValue = True
                DateStart.DateTime = Today
                TextRefAddress.Text = ""
                TextReferanceCode.Text = ""
                IdentityNo.Text = ""
                GridControl2.DataSource = GetAttachmentsByReferance(-1)
                SearchEmployees.EditValue = 0
                ContactPerson.Text = ""
                txtMaxDebit.EditValue = 0
                Me.LookUpEditDays.EditValue = 0
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LookRefType_EditValueChanged(sender As Object, e As EventArgs) Handles LookRefType.EditValueChanged
        'Select Case LookRefType.EditValue
        '    Case 1 'مورد
        '        SearchRefAccID.EditValue = 2101000000
        '    Case 2
        '        SearchRefAccID.EditValue = 1104010000
        '    Case 99
        '        SearchRefAccID.EditValue = 2102000000
        'End Select

        If CheckIfHasRefHasTrans(TextRefNo.EditValue) = False Then
            SearchRefAccID.EditValue = GetFinancialAccountForRefType(LookRefType.EditValue)
        Else
            SearchRefAccID.ReadOnly = True
        End If




    End Sub

    Private Sub TextRefName_Validating(sender As Object, e As CancelEventArgs) Handles TextRefName.Validating
        TextRefName.Text = TextRefName.Text.Replace(",", "").Replace("'", "")
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        AddNewOrSaveReferanc()
    End Sub

    Private Sub TextRefNo_Leave(sender As Object, e As EventArgs) Handles TextRefNo.Leave

    End Sub

    Private Sub ReferancessAddNew_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub SearchCity_AddNewValue(sender As Object, e As EventArgs) Handles SearchCity.AddNewValue
        My.Forms.AccountingLists.NavigationPane1.SelectedPage = My.Forms.AccountingLists.Cities
        AccountingLists.ShowDialog()
    End Sub
    Private Sub SearchCity_BeforePopup(sender As Object, e As EventArgs) Handles SearchCity.BeforePopup
        SearchCity.Properties.DataSource = GetRefCities()
    End Sub

    Private Sub SearchSort_AddNewValue(sender As Object, e As EventArgs) Handles SearchSort.AddNewValue
        My.Forms.AccountingLists.NavigationPane1.SelectedPage = My.Forms.AccountingLists.RefSorts
        AccountingLists.ShowDialog()
    End Sub
    Private Sub SearchSort_BeforePopup(sender As Object, e As EventArgs) Handles SearchSort.BeforePopup
        SearchSort.Properties.DataSource = GetRefSorts(False)
    End Sub

    Private Sub RepositoryOpenFile_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryOpenFile.ButtonClick
        Dim File As String = CType(Me.GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "DocID"), String)
        LoadPdfFile(File)
        Dim mydialogbox As New AttachmentDispaly
        AttachmentDispaly.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AttachmentsBulkAdd.ReferanceID.EditValue = TextRefNo.EditValue
        AttachmentsBulkAdd.ReferanceID.ReadOnly = True
        AttachmentsBulkAdd.SearchAccount.ReadOnly = True
        'AttachmentsBulkAdd.ShowDialog()


        If AttachmentsBulkAdd.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GridControl2.DataSource = GetAttachmentsByReferance(TextRefNo.Text)
        End If

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        'GetSteps()
        'GetSteps()
        'StepProgressBar1.Appearances.FirstContentBlockAppearance.Caption.ForeColor = Color.FromArgb(40, 40, 40)
        'StepProgressBar1.Appearances.SecondContentBlockAppearance.Description.ForeColor = Color.FromArgb(80, 80, 80)
        'StepProgressBar1.Appearances.FirstContentBlockAppearance.CaptionActive.ForeColor = Color.FromArgb(40, 40, 40)
        'StepProgressBar1.Appearances.FirstContentBlockAppearance.CaptionInactive.ForeColor = Color.Gray
        'StepProgressBar1.Appearances.SecondContentBlockAppearance.DescriptionActive.ForeColor = Color.DimGray
        'StepProgressBar1.Appearances.SecondContentBlockAppearance.DescriptionInactive.ForeColor = Color.LightGray


    End Sub

    Private Sub CheckActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckActive.CheckedChanged
        'If CheckActive.CheckState = 1 Then
        '    LayoutStatus.Text = "فعال"
        'Else
        '    LayoutStatus.Text = "غير فعال"
        'End If

        If CheckActive.Checked = True Then
            'CheckActive.BackColor = Color.Green
            '  CheckActive.Text = "فعال"
            '  LayoutStatus.Text = "فعال"
        Else
            'CheckActive.BackColor = Color.Red
            ' CheckActive.Text = "غير فعال"
            ' LayoutStatus.Text = "غير فعال"
        End If

    End Sub

    Private Sub StepProgressBar1_SelectedItemChanged(sender As Object, e As StepProgressBarSelectedItemChangedEventArgs)
        'Dim bar As DevExpress.XtraEditors.StepProgressBar = TryCast(sender, DevExpress.XtraEditors.StepProgressBar)
        'For Each item As StepProgressBarItem In bar.Items
        '    'item.Options.Indicator.Images.ActiveStateImageOptions.SvgImage = Nothing
        '    item.Options.Indicator.Width = 50
        '    item.Options.ConnectorOffset = -20
        '    item.ContentBlock1.Description = Nothing
        'Next item

        'If bar.SelectedItemIndex < 3 Then
        '    bar.Appearances.CommonActiveColor = Color.IndianRed
        'End If
        'If bar.SelectedItemIndex >= 3 AndAlso bar.SelectedItemIndex < 5 Then
        '    bar.Appearances.CommonActiveColor = Color.Goldenrod
        'End If
        'If bar.SelectedItemIndex >= 5 Then
        '    bar.Appearances.CommonActiveColor = Color.Green
        'End If



        'If e.Item IsNot Nothing Then
        '    e.Item.Options.Indicator.Images.ActiveStateImageOptions.SvgImage = svgImageCollection1(0)
        '    e.Item.Options.Indicator.Width = 100
        '    e.Item.ContentBlock1.Description = "Step " & (bar.SelectedItemIndex + 1).ToString() & " of 6"
        '    e.Item.Options.ConnectorOffset = 0
        '    If bar.SelectedItemIndex < 3 Then
        '        bar.Appearances.CommonActiveColor = Color.IndianRed
        '    End If
        '    If bar.SelectedItemIndex >= 3 AndAlso bar.SelectedItemIndex < 5 Then
        '        bar.Appearances.CommonActiveColor = Color.Goldenrod
        '    End If
        '    If bar.SelectedItemIndex >= 5 Then
        '        bar.Appearances.CommonActiveColor = Color.Green
        '    End If
        'End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _Count As Integer
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select count(ID) as Count from Journal where [DocStatus] > 0 and [Referance]='" & Me.TextRefNo.Text & "'")
            _Count = Sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _Count = 0
        End Try

        Dim _Count2 As Integer
        Try
            Sql.SqlTrueAccountingRunQuery("Select count(ID) as Count from [ReservationsList] where [DocStatus] = 0 and [ReferanceNo]='" & Me.TextRefNo.Text & "'")
            _Count2 = Sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _Count2 = 0
        End Try

        If _Count > 0 Or _Count2 > 0 Then
            XtraMessageBox.Show("لا يمكن حذف الذمة، يوجد لها حركات مالية")
        Else
            Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Referencess] where [RefNo]= '" & Me.TextRefNo.Text & "'")
            XtraMessageBox.Show("تم حذف الذمة")
            CreateDocLog("File", "", "0", Me.TextRefNo.Text, "Delete", "Delete Referance" & ":" & Me.TextRefName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
            Me.Close()
        End If


        'Try

        '    Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Referencess] where [RefNo]= '" & Me.TextRefNo.Text & "'")
        '    Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[Journal] where [Referance]= '" & Me.TextRefNo.Text & "'")
        '    Sql.SqlTrueAccountingRunQuery("Delete from [dbo].[PosVouchers] where [VoucherReferance]= '" & Me.TextRefNo.Text & "'")
        '    XtraMessageBox.Show("تم حذف الذمة")
        '    CreateDocLog("File", "", "0", Me.TextRefNo.Text, "Delete", "Delete Referance" & ":" & Me.TextRefName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
        '    Me.Close()
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim F3 As New AccountStatmentForRef
        With F3
            .CheckReportForRef.Text = "True"
            .Text = "كشف حساب ( " & TextRefName.Text & " )"
            .SearchReferance.Text = TextRefNo.Text
            .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
            .DateEditTo.DateTime = Today
            .Show()
            .RefreshDataInAccountStatmentForRef()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub TextRefName_EditValueChanged(sender As Object, e As EventArgs) Handles TextRefName.EditValueChanged
        If _AddNewOrSave = "AddNew" Then
            Me.Text = " اضافة جديد  " & " ( " & TextRefName.Text & " ) "
        Else
            Me.Text = " تعديل بيانات  " & " ( " & TextRefName.Text & " ) "
        End If
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles BtnSave.Click
        AddNewOrSaveReferanc()
    End Sub

    'Private Sub GetSteps()
    '    'StepProgressBar1.SelectedItemIndex = 1
    '    'StepProgressBar1.GetItemByIndex(1).ContentBlock2.Caption = "mmmmmm"
    '    Dim Sql As New SQLControl
    '    Sql.SqlTrueAccountingRunQuery("Select [CreatedBy] ,[CreateDate] ,[FirstTransInJournalDate] 
    '                                   From [dbo].[Referencess] Where [RefNo]= '" & TextRefNo.Text & "'")
    '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CreateDate")) Then
    '        StepProgressBar1.GetItemByIndex(0).ContentBlock2.Caption = Sql.SQLDS.Tables(0).Rows(0).Item("CreateDate")
    '        StepProgressBar1.SelectedItemIndex = 1
    '    End If
    '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("FirstTransInJournalDate")) Then
    '        StepProgressBar1.GetItemByIndex(2).ContentBlock2.Caption = Sql.SQLDS.Tables(0).Rows(0).Item("FirstTransInJournalDate")
    '        StepProgressBar1.SelectedItemIndex = 2
    '    End If
    'End Sub
    Private Function CheckIfHasRefHasTrans(_RefNo As Integer) As Boolean
        Dim _result As Boolean = False
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = " SELECT CAST(CASE WHEN EXISTS(SELECT * FROM Journal  WHERE Referance=" & _RefNo & ") THEN 1 ELSE 0 END AS BIT) as result; "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _result = CBool(sql.SQLDS.Tables(0).Rows(0).Item("result"))
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function
    Private Function CheckIfReferanceNameExist(RefNo As Integer, RefName As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select * from Referencess where [RefName]=N'" & RefName & "' and RefNo<>" & RefNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Private Sub TextRefName_Leave(sender As Object, e As EventArgs) Handles TextRefName.Leave
        If CheckIfReferanceNameExist(Me.TextRefNo.Text, Me.TextRefName.Text) = True Then
            If XtraMessageBox.Show(" الاسم موجود مسبقا، هل تريد الاستمرار؟ ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, DefaultBoolean.Default) = DialogResult.No Then
                Me.TextRefName.Focus()
            End If
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim _Report As New ReferanceDataLabel
        With _Report
            .XrLabelName.Text = Me.TextRefName.Text
            .XrLabelAddress.Text = Me.TextRefAddress.Text
            .XrLabelMobile.Text = Me.TextRefMobile.Text

            ' Create a print tool for the report
            Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(_Report)

            ' Show the report's preview form
            printTool.ShowPreview()
        End With
    End Sub

    Private Sub GridViewSubRef_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewSubRef.InitNewRow
        Me.GridViewSubRef.SetRowCellValue(e.RowHandle, "RefNo", TextRefNo.EditValue)
    End Sub
End Class