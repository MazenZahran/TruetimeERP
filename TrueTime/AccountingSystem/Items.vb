Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.CodeParser
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI


Public Class Items
    Dim AdapterItemsUnits, AdapterBarcodeUnits, AdapterItemPortions As SqlDataAdapter
    Dim dataSet11 As DataSet
    Dim Con As SqlConnection
    Dim _Calc As Boolean = True
    Dim _Save As Boolean = True
    Dim _validategrid7 As Boolean = True
    Dim _HasTrans As Boolean
    Private _AutoGenerateBarcode As Boolean = True
    Private _HasMatjar As Boolean
    Public _OpenedFromDocument As Boolean
    Public _CopyItem As Boolean = False
    Private _AccountChanged As Boolean = False
    Dim _Colors As New DataTable
    Dim _Measures As New DataTable

    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.
        ' Me.ReferancesListTableAdapter.Fill(Me.AccountingDataSet.ReferancesList)
        _Measures = GetItemsMeasures()
        _Colors = GetItemsColors()
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroup1
        Me.SearchItemsCategories.Properties.DataSource = GetItemsCategories()
        Me.SearchItemsTradeMark.Properties.DataSource = GetItemsTradeMark()
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
        Me.RepositoryItemColors.DataSource = _Colors
        Me.SearchColor.Properties.DataSource = _Colors
        Me.SearchSize.Properties.DataSource = _Measures
        Me.RepositoryItemMeasures.DataSource = _Measures
        Me.SearchLookUpCostCenter.Properties.DataSource = GetCostCenter(False)
        Me.Vendor.Properties.DataSource = GetReferencesForItems(-1, -1, -1)
        LookItemsclassification.Properties.DataSource = GetItemsClassification()
        Me.ItemNo.Select()
        Me.ItemName.Select()
        Me.ItemName.SelectAll()
        Me.KeyPreview = True

        If GlobalVariables._UserAccessType = 98 Then
            LayoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        GetSettings()

        If _HasMatjar = True Then
            GridColumn27.OptionsColumn.ReadOnly = False
            GridColumn27.OptionsColumn.AllowEdit = True
        End If

        If GlobalVariables._ShowItemCostInItemScreenUser = False Then
            LayoutControlLastCost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlLastCostDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlLastCost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlLastCostDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

        If GlobalVariables._Shalash = True Then
            Me.BtnSendWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        SwitchKeyboardLayout("ar")
        If GlobalVariables.HasPosSystem Then
            LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub
    Private Sub GetSettings()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select [SettingName],[SettingValue] from [dbo].[Settings]  where [SettingName] IN ('E-Matjat','GenarateAutoBarcodeWhenSaveNewItem') ")
            For i = 0 To sql.SQLDS.Tables(0).Rows.Count - 1
                Select Case sql.SQLDS.Tables(0).Rows(i).Item("SettingName")
                    Case "E-Matjat"
                        _HasMatjar = CBool(sql.SQLDS.Tables(0).Rows(i).Item("SettingValue"))
                    Case "GenarateAutoBarcodeWhenSaveNewItem"
                        _AutoGenerateBarcode = CBool(sql.SQLDS.Tables(0).Rows(i).Item("SettingValue"))
                End Select
            Next
        Catch ex As Exception
            _HasMatjar = False
            _AutoGenerateBarcode = True
        End Try
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Saving()
        ElseIf e.KeyCode = Keys.F4 Then
            DeleteItem()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub GetItemsUntis(ItemID As Integer)
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select id,item_id,unit_id,main_unit,EquivalentToMain,case when item_unit_bar_code='0' then ''  else item_unit_bar_code end as item_unit_bar_code,Price1,Price2,Price3
                      From Items_units
                      Where item_id='" & ItemID & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControlUnits.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadUnitsAndBarcodes(ItemID As String)
        Dim SqlString1, SqlString2, SqlString3 As String


        SqlString1 = " Select A.id,item_id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,
                              Price1,Price2,Price3,IsUnit,isnull(TransCount,0) as TransCount,Color,Measure  from  
                      (Select IU.id,item_id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,
                               Price1,Price2,Price3,IsUnit,Color,Measure
                        From Items_units IU
                        Where item_id= '" & ItemID & "' and [IsUnit]=1 ) A
                        left join 
                     (select  count(id)  as TransCount,J.StockBarcode
                        from journal J 
                        where StockID='" & ItemID & "' 
                        group by StockBarcode) B
                    on A.item_unit_bar_code=B.StockBarcode "

        SqlString2 = " Select A.id,item_id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,
                              Price1,Price2,Price3,IsUnit,isnull(TransCount,0) as TransCount,Color,Measure  from  
                      (Select IU.id,item_id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,
                               Price1,Price2,Price3,IsUnit,Color,Measure
                        From Items_units IU
                        Where item_id= '" & ItemID & "' and [IsUnit]<>1 ) A
                        left join 
                     (select  count(id)  as TransCount,J.StockBarcode
                        from journal J 
                        where StockID='" & ItemID & "' 
                        group by StockBarcode) B
                    on A.item_unit_bar_code=B.StockBarcode"
        SqlString3 = "SELECT  [ID]      ,[ItemNo]      ,[PortionName],
                              [ItemPrice]      ,[AddOrRemove]
                      FROM [dbo].[ItemsPortions] where ItemNo=" & ItemID

        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
        Con.Open()
        AdapterItemsUnits = New SqlDataAdapter(SqlString1, Con)
        AdapterBarcodeUnits = New SqlDataAdapter(SqlString2, Con)
        AdapterItemPortions = New SqlDataAdapter(SqlString3, Con)


        dataSet11 = New System.Data.DataSet()
        AdapterItemsUnits.Fill(dataSet11, "Items_units")
        AdapterBarcodeUnits.Fill(dataSet11, "Items_Barcodes")
        AdapterItemPortions.Fill(dataSet11, "ItemsPortions")

        Me.GridControlUnits.DataSource = dataSet11.Tables("Items_units")
        Me.GridControlBarcodes.DataSource = dataSet11.Tables("Items_Barcodes")
        Me.GridPortions.DataSource = dataSet11.Tables("ItemsPortions")
        Con.Close()
    End Sub
    Private Sub GetUnitsNames()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select id,name from Units "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryUnitID.DataSource = Sql.SQLDS.Tables(0)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub GetUnitsBarcode(_ItemNo As String)
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  SELECT unit_id as id,U.name    FROM [dbo].[Items_units] UI
  left join Units U on U.id=UI.unit_id
  where item_id='" & _ItemNo & "' And UI.IsUnit = 1"
            sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryItemSearchBarcodes.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ServiceOrItem()
        Dim Sr As New DataTable
        Sr.Columns.Add("id", GetType(Integer))
        Sr.Columns.Add("ItemType", GetType(String))
        Sr.Rows.Add(0, "صنف")
        Sr.Rows.Add(1, "خدمة")
        Type.Properties.DataSource = Sr
    End Sub
    Public Function DefualtUnit() As DataTable
        Dim _DefualtUnit As New DataTable
        _DefualtUnit.Columns.Add("unit_id", GetType(Integer))
        _DefualtUnit.Columns.Add("main_unit", GetType(Boolean))
        _DefualtUnit.Columns.Add("EquivalentToMain", GetType(Decimal))
        _DefualtUnit.Columns.Add("item_unit_bar_code", GetType(String))
        _DefualtUnit.Columns.Add("Price1", GetType(Decimal))
        _DefualtUnit.Columns.Add("Price2", GetType(Decimal))
        _DefualtUnit.Columns.Add("Price3", GetType(Decimal))
        _DefualtUnit.Columns.Add("Color", GetType(Integer))
        _DefualtUnit.Columns.Add("Measure", GetType(Integer))
        _DefualtUnit.Columns.Add("IsUnit", GetType(Integer))
        Dim _Barcode As String
        If _AutoGenerateBarcode = True Then
            _Barcode = Me.ItemNo.Text & "000" & "1"
        Else
            _Barcode = "0"
        End If
        _DefualtUnit.Rows.Add(1, True, 1, _Barcode, 0, 0, 0, 1)
        Return _DefualtUnit
    End Function
    Private Sub ItemNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ItemNo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "1234567890"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Or e.KeyChar = " " Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub ItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles ItemNo.EditValueChanged

        If _CopyItem = True Then
            If _AutoGenerateBarcode = False Then
                GetItemsUntis(-1)
                GetUnitsNames()
                ServiceOrItem()
                'GetUnitsBarcode(ItemNo.EditValue)
                GridControlUnits.DataSource = DefualtUnit()
                GridControlBarcodes.DataSource = ""
            End If
            Exit Sub
        End If

        GetItemsUntis(-1)
        GetUnitsNames()
        ServiceOrItem()
        GetUnitsBarcode(ItemNo.EditValue)
        'GridItemsPriceCategories.DataSource = GetItemsPriceCategories(ItemNo.EditValue)

        Dim Accounts As New DataTable
        Accounts = GetFinancialAccounts(-1, -1, False, -1, -1)
        AccPurches.Properties.DataSource = Accounts
        AccSales.Properties.DataSource = Accounts
        AccRetPurches.Properties.DataSource = Accounts
        AccRetSales.Properties.DataSource = Accounts


        If CheckIfExisist(ItemNo.EditValue) = True Then
            Dim _ItemData = GetItemsData(ItemNo.EditValue, False)
            With Me
                .ItemName.Text = _ItemData.ItemName
                .Type.EditValue = _ItemData.ItemType
                .HasExpireDate.Checked = False
                .LastPurchasePrice.Text = _ItemData.LastPurchasePrice
                Try
                    .LastPurchaseDate.DateTime = CDate(_ItemData._LastPurchaseDate)
                Catch ex As Exception
                    .LastPurchaseDate.DateTime = "1900-01-01"
                End Try
                LoadUnitsAndBarcodes(ItemNo.EditValue)
                ' .GridControlItems.DataSource = _ItemData.ItemUnits
                .AccPurches.EditValue = _ItemData.AccPurches
                .AccSales.EditValue = _ItemData.AccSales
                .AccRetPurches.EditValue = AccRetPurches.EditValue
                .AccRetSales.EditValue = AccRetSales.EditValue
                .notes.Text = _ItemData.ItemNote
                .AccRetPurches.EditValue = _ItemData.AccRetPurches
                .AccRetSales.EditValue = _ItemData.AccRetSales
                .SearchItemsCategories.EditValue = _ItemData.CategoryID
                .SearchItemsTradeMark.EditValue = _ItemData.TradeMarkID
                .SearchItemsGroups.EditValue = _ItemData.GroupID
                .ItemNo2.Text = _ItemData._ItemNo2
                .ItemNo3.Text = _ItemData._ItemNo3
                .ItemNo4.Text = _ItemData._ItemNo4
                .Vendor.Text = _ItemData._Vendor
                .ProductCompany.Text = _ItemData._ProductCompany
                .WebSite1.Text = _ItemData._WebSite1
                .WebSite2.Text = _ItemData._WebSite2
                .VisibleInAPP.Checked = _ItemData._VisibleInAPP
                .ReOrderQuantity.EditValue = _ItemData.ReOrderQuantity
                .SearchLookUpCostCenter.EditValue = _ItemData.CostCenter
                .MaxQuantity.EditValue = _ItemData.MaxQuantity
                .LookItemsclassification.EditValue = _ItemData._LookItemsclassification
                .CheckUseBatch.EditValue = _ItemData.UseBatchNo
                Try
                    .SaleOnScale.EditValue = _ItemData.SaleOnScale
                Catch ex As Exception
                    .SaleOnScale.EditValue = False
                End Try
                .CheckRequirePriceInPOS.EditValue = _ItemData.RequirePriceInPOS
                .CheckHasSerial.Checked = _ItemData._HasSerial
                .CheckWithAddtions.Checked = _ItemData._WithAdditions
                .CheckSaleOnSamba.Checked = _ItemData.SaleOnSamba
                .ComboPeriodType.Text = _ItemData.PeriodType
                .TextPeriodCount.Text = _ItemData.PeriodCount
                .SearchSize.Text = _ItemData.DefaultSize
                .SearchColor.Text = _ItemData.DefaultColor
                TextNewOld.Text = "Old"
                GetImageCompany()
                GridControlBarcodes.Enabled = True
                GridPortions.Enabled = True
                'LayoutControlItemPorions.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                If ItemTrans() = True Then
                    'CheckHasSerial.Enabled = False
                    CheckHasSerial.Text = "سيريال" + " (البند لا يعمل بسبب وجود حركات على الصنف) "
                Else
                    'CheckHasSerial.Enabled = True
                    CheckHasSerial.Text = "سيريال"
                End If
                .LastNetPurchasePrice.Text = _ItemData.LastNetPurchasePrice
                .VisibleInPOS.EditValue = _ItemData.VisibleInPOS
                .TextTaxPercentage.EditValue = _ItemData.TaxPercentage
            End With
        Else
            With Me
                LoadUnitsAndBarcodes(ItemNo.EditValue)
                .ItemName.Text = ""
                .Type.EditValue = 0
                .HasExpireDate.Checked = False
                .LastPurchasePrice.Text = ""
                .GridControlUnits.DataSource = DefualtUnit()
                .AccPurches.EditValue = 4020000000
                .AccSales.EditValue = 3000000000
                .AccRetPurches.EditValue = 4030000000
                .AccRetSales.EditValue = 3010000000
                .notes.Text = ""
                .SearchItemsCategories.EditValue = ""
                .SearchItemsTradeMark.EditValue = ""
                .SearchItemsGroups.EditValue = ""
                .ItemImage.Image = Nothing
                .SaleOnScale.CheckState = False
                .ItemNo2.Text = ""
                .ItemNo3.Text = ""
                .ItemNo4.Text = ""
                .TextNewOld.Text = "New"
                .Vendor.EditValue = Nothing
                .VisibleInAPP.Checked = True
                .ReOrderQuantity.EditValue = 0
                .CheckHasSerial.Checked = False
                GridControlBarcodes.Enabled = False
                GridPortions.Enabled = False
                LayoutControlItemPorions.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.SearchLookUpCostCenter.Text = ""
                Me.MaxQuantity.EditValue = 0
                .LookItemsclassification.EditValue = 1
                CheckWithAddtions.Checked = False
                CheckUseBatch.Checked = False
                CheckSaleOnSamba.Checked = False
                CheckRequirePriceInPOS.Checked = False
                .ComboPeriodType.Text = ""
                .TextPeriodCount.Text = 0.0
                VisibleInPOS.EditValue = True
                TextTaxPercentage.EditValue = 0.0
                .TextTaxPercentage.EditValue = GlobalVariables.VATDefaultPercentage
            End With
        End If
    End Sub
    Private Sub GetImageCompany()
        Dim cn As SqlConnection
        cn = New SqlConnection
        cn.ConnectionString = My.Settings.TrueTimeConnectionString
        Dim cmd As New System.Data.SqlClient.SqlCommand("Select [ItemImage] from [dbo].[Items] where [ItemNo] ='" & ItemNo.Text & "'")
        cn.Open()
        Try
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            ItemImage.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try
        cn.Close()
    End Sub
    Private Function CheckIfExisist(ItemNo As String) As Boolean
        Dim _Result As Boolean
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select ItemNo from Items where ItemNo= '" & ItemNo & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")) Then
                _Result = True
            Else
                _Result = False
            End If
        Catch ex As Exception
            _Result = False
        End Try

        Return _Result
    End Function
    Private Function HasMainUnit() As Boolean
        For i = 0 To GridViewUnits.RowCount - 1
            Dim IsMain As Boolean = CBool(GridViewUnits.GetRowCellValue(i, "main_unit"))
            If IsMain Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub Saving()



        _Save = True

        Dim _CostCenter As Integer
        If SearchLookUpCostCenter.Text = "" Then _CostCenter = 0 : Else _CostCenter = SearchLookUpCostCenter.EditValue
        If GlobalVariables._UserAccessType = 98 Then
            Exit Sub
        End If
        'GridView4.AddNewRow()
        'GridView7.AddNewRow()
        'GridView4.CloseEditor()

        'GridView4.UpdateCurrentRow()

        'If GridView7.IsEditing = True Then
        '    GridView7.UpdateCurrentRow()
        '    GridView7.CloseEditor()
        '    GridView7.PostEditor()
        '    GridView7.CancelUpdateCurrentRow()
        'End If
        ' SimpleButton3.Select()
        ItemNo.Select()
        ' AddHandler GridView4.ValidateRow, AddressOf View_ValidateRow
        If _Save = False Then
            MsgBox("لا يمكن حفظ الصنف")
            _Save = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(ItemNo.Text) Then
            XtraMessageBox.Show("رقم الصنف فارغ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(ItemName.Text) Then
            XtraMessageBox.Show("اسم الصنف فارغ")
            Exit Sub
        End If
        If Len(ItemNo.Text) > 99 Then
            XtraMessageBox.Show("اسم الصنف طويل جدا")
            Exit Sub
        End If



        If HasMainUnit() = False Then
            XtraMessageBox.Show(" لا يوجد وحدة رئيسية للصنف، الرجاء اختيار وحدة رئيسية ")
            TabbedControlGroup1.SelectedTabPage = TabUnits
            Exit Sub
        End If

        For b = 0 To GridViewUnits.RowCount - 1
            Dim _Barcode As String
            _Barcode = GridViewUnits.GetRowCellValue(b, "item_unit_bar_code")
            If _Barcode = "" Or _Barcode = "0" Then
                Me.GridViewUnits.SetRowCellValue(b, "item_unit_bar_code", ItemNo.Text & "000" & b)
            End If
            If Me.ItemNo2.Text = _Barcode And GlobalVariables._Shalash = True Then
                MsgBoxShowError("لا يمكن استخدام نفس الباركود في رقم الصنف الثاني")
                Exit Sub
            End If
        Next


        If _HasMatjar = False Then
            _validategrid7 = False
            Dim j As Integer
            For j = 0 To GridViewAdditionalBarcodes.RowCount - 1
                Dim UnitID As Integer
                UnitID = GridViewAdditionalBarcodes.GetRowCellValue(j, "unit_id")
                For D = 0 To GridViewUnits.RowCount - 1
                    Dim UnitID2 As Integer = GridViewUnits.GetRowCellValue(D, "unit_id")
                    If UnitID = UnitID2 Then
                        Dim Price1 As Decimal = GridViewUnits.GetRowCellValue(D, "Price1")
                        GridViewAdditionalBarcodes.SetRowCellValue(j, "Price1", GridViewUnits.GetRowCellValue(D, "Price1"))
                        GridViewAdditionalBarcodes.SetRowCellValue(j, "Price2", GridViewUnits.GetRowCellValue(D, "Price2"))
                        GridViewAdditionalBarcodes.SetRowCellValue(j, "Price3", GridViewUnits.GetRowCellValue(D, "Price3"))
                    End If
                Next
            Next
        End If

        '  GridView7.EndDataUpdate()
        GridViewAdditionalBarcodes.MoveLast()

        Dim _ItemNo As Integer
        _ItemNo = Me.ItemNo.EditValue

        If Me.TextNewOld.Text = "Old" Then
            _ItemNo = Me.ItemNo.EditValue
        Else
            If CheckIfExisist(_ItemNo) = True Then
                ' Dim _ItemInItems As Integer
                Dim sql As New SQLControl
                Dim SqlString = " SELECT isnull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items  "
                sql.SqlTrueAccountingRunQuery(SqlString)
                _ItemNo = CInt(sql.SQLDS.Tables(0).Rows(0).Item("ItemNo"))
            Else
                _ItemNo = Me.ItemNo.EditValue
            End If



        End If

        Dim _thevendor As Integer
        If IsNothing(Vendor.EditValue) Then
            _thevendor = 0
        Else
            _thevendor = Vendor.EditValue
        End If

        If Me.TextNewOld.Text = "Old" Then
            Dim SqlString As String
            Dim Sql As New SQLControl

            SqlString = "Update Items
                                        Set ItemName=N'" & ItemName.Text & "', 
                                        [Type]=" & Type.EditValue & ",
                                        ReOrderQuantity='" & ReOrderQuantity.Text & "', 
                                        notes=N'" & notes.Text & "',
                                        HasExpireDate=N'" & HasExpireDate.EditValue & "',
                                        AccPurches='" & AccPurches.EditValue & "',
                                        AccRetPurches='" & AccRetPurches.EditValue & "',
                                        AccSales='" & AccSales.EditValue & "',
                                        AccRetSales='" & AccRetSales.EditValue & "',
                                        CategoryID='" & SearchItemsCategories.EditValue & "',
                                        TradeMarkID='" & SearchItemsTradeMark.EditValue & "',
                                        GroupID='" & SearchItemsGroups.EditValue & "',
                                        SaleOnScale=" & SaleOnScale.CheckState & ",
                                        ItemNo2='" & ItemNo2.Text & "',
                                        ItemNo3='" & ItemNo3.Text & "',
                                        ItemNo4='" & ItemNo4.Text & "',
                                        ProductCompany=N'" & ProductCompany.Text & "',
                                        WebSite1='" & WebSite1.Text & "',
                                        WebSite2='" & WebSite2.Text & "',
                                        VisibleInAPP='" & VisibleInAPP.CheckState & "',
                                        HasSerial='" & CheckHasSerial.CheckState & "',
                                        Vendor='" & _thevendor & "',
                                        CostCenter='" & _CostCenter & "',
                                        MaxQuantity=" & MaxQuantity.EditValue & ",
                                        classification=" & LookItemsclassification.EditValue & ",
                                        WithAdditions=" & CheckWithAddtions.CheckState & ",
                                        UseBatchNo=" & CheckUseBatch.CheckState & ",
                                        SaleOnSamba=" & CheckSaleOnSamba.CheckState & ",
                                        RequirePriceInPOS=" & CheckRequirePriceInPOS.CheckState & ",
                                        PeriodType=N'" & Me.ComboPeriodType.Text & "',
                                        PeriodCount='" & Me.TextPeriodCount.EditValue & "',
                                        ItemSize=N'" & Me.SearchSize.EditValue & "',
                                        ItemColor='" & Me.SearchColor.EditValue & "',
                                        VisibleInPOS='" & Me.VisibleInPOS.EditValue & "',
                                        TaxPercentage='" & Me.TextTaxPercentage.EditValue & "'
                                        Where ItemNo=" & ItemNo.EditValue & ""
            If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then
                XtraMessageBox.Show("لا يمكن تعديل الصنف")
                _validategrid7 = True
                Exit Sub
            End If

            Try
                Dim SqlCommBuil As SqlCommandBuilder
                SqlCommBuil = New SqlCommandBuilder(AdapterItemsUnits)
                AdapterItemsUnits.Update(dataSet11, "Items_units")
            Catch ex As Exception
                MsgBox("لا يمكن حفظ الوحدات")
            End Try

            Try
                Dim SqlCommBuil As SqlCommandBuilder
                SqlCommBuil = New SqlCommandBuilder(AdapterItemPortions)
                AdapterItemPortions.Update(dataSet11, "ItemsPortions")
            Catch ex As Exception
                MsgBox("لا يمكن حفظ الاضافات")
            End Try


            Try
                Dim SqlCommBuil As SqlCommandBuilder
                SqlCommBuil = New SqlCommandBuilder(AdapterBarcodeUnits)
                AdapterBarcodeUnits.Update(dataSet11, "Items_Barcodes")
            Catch ex As Exception
            End Try

            If _AccountChanged = True Then
                SqlString = " Declare @PurchaseAccount varchar(10)
                              Declare @SalesAccount    varchar(10)
                              Set @PurchaseAccount = '" & AccPurches.EditValue & "'
                              Set @SalesAccount    = '" & AccSales.EditValue & "'
                              Update Journal set DebitAcc=@PurchaseAccount where StockID=" & ItemNo.Text & " and DocName=1
                              Update Journal set CredAcc=@SalesAccount     where StockID=" & ItemNo.Text & " and DocName=2 "
                Dim _EditedTrans As Integer = Sql.SqlTrueAccountingRunQueryWithResultCount(SqlString)
                If _EditedTrans > 0 Then
                    MsgBoxShowSuccess(" تم تعديل " & _EditedTrans & " حركة سابقة ")
                End If
                _AccountChanged = False
            End If
            CreateDocLog("Item", "", "0", Me.ItemNo.Text, "Update", "Edit Item" & ":" & Me.ItemName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
            'SqlString2 = "Delete from Items_units where item_id= '" & ItemNo.EditValue & "'"
            'If Sql.SqlTrueAccountingRunQuery(SqlString2) = False Then XtraMessageBox.Show("لا يمكن حفظ الصنف") : Exit Sub

        Else
            Dim SqlString2 As String
            Dim Sql As New SQLControl
            SqlString2 = "Insert Into Items (ItemNo,ItemName,[Type],ReOrderQuantity,notes,AccSales,AccPurches,AccRetPurches,
                                             AccRetSales,HasExpireDate,CategoryID,TradeMarkID,GroupID,SaleOnScale,ItemNo2,
                                            ItemNo3,ItemNo4,WebSite1,WebSite2,ProductCompany,HasSerial,[ItemStatus],CostCenter,
                                            MaxQuantity,Vendor,classification,WithAdditions,UseBatchNo,SaleOnSamba,RequirePriceInPOS,
                                            PeriodType,PeriodCount,ItemColor,ItemSize,VisibleInPOS,TaxPercentage) Values (
                                            '" & _ItemNo & "',
                                            N'" & ItemName.Text & "',
                                            '" & Type.EditValue & "',
                                            '" & ReOrderQuantity.Text & "',
                                            N'" & notes.Text & "',
                                            '" & AccSales.EditValue & "',
                                            '" & AccPurches.EditValue & "',
                                            '" & AccRetPurches.EditValue & "',
                                            '" & AccRetSales.EditValue & "',
                                            '" & HasExpireDate.EditValue & "',
                                            '" & SearchItemsCategories.EditValue & "',
                                            '" & SearchItemsTradeMark.EditValue & "',
                                            '" & SearchItemsGroups.EditValue & "',
                                            " & SaleOnScale.CheckState & ",
                                            '" & ItemNo2.Text & "',
                                            '" & ItemNo3.Text & "',
                                            '" & ItemNo4.Text & "',
                                            '" & WebSite1.Text & "',
                                            '" & WebSite2.Text & "',
                                            N'" & ProductCompany.Text & "',
                                            '" & CheckHasSerial.CheckState & "',
                                            " & 1 & ",
                                            " & _CostCenter & " ,
                                            " & MaxQuantity.EditValue & " ,
                                            " & _thevendor & " ,
                                            " & LookItemsclassification.EditValue & ", 
                                            " & CheckWithAddtions.CheckState & ",
                                            " & CheckUseBatch.CheckState & ", 
                                            " & CheckSaleOnSamba.CheckState & " ,
                                            " & CheckRequirePriceInPOS.CheckState & ", 
                                            N'" & Me.ComboPeriodType.Text & "', 
                                            " & Me.TextPeriodCount.EditValue & " ,
                                            " & Me.SearchColor.EditValue & " ,
                                            " & Me.SearchSize.EditValue & " ,
                                            " & Me.VisibleInPOS.CheckState & " ,
                                            " & Me.TextTaxPercentage.EditValue & " 
                                            )"
            If Sql.SqlTrueAccountingRunQuery(SqlString2) = False Then XtraMessageBox.Show("لا يمكن حفظ الصنف") : Exit Sub

            'Sql.SqlTrueAccountingRunQuery("  Insert Into [dbo].[CostCenter] ( [CostName]) Values (N'" & ItemName.Text & "')  ")


            Try
                Dim i As Integer
                Dim SqlString As String
                For i = 0 To GridViewUnits.RowCount - 1
                    If Not String.IsNullOrEmpty(CStr(Me.GridViewUnits.GetRowCellValue(i, "unit_id"))) Then
                        Dim a, b, _Barcode, d, e As String
                        a = CStr(Me.GridViewUnits.GetRowCellValue(i, "unit_id"))
                        b = CStr(Me.GridViewUnits.GetRowCellValue(i, "EquivalentToMain"))
                        _Barcode = Me.GridViewUnits.GetRowCellValue(i, "item_unit_bar_code")
                        d = CStr(Me.GridViewUnits.GetRowCellValue(i, "Price1"))
                        e = CStr(Me.GridViewUnits.GetRowCellValue(i, "Price2"))
                        If _Barcode = "" Then _Barcode = "0"
                        SqlString = " Insert Into Items_units (item_id,unit_id,main_unit,EquivalentToMain,
                                             item_unit_bar_code,Price1,Price2,Price3,IsUnit) Values (
                                                '" & _ItemNo & "',
                                                '" & CStr(Me.GridViewUnits.GetRowCellValue(i, "unit_id")) & "',
                                                '" & CBool(Me.GridViewUnits.GetRowCellValue(i, "main_unit")) & "',
                                                '" & CStr(Me.GridViewUnits.GetRowCellValue(i, "EquivalentToMain")) & "',
                                                '" & _Barcode & "',
                                                " & CStr(Me.GridViewUnits.GetRowCellValue(i, "Price1")) & ",
                                                " & CStr(Me.GridViewUnits.GetRowCellValue(i, "Price2")) & ",
                                                " & CStr(Me.GridViewUnits.GetRowCellValue(i, "Price3")) & ",
                                                1)"
                        Sql.SqlTrueAccountingRunQuery(SqlString)
                    End If
                Next

                If GlobalVariables._Shalash = True Then
                    SendSMSMessage(CStr("120363399527426539"), Me.ItemName.Text & "  " & Me.ItemNo2.Text, "WhatsApp", True, "")
                End If
                'SendWhatsAppMessage()

                'For i = 0 To GridView7.RowCount - 1
                '    If Not String.IsNullOrEmpty(CStr(Me.GridView7.GetRowCellValue(i, "unit_id"))) Then
                '        SqlString = " Insert Into Items_units (item_id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,Price1) Values (
                '                                '" & _ItemNo & "',
                '                                '" & CStr(Me.GridView7.GetRowCellValue(i, "unit_id")) & "',
                '                                '" & CBool(Me.GridView7.GetRowCellValue(i, "main_unit")) & "',
                '                                '" & CStr(Me.GridView7.GetRowCellValue(i, "EquivalentToMain")) & "',
                '                                '" & Me.GridView7.GetRowCellValue(i, "item_unit_bar_code") & "',
                '                                " & CStr(Me.GridView7.GetRowCellValue(i, "Price1")) & "
                '                                )"
                '        Sql.SqlTrueAccountingRunQuery(SqlString)
                '    End If
                'Next
            Catch ex As Exception

            End Try
            CreateDocLog("Item", "", "0", Me.ItemNo.Text, "Insert", "Insert Item" & ":" & ItemName.Text, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
        End If

        If Me.TextNewOld.Text = "Old" Then
            If _HasMatjar = False Then
                Try
                    Dim sql2 As New SQLControl
                    Dim sqlstring As String
                    sqlstring = "   Update u
                                Set u.Price1 = s.Price1,
                                    u.Price2 = s.Price2,
                                    u.Price3 = s.Price3
                                From Items_units u
                                Inner join Items_units s on
                                u.item_id  = s.item_id and u.unit_id=S.unit_id 
                                Where u.item_id=" & ItemNo.EditValue & " And u.IsUnit=0 and s.IsUnit=1 "
                    sql2.SqlTrueAccountingRunQuery(sqlstring)
                Catch ex As Exception

                End Try
            End If
        End If



        ' SavePriceCategoriesTable()

        Try
            If Not ItemImage.Image Is Nothing Then
                Dim m As New IO.MemoryStream
                ItemImage.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhoto(b, _ItemNo)
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try

        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "UPDATE Items SET BarcodesCount = ( SELECT COUNT(*) FROM Items_units WHERE item_id = " & ItemNo.EditValue & " ) WHERE itemNo = " & ItemNo.EditValue
            sql.SqlTrueTimeRunQuery(sqlString)
        Catch ex As Exception

        End Try


        If _OpenedFromDocument = True Then
            GlobalVariables._TempItemNo = Me.ItemNo.Text
            GlobalVariables._ItemBarcodeGlobal = "0"
            GlobalVariables._ItemColorIDGlobal = 0
            GlobalVariables._ItemMeasureIDGlobal = 0
            Me.Close()
            Exit Sub
        End If
        'XtraMessageBox.Show("تم حفظ البيانات", "", MessageBoxButtons.OK)
        MsgBoxShowSuccess(" تم حفظ البيانات ")

        GridControlBarcodes.DataSource = ""
        GridControlUnits.DataSource = ""
        GridPortions.DataSource = ""
        Me.GridControlUnits.DataSource = DefualtUnit()

        Try
            ItemNo2.Text = ""
            ItemNo3.Text = ""
            ItemNo4.Text = ""
            Me.ItemNo.Text = GetLastItemNo()
        Catch ex As Exception

        End Try



        'LoadUnitsAndBarcodes(ItemNo.EditValue)
        'Me.GridControlItems.DataSource = DefualtUnit()


        Me.ItemName.Select()
        _validategrid7 = True
        SwitchKeyboardLayout("ar")


    End Sub
    Private Function GetLastItemNo() As Integer
        Dim _ItemInItems As Integer
        Try
            Dim sql As New SQLControl
            Dim SqlString = " SELECT isnull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            _ItemInItems = CInt(sql.SQLDS.Tables(0).Rows(0).Item("ItemNo"))
        Catch ex As Exception
            _ItemInItems = Me.ItemNo.EditValue + 1
        End Try
        Return _ItemInItems
    End Function

    'Private Sub SavePriceCategoriesTable()
    '    Dim i As Integer
    '    For i = 0 To GridView5.RowCount - 1
    '        Dim ID As Integer = CInt(Me.GridView5.GetRowCellValue(i, "ID"))
    '        Dim ItemPrice As Decimal = CDec(Me.GridView5.GetRowCellValue(i, "ItemPrice"))
    '        Dim PriceCategoryID As Integer = CInt(Me.GridView5.GetRowCellValue(i, "PriceID"))

    '        Select Case ID
    '            Case 0
    '                Try
    '                    Dim sql As New SQLControl
    '                    Dim SqlString As String
    '                    SqlString = " Insert Into  ItemsPriceCategories (ItemNo,PriceCategoryID,ItemPrice)
    '                                    Values
    '                                    ('" & ItemNo.EditValue & "'," & PriceCategoryID & "," & ItemPrice & ")"
    '                    sql.SqlTrueAccountingRunQuery(SqlString)
    '                Catch ex As Exception
    '                End Try
    '            Case > 0
    '                Try
    '                    Dim sql As New SQLControl
    '                    Dim SqlString As String
    '                    SqlString = " Update ItemsPriceCategories Set ItemPrice= " & ItemPrice & " Where ID=" & ID
    '                    sql.SqlTrueAccountingRunQuery(SqlString)
    '                Catch ex As Exception
    '                End Try
    '        End Select

    '    Next
    'End Sub

    Private Sub UpdatePriceCategories(ID As Integer, ItemPrice As Decimal)
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Update ItemsPriceCategories Set ItemPrice= " & ItemPrice & " Where ID=" & ID
            sql.SqlTrueAccountingRunQuery(SqlString)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub InsertNewPriceCategories()

    End Sub
    Private Sub GridView4_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewUnits.InitNewRow
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "main_unit", False)
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "Price1", 0)
        If _AutoGenerateBarcode = True Then
            Me.GridViewUnits.SetRowCellValue(e.RowHandle, "item_unit_bar_code", ItemNo.Text & "000" & GridViewUnits.RowCount)
        Else
            Me.GridViewUnits.SetRowCellValue(e.RowHandle, "item_unit_bar_code", "0")
        End If
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "IsUnit", True)
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "Price2", "0")
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "Price3", "0")
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "item_id", ItemNo.EditValue)
        Me.GridViewUnits.SetRowCellValue(e.RowHandle, "EquivalentToMain", 0)
    End Sub
    Private Sub GridView7_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewAdditionalBarcodes.InitNewRow
        Dim ItemData = GetUnitsData(ItemNo.EditValue, GetMainUnit(ItemNo.EditValue))
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "main_unit", False)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "Price1", ItemData._Price1)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "unit_id", GetMainUnit(ItemNo.EditValue))
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "IsUnit", False)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "Price2", ItemData._Price2)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "Price3", ItemData._Price3)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "item_id", ItemNo.EditValue)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "EquivalentToMain", ItemData.EquivalentToMain)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "Measure", 0)
        Me.GridViewAdditionalBarcodes.SetRowCellValue(e.RowHandle, "Color", 0)
    End Sub
    Private Sub GetUnitDetails()

    End Sub
    Private edit As BaseEdit = Nothing
    Dim _FieldName As String

    Private Sub GridView7_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewAdditionalBarcodes.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor
        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
    End Sub
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            GridViewAdditionalBarcodes.PostEditor()
            Dim _StockID As String = "0"
            Dim _Unit As Integer
            Try
                _StockID = ItemNo.EditValue
            Catch ex As Exception
                _StockID = "0"
            End Try
            Try
                _Unit = CInt(Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "unit_id"))
            Catch ex As Exception
                _Unit = 0
            End Try
            Select Case _FieldName
                Case "unit_id"
                    If _StockID <> "0" And _Unit <> "0" Then
                        Dim ItemData = GetUnitsData(_StockID, _Unit)
                        GridViewAdditionalBarcodes.SetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, GridViewAdditionalBarcodes.Columns("EquivalentToMain"), ItemData.EquivalentToMain)
                        GridViewAdditionalBarcodes.SetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, GridViewAdditionalBarcodes.Columns("Price1"), ItemData._Price1)
                        GridViewAdditionalBarcodes.SetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, GridViewAdditionalBarcodes.Columns("Price2"), ItemData._Price2)
                        GridViewAdditionalBarcodes.SetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, GridViewAdditionalBarcodes.Columns("Price3"), ItemData._Price3)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GridView4_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewUnits.ShownEditor
        If _Calc = True Then
            Dim view As ColumnView = DirectCast(sender, ColumnView)
            _FieldName = view.FocusedColumn.FieldName
            Dim view2 As GridView = TryCast(sender, GridView)
            edit = view2.ActiveEditor
            AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged4
        End If
    End Sub
    Private Sub Edit_EditValueChanged4(ByVal sender As Object, ByVal e As EventArgs)
        Try
            GridViewUnits.PostEditor()
            Dim _StockID As String = "0"
            Dim _Unit As Integer
            Try
                _StockID = ItemNo.EditValue
            Catch ex As Exception
                _StockID = "0"
            End Try
            Try
                _Unit = CInt(Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "unit_id"))
            Catch ex As Exception
                _Unit = 0
            End Try
            Select Case _FieldName
                Case "unit_id"
                    Dim i As Integer
                    For i = 0 To GridViewUnits.RowCount - 1
                        Dim StockbARCODE = Me.GridViewUnits.GetRowCellValue(i, "unit_id")
                        Dim FocusStockbARCODE = Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "unit_id")
                        Dim _RowHandel As Integer = GridViewUnits.GetDataSourceRowIndex(i)
                        Dim _RowHandelFocus As Integer = GridViewUnits.GetFocusedDataSourceRowIndex()
                        If _RowHandel <> _RowHandelFocus And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "unit_id") = StockbARCODE And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "unit_id") <> "0" Then
                            ' GridView4.DeleteSelectedRows()
                            GridViewUnits.SetRowCellValue(GridViewUnits.FocusedRowHandle, "unit_id", "0")
                            MsgBox("لا يمكن اختيار اكثر من نفس الوحدة للصناف")
                        End If
                    Next
                Case "main_unit"
                    Dim i As Integer
                    For i = 0 To GridViewUnits.RowCount - 1
                        Dim StockbARCODE = Me.GridViewUnits.GetRowCellValue(i, "main_unit")
                        Dim FocusStockbARCODE = Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "main_unit")
                        Dim _RowHandel As Integer = GridViewUnits.GetDataSourceRowIndex(i)
                        Dim _RowHandelFocus As Integer = GridViewUnits.GetFocusedDataSourceRowIndex()
                        If _RowHandel <> _RowHandelFocus And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "main_unit") = StockbARCODE And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "main_unit") <> "0" Then
                            MsgBox("Error")
                            _Calc = False
                            GridViewUnits.SetRowCellValue(GridViewUnits.FocusedRowHandle, "main_unit", False)
                            _Calc = True
                        End If
                    Next
                Case "Price1"
                    If Me.TextNewOld.Text = "New" Then
                        Dim _Price1 As Decimal
                        _Price1 = GridViewUnits.GetFocusedRowCellValue("Price1")
                        GridViewUnits.SetFocusedRowCellValue("Price2", _Price1)
                        GridViewUnits.SetFocusedRowCellValue("Price3", _Price1)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function GetUnitsData(ItemNo As String, Unit As Integer) As _
    (EquivalentToMain As Decimal, _Price1 As Decimal, _Price2 As Decimal, _Price3 As Decimal)

        Dim _EquivalentToMain As Decimal = 0
        Dim _Price1 As Decimal = 0
        Dim _Price2 As Decimal = 0
        Dim _Price3 As Decimal = 0
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  
                      SELECT U.id,U.name, Price1,Price2,Price3,case when item_unit_bar_code='0' then ''  else item_unit_bar_code end as item_unit_bar_code,EquivalentToMain
                      FROM [dbo].[Items_units] UI
                      left join Units U on U.id=UI.unit_id
                      left join Items I on I.ItemNo=UI.item_id 
                      where U.id=" & Unit & " and I.ItemNo='" & ItemNo & "'"
        sql.SqlTrueAccountingRunQuery(SqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain"))) Then _EquivalentToMain = sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Price1"))) Then _Price1 = sql.SQLDS.Tables(0).Rows(0).Item("Price1")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Price2"))) Then _Price2 = sql.SQLDS.Tables(0).Rows(0).Item("Price2")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Price3"))) Then _Price3 = sql.SQLDS.Tables(0).Rows(0).Item("Price3")
        End If
        Return (_EquivalentToMain, _Price1, _Price2, _Price3)
    End Function
    Private Function GetMainUnit(ItemNo As String)
        Dim _Unit As Integer = 1
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "   SELECT U.id as id
                              FROM [dbo].[Items_units] UI
                              left join Units U on U.id=UI.unit_id
                              left join Items I on I.ItemNo=UI.item_id 
                              where  I.ItemNo=" & ItemNo & " and UI.main_unit= 1  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Unit = sql.SQLDS.Tables(0).Rows(0).Item("id")
        Catch ex As Exception
            _Unit = 1
        End Try
        Return _Unit
    End Function

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        Saving()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        DeleteItem()
    End Sub

    Private Sub DeleteItem()
        Dim Sql As New SQLControl
        Dim _Result1, _Result2 As String
        Sql.SqlTrueAccountingRunQuery(" Select isnull(Count(StockID),0) As Count 
                                        from [Journal] 
                                        where StockID='" & ItemNo.EditValue & "' And DocStatus> 0 ")
        If Sql.SQLDS.Tables(0).Rows(0).Item("Count") > 0 Then
            XtraMessageBox.Show("خطا: الصنف له حركات لا يمكن حذف الصنف")
            Exit Sub
        End If

        Sql.SqlTrueAccountingRunQuery(" Select IsNull([HasProductionEquation],0) As HasProductionEquation  From [dbo].[Items] Where [ItemNo]= " & ItemNo.EditValue)
        If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("HasProductionEquation")) = True Then
            XtraMessageBox.Show("خطا: الصنف له معادلة انتاج لا يمكن حذفه")
            Exit Sub
        End If

        Sql.SqlTrueAccountingRunQuery(" Select isnull(Count([RawItemNo]),0) As Count  From [dbo].[ProductionEquation] Where [RawItemNo]= " & ItemNo.EditValue)
        If Sql.SQLDS.Tables(0).Rows(0).Item("Count") > 0 Then
            XtraMessageBox.Show("خطا: الصنف داخل في معادلات انتاج لا يمكن حذفه")
            Exit Sub
        End If


        If XtraMessageBox.Show("هل تريد حذف الصنف ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Try
                _Result1 = Sql.SqlTrueAccountingRunQuery("Delete from [Items] where ItemNo='" & ItemNo.Text & "'")
                If _Result1 = "True" Then
                    _Result2 = Sql.SqlTrueAccountingRunQuery("Delete from [Items_units] where item_id='" & ItemNo.Text & "'")
                    If _Result1 = "True" And _Result2 = "True" Then
                        MsgBox("تم حذف الصنف")
                    End If
                Else
                    MsgBox("لا يمكن حذف الصنف")
                End If
            Catch ex As Exception
                XtraMessageBox.Show("خطا: لا يمكن حذف الصنف")
            End Try

        End If
        Me.Dispose()

    End Sub

    Private Sub ItemName_Validating(sender As Object, e As CancelEventArgs) Handles ItemName.Validating
        ItemName.Text = ItemName.Text.Replace(",", "").Replace("'", "")
    End Sub





    Private Sub SavePhoto(ByVal bytPhoto As Byte(), _ItemNo As String)
        Try
            Dim SQLString As String = " UPDATE [Items] "
            SQLString = SQLString + " SET ItemImage = @photo  WHERE [ItemNo] = " & _ItemNo
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

    Private Sub GridView4_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewUnits.CellValueChanged

        ''If e.Column.FieldName = "item_unit_bar_code" Then
        'Dim StockParcode = Me.GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "item_unit_bar_code")
        'Dim _id As Integer
        'Try
        '    _id = Me.GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "id")
        'Catch ex As Exception
        '    _id = 0
        'End Try

        'Dim _idOnData As Integer = SearchBarcodeIfFound(StockParcode)
        'If _idOnData <> 0 And _id <> _idOnData Then
        '    XtraMessageBox.Show("الباركود موجود مسبقا")
        '    Return
        'End If

        'End If

    End Sub
    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridViewUnits.ValidateRow
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim BarcodeCodeCol As GridColumn = view.Columns("item_unit_bar_code")
        Dim StockParcode = Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "item_unit_bar_code")
        Try

            Dim _id As Integer
            Try
                _id = Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "id")
            Catch ex As Exception
                _id = 0
            End Try

            Dim _idOnData As String = SearchBarcodeIfFound(StockParcode)
            If _idOnData <> 0 And _id <> _idOnData And StockParcode <> "0" And StockParcode <> "" Then
                ' XtraMessageBox.Show("الباركود موجود مسبقا")
                e.Valid = False
                e.ErrorText = "الباركود مكرر"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = BarcodeCodeCol
                view.ShowEditor()
            End If

        Catch ex As Exception

        End Try

        Try
            Dim i As Integer
            For i = 0 To GridViewUnits.RowCount - 1
                Dim StockbARCODE = Me.GridViewUnits.GetRowCellValue(i, "item_unit_bar_code")
                Dim FocusStockbARCODE = Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "item_unit_bar_code")
                Dim _RowHandel As Integer = GridViewUnits.GetDataSourceRowIndex(i)
                Dim _RowHandelFocus As Integer = GridViewUnits.GetFocusedDataSourceRowIndex()
                If _RowHandel <> _RowHandelFocus And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "item_unit_bar_code") = StockbARCODE And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "item_unit_bar_code") <> "0" And Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "item_unit_bar_code") <> "" Then
                    e.Valid = False
                    e.ErrorText = "الباركود مكرر بنفس السند"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = BarcodeCodeCol
                    view.ShowEditor()
                    _Save = False
                End If
            Next
        Catch ex As Exception

        End Try

        Dim ColEquivalentToMain As GridColumn = view.Columns("EquivalentToMain")
        Try
            Dim _EquivalentToMain As Decimal
            _EquivalentToMain = CDec(Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "EquivalentToMain"))
            If _EquivalentToMain = 0 Then
                e.Valid = False
                e.ErrorText = "يجب تحديد عدد الوحدات "
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = ColEquivalentToMain
                view.ShowEditor()
                _Save = False
            End If
        Catch ex As Exception
            e.Valid = False
            e.ErrorText = "يجب تحديد عدد الوحدات "
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = ColEquivalentToMain
            view.ShowEditor()
        End Try



        Try
            Dim _EquivalentToMain As Decimal
            Dim _main_unit As Boolean
            _main_unit = CBool(Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "main_unit"))
            _EquivalentToMain = CDec(Me.GridViewUnits.GetRowCellValue(GridViewUnits.FocusedRowHandle, "EquivalentToMain"))
            If _main_unit = True AndAlso (_EquivalentToMain = 0 Or _EquivalentToMain > 1) Then
                e.Valid = False
                e.ErrorText = " غير ممكن ان يكون عدد الوحدات صحيح للوحدة الرئيسية  "
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = ColEquivalentToMain
                view.ShowEditor()
                _Save = False
            End If
        Catch ex As Exception
            e.Valid = False
            e.ErrorText = "غير ممكن ان يكون عدد الوحدات صحيح للوحدة الرئيسية "
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = ColEquivalentToMain
            view.ShowEditor()
        End Try

    End Sub

    Private Sub View7_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridViewAdditionalBarcodes.ValidateRow
        If _validategrid7 = False Then Exit Sub
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim BarcodeCodeCol As GridColumn = view.Columns("item_unit_bar_code")
        Dim StockParcode = Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "item_unit_bar_code")
        Try
            Dim _id As Integer
            Try
                _id = Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "id")
            Catch ex As Exception
                _id = 0
            End Try

            Dim _idOnData As String = SearchBarcodeIfFound(StockParcode)
            If _idOnData <> 0 And _id <> _idOnData And StockParcode <> "0" And StockParcode <> "" Then
                ' XtraMessageBox.Show("الباركود موجود مسبقا")
                e.Valid = False
                e.ErrorText = "الباركود مكرر"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = BarcodeCodeCol
                view.ShowEditor()
                _Save = False
            End If
        Catch ex As Exception

        End Try
        If String.IsNullOrEmpty(StockParcode) Or StockParcode = "0" Then
            e.Valid = False
            e.ErrorText = "الباركود فارغ"
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = BarcodeCodeCol
            view.ShowEditor()
            _Save = False
        End If

        Dim UnitCol As GridColumn = view.Columns("unit_id")
        Try
            Dim _Unit As Integer
            _Unit = Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "unit_id")
        Catch ex As Exception
            e.Valid = False
            e.ErrorText = " يجب اختيار الوحدة"
            view.FocusedRowHandle = e.RowHandle
            view.FocusedColumn = UnitCol
            view.ShowEditor()
            _Save = False
        End Try


        Try
            Dim i As Integer
            For i = 0 To GridViewAdditionalBarcodes.RowCount - 1
                Dim StockbARCODE = Me.GridViewAdditionalBarcodes.GetRowCellValue(i, "item_unit_bar_code")
                If IsNothing(StockbARCODE) Then Exit Sub
                If StockbARCODE <> "" Or StockbARCODE <> "0" Then
                    Dim FocusStockbARCODE = Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "item_unit_bar_code")
                    Dim _RowHandel As Integer = GridViewAdditionalBarcodes.GetDataSourceRowIndex(i)
                    Dim _RowHandelFocus As Integer = GridViewAdditionalBarcodes.GetFocusedDataSourceRowIndex()
                    If _RowHandel <> _RowHandelFocus And Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "item_unit_bar_code") = StockbARCODE And Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "item_unit_bar_code") <> "0" And Me.GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "item_unit_bar_code") <> "" Then
                        e.Valid = False
                        e.ErrorText = "الباركود مكرر بنفس السند"
                        view.FocusedRowHandle = e.RowHandle
                        view.FocusedColumn = BarcodeCodeCol
                        view.ShowEditor()
                        _Save = False
                    End If
                End If

            Next
        Catch ex As Exception

        End Try

    End Sub


    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        ' save items units
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(AdapterItemsUnits)
            AdapterItemsUnits.Update(dataSet11, "Items_units")
        Catch ex As Exception

        End Try
        LoadUnitsAndBarcodes(ItemNo.EditValue)
    End Sub

    Private Function SearchBarcodeIfFound(_Barcode As String) As Integer
        Dim _Result As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select top 1 item_unit_bar_code,id from [dbo].[Items_units] where item_unit_bar_code ='" & _Barcode & "'")
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Result = Sql.SQLDS.Tables(0).Rows(0).Item("id")
            Else
                _Result = 0
            End If
        Catch ex As Exception
            _Result = 0
        End Try
        Return _Result
    End Function

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(AdapterBarcodeUnits)
            AdapterBarcodeUnits.Update(dataSet11, "Items_Barcodes")
        Catch ex As Exception

        End Try
        ' LoadUnitsAndBarcodes(ItemNo.EditValue)
    End Sub

    Private Sub GridControlItems_Click(sender As Object, e As EventArgs) Handles GridControlUnits.Click

    End Sub
    Private Sub GridControlItems_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControlUnits.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If


        If e.KeyCode = Keys.Delete AndAlso e.Control AndAlso view.Editable _
            AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True

            If view.GetRowCellValue(view.FocusedRowHandle, "TransCount") > 0 Then
                XtraMessageBox.Show("الوحدة لها حركات لا يمكن حذفها")
                Return
            End If

            Dim _MainUnit As Boolean
            _MainUnit = view.GetRowCellValue(view.FocusedRowHandle, "main_unit")
            If _MainUnit = True Then
                XtraMessageBox.Show("وحدة رئيسية، لا يمكن حذفها")
                Return
            End If

            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridViewUnits.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.F1 Then

        End If
    End Sub


    Private Sub GridControlBarcodes_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControlBarcodes.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If


        If e.KeyCode = Keys.Delete AndAlso view.Editable _
            AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True

            If Not IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, "TransCount")) Then
                If view.GetRowCellValue(view.FocusedRowHandle, "TransCount") > 0 Then
                    XtraMessageBox.Show("الوحدة لها حركات لا يمكن حذفها")
                    Return
                End If
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridViewAdditionalBarcodes.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.F1 Then

        End If
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim webAddress As String = WebSite1.Text
        Process.Start(webAddress)
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim webAddress As String = WebSite2.Text
        Process.Start(webAddress)
    End Sub

    Private Sub VisibleInAPP_CheckedChanged(sender As Object, e As EventArgs) Handles VisibleInAPP.CheckedChanged

    End Sub



    Private Sub SearchItemsGroups_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsGroups.BeforePopup
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
    End Sub

    'Private Sub SearchItemsTradeMark_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsTradeMark.AddNewValue
    '    ItemsList.Show()
    'End Sub

    'Private Sub SearchItemsCategories_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsCategories.AddNewValue
    '    ItemsList.Show()
    'End Sub

    Private Sub SearchItemsCategories_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsCategories.BeforePopup
        Me.SearchItemsCategories.Properties.DataSource = GetItemsCategories()
    End Sub

    Private Sub SearchItemsTradeMark_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsTradeMark.BeforePopup
        Me.SearchItemsTradeMark.Properties.DataSource = GetItemsTradeMark()
    End Sub

    Private Sub RepositoryItemColors_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemColors.BeforePopup
        'Me.RepositoryItemColors.DataSource = GetItemsColors()
    End Sub
    Private Sub RepositoryItemMeasures_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemMeasures.BeforePopup
        'Me.RepositoryItemMeasures.DataSource = GetItemsMeasures()
    End Sub
    Private Sub SearchItemsGroups_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsGroups.Properties.AddNewValue
        AccountingLists.NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(6)
        AccountingLists.ShowDialog()
    End Sub
    Private Sub SearchItemsCategories_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsCategories.Properties.AddNewValue
        AccountingLists.NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(4)
        AccountingLists.ShowDialog()
    End Sub

    Private Sub SearchItemsTradeMark_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsTradeMark.Properties.AddNewValue
        AccountingLists.NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(5)
        AccountingLists.ShowDialog()
    End Sub

    Private Sub SearchItemsGroups_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsGroups.Properties.BeforePopup
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
    End Sub

    Private Sub SearchItemsCategories_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsCategories.Properties.BeforePopup
        Me.SearchItemsCategories.Properties.DataSource = GetItemsCategories()
    End Sub

    Private Sub SearchItemsTradeMark_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsTradeMark.Properties.BeforePopup
        Me.SearchItemsTradeMark.Properties.DataSource = GetItemsTradeMark()
    End Sub

    Private Sub ReOrderQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles ReOrderQuantity.EditValueChanged

    End Sub

    Private Sub CheckHasSerial_CheckedChanged(sender As Object, e As EventArgs) Handles CheckHasSerial.CheckedChanged
        'XtraMessageBox.Show("خطا: الصنف له حركات لا يمكن تعديله")


    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Function ItemTrans() As Boolean
        Dim Sql As New SQLControl
        Dim _Result As Boolean
        Try
            Sql.SqlTrueAccountingRunQuery(" Select isnull(Count(StockID),0) As Count 
                                        from [Journal] 
                                        where StockID='" & ItemNo.EditValue & "' And DocStatus> 0 ")
            If Sql.SQLDS.Tables(0).Rows(0).Item("Count") > 0 Then
                _Result = True
            Else
                _Result = False
            End If
        Catch ex As Exception
            _Result = False
        End Try
        Return _Result
    End Function

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        DeleteItem()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim F As New ProductionRowItemLastEquations
        With F
            Dim _ItemNo As Integer
            _ItemNo = ItemNo.EditValue
            .RefreshDataToGetRowItemEquations(_ItemNo)
            .Text = "معادلات الانتاج للصنف"
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = ItemNo.EditValue
            .TextPurchaseOrSale.Text = 1
            .TextItemName.Text = ItemName.Text
            .Text = "اخر اسعار الشراء "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = ItemNo.EditValue
            .Warehouses.Text = 1
            .Text = " حركة صنف ( " & ItemName.Text & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = ItemNo.EditValue
            .TextPurchaseOrSale.Text = 2
            .TextItemName.Text = ItemName.Text
            .GetLastPrices(-1)
            .Text = "اخر اسعار البيع "
            .Show()
        End With
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim sqlstring As String
        Dim sql As New SQLControl
        Dim _EquationID As Integer
        Try
            sqlstring = "  select top(1) EquationID from [dbo].[ProductionEquation] where [ItemNo] = " & ItemNo.EditValue
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _EquationID = sql.SQLDS.Tables(0).Rows(0).Item("EquationID")
            End If
        Catch ex As Exception
            _EquationID = 0
        End Try
        If _EquationID <> 0 Then

            Dim F As New ProductionEquation
            With F
                .EquationIDQuery.EditValue = _EquationID
                .ProductionEquationTableAdapter.FillByEquationID(.AccountingDataSet.ProductionEquation, .EquationIDQuery.EditValue)

                .ShowDialog()
            End With
        Else
            XtraMessageBox.Show("لا يوجد معادلات انتاج لهذا الصنف")
        End If
    End Sub

    Private Sub ProductCompany_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Vendor.Properties.BeforePopup
        Me.Vendor.Properties.DataSource = GetReferencesForItems(-1, -1, -1)
    End Sub


    Private Sub ItemName_MouseUp(sender As Object, e As MouseEventArgs) Handles ItemName.MouseUp
        'TextEditSelectText(ItemName)
    End Sub

    Private Sub ReOrderQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles ReOrderQuantity.MouseUp
        TextEditSelectText(ReOrderQuantity)
    End Sub

    Private Sub ItemNo2_MouseUp(sender As Object, e As MouseEventArgs) Handles ItemNo2.MouseUp
        TextEditSelectText(ItemNo2)
    End Sub

    Private Sub ItemNo3_MouseUp(sender As Object, e As MouseEventArgs) Handles ItemNo3.MouseUp
        TextEditSelectText(ItemNo3)
    End Sub

    Private Sub ItemNo4_MouseUp(sender As Object, e As MouseEventArgs) Handles ItemNo4.MouseUp
        TextEditSelectText(ItemNo4)
    End Sub

    Private Sub SearchLookUpEdit1_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchLookUpCostCenter.Properties.AddNewValue
        Dim f As New CostCenters
        With f
            If .ShowDialog <> DialogResult.OK Then
                Me.SearchLookUpCostCenter.Properties.DataSource = GetCostCenter(False)
            End If
        End With
    End Sub

    'Private Sub gridView4_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView4.ShownEditor
    '    Dim gridView As GridView = TryCast(sender, GridView)
    '    hilite(TryCast(gridView.ActiveEditor, TextEdit))
    '    Return
    'End Sub
    'Private Sub hilite(ByVal sender As Object)
    '    Dim textbox = CType(sender, TextEdit)
    '    BeginInvoke(New MethodInvoker(Function()
    '                                      textbox.SelectionStart = 0
    '                                      textbox.SelectionLength = textbox.Text.Length
    '                                  End Function))
    'End Sub

    Private Sub Items_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Saving()
    End Sub

    Private Sub RepositoryItemMeasures_Popup(sender As Object, e As EventArgs) Handles RepositoryItemMeasures.Popup

    End Sub



    Private Sub RepositoryItemColors_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles RepositoryItemColors.AddNewValue
        Dim f As New AccountingLists
        With f
            .NavigationPane1.SelectedPage = .NavigationPageColors
            If .ShowDialog() <> DialogResult.OK Then
                Me.RepositoryItemColors.DataSource = GetItemsColors()
            End If
        End With
    End Sub

    Private Sub GridViewItemsPortions_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridViewItemsPortions.InitNewRow
        Me.GridViewItemsPortions.SetRowCellValue(e.RowHandle, "ItemNo", ItemNo.EditValue)
        Me.GridViewItemsPortions.SetRowCellValue(e.RowHandle, "AddOrRemove", "اضافة")

        Me.GridViewItemsPortions.SetRowCellValue(e.RowHandle, "ItemPrice", GridViewUnits.GetRowCellValue(0, "Price1"))

    End Sub

    Private Sub RepositoryItemButtonDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonDelete.ButtonClick
        GridViewItemsPortions.DeleteSelectedRows()
    End Sub

    Private Sub BarButtonItemBalanceByBatch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemBalanceByBatch.ItemClick
        Dim f As New ItemsAvailableBatches
        With f
            .GridColumn1.Visible = False
            .TextItemNo.Text = Me.ItemNo.Text
            .TextItemName.Text = Me.ItemName.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub RepositoryItemMeasures_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles RepositoryItemMeasures.AddNewValue
        Dim f As New AccountingLists
        With f
            .NavigationPane1.SelectedPage = .Measures
            If .ShowDialog() <> DialogResult.OK Then
                Me.RepositoryItemMeasures.DataSource = GetItemsMeasures()
            End If
        End With
    End Sub

    Private Sub ItemName_EditValueChanged(sender As Object, e As EventArgs) Handles ItemName.EditValueChanged
        ChangeFromText()
    End Sub
    'Public Function FindItemBarcode(_Barcode As String) As (_item_unit_bar_code As String, _ID As Integer)
    '    Dim sql As New SQLControl
    '    Dim SqlString As String
    '    SqlString = "  Select top 1 id,item_unit_bar_code from [dbo].[Items_units] where item_unit_bar_code ='" & _Barcode & "'"
    '    sql.SqlTrueAccountingRunQuery(SqlString)
    '    Dim _item_unit_bar_code As String = "0"
    '    Dim _ID As Integer = 0
    '    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("id"))) Then _ID = sql.SQLDS.Tables(0).Rows(0).Item("id").ToString
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code"))) Then _item_unit_bar_code = sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")
    '    End If
    '    Return (_item_unit_bar_code, _ID)
    'End Function
    Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewAdditionalBarcodes.CellValueChanged
        'Dim view As BandedGridView = sender
        'If view Is Nothing Then
        '    Return
        'End If
        'If e.Column.Caption <> "FirstName" Then
        '    Return
        'End If
        'Dim cellValue As String = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns("LastName")).ToString()
        'view.SetRowCellValue(e.RowHandle, view.Columns("FullName"), cellValue)
    End Sub

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        ChangeFromText()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick

        Dim sqlstring As String
        Dim sql As New SQLControl
        Dim _EquationID As Integer
        Try
            sqlstring = "  select top(1) EquationID from [dbo].[ProductionEquation] where [ItemNo] = " & ItemNo.EditValue
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _EquationID = sql.SQLDS.Tables(0).Rows(0).Item("EquationID")
            End If
        Catch ex As Exception
            _EquationID = 0
        End Try

        If _EquationID = 0 Then
            Dim f As ProductionEquation = New ProductionEquation()
            With f
                .Show()
                .AddNewEquation()
                .SearchItems.EditValue = ItemNo.EditValue
            End With
        Else
            MsgBoxShowError(" الصنف له معادلة انتاج ")
        End If

    End Sub

    Private Sub ItemName_Leave(sender As Object, e As EventArgs) Handles ItemName.Leave
        If Me.ItemName.Text <> "" Then
            If CheckIfItemNameExist(Me.ItemNo.Text, Me.ItemName.Text) = True Then
                If XtraMessageBox.Show(" اسم الصنف موجود مسبقا هل تريد الاستمرار؟ ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, DefaultBoolean.Default) = DialogResult.No Then
                    Me.ItemName.Select()
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Private Sub ChangeFromText()
        If TextNewOld.Text = "Old" Then
            Me.Text = " تعديل بيانات الصنف " & ": " & Me.ItemName.Text
        ElseIf TextNewOld.Text = "New" Then
            Me.Text = " اضافة صنف جديد " & ": " & Me.ItemName.Text
        End If
    End Sub

    Private Sub BtnSendWhatsApp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnSendWhatsApp.ItemClick
        If GlobalVariables._Shalash = True Then
            SendSMSMessage(CStr("120363282114960152"), Me.ItemName.Text & "  " & Me.ItemNo2.Text, "WhatsApp", True, "")
        End If
    End Sub

    Private Sub AccPurches_EditValueChanged(sender As Object, e As EventArgs) Handles AccPurches.EditValueChanged
        If Me.IsHandleCreated Then
            If Me.TextNewOld.Text = "Old" Then
                If AccSales.Text = "" Or AccPurches.Text = "" Or ItemNo.Text = "" Or ItemName.Text = "" Then
                    Exit Sub
                Else
                    If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد تعديل الحساب للحركات المالية القديمة؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        _AccountChanged = True
                    Else
                        _AccountChanged = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RepositoryDelete_Click(sender As Object, e As EventArgs) Handles RepositoryDelete.Click
        If XtraMessageBox.Show("هل تريد حذف الباركود ؟ ", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Dim sql As New SQLControl
            Dim sqlString As String
            If CStr(GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "id")) <> "" Then
                Dim _ID As Integer = Integer.Parse(GridViewAdditionalBarcodes.GetRowCellValue(GridViewAdditionalBarcodes.FocusedRowHandle, "id"))
                sqlString = " Delete from [Items_units] where id=" & _ID
                sql.SqlTrueAccountingRunQuery(sqlString)
                GridViewAdditionalBarcodes.DeleteRow(GridViewAdditionalBarcodes.FocusedRowHandle)
            End If


        End If
    End Sub


    'Private Function CheckIFBarcodeHasTrans() As Boolean
    '    Try
    '        Dim sql As New SQLControl
    '        Dim sqlString As String
    '        sqlString = " Select isnull(Count(StockID),0) As Count 
    '                                    from [Journal] 
    '                                    where StockID='" & ItemNo.EditValue & "' And DocStatus> 0 "
    '        sql.SqlTrueAccountingRunQuery(sqlString)
    '        If sql.SQLDS.Tables(0).Rows(0).Item("Count") > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    Private Function CheckIfItemNameExist(ItemNo As Integer, ItemName As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select * from Items where ItemName=N'" & ItemName & "' and ItemNo<>" & ItemNo
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



    Private Function GetReferencesForItems(RefStatus As Integer, RefType As Integer, UserID As String) As DataTable

        Dim AllReferences As New DataTable
        Try
            Dim References As New DataTable
            Dim SqlString As String
            Dim sql As New SQLControl

            SqlString = " Select RefName,RefNo as RefNo ,RefTypeName,RefMobile,T.TypeID, RefAccID ,'1' as Currency,IdentityNo
from Referencess R left join ReferencesTypes T on T.TypeID=R.RefType Where 1=1 "
            If RefStatus = "1" Then SqlString += " and [Active]='True'"
            If RefType <> "-1" Then SqlString += " and [RefType]=" & RefType
            SqlString += " Order By RefNo  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            References = sql.SQLDS.Tables(0)
            AllReferences.Merge(References)
        Catch ex As Exception

        End Try

        Return AllReferences

    End Function

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick

    End Sub

    Private Sub SearchSize_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchSize.Properties.AddNewValue
        Dim f As New AccountingLists
        With f
            .NavigationPane1.SelectedPage = .Measures
            If .ShowDialog() <> DialogResult.OK Then
                _Measures = GetItemsMeasures()
                Me.SearchSize.Properties.DataSource = _Measures
            End If
        End With
    End Sub

    Private Sub RepositoryBarCode_Enter(sender As Object, e As EventArgs) Handles RepositoryBarCode.Enter
        SwitchKeyboardLayout("en")
    End Sub

    Private Sub RepositoryItemTextEdit1_Enter(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.Enter
        SwitchKeyboardLayout("en")
    End Sub

    Private Sub BtnItemColorImages_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnItemColorImages.ItemClick
        Try
            Dim f As New FrmItemColorImages(ItemNo.EditValue)
            f.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error opening Item Images form: " & ex.Message)
            Debug.WriteLine($"[ItemsList] ❌ Error: {ex.Message}")
        End Try
    End Sub

    Private Sub BtnItemGroups_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnItemGroups.ItemClick
        Try
            Dim f As New ItemMainSubGroupAddEdit(ItemNo.EditValue)
            f.ShowDialog()

        Catch ex As Exception
            Debug.WriteLine($"[ItemMainSubGroupAddEdit] ❌ Error: {ex.Message}")
        End Try
    End Sub

    Private Sub SearchColor_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchColor.Properties.AddNewValue
        Dim f As New AccountingLists
        With f
            .NavigationPane1.SelectedPage = .NavigationPageColors
            If .ShowDialog() <> DialogResult.OK Then
                _Colors = GetItemsColors()
                Me.SearchColor.Properties.DataSource = _Colors
            End If
        End With
    End Sub

    Private Sub ItemNo_Enter(sender As Object, e As EventArgs) Handles ItemNo.Enter
        SwitchKeyboardLayout("en")
    End Sub
End Class