Imports System.Data.SqlClient
Imports System.Web.UI.Adapters

Public Class AccountingPosNamesAdd
    Public _PosID As Integer
    Public _AddOrEdit As String
    Dim Con As SqlConnection
    Dim TablesAdapter As SqlDataAdapter
    Dim TablesLocationsAdapter As SqlDataAdapter
    Dim DS1 As DataSet
    Dim DS2 As DataSet
    Private Sub AccountingPosNamesAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchWhereHouse.Properties.DataSource = GetWharehouses(False)
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
        GetBranchesNames()
        If _AddOrEdit = "Add" Then
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select IsNull(max(ID),0)+1 as PosID from [dbo].[AccountingPOSNames] ")
            Me.TextPosID.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("PosID")
            TabTables.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            TabTables.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

        Select Case LogInMenue.CurrentModuleID
            Case 9189 ' مطعم نقطة بيع
                Debug.WriteLine($"CurrentModuleID:{LogInMenue.CurrentModuleID} ")
                My.Forms.Items.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.TabTables.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.TabTablesLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                'Debug.WriteLine("Inside case 1:TabTablesLocations visibility: " & Me.TabTablesLocations.Visibility.ToString())
            Case 9188 ' سوبر ماركت نقطة بيع
                Debug.WriteLine($"CurrentModuleID:{LogInMenue.CurrentModuleID} ")
                My.Forms.Items.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.TabTables.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.TabTablesLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                'Debug.WriteLine("Inside case 2:TabTablesLocations visibility: " & Me.TabTablesLocations.Visibility.ToString())

        End Select
        Me.KeyPreview = True
        Me.SearchDefaultPrinter.Properties.DataSource = GetPrintersDataTable()
        Me.SearchKitchenPrinter.Properties.DataSource = GetPrintersDataTable()
        'TabbedControlGroup1.SelectedTabPage = LayoutControlGroup1
        GetTablesTable()
        GetTablesLocations()
    End Sub
    Public Sub GetPosNameData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  [ID],[POSCode],[POSName]
                                ,[CostCenter],[PrefixCode],[BranchID],[Warehouse]
                                ,[OnlineOnly],[Note1],[Note2],[PaperSize]
                                ,[OpenCashDrawerOnSave],[POSQr],[ServerAddress],[DefaultPrinter]
                                ,[Tickets],[UseDirectProduction],[SamabaPos],[TempAccounting]
                                ,[ItemsGroups],[PosType],[Kitchen_printer],IsNull(ResturantMode,0) As ResturantMode 
                                ,IsNull(PrintVoucherByItemGroup,0) As PrintVoucherByItemGroup
                     FROM [dbo].[AccountingPOSNames]
                     Where ID=" & _PosID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                TextPosID.EditValue = .Item("ID")
                TextPOSName.EditValue = .Item("POSName")
                SearchWhereHouse.EditValue = .Item("Warehouse")
                LookCostCenter.EditValue = .Item("CostCenter")
                SearchBranch.EditValue = .Item("BranchID")
                SearchDefaultPrinter.EditValue = .Item("DefaultPrinter")
                SearchKitchenPrinter.EditValue = .Item("Kitchen_printer")
                CheckResturantMode.Checked = .Item("ResturantMode")
                CheckPrintVoucherByItemGroup.Checked = .Item("PrintVoucherByItemGroup")
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GetTablesTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            TablesAdapter = New SqlDataAdapter("SELECT [TableID]
      ,[TableName]
      ,[Location]
      ,[POSNo]
      ,[IsReserved]
  FROM [dbo].[PosTables] ", Con)
            DS1 = New System.Data.DataSet()
            TablesAdapter.Fill(DS1, "PosTables")
            GridControlTables.DataSource = DS1.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingTablesTable()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(TablesAdapter)
            TablesAdapter.Update(DS1, "PosTables")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetTablesLocations()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            TablesLocationsAdapter = New SqlDataAdapter(" SELECT  [ID],[LocationName],PosNo
                                                FROM [dbo].[PosTablesLocations] 
                                                WHERE [PosNo]=" & _PosID, Con)
            DS2 = New System.Data.DataSet()
            TablesLocationsAdapter.Fill(DS2, "Locations")
            GridLocations.DataSource = DS2.Tables(0)
            RepositoryLocations.DataSource = DS2.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingTablesLocations()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(TablesLocationsAdapter)
            TablesLocationsAdapter.Update(DS2, "Locations")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub WhereHouse_BeforePopup(sender As Object, e As EventArgs) Handles SearchWhereHouse.BeforePopup
        SearchWhereHouse.Properties.DataSource = GetWharehouses(False)
    End Sub

    Private Sub LookCostCenter_BeforePopup(sender As Object, e As EventArgs) Handles LookCostCenter.BeforePopup
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.TextPOSName.Text = "" Then
            MsgBoxShowError(" يجب تعبئة اسم نقطة بيع ")
            Exit Sub
        End If

        If Me.SearchBranch.Text = "" Then
            MsgBoxShowError(" يجب اختيار الفرع ")
            Exit Sub
        End If

        If Me.SearchWhereHouse.Text = "" Then
            MsgBoxShowError(" يجب اختيار المستودع ")
            Exit Sub
        End If

        If Me.LookCostCenter.Text = "" Then
            MsgBoxShowError(" يجب اختيار مركز تكلفة ")
            Exit Sub
        End If

        Dim sql As New SQLControl
        If _AddOrEdit = "Add" Then
            If sql.SqlTrueAccountingRunQuery(" Insert Into [dbo].[AccountingPOSNames] 
                                                       ([ID],[POSCode],[POSName],[CostCenter],[BranchID],
                                                        [Warehouse],[OnlineOnly],[OpenCashDrawerOnSave],
                                                        [UseDirectProduction],[PosType],PrefixCode,Tickets,DefaultPrinter,Kitchen_printer) 
                                                        Values 
                                                       ((Select IsNull(Max(ID),0)+1 From AccountingPOSNames ),
                                                        (Select IsNull(Max(ID),0)+1 From AccountingPOSNames ),
                                                        N'" & TextPOSName.Text & "',
                                                        " & LookCostCenter.EditValue & ",
                                                        " & SearchBranch.EditValue & ",
                                                        " & SearchWhereHouse.EditValue & ",
                                                        " & 1 & ",
                                                        " & 1 & ",
                                                        " & 1 & ",
                                                        " & 1 & ",
                                                        " & "'A'" & ",
                                                        " & 1 & ",N'" & SearchDefaultPrinter.Text & "',N'" & SearchKitchenPrinter.Text & "'
                                                        ) ") = True Then
                MsgBoxShowSuccess(" تم تعريف الفرع بنجاح ")
                Me.Dispose()
            Else
                MsgBoxShowError(" لم يتم تعريف الفرع ")
            End If

        Else
            Dim SqlString As String
            SqlString = " UPDATE [dbo].[AccountingPOSNames]
                                                   SET 
                                                       [POSCode] = " & TextPosID.EditValue & "
                                                      ,[POSName] = N'" & TextPOSName.Text & "'
                                                      ,[CostCenter] = " & LookCostCenter.EditValue & "
                                                      ,[PrefixCode] = 'A'
                                                      ,[BranchID] = " & SearchBranch.EditValue & "
                                                      ,[Warehouse] =" & SearchWhereHouse.EditValue & "
                                                      ,[OnlineOnly] = 1
                                                      ,[Note1] = N''
                                                      ,[Note2] = N''
                                                      ,[PaperSize] = 0
                                                      ,[OpenCashDrawerOnSave] = 1
                                                      ,[ServerAddress] = ''
                                                      ,[Tickets] = ''
                                                      ,[UseDirectProduction] = 1
                                                      ,[SamabaPos] = 0
                                                      ,[TempAccounting] = ''
                                                      ,[DefaultPrinter] = N'" & SearchDefaultPrinter.Text & "'
                                                      ,[ResturantMode] = N'" & CheckResturantMode.EditValue & "'
                                                      ,[PrintVoucherByItemGroup] = N'" & CheckPrintVoucherByItemGroup.EditValue & "'
                                                 WHERE [ID] = " & TextPosID.EditValue
            If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                SavingTablesTable()
                SavingTablesLocations()
                MsgBoxShowSuccess(" تم تعديل بيانات نقطة البيع بنجاح ")
                Me.Dispose()
            Else
                MsgBoxShowError(" خطأ: لم يتم تعديل بيانات نقطة البيع ")
            End If


        End If

    End Sub

    Private Sub SearchBranch_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchBranch.Properties.AddNewValue
        Dim F As New AccountingBranches
        With F
            ._AddOrEdit = "Add"
            .Text = " اضافة فرع جديد "
            If .ShowDialog <> DialogResult.OK Then
                GetBranchesNames()
            End If
        End With
    End Sub

    Private Sub SearchBranch_EditValueChanged(sender As Object, e As EventArgs) Handles SearchBranch.EditValueChanged

    End Sub
    Private Sub GetBranchesNames()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  [ID],[BranchName],[BranchNameE],[BranchCode]
                      FROM [dbo].[AccountingBranches]  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.SearchBranch.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SearchWhereHouse_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchWhereHouse.Properties.AddNewValue
        Dim f As New AccountingLists
        With f
            .NavigationPane1.SelectedPage = .NavigationPane1.Pages(0)
            If .ShowDialog() <> DialogResult.OK Then
                SearchWhereHouse.Properties.DataSource = GetWharehouses(False)
            End If
        End With

    End Sub

    Private Sub SearchWhereHouse_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchWhereHouse.Properties.BeforePopup
        SearchWhereHouse.Properties.DataSource = GetWharehouses(False)
    End Sub

    Private Sub SearchDefaultPrinter_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchDefaultPrinter.Properties.BeforePopup
        SearchDefaultPrinter.Properties.DataSource = GetPrintersDataTable()
    End Sub

    Private Sub SearchDefaultPrinter_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchDefaultPrinter.Properties.AddNewValue
        SearchDefaultPrinter.Properties.DataSource = GetPrintersDataTable()
    End Sub

    Private Sub LookCostCenter_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles LookCostCenter.Properties.AddNewValue
        Dim f As New CostCenters
        With f
            If .ShowDialog() <> DialogResult.OK Then
                LookCostCenter.Properties.DataSource = GetCostCenter(False)
            End If
        End With
    End Sub
    Private Sub FItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewTables_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewTables.InitNewRow
        GridViewTables.SetRowCellValue(e.RowHandle, "POSNo", TextPosID.EditValue)
    End Sub
    Private Sub GridViewLocations_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewLocations.InitNewRow
        Dim _PosNo As Integer = TextPosID.EditValue
        GridViewLocations.SetRowCellValue(e.RowHandle, "PosNo", _PosNo)
    End Sub

    Private Sub RepositoryDelete_Click(sender As Object, e As EventArgs) Handles RepositoryDelete.Click


        Dim value = GridViewTables.GetRowCellValue(GridViewTables.FocusedRowHandle, "TableID")

        Dim _TableId As Integer
        If Not IsDBNull(value) Then
            _TableId = GridViewTables.GetRowCellValue(GridViewTables.FocusedRowHandle, "TableID")
            If CheckIfTableReserved(_TableId) = True Then
                MsgBoxShowError(" لا يمكن حذف الطاولة لانها محجوزة ")
                Exit Sub
            Else
                GridViewTables.DeleteRow(GridViewTables.FocusedRowHandle)
                SavingTablesTable()
            End If
        Else
            GridViewTables.DeleteRow(GridViewTables.FocusedRowHandle)
        End If




    End Sub
    Private Function CheckIfTableReserved(TableID As Integer) As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  Count(*) As Count
                      FROM [dbo].[POSHoldJournal] 
                      Where TableID=" & TableID & " "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows(0).Item("Count") > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SavingTablesLocations()
        GetTablesLocations()
    End Sub
End Class