Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class AccountingLists
    Dim Con As SqlConnection
    Dim RefSortsAdapter As SqlDataAdapter
    Dim RefCitiesAdapter As SqlDataAdapter
    Dim ItemsCategoriesAdapter As SqlDataAdapter
    Dim ItemsTradeMarkAdapter As SqlDataAdapter
    Dim ItemsGroupsAdapter As SqlDataAdapter
    Dim ItemsColorAdapter As SqlDataAdapter
    Dim ItemsMeasureAdapter As SqlDataAdapter
    Dim ShelvesAdapter As SqlDataAdapter
    Dim BanksAdapter As SqlDataAdapter
    Dim BanksBranchAdapter As SqlDataAdapter

    Dim DS As DataSet
    Dim DS2 As DataSet
    Dim DS3 As DataSet
    Dim DS4 As DataSet
    Dim DS5 As DataSet
    Dim DSColor As DataSet
    Dim DSMeasures As DataSet
    Dim DSShelves As DataSet
    Dim DSBanks As DataSet
    Dim DSBanksBranches As DataSet

    Public BankNo As Integer
    Public BankName As String
    Private color As String
    Private Sub AcountingLists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GetWarehouses()
        GetUnits()
        RepositoryBanks.DataSource = GetBanksTable()
        LookUpBanks.Properties.DataSource = GetBanksTable()
        '  GridRefSort.DataSource = GetRefSorts()
        ' GridCities.DataSource = GetRefCities()
        GetRefSortTables()
        GetRefCitiesTables()
        GetItemsCategoriesTable()
        GetItemsTradeMarkTable()
        GetItemsColorsTable()
        GetItemsMeasuresTable()
        GetItemsGroupsTable()
        GetTheBanksTable()
        Me.RepositoryPrinters.DataSource = GetPrintersDataTable()

        LookUpEdit1.Properties.DataSource = GetWharehouses(False)
        LookUpEdit1.EditValue = 1
        GetShelvesTable(LookUpEdit1.EditValue)


        Shelves.Visible = GlobalVariables.HasShelfsService
        Me.RepositoryUnitType.DataSource = CreateUnitTypesDataTable()
        'Me.RepositoryPrinters.DataSource = GetPrintersDataTable()
    End Sub
    Private Sub GetRefSortTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            RefSortsAdapter = New SqlDataAdapter("SELECT [ID],[SortName]  FROM [dbo].[RefSorts] order by ID ", Con)
            DS2 = New System.Data.DataSet()
            RefSortsAdapter.Fill(DS2, "RefSorts")
            GridRefSort.DataSource = DS2.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetRefCitiesTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            RefCitiesAdapter = New SqlDataAdapter("SELECT [ID],[CITY]  FROM [dbo].[RefCities] order by ID ", Con)
            DS = New System.Data.DataSet()
            RefCitiesAdapter.Fill(DS, "RefCities")
            GridCities.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetItemsCategoriesTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsCategoriesAdapter = New SqlDataAdapter("SELECT [CategoryID],[CategoryName]  FROM [dbo].[ItemsCategories] order by CategoryID ", Con)
            DS3 = New System.Data.DataSet()
            ItemsCategoriesAdapter.Fill(DS3, "ItemsCategories")
            GridItemsCatagories.DataSource = DS3.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetItemsTradeMarkTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsTradeMarkAdapter = New SqlDataAdapter("SELECT [TradeMarkID],[TradeMarkName]   FROM [dbo].[ItemsTradeMark] order by TradeMarkID ", Con)
            DS4 = New System.Data.DataSet()
            ItemsTradeMarkAdapter.Fill(DS4, "ItemsTradeMark")
            GridTradeMark.DataSource = DS4.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetItemsGroupsTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsGroupsAdapter = New SqlDataAdapter("SELECT [GroupID],[GroupName],[AvailableOnPOS],[VisibleInSalesApp],[DefaultPrinter]  FROM  [dbo].[ItemsGroups] order by GroupID ", Con)
            DS5 = New System.Data.DataSet()
            ItemsGroupsAdapter.Fill(DS5, "ItemsGroups")
            GridItemsGroups.DataSource = DS5.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try

    End Sub
    Private Sub GetItemsColorsTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsColorAdapter = New SqlDataAdapter("SELECT [ID],[ColorName],[ColorNo],[ColorHex]  
                                                    FROM  [dbo].[ItemsColors] 
                                                    order by ID ", Con)
            DSColor = New System.Data.DataSet()
            ItemsColorAdapter.Fill(DSColor, "ItemsColors")
            GridItemsColors.DataSource = DSColor.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetItemsMeasuresTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsMeasureAdapter = New SqlDataAdapter("SELECT [ID],[MeasureName]    
                                                    FROM [dbo].[ItemsMeasures]
                                                    order by ID ", Con)
            DSMeasures = New System.Data.DataSet()
            ItemsMeasureAdapter.Fill(DSMeasures, "ItemsMeasures")
            GridItemsMeasures.DataSource = DSMeasures.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetShelvesTable(WareHouseID As Integer)
        GridShelves.DataSource = ""
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ShelvesAdapter = New SqlDataAdapter("SELECT [ShelfID]
      ,[ShelfCode]
      ,[WareHouseID]
  FROM [dbo].[FinancialShelves] where WareHouseID=" & WareHouseID, Con)
            DSShelves = New System.Data.DataSet()
            ShelvesAdapter.Fill(DSShelves, "FinancialShelves")
            GridShelves.DataSource = DSShelves.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetTheBanksTable()
        BankGridControl.DataSource = ""
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            BanksAdapter = New SqlDataAdapter("SELECT  [ID],[BankNo],[BankName]  FROM [dbo].[Bank] order by ID desc", Con)
            DSBanks = New System.Data.DataSet()
            BanksAdapter.Fill(DSBanks, "Bank")
            BankGridControl.DataSource = DSBanks.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub GetTheBanksBranchTable(BankID As Integer)
        BankBrancheGridControl.DataSource = ""
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            BanksBranchAdapter = New SqlDataAdapter("SELECT  [ID],[BranchNo],[BranchName],[BankID]  FROM [dbo].[BankBranche] where BankID=" & BankID & " Order by ID desc ", Con)
            DSBanksBranches = New System.Data.DataSet()
            BanksBranchAdapter.Fill(DSBanksBranches, "BankBranche")
            Me.BankBrancheGridControl.DataSource = DSBanksBranches.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingShelvesTables()
        Dim i As Integer
        For i = 0 To GridView10.RowCount - 1
            GridView10.SetRowCellValue(i, "WareHouseID", LookUpEdit1.EditValue)
        Next
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ShelvesAdapter)
            ShelvesAdapter.Update(DSShelves, "FinancialShelves")
        Catch ex As Exception

        End Try
        GetShelvesTable(LookUpEdit1.EditValue)
        Me.Close()
    End Sub
    Private Sub SavingRefCitiesTables()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(RefCitiesAdapter)
            RefCitiesAdapter.Update(DS, "RefCities")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        GetRefCitiesTables()
        Me.Close()
    End Sub
    Private Sub SavingRefSortTables()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(RefSortsAdapter)
            RefSortsAdapter.Update(DS2, "RefSorts")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        GetRefSortTables()
        Me.Close()
    End Sub
    Private Sub SavingItemsCategories()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsCategoriesAdapter)
            ItemsCategoriesAdapter.Update(DS3, "ItemsCategories")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub
    Private Sub SavingItemsTradeMarks()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsTradeMarkAdapter)
            ItemsTradeMarkAdapter.Update(DS4, "ItemsTradeMark")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        GetItemsTradeMarkTable()
        Me.Close()
    End Sub
    Private Sub SavingItemsGroups()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsGroupsAdapter)
            ItemsGroupsAdapter.Update(DS5, "ItemsGroups")
        Catch ex As Exception

        End Try
        GetItemsGroups(False)
        Me.Close()
    End Sub
    Private Sub SavingItemsColors()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsColorAdapter)
            ItemsColorAdapter.Update(DSColor, "ItemsColors")
        Catch ex As Exception
        End Try
        GetItemsColorsTable()
    End Sub
    Private Sub SavingItemsMeasures()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsMeasureAdapter)
            ItemsMeasureAdapter.Update(DSMeasures, "ItemsMeasures")
        Catch ex As Exception
        End Try
        GetItemsMeasuresTable()
        Me.Close()
    End Sub
    Private Sub SavingBanks()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(BanksAdapter)
            BanksAdapter.Update(DSBanks, "Bank")
            MsgBoxShowSuccess(" تم الحفظ بنجاح ")
        Catch ex As Exception
            MsgBoxShowError(" خطأ: لم يتم حفظ البيانات ")
        End Try
        GetTheBanksTable()
        Me.Close()
    End Sub
    Private Sub SavingBanksBranches()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(BanksBranchAdapter)
            BanksBranchAdapter.Update(DSBanksBranches, "BankBranche")
            MsgBoxShowSuccess(" تم الحفظ بنجاح ")
        Catch ex As Exception
            MsgBoxShowError(" خطأ: لم يتم حفظ البيانات ")
        End Try
        GetTheBanksTable()
        Me.Close()
    End Sub
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveWarehousesTable()
            SaveUnitsTable()
        End If
    End Sub

    Private Sub GetWarehouses()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select WarehouseID,[WarehouseNameAR],[WarehouseNameEn],[IsDefault] from [Warehouses] order by WarehouseID "
            If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then MsgBox("لا يمكن تحميل المستودعات") : Exit Sub
            WarehousesGridControl.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetUnits()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT  [id],[name],[state],UnitTypeID FROM [Units] order by [id] "
            If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then MsgBox("لا يمكن تحميل وحدات الاصناف") : Exit Sub
            GridUnits.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonSaveWarehouses_Click(sender As Object, e As EventArgs) Handles ButtonSaveWarehouses.Click
        SaveWarehousesTable()
    End Sub
    Private Sub SaveWarehousesTable()
        GridView1.UpdateSummary()

        If CInt(colIsDefault.SummaryText) > 1 Then
            MsgBox("يوجد اكثر من مستودع رئيسي")
            Exit Sub
        End If

        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            Dim ID As Integer = CInt(Me.GridView1.GetRowCellValue(i, "WarehouseID"))
            Dim WarehouseNameAR As String
            Try
                WarehouseNameAR = CStr(Me.GridView1.GetRowCellValue(i, "WarehouseNameAR"))
            Catch ex As Exception
                WarehouseNameAR = ""
            End Try
            Dim IsDefault As String = CInt(Me.GridView1.GetRowCellValue(i, "IsDefault"))
            If Not String.IsNullOrEmpty(WarehouseNameAR) Or WarehouseNameAR <> "" Or
               Not String.IsNullOrWhiteSpace(WarehouseNameAR) Then
                Select Case ID
                    Case 0
                        Try
                            Dim sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Insert Into  Warehouses (WarehouseID,WarehouseNameAR,WarehouseNameEn,IsDefault)
                                        Values
                                        ((Select IsNull(Max(WarehouseID),0)+1  from Warehouses),N'" & WarehouseNameAR & "',N'" & WarehouseNameAR & "'," & IsDefault & ")"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                        Catch ex As Exception
                        End Try
                    Case > 0
                        Try
                            Dim sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Warehouses Set WarehouseNameAR= N'" & WarehouseNameAR & "',
                                                            WarehouseNameEn= N'" & WarehouseNameAR & "',
                                                            IsDefault= " & IsDefault & "
                                      Where WarehouseID=" & ID
                            sql.SqlTrueAccountingRunQuery(SqlString)
                        Catch ex As Exception
                        End Try
                End Select
                '   XtraMessageBox.Show("تم حفظ البيانات")
            End If
        Next
        GetWarehouses()
        Me.Close()
    End Sub

    Private Sub WarehousesGridControl_Click(sender As Object, e As EventArgs) Handles WarehousesGridControl.Click

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        GridView1.SetRowCellValue(e.RowHandle, "WarehouseID", 0)
        GridView1.SetRowCellValue(e.RowHandle, "IsDefault", 0)
    End Sub
    Private Sub GridView2_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView2.InitNewRow
        GridView2.SetRowCellValue(e.RowHandle, "id", 0)
    End Sub

    Private Sub ButtonSaveUnits_Click(sender As Object, e As EventArgs) Handles ButtonSaveUnits.Click
        SaveUnitsTable()
    End Sub

    Private Sub SaveUnitsTable()



        Dim i As Integer
        For i = 0 To GridView2.RowCount - 1
            Dim ID As Integer = 0
            Dim UnitName As String = ""
            Dim UnitTypeID As Integer = 1

            Try
                ID = CInt(Me.GridView2.GetRowCellValue(i, "id"))
            Catch ex As Exception
                ID = 0
            End Try

            Try
                UnitName = CStr(Me.GridView2.GetRowCellValue(i, "name"))
            Catch ex As Exception
                UnitName = ""
            End Try

            Try
                UnitTypeID = CInt(Me.GridView2.GetRowCellValue(i, "UnitTypeID"))
            Catch ex As Exception
                UnitTypeID = 0
            End Try

            If Not String.IsNullOrEmpty(UnitName) And Not String.IsNullOrWhiteSpace(UnitName) And Not String.IsNullOrWhiteSpace(UnitTypeID) Then
                Select Case ID
                    Case 0
                        Try
                            Dim sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Insert Into  Units (id,name,UnitTypeID)
                                        Values
                                        ((Select IsNull(Max(id),0)+1  from Units),N'" & UnitName & "'," & UnitTypeID & ")"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                        Catch ex As Exception
                        End Try
                    Case > 0
                        Try
                            Dim sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Units Set name= N'" & UnitName & "',UnitTypeID=" & UnitTypeID & "
                                                 Where id=" & ID
                            sql.SqlTrueAccountingRunQuery(SqlString)
                        Catch ex As Exception
                        End Try
                End Select
            End If
        Next
        ' XtraMessageBox.Show("تم حفظ البيانات")
        GetUnits()
        Me.Close()
    End Sub

    Private Sub NavigationPane1_Click(sender As Object, e As EventArgs) Handles NavigationPane1.Click

    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingRefSortTables()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingRefCitiesTables()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SavingItemsCategories()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        SavingItemsTradeMarks()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        SavingItemsGroups()
    End Sub

    Private Sub GridView7_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView7.InitNewRow
        GridView7.SetRowCellValue(e.RowHandle, "AvailableOnPOS", 1)
    End Sub

    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView5.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _ColCategoryID As GridColumn = view.Columns("CategoryID")
            Dim _ColCategoryName As GridColumn = view.Columns("CategoryName")
            Dim CategoryName As String = ""
            Dim CategoryID As Integer = 0

            Try
                CategoryID = Me.GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "CategoryID")
            Catch ex As Exception
                CategoryID = 0
            End Try

            Try
                CategoryName = Me.GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "CategoryName")
            Catch ex As Exception
                CategoryName = ""
            End Try


            If IsDBNull(CategoryID) Or String.IsNullOrEmpty(CategoryID) Or
                CategoryID = 0 Then
                e.Valid = False
                e.ErrorText = "يجب ادخال قيمة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColCategoryID
                view.ShowEditor()
            End If

            If IsDBNull(CategoryName) = True Or String.IsNullOrEmpty(CategoryName) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال اسم"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColCategoryName
                view.ShowEditor()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub GridControlChecks_ProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles GridItemsCatagories.ProcessGridKey
        Dim grid = TryCast(sender, GridControl)
        Dim view = TryCast(grid.FocusedView, GridView)
        If e.KeyData = Keys.Delete Then
            view.DeleteSelectedRows()
            view.UpdateSummary()
            e.Handled = True
        End If
    End Sub

    Private Sub AccountingLists_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        SavingItemsColors()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        SavingItemsMeasures()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        SavingShelvesTables()
    End Sub

    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit1.EditValueChanged
        GetShelvesTable(LookUpEdit1.EditValue)
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        SavingBanks()
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        SavingBanksBranches()
    End Sub
    Private Sub GridView11_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView11.ValidateRow
        '  If _ValidateRow = False Then Exit Sub
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim _BankNo As GridColumn = view.Columns("BankNo")
        If IsDBNull(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankNo")) = True Then
            e.Valid = False
            e.ErrorText = "يجب ادخال رقم البنك"
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = _BankNo
            view.ShowEditor()
        End If
        If Not IsDBNull(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankNo")) Then
            If String.IsNullOrWhiteSpace(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankNo")) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال رقم البنك"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _BankNo
                view.ShowEditor()
            End If
        End If


        Dim _BankName As GridColumn = view.Columns("BankName")
        If IsDBNull(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankName")) = True Then
            e.Valid = False
            e.ErrorText = "يجب ادخال اسم البنك"
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = _BankName
            view.ShowEditor()
        End If

        If Not IsDBNull(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankName")) Then
            If String.IsNullOrWhiteSpace(Me.GridView11.GetRowCellValue(GridView11.FocusedRowHandle, "BankName")) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال اسم البنك"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _BankName
                view.ShowEditor()
            End If
        End If


        If e.Valid Then
            view.ClearColumnErrors()
        End If

    End Sub

    Private Sub RepositoryDeleteBank_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDeleteBank.ButtonClick
        If GridView11.Editable Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                GridView11.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub LookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpBanks.EditValueChanged
        If LookUpBanks.Text <> "" Then
            GetTheBanksBranchTable(LookUpBanks.EditValue)
        End If

    End Sub


    Private Sub LookUpBanks_Properties_BeforePopup(sender As Object, e As EventArgs) Handles LookUpBanks.Properties.BeforePopup
        LookUpBanks.Properties.DataSource = GetBanksTable()
    End Sub

    Private Sub GridView12_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView12.InitNewRow
        GridView12.SetRowCellValue(e.RowHandle, "BankID", LookUpBanks.EditValue)
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        If GridView12.Editable Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                GridView12.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub BankBrancheGridControl_Click(sender As Object, e As EventArgs) Handles BankBrancheGridControl.Click

    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        RepositoryBanks.DataSource = GetBanksTable()
        LookUpBanks.Properties.DataSource = GetBanksTable()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        Dim f As New ItemsColorAddForm
        With f
            .TextID.EditValue = -1
            If .ShowDialog <> DialogResult.OK Then
                GetItemsColorsTable()
            End If
        End With
    End Sub

    Private Sub RepositoryBottonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryBottonEdit.ButtonClick
        Dim f As New ItemsColorAddForm
        With f
            .TextID.EditValue = Me.GridView8.GetFocusedRowCellValue("ID")
            If .ShowDialog <> DialogResult.OK Then
                GetItemsColorsTable()
            End If
        End With
    End Sub

    Private Sub RepositoryPrinters_Popup(sender As Object, e As EventArgs) Handles RepositoryPrinters.BeforePopup

    End Sub

    ' Plan:
    ' - Create function that builds a DataTable named "UnitTypes".
    ' - Add two columns: ID (Integer), UnitType (String).
    ' - Insert three rows: (1, "حبة"), (2, "متر طول"), (3, "متر عرض").
    ' - Return the populated DataTable for binding/consumption.

    Private Function CreateUnitTypesDataTable() As DataTable
        Dim dt As New DataTable("UnitTypes")
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("UnitType", GetType(String))

        dt.Rows.Add(1, "حبة")
        dt.Rows.Add(2, "متر طول")
        dt.Rows.Add(3, "متر عرض")
        dt.Rows.Add(4, "حجم")

        Return dt
    End Function

End Class