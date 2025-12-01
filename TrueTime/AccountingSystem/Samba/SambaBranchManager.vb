Imports System.Data.SqlTypes
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Tile
Imports System.Threading
Imports System.Threading.Tasks
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraEditors.Controls
Imports System.Data.SqlClient

Public Class SambaBranchManager
    Private _BranchName As String
    Private _BranchID As Integer
    Private _GroupID As Integer
    Private serverStatusLabel As Label ' Reference to the label on your form
    Private Sub SambaBranchManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBranches()
        CreateCloseAction()
        TabbedControlGroup1.SelectedTabPage = TabBranches
        TabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        PictureEdit1.LoadAsync("https://sambapos.com/wp-content/uploads/sambapos_logo.png")
    End Sub
    Private Sub TileViewBranches_ItemClick(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs) Handles TileViewBranches.ItemClick
        ' ادارة فرع
        _BranchName = TileViewBranches.GetFocusedRowCellValue("POSName")
        _BranchID = TileViewBranches.GetFocusedRowCellValue("ID")
        TabbedControlGroup1.SelectedTabPage = TabItemGroups
        TileControl1.Text = " إدارة فرع " & _BranchName
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub
    Private Sub TileItemMenue_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemMenue.ItemClick
        ' ادارة المجموعات
        LoadScreenMenuCategories()
        TileViewMenuCategory.ViewCaption = _BranchName & " / " & " مجموعات الأصناف "
        TabbedControlGroup1.SelectedTabPage = TabItemGroups
    End Sub
    Private Sub TileViewMenuCategory_ItemClick(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs) Handles TileViewMenuCategory.ItemClick
        ' ادارة الاصناف لمجموعة
        Dim _MenueId As Integer
        Dim _Name As String
        _MenueId = TileViewMenuCategory.GetFocusedRowCellValue("Id")
        _Name = TileViewMenuCategory.GetFocusedRowCellValue("Name")
        TileViewMenuItems.ViewCaption = _BranchName & " / " & _Name & " / " & " قائمة الأصناف "
        _GroupID = _MenueId
        LoadItem()
        TabbedControlGroup1.SelectedTabPage = TabItems
    End Sub

    Private Sub GetBranches()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select [ID],[POSName] from [dbo].[AccountingPOSNames] "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.GridControlPosNames.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Function CreateCloseAction() As FlyoutAction
        Dim closeAction As FlyoutAction = New FlyoutAction()
        closeAction.Caption = Text
        closeAction.Description = "Do you really want to close the demo?"
        closeAction.Commands.Add(FlyoutCommand.Yes)
        closeAction.Commands.Add(FlyoutCommand.No)
        Return closeAction
    End Function
    Private Sub btnAddNewGroup_Click(sender As Object, e As EventArgs) Handles btnAddNewGroup.Click
        Dim _GroupName = XtraInputBox.Show(" اسم المجموعة ", " اضافة مجموعة جديدة ", "")

        If _GroupName = "" Then Exit Sub

        If CheckGroupExists(_GroupName) Then
            MsgBoxShowError(" المجموعة موجودة  ")
            Exit Sub
        End If

        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " exec sp_executesql N'INSERT [dbo].[ScreenMenuCategories]([Name], [Header], [Appearance], [SortOrder], [ScreenMenuId], [MostUsedItemsCategory], [ColumnCount], [MenuItemButtonHeight], [MenuItemButtonColor], [MenuItemFontSize], [WrapText], [PageCount], [SortAlphabetically], [MainButtonHeight], [MainButtonColor], [MainFontSize], [SubButtonHeight], [SubButtonRows], [SubButtonColorDef], [NumeratorType], [NumeratorValues], [AlphaButtonValues], [ImagePath], [NumberPadPercent], [MaxItems])
                                                        VALUES (@0, NULL, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13, @14, @15, @16, @17, @18, NULL, NULL, NULL, @19, @20)
                                                        SELECT [Id]
                                                        FROM [dbo].[ScreenMenuCategories]
                                                        WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()',N'@0 nvarchar(max) ,@1 int,@2 int,@3 int,@4 bit,@5 int,@6 int,@7 nvarchar(max) ,@8 float,@9 bit,@10 int,@11 bit,@12 int,@13 nvarchar(max) ,@14 float,@15 int,@16 int,@17 nvarchar(max) ,@18 int,@19 int,@20 int',@0=N'" & _GroupName & "',@1=0,@2=0,@3=1,@4=0,@5=0,@6=0,@7=N'Green',@8=24,@9=1,@10=1,@11=0,@12=0,@13=N'Orange',@14=26,@15=75,@16=1,@17=N'',@18=2,@19=45,@20=0 "
        If sql.SqlPosRunQuery(sqlstring, _BranchID) = False Then
            MsgBoxShowError(" Error ")
        Else
            LoadScreenMenuCategories()
        End If
    End Sub
    Private Sub LoadScreenMenuCategories()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT C.Id,C.Name,Count(I.Id)as ItemsCount  
                          FROM [dbo].[ScreenMenuCategories] C 
                          left join ScreenMenuItems I on I.ScreenMenuCategoryId=C.Id 
                          group by C.id,C.Name   "
            sql.SqlPosRunQuery(sqlstring, _BranchID)
            GridControlMenuCategories.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(" خطا بالاتصال ")
        End Try

    End Sub
    Private Sub TileViewMenuCategory_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles TileViewMenuCategory.ContextButtonClick
        ' تعديل بيانات المجموعة
        Dim view1 = TryCast(sender, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = (TryCast(e.DataItem, DevExpress.XtraGrid.Views.Tile.TileViewItem)).RowHandle
        view1.FocusedRowHandle = rowHandle
        Dim view As TileView = TryCast(sender, TileView)
        Dim sql As New SQLControl
        Dim _GroupID As Integer = TileViewMenuCategory.GetFocusedRowCellValue("Id")
        Dim _GroupName As String = TileViewMenuCategory.GetFocusedRowCellValue("Name")
        Select Case e.Item.Tag
            Case "EditGroup"
                Dim _GroupNameEdit = XtraInputBox.Show(" تعديل المجموعة ", " تعديل اسم المجموعة ", _GroupName)
                If String.IsNullOrWhiteSpace(_GroupNameEdit) Then
                    'MsgBoxShowError(" الاسم فارغ ")
                    Exit Sub
                Else
                    If _GroupNameEdit <> _GroupName Then
                        If CheckGroupExists(_GroupNameEdit) = True Then
                            MsgBoxShowError(" المجموعة موجودة  ")
                            Exit Sub
                        End If
                        Dim sqlstring As String = " UPDATE [dbo].[ScreenMenuCategories] SET [Name]=N'" & CStr(_GroupNameEdit) & "' Where Id=" & _GroupID
                        If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                            TileViewMenuCategory.SetFocusedRowCellValue("Name", _GroupNameEdit)
                        End If
                    End If
                End If
            Case "RemoveGroup"
                If CheckGroupHasItems(_GroupID) = True Then
                    MsgBoxShowError(" يجب ازالة الأصناف قبل حذف المجموعة ")
                    Exit Sub
                Else
                    If XtraMessageBox.Show(" هل تريد ازالة المجموعة  ", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Dim sqlstring = " delete from [ScreenMenuCategories] where Id=" & _GroupID
                        If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                            TileViewMenuCategory.DeleteRow(TileViewMenuCategory.FocusedRowHandle)
                        End If
                    End If
                End If
        End Select
    End Sub
    Private Sub TileViewMenuItems_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles TileViewMenuItems.ContextButtonClick
        ' تعديل او ازالة بيانات صنف
        Dim view1 = TryCast(sender, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = (TryCast(e.DataItem, DevExpress.XtraGrid.Views.Tile.TileViewItem)).RowHandle
        view1.FocusedRowHandle = rowHandle
        Dim view As TileView = TryCast(sender, TileView)
        Dim sql As New SQLControl
        Dim _ID As Integer = TileViewMenuItems.GetFocusedRowCellValue("Id")
        Dim _Name As String = TileViewMenuItems.GetFocusedRowCellValue("Name")
        Dim _Price As String = TileViewMenuItems.GetFocusedRowCellValue("Price")
        Dim _PortionID As String = TileViewMenuItems.GetFocusedRowCellValue("PortionID")
        Select Case e.Item.Tag
            Case "edit"
                Dim F As New SambaEditItem(_BranchID, _ID, _Name, _Price, _PortionID)
                With F
                    If .ShowDialog <> DialogResult.OK Then
                        LoadItem()
                    End If
                End With
                'Dim _GroupNameEdit = XtraInputBox.Show(" تعديل المجموعة ", " تعديل اسم المجموعة ", _GroupName)
                'If String.IsNullOrWhiteSpace(_GroupNameEdit) Then
                '    'MsgBoxShowError(" الاسم فارغ ")
                '    Exit Sub
                'Else
                '    If _GroupNameEdit <> _GroupName Then
                '        If CheckGroupExists(_GroupNameEdit) = True Then
                '            MsgBoxShowError(" المجموعة موجودة  ")
                '            Exit Sub
                '        End If
                '        Dim sqlstring As String = " UPDATE [dbo].[ScreenMenuCategories] SET [Name]=N'" & CStr(_GroupNameEdit) & "' Where Id=" & _GroupID
                '        If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                '            TileViewMenuCategory.SetFocusedRowCellValue("Name", _GroupNameEdit)
                '        End If
                '    End If
                'End If
            Case "delete"
                If XtraMessageBox.Show(" هل تريد ازالة الصنف  " & _Name, "تنبيه", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim sqlstring = "   
										BEGIN TRANSACTION;
                                        Declare @ItemID int
                                        Set @ItemID=" & _ID & "
										delete from ScreenMenuItems where MenuItemId=@ItemID
										Declare @PorionID int ; Set @PorionID= ( Select top(1) ID from MenuItemPortions where MenuItemId=@ItemID )
										delete from MenuItemPrices where MenuItemPortionId=@PorionID
										delete from MenuItemPortions where MenuItemId=@ItemID
										delete from MenuItems where Id=@ItemID
                                        IF @@ERROR <> 0
                                        BEGIN
                                            ROLLBACK TRANSACTION;
                                        END
                                        ELSE
                                        BEGIN
                                            COMMIT TRANSACTION;
                                        END "
                    If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                        TileViewMenuItems.DeleteRow(TileViewMenuItems.FocusedRowHandle)
                    End If
                End If
        End Select
    End Sub
    Private Function CheckGroupExists(_Name As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " select COUNT(*) as count FROM [dbo].ScreenMenuCategories WHERE [Name]=N'" & _Name & "'"
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                If sql.SQLDS.Tables(0).Rows(0).Item("count") > 0 Then
                    result = True
                Else
                    result = False
                End If
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function
    Private Function CheckGroupHasItems(_GroupID As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " select count(*) as count from ScreenMenuItems where ScreenMenuCategoryId= " & _GroupID & ""
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                If sql.SQLDS.Tables(0).Rows(0).Item("count") > 0 Then
                    result = True
                Else
                    result = False
                End If
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Private Sub btnBackToBranchManager_Click(sender As Object, e As EventArgs) Handles btnBackToBranchManager.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHomeFromGroups.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub btnBackToBranches_Click(sender As Object, e As EventArgs) Handles btnBackToBranches.Click
        TabbedControlGroup1.SelectedTabPage = TabBranches
    End Sub

    Private Sub btnHomeFromItems_Click(sender As Object, e As EventArgs) Handles btnHomeFromItems.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub btnBacktoGroups_Click(sender As Object, e As EventArgs) Handles btnBacktoGroups.Click
        LoadScreenMenuCategories()
        TabbedControlGroup1.SelectedTabPage = TabItemGroups
    End Sub

    Private Sub btnAddItemIntoMenue_Click(sender As Object, e As EventArgs) Handles btnAddItemIntoMenue.Click
        Dim _F As New SambaNewItem(_BranchID, _BranchName, 0, _GroupID)
        With _F
            If .ShowDialog <> DialogResult.OK Then
                LoadItem()
            End If
        End With
    End Sub
    Private Sub LoadItem()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   select I.MenuItemId as Id,I.Name,Pr.Price,I.ScreenMenuCategoryId ,P.id as PortionID
                        from ScreenMenuItems I 
                        left join MenuItemPortions P on I.MenuItemId=P.MenuItemId 
                        left join MenuItemPrices Pr on Pr.MenuItemPortionId=P.Id where P.Name='Normal' And ScreenMenuCategoryId =" & _GroupID & " Order by I.Name "
            sql.SqlPosRunQuery(sqlstring, _BranchID)
            GridControlMenuItems.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TileItemCurrencies_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItemCurrencies.ItemClick
        LabelControlBranchNameInCurrencies.Text = " تعديل أسعار صرف العملات لفرع " & _BranchName
        TabbedControlGroup1.SelectedTabPage = TabForeignCurrencies
        GetCurrencyTable()
    End Sub
    Private Sub GetCurrencyTable()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT *  FROM [dbo].[ForeignCurrencies]  "
            sql.SqlPosRunQuery(sqlstring, _BranchID)
            GridControlForeignCurrencies.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(" خطا بالاتصال ")
        End Try
    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub RepositoryButtonSave_Click(sender As Object, e As EventArgs) Handles RepositoryButtonSave.Click
        Dim _Id As Integer = GridViewForeignCurrencies.GetFocusedRowCellValue("Id")
        Dim _Name As String = GridViewForeignCurrencies.GetFocusedRowCellValue("Name")
        Dim _ExchengeRate As String = GridViewForeignCurrencies.GetFocusedRowCellValue("ExchangeRate")
        Dim sql As New SQLControl
        If _ExchengeRate <= 0 Then
            MsgBoxShowError(" سعر الصرف خطأ ")
            Exit Sub
        End If
        Dim sqlstring As String = " Update [ForeignCurrencies] set [ExchangeRate]=" & _ExchengeRate & " where  Id=" & _Id
        If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
            MsgBoxShowSuccess(" رائع ، تم تعديل سعر الصرف لعملة  " & _Name)
            GetCurrencyTable()
        End If
    End Sub

    Private Sub TileItem2_ItemClick(sender As Object, e As TileItemEventArgs)
        'Dim f3 As XtraForm = New SambaReports2()
        'f3.TopLevel = False
        'f3.Visible = True
        'f3c
        'f3.FormBorderStyle = FormBorderStyle.None

        'PanelControl1.Controls.Add(f3)
        'f3.Dock = DockStyle.Fill
        'TabbedControlGroup1.SelectedTabPage = TabReports

    End Sub

    Private Sub BtnBackFromReports_Click(sender As Object, e As EventArgs) Handles BtnBackFromReports.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem1.ItemClick

        Dim F As New SambaAdjustment
        With F
            .TopLevel = False
            .Visible = True
            .Dock = DockStyle.Fill
            .FormBorderStyle = FormBorderStyle.None
            .ControlBox = False
            .PosNo.EditValue = _BranchID
        End With
        PanelControl2.Controls.Add(F)
        TabbedControlGroup1.SelectedTabPage = TabAdjustments


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'GetCustomers()
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub TileItem3_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem3.ItemClick

        Dim F As New SambaReports2
        With F
            .TopLevel = False
            .Visible = True
            .Dock = DockStyle.Fill
            .FormBorderStyle = FormBorderStyle.None
            .ControlBox = False
            .SearchPosName.EditValue = _BranchID
        End With
        PanelControl1.Controls.Add(F)
        TabbedControlGroup1.SelectedTabPage = TabReports
    End Sub

    Private Sub TileItem2_ItemClick_1(sender As Object, e As TileItemEventArgs) Handles TileItem2.ItemClick
        GetCustomers()
        TabbedControlGroup1.SelectedTabPage = TabReferances
    End Sub
    Private Sub GetCustomers()
        Dim sql As New SQLControl
        Dim sqlString As String
        'sqlstring = " SELECT  [Id]      ,[EntityTypeId]      ,[LastUpdateTime]
        '              ,[SearchString]      ,[CustomData]      ,[Notes]
        '              ,[AccountId]      ,[WarehouseId]      ,[Name]
        '             FROM [dbo].[Entities]
        '             where CustomData is Not Null and CustomData<>'[]' "

        sqlString = "   Select A.Id,A.AccountTypeId,A.Name,T.ttsAccountNo,T.ttsRefNo 
                        From [Accounts] A
                        Left join [AccountsMapWithTTS] T on A.Id=T.SambaAccountID "
        If sql.SqlPosRunQuery(sqlString, _BranchID) = True Then
            GridControlCustomers.DataSource = sql.SQLDS.Tables(0)
        End If
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim F As New SambaNewReferance(_BranchID, -1, -1)
        With F
            .LabelControl1.Text = " اضافة زبون جديد على فرع " & _BranchName
            If .ShowDialog <> DialogResult.OK Then
                GetCustomers()
            End If
        End With

    End Sub

    Private Sub BtnBackFromCustomers_Click(sender As Object, e As EventArgs) Handles BtnBackFromCustomers.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim _ID As Integer = GridViewCustomers.GetFocusedRowCellValue("Id")
        Dim _AccountID As Integer = GridViewCustomers.GetFocusedRowCellValue("AccountId")
        Dim _Name As String = GridViewCustomers.GetFocusedRowCellValue("Name")
        If XtraMessageBox.Show(" هل تريد ازالة الزبون  " & _Name & " ? ", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  delete from Entities where Id=" & _ID & "; delete from [dbo].[Accounts] where id=" & _AccountID
            If sql.SqlPosRunQuery(SqlString, _BranchID) = True Then
                MsgBoxShowSuccess(" تم ازالة الزبون " & _Name)
                GetCustomers()
            Else
                MsgBoxShowError(" خطا بعملية الحذف ")
            End If

        End If
    End Sub
    Private Sub GetAccounts()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "   select A.Id As AccountId,A.AccountTypeId,A.Name As AccountNameOnSamba,T.ttsAccountNo,T.ttsRefNo,
    CASE WHEN A.AccountTypeId=7 then 'Supplier' when A.AccountTypeId=8 then 'Employee' when A.AccountTypeId=5 then 'Debit' else 'Other' end as AccountType
  from [Accounts] A
  left join [AccountsMapWithTTS] T on A.Id=T.SambaAccountID "
        If sql.SqlPosRunQuery(sqlString, _BranchID) = True Then
            Me.GridSupliersPayments.DataSource = sql.SQLDS.Tables(0)
        End If

    End Sub

    Private Sub TileItem4_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileItem4.ItemClick
        GetAccounts()
        Me.RepositoryTTSReferances.DataSource = GetReferences(-1, -1, -1)
        TabbedControlGroup1.SelectedTabPage = TabSupliersPayments
    End Sub

    Private Sub RepositoryTTSReferances_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles RepositoryTTSReferances.AddNewValue
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = GridView1.GetFocusedRowCellValue("AccountName")
            If GridView1.GetFocusedRowCellValue("AccountTransactionTypeName") = "Supplier" Then
                .LookRefType.EditValue = 1
            ElseIf GridView1.GetFocusedRowCellValue("AccountTransactionTypeName") = "Employee" Then
                .LookRefType.EditValue = 99
            End If
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .TextRefName.Select()
            ._AddNewOrSave = "AddNew"
            .CheckActive.Checked = True
            If .ShowDialog() <> DialogResult.OK Then
                Me.RepositoryTTSReferances.DataSource = GetReferences(-1, -1, -1)
            End If
        End With
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GetAccounts()
        Me.RepositoryTTSReferances.DataSource = GetReferences(-1, -1, -1)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        TabbedControlGroup1.SelectedTabPage = TabBranchManager
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click

        Dim cellValue As Object = GridViewSupliersPayments.GetFocusedRowCellValue("ttsRefNo")
        Dim _ttsRefNo As String = If(IsDBNull(cellValue), String.Empty, cellValue.ToString())
        Dim _Type As String = GridViewSupliersPayments.GetFocusedRowCellValue("AccountType")

        If _Type = "Suplier" Or _Type = "Employee" Then

            Select Case _ttsRefNo
                Case ""
                    'InsertRefIntoAccountsMapWithTTS(_Type, GridViewSupliersPayments.GetFocusedRowCellValue("AccountNameOnSamba"), GridViewSupliersPayments.GetFocusedRowCellValue("ttsAccountNo"), _Type, GetReferanceMax() + 1, 1, GridViewSupliersPayments.GetFocusedRowCellValue("AccountId")))
                Case Else
                    MsgBox("edit")
            End Select


        End If

    End Sub
    Private Sub InsertRefIntoAccountsMapWithTTS(SambaName As String, ttsName As String, ttsAccountNo As String, ttsAccountType As String, ttsRefNo As Integer, Currency As Integer, SambaAccountID As Integer)
        Try
            Dim SqlString As String = "INSERT INTO AccountsMapWithTTS (SambaName, ttsName, ttsAccountNo, ttsAccountType, ttsRefNo, Currency, SambaAccountID) " &
                                      "VALUES (@SambaName, @ttsName, @ttsAccountNo, @ttsAccountType, @ttsRefNo, @Currency, @SambaAccountID)"
            Using Con As New SqlConnection("")
                Using Cmd As New SqlCommand(SqlString, Con)
                    Cmd.Parameters.AddWithValue("@SambaName", SambaName)
                    Cmd.Parameters.AddWithValue("@ttsName", ttsName)
                    Cmd.Parameters.AddWithValue("@ttsAccountNo", ttsAccountNo)
                    Cmd.Parameters.AddWithValue("@ttsAccountType", ttsAccountType)
                    Cmd.Parameters.AddWithValue("@ttsRefNo", ttsRefNo)
                    Cmd.Parameters.AddWithValue("@Currency", Currency)
                    Cmd.Parameters.AddWithValue("@SambaAccountID", SambaAccountID)
                    Con.Open()
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBoxShowError("Error " & ex.Message)
        End Try
    End Sub
End Class