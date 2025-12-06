Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Web
Imports DevExpress
Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSpreadsheet.Model.CopyOperation

Module AccountingFunctions

    Public Function OpenDocumentsByDocCode(DocCode As String, DataName As String,
                                      OpenFrom As String, Optional ByVal _ModifiedDateTime As String = "") As String
        ' استخدام الكلاس الجديد
        Dim opener As New DocumentOpener()
        Return opener.OpenDocument(DocCode, DataName, OpenFrom, _ModifiedDateTime)
    End Function

    Public Function GetItemsData(SearchNo As String, SearchByBarcode As Boolean) As _
    (ItemName As String, HasExpireDate As String, LastPurchasePrice As String, _Price1 As Decimal,
    AccSales As String, AccPurches As String, DefaultUnit As Integer, ItemUnits As DataTable, ItemNote As String,
    AccRetSales As String, AccRetPurches As String, ItemType As String, CategoryID As String, TradeMarkID As Integer,
    GroupID As Integer, SaleOnScale As Boolean, UnitBarcode As String, ItemNo As String,
    EquivalentToMain As Decimal, _LastPurchaseDate As String, _Price2 As Decimal,
    _Price3 As Decimal, _Color As Integer, _Measure As Integer,
    _ItemNo2 As String, _ItemNo3 As String, _ItemNo4 As String, _ProductCompany As String,
    _WebSite1 As String, _WebSite2 As String, _VisibleInAPP As Boolean, ReOrderQuantity As Decimal,
    _HasSerial As Boolean, _HasProductionEquation As Boolean, CostCenter As Integer, MaxQuantity As Decimal,
    _Vendor As Integer, _LookItemsclassification As Integer, _WithAdditions As Boolean, UseBatchNo As Boolean,
    SaleOnSamba As Boolean, RequirePriceInPOS As Boolean, PeriodType As String, PeriodCount As Decimal,
    DefaultColor As Integer, DefaultSize As Integer, LastNetPurchasePrice As Decimal, VisibleInPOS As Boolean, TaxPercentage As Decimal)
        Dim ItemName As String = "0"
        Dim HasExpireDate As String = "0"
        Dim LastPurchasePrice As String = "0"
        Dim _Price1 As Decimal = 0
        Dim AccSales As String = "0"
        Dim AccPurchase As String = "0"
        Dim DefaultUnit As Integer = 0
        Dim _ItemUnits As New DataTable
        Dim _notes As String = "0"
        Dim _AccRetSales As String = "0"
        Dim _AccRetPurches As String = "0"
        Dim _ItemType As String = "0"
        Dim _CategoryID As String = "0"
        Dim _TradeMarkID As Integer = "0"
        Dim _GroupID As Integer = "0"
        Dim _SaleOnScale As Boolean = False
        Dim _UnitBarcode As String = 0
        Dim _ItemNo As String = "0"
        Dim _EquivalentToMain As Decimal = 0
        Dim _LastPurchaseDate As String = 0
        Dim _Price2 As Decimal = 0
        Dim _Price3 As Decimal = 0
        Dim _Color As Integer = 0
        Dim _Measure As Integer = 0
        Dim _ItemNo2 As String = String.Empty
        Dim _ItemNo3 As String = String.Empty
        Dim _ItemNo4 As String = String.Empty
        Dim _ProductCompany As String = String.Empty
        Dim _Vendor As Integer = 0
        Dim _WebSite1 As String = String.Empty
        Dim _WebSite2 As String = String.Empty
        Dim _VisibleInAPP As Boolean = True
        Dim _ReOrderQuantity As Decimal = 0
        Dim _HasSerial As Boolean = False
        Dim _HasProductionEquation As Boolean = False
        Dim _CostCenter As Integer = 0
        Dim _MaxQuantity As Decimal = 0
        Dim _Itemclassification As Integer = 1
        Dim _WithAdditions As Boolean = False
        Dim _UseBatchNo As Boolean = False
        Dim _SaleOnSamba As Boolean = False
        Dim _RequirePriceInPOS As Boolean = False
        Dim _PeriodType As String = ""
        Dim _PeriodCount As Decimal = 0.0
        Dim _DefaultColor As Integer = 0
        Dim _DefaultSize As Integer = 0
        Dim _LastNetPurchasePrice As Decimal = 0.0
        Dim _VisibleInPOS As Boolean = True
        Dim _TaxPercentage As Decimal = 0.0

        If String.IsNullOrEmpty(SearchNo) Or SearchNo = "0" Then
            Return (ItemName, HasExpireDate, LastPurchasePrice, _Price1, AccSales, AccPurchase,
                 DefaultUnit, _ItemUnits, _notes, _AccRetSales, _AccRetPurches, _ItemType, _CategoryID,
                 _TradeMarkID, _GroupID, _SaleOnScale, _UnitBarcode, _ItemNo, _EquivalentToMain, _LastPurchaseDate,
                 _Price2, _Price3, _Color, _Measure, _ItemNo2, _ItemNo3, _ItemNo4, _ProductCompany, _WebSite1, _WebSite2,
                 _VisibleInAPP, _ReOrderQuantity, _HasSerial, _HasProductionEquation, _CostCenter, _MaxQuantity, _Vendor,
                 _Itemclassification, _WithAdditions, _UseBatchNo, _SaleOnSamba, _RequirePriceInPOS, _PeriodType, _PeriodCount, _DefaultColor, _DefaultSize, _LastNetPurchasePrice, _VisibleInPOS, _TaxPercentage)
            Exit Function
        End If

        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  Select top(1) I.id,ItemName,[Type],HasExpireDate,LastPurchasePrice,LastPurchaseDate,
                              IU.Price1 as Price1,
                              ReOrderQuantity,AccSales,AccPurches,AccRetSales,AccRetPurches,unit_id as DefaultUnit,
                              notes,CategoryID,TradeMarkID,[GroupID],SaleOnScale,
                              IU.item_unit_bar_code,
                              I.ItemNo,IU.EquivalentToMain,IU.Price2,IU.Price3,Color,Measure,
                              ItemNo2,ItemNo3,ItemNo4,ProductCompany,WebSite1,WebSite2,VisibleInAPP,HasSerial,HasProductionEquation,
                              CostCenter,MaxQuantity,Vendor,classification,WithAdditions,UseBatchNo,SaleOnSamba,RequirePriceInPOS,PeriodType,
                              PeriodCount,IsNull(ItemColor,0) As ItemColor ,IsNull(ItemSize,0) As ItemSize,IsNull(LastNetPurchasePrice,0) As LastNetPurchasePrice,IsNull(VisibleInPOS,1) As VisibleInPOS,IsNull(TaxPercentage,0) As TaxPercentage
                       FROM         [Items] I
                       Left join [Items_units] IU on   I.ItemNo=IU.item_id "
        If SearchByBarcode = False Then
            SqlString += " WHERE (ItemNo  ='" & SearchNo & "') and main_unit=1"
        Else
            SqlString += " WHERE(IU.item_unit_bar_code ='" & SearchNo & "')  "
        End If


        sql.SqlTrueAccountingRunQuery(SqlString)
        'sql.SqlLocalTrueTimeRunQuery(SqlString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Return (ItemName, HasExpireDate, LastPurchasePrice, _Price1, AccSales, AccPurchase,
                 DefaultUnit, _ItemUnits, _notes, _AccRetSales, _AccRetPurches, _ItemType, _CategoryID,
                 _TradeMarkID, _GroupID, _SaleOnScale, _UnitBarcode, _ItemNo, _EquivalentToMain, _LastPurchaseDate,
                 _Price2, _Price3, _Color, _Measure, _ItemNo2, _ItemNo3, _ItemNo4, _ProductCompany, _WebSite1, _WebSite2,
                 _VisibleInAPP, _ReOrderQuantity, _HasSerial, _HasProductionEquation, _CostCenter, _MaxQuantity, _Vendor,
                 _Itemclassification, _WithAdditions, _UseBatchNo, _SaleOnSamba, _RequirePriceInPOS, _PeriodType, _PeriodCount, _DefaultColor, _DefaultSize, _LastNetPurchasePrice, _VisibleInPOS, _TaxPercentage)
            Exit Function
        End If
        With sql.SQLDS.Tables(0).Rows(0)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not (IsDBNull(.Item("ItemName"))) Then ItemName = (.Item("ItemName").ToString)
                If Not (IsDBNull(.Item("HasExpireDate"))) Then HasExpireDate = .Item("HasExpireDate")
                If Not (IsDBNull(.Item("LastPurchasePrice"))) Then LastPurchasePrice = .Item("LastPurchasePrice")
                If Not (IsDBNull(.Item("Price1"))) Then _Price1 = .Item("Price1")
                If Not (IsDBNull(.Item("AccSales"))) Then AccSales = .Item("AccSales")
                If Not (IsDBNull(.Item("AccPurches"))) Then AccPurchase = .Item("AccPurches")
                If Not (IsDBNull(.Item("DefaultUnit"))) Then DefaultUnit = .Item("DefaultUnit")
                If Not (IsDBNull(.Item("notes"))) Then _notes = .Item("notes")
                If Not (IsDBNull(.Item("AccRetSales"))) Then _AccRetSales = .Item("AccRetSales")
                If Not (IsDBNull(.Item("AccRetPurches"))) Then _AccRetPurches = .Item("AccRetPurches")
                If Not (IsDBNull(.Item("Type"))) Then _ItemType = .Item("Type")
                If Not (IsDBNull(.Item("CategoryID"))) Then _CategoryID = .Item("CategoryID")
                If Not (IsDBNull(.Item("TradeMarkID"))) Then _TradeMarkID = .Item("TradeMarkID")
                If Not (IsDBNull(.Item("GroupID"))) Then _GroupID = .Item("GroupID")
                If Not (IsDBNull(.Item("SaleOnScale"))) Then _SaleOnScale = .Item("SaleOnScale")
                If Not (IsDBNull(.Item("item_unit_bar_code"))) Then _UnitBarcode = .Item("item_unit_bar_code")
                If Not (IsDBNull(.Item("ItemNo"))) Then _ItemNo = .Item("ItemNo")
                If Not (IsDBNull(.Item("EquivalentToMain"))) Then _EquivalentToMain = .Item("EquivalentToMain")
                If Not (IsDBNull(.Item("LastPurchaseDate"))) Then _LastPurchaseDate = .Item("LastPurchaseDate")
                If Not (IsDBNull(.Item("Price2"))) Then _Price2 = .Item("Price2")
                If Not (IsDBNull(.Item("Price3"))) Then _Price3 = .Item("Price3")
                If Not (IsDBNull(.Item("Color"))) Then _Color = .Item("Color")
                If Not (IsDBNull(.Item("Measure"))) Then _Measure = .Item("Measure")
                If Not (IsDBNull(.Item("ItemNo2"))) Then _ItemNo2 = .Item("ItemNo2")
                If Not (IsDBNull(.Item("ItemNo3"))) Then _ItemNo3 = .Item("ItemNo3")
                If Not (IsDBNull(.Item("ItemNo4"))) Then _ItemNo4 = .Item("ItemNo4")
                If Not (IsDBNull(.Item("ProductCompany"))) Then _ProductCompany = .Item("ProductCompany")
                If Not (IsDBNull(.Item("WebSite1"))) Then _WebSite1 = .Item("WebSite1")
                If Not (IsDBNull(.Item("WebSite2"))) Then _WebSite2 = .Item("WebSite2")
                If Not (IsDBNull(.Item("MaxQuantity"))) Then _MaxQuantity = .Item("MaxQuantity")

                _DefaultColor = .Item("ItemColor")
                _DefaultSize = .Item("ItemSize")
                _LastNetPurchasePrice = .Item("LastNetPurchasePrice")
                _VisibleInPOS = .Item("VisibleInPOS")

                If Not (IsDBNull(.Item("VisibleInAPP"))) Then
                    _VisibleInAPP = .Item("VisibleInAPP")
                Else
                    _VisibleInAPP = True
                End If
                If Not (IsDBNull(.Item("ReOrderQuantity"))) Then _ReOrderQuantity = .Item("ReOrderQuantity")
                If Not (IsDBNull(.Item("HasSerial"))) Then
                    _HasSerial = .Item("HasSerial")
                Else
                    _HasSerial = True
                End If
                If Not IsDBNull(.Item("HasProductionEquation")) Then
                    _HasProductionEquation = .Item("HasProductionEquation")
                Else
                    .Item("HasProductionEquation") = False
                End If
                If Not IsDBNull(.Item("CostCenter")) Then
                    _CostCenter = .Item("CostCenter")
                Else
                    _CostCenter = 0
                End If
                If Not IsDBNull(.Item("Vendor")) Then
                    _Vendor = .Item("Vendor")
                Else
                    _Vendor = 0
                End If
                If Not IsDBNull(.Item("classification")) Then
                    _Itemclassification = .Item("classification")
                Else
                    _Itemclassification = 1
                End If
                If Not IsDBNull(.Item("WithAdditions")) Then
                    _WithAdditions = .Item("WithAdditions")
                Else
                    _WithAdditions = False
                End If
                If Not IsDBNull(.Item("UseBatchNo")) Then
                    _UseBatchNo = .Item("UseBatchNo")
                Else
                    _UseBatchNo = False
                End If
                If Not IsDBNull(.Item("SaleOnSamba")) Then
                    _SaleOnSamba = .Item("SaleOnSamba")
                Else
                    _SaleOnSamba = False
                End If
                If Not IsDBNull(.Item("RequirePriceInPOS")) Then
                    _RequirePriceInPOS = .Item("RequirePriceInPOS")
                Else
                    _RequirePriceInPOS = False
                End If
                If Not IsDBNull(.Item("PeriodType")) Then
                    _PeriodType = .Item("PeriodType")
                Else
                    _PeriodType = ""
                End If
                If Not IsDBNull(.Item("PeriodCount")) Then
                    _PeriodCount = .Item("PeriodCount")
                Else
                    _PeriodCount = 0.0
                End If
                If Not IsDBNull(.Item("TaxPercentage")) Then
                    _TaxPercentage = .Item("TaxPercentage")
                Else
                    _TaxPercentage = 0.0
                End If
            End If
        End With

        If SearchByBarcode = False Then
            Try
                Dim Sql2 As New SQLControl
                Dim SqlString2 As String
                SqlString2 = " Select id,unit_id,main_unit,EquivalentToMain,item_unit_bar_code,
                                      Price1 
                                      from Items_units 
                                      where item_id='" & SearchNo & "'"
                Sql2.SqlTrueAccountingRunQuery(SqlString2)
                _ItemUnits = Sql2.SQLDS.Tables(0)
            Catch ex As Exception

            End Try
        End If

        Return (ItemName, HasExpireDate, LastPurchasePrice, _Price1, AccSales, AccPurchase,
                 DefaultUnit, _ItemUnits, _notes, _AccRetSales, _AccRetPurches, _ItemType, _CategoryID,
                 _TradeMarkID, _GroupID, _SaleOnScale, _UnitBarcode, _ItemNo, _EquivalentToMain, _LastPurchaseDate,
                 _Price2, _Price3, _Color, _Measure, _ItemNo2, _ItemNo3, _ItemNo4, _ProductCompany, _WebSite1, _WebSite2,
                 _VisibleInAPP, _ReOrderQuantity, _HasSerial, _HasProductionEquation, _CostCenter, _MaxQuantity, _Vendor,
                 _Itemclassification, _WithAdditions, _UseBatchNo, _SaleOnSamba, _RequirePriceInPOS, _PeriodType, _PeriodCount, _DefaultColor, _DefaultSize, _LastNetPurchasePrice, _VisibleInPOS, _TaxPercentage)
    End Function
    Public Function GetItemDataByItemBaroce(_ItemBarcode As String) As _
            (Barcode As String, ItemNo As Integer, ItemName As String, UnitName As String, Price1 As Decimal)
        Dim sql As New SQLControl
        Dim sqlString As String = "   Select ItemNo,ItemName,IU.item_unit_bar_code as Barcode,U.name as UnitName,IU.Price1 
  from Items I
  left join Items_units IU on I.ItemNo=IU.item_id
  left join Units U on U.id=IU.unit_id
  where IU.item_unit_bar_code='" & _ItemBarcode & "'"
        sql.SqlTrueAccountingRunQuery(sqlString)
        Dim _Barcode As String = String.Empty
        Dim _ItemNo As Integer = 0
        Dim _ItemName As String = String.Empty
        Dim _UnitName As String = String.Empty
        Dim _Price1 As Decimal = 0

        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _ItemNo = sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
            _ItemName = sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
            _UnitName = sql.SQLDS.Tables(0).Rows(0).Item("UnitName")
            _Price1 = sql.SQLDS.Tables(0).Rows(0).Item("Price1")
            _Barcode = sql.SQLDS.Tables(0).Rows(0).Item("Barcode")
        End If
        Return (_Barcode, _ItemNo, _ItemName, _UnitName, _Price1)
    End Function
    Public Function ChangeItemBarcode(_ID As Integer, _item_unit_bar_code As String) As Boolean
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String
            If CheckIfBarcodeFound(_item_unit_bar_code) = False Then
                SqlString = " Update Items_units 
                      Set item_unit_bar_code='" & _item_unit_bar_code & "' 
                      where id =" & _ID
                If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ChangeItemName(ItemNo As Integer, ItemName As String) As Boolean
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String
            SqlString = " Update [dbo].[Items] 
                            Set [ItemName]=N'" & ItemName & "' 
                            where [ItemNo] =" & ItemNo
            If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetItemsBatchNoTable(_ItemNo As Integer) As DataTable
        Dim _table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select ID,BatchNo,CONVERT(Date, ExpireDate) as ExpireDate ,ItemNo from ItemBatchNo where ItemNo=" & _ItemNo)
            _table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function
    Public Function GetAllBatchesNumbersForItems()
        Dim _table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT  ID,BatchNo,CONVERT(Date, ExpireDate) as ExpireDate,ItemNo from ItemBatchNo   ")
            _table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function

    'Public Function GetItemsDataByBarcodex(UnitBarcode As String) As _
    '(ItemName As String, HasExpireDate As String, LastPurchasePrice As String, StockItemPrice As Decimal,
    'AccSales As String, AccPurches As String, DefaultUnit As Integer, ItemUnits As DataTable, ItemNote As String,
    'AccRetSales As String, AccRetPurches As String, ItemType As String, CategoryID As String, TradeMarkID As Integer,
    'GroupID As Integer, SaleOnScale As Boolean, UnitBarcode As String, ItemNo As String)



    '    Dim ItemName As String = "0"
    '    Dim HasExpireDate As String = "0"
    '    Dim LastPurchasePrice As String = "0"
    '    Dim StockItemPrice As Decimal = 0
    '    Dim AccSales As String = "0"
    '    Dim AccPurchase As String = "0"
    '    Dim DefaultUnit As Integer = 0
    '    Dim _ItemUnits As New DataTable
    '    Dim _notes As String = "0"
    '    Dim _AccRetSales As String = "0"
    '    Dim _AccRetPurches As String = "0"
    '    Dim _ItemType As String = "0"
    '    Dim _CategoryID As String = "0"
    '    Dim _TradeMarkID As Integer = "0"
    '    Dim _GroupID As Integer = "0"
    '    Dim _SaleOnScale As Boolean = False
    '    Dim _UnitBarcode As String = "0"
    '    Dim _ItemNo As String = "0"

    '    If String.IsNullOrEmpty(UnitBarcode) Or UnitBarcode = 0 Then
    '        Return (ItemName, HasExpireDate, LastPurchasePrice, StockItemPrice, AccSales, AccPurchase,
    '             DefaultUnit, _ItemUnits, _notes, _AccRetSales, _AccRetPurches, _ItemType, _CategoryID,
    '             _TradeMarkID, _GroupID, _SaleOnScale, _UnitBarcode, _ItemNo)
    '    End If

    '    Dim sql As New SQLControl
    '    Dim SqlString As String
    '    SqlString = "  Select TOP(1)  I.id,ItemName,[Type],HasExpireDate,LastPurchasePrice,IU.Price1 as StockItemPrice,
    '                          ReOrderQuantity,AccSales,AccPurches,AccRetSales,AccRetPurches,unit_id as DefaultUnit,notes,CategoryID,
    '                          TradeMarkID,[GroupID],SaleOnScale,IU.item_unit_bar_code,I.ItemNo
    '                   FROM         [Items] I
    '                   Left join [Items_units] IU on   I.ItemNo=IU.item_id
    '                   WHERE     (IU.item_unit_bar_code  ='" & UnitBarcode & "') "
    '    sql.SqlTrueAccountingRunQuery(SqlString)
    '    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ItemName"))) Then ItemName = (sql.SQLDS.Tables(0).Rows(0).Item("ItemName").ToString)
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("HasExpireDate"))) Then HasExpireDate = sql.SQLDS.Tables(0).Rows(0).Item("HasExpireDate")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice"))) Then LastPurchasePrice = sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StockItemPrice"))) Then StockItemPrice = sql.SQLDS.Tables(0).Rows(0).Item("StockItemPrice")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccSales"))) Then AccSales = sql.SQLDS.Tables(0).Rows(0).Item("AccSales")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccPurches"))) Then AccPurchase = sql.SQLDS.Tables(0).Rows(0).Item("AccPurches")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DefaultUnit"))) Then DefaultUnit = sql.SQLDS.Tables(0).Rows(0).Item("DefaultUnit")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("notes"))) Then _notes = sql.SQLDS.Tables(0).Rows(0).Item("notes")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccRetSales"))) Then _AccRetSales = sql.SQLDS.Tables(0).Rows(0).Item("AccRetSales")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccRetPurches"))) Then _AccRetPurches = sql.SQLDS.Tables(0).Rows(0).Item("AccRetPurches")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Type"))) Then _ItemType = sql.SQLDS.Tables(0).Rows(0).Item("Type")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CategoryID"))) Then _CategoryID = sql.SQLDS.Tables(0).Rows(0).Item("CategoryID")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TradeMarkID"))) Then _TradeMarkID = sql.SQLDS.Tables(0).Rows(0).Item("TradeMarkID")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("GroupID"))) Then _GroupID = sql.SQLDS.Tables(0).Rows(0).Item("GroupID")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SaleOnScale"))) Then _SaleOnScale = sql.SQLDS.Tables(0).Rows(0).Item("SaleOnScale")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code"))) Then _UnitBarcode = sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ItemNo"))) Then _ItemNo = sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
    '    End If



    '    Return (ItemName, HasExpireDate, LastPurchasePrice, StockItemPrice, AccSales, AccPurchase,
    '             DefaultUnit, _ItemUnits, _notes, _AccRetSales, _AccRetPurches, _ItemType, _CategoryID,
    '             _TradeMarkID, _GroupID, _SaleOnScale, _UnitBarcode, _ItemNo)
    'End Function
    Public Function GetItems(ItemsOrServices As String) As DataTable
        Dim _Items As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select ItemNo,ItemName,ItemNo2 from Items Where 1=1 and [ItemStatus]=1 "
            If ItemsOrServices = "Items" Then
                SqlString += " And [Type]=0 "
            ElseIf ItemsOrServices = "Services" Then
                SqlString += " And [Type]=1"
            End If
            Sql.SqlTrueAccountingRunQuery(SqlString)
            ' Sql.SqlLocalTrueTimeRunQuery(SqlString)
            _Items = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Items
    End Function
    Public Function GetItemsFromBarcodesTable(ItemsOrServices As String) As DataTable
        Dim _Items As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " select I.ItemNo,ItemName,unit_id,item_unit_bar_code,U.name as UnitName  
                            from Items_units IU 
                            left join Items I on I.ItemNo=IU.item_id
                            left join Units U on U.id=IU.unit_id
                            where item_unit_bar_code<>'0' and item_unit_bar_code<>'' and [ItemStatus]=1 "
            If ItemsOrServices = "Items" Then
                SqlString += " And [Type]=0 "
            ElseIf ItemsOrServices = "Services" Then
                SqlString += " And [Type]=1"
            End If
            Sql.SqlTrueAccountingRunQuery(SqlString)
            ' Sql.SqlLocalTrueTimeRunQuery(SqlString)
            _Items = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Items
    End Function
    Public Function GetUnitsTable(ItemNo As String) As DataTable

        Dim Units As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SQlString As String
            If ItemNo = "-1" Then
                SQlString = "   Select  U.[id] As UnitID ,U.[name],isnull(IU.item_id,0) as item_id from Units U  left join Items_units IU on IU.unit_id=U.id where  IsUnit=1 "
            Else
                SQlString = " select U.[id] as UnitID ,U.[name],IU.item_id from Units U left join Items_units IU on IU.unit_id=U.id where item_id = '" & ItemNo & "' and IsUnit=1"
            End If
            Sql.SqlTrueAccountingRunQuery(SQlString)
            Return Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return Units
        End Try


    End Function


    Public Function GetCountMainUnitsInUnit(ItemNo, UnitID) As Decimal
        Dim CountMainUnitsInUnit As Decimal
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("select EquivalentToMain  from Items_units 
where item_id = '" & ItemNo & "' and unit_id = " & UnitID)
            CountMainUnitsInUnit = sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")
        Catch ex As Exception
            CountMainUnitsInUnit = 0
        End Try
        Return CountMainUnitsInUnit
    End Function

    Public Function GetDefaultUnitIDForItem(ItemID As Integer) As Integer
        Dim DefaultUnit As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("   select unit_id from [Items_units] 
  where item_id=" & ItemID & " and main_unit=1 ")
            DefaultUnit = Sql.SQLDS.Tables(0).Rows(0).Item("unit_id")
        Catch ex As Exception
            DefaultUnit = 0
        End Try

        Return DefaultUnit

    End Function
    Public Function GetDocSort(DocID As Integer) As DataTable
        Dim DocSort As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " select SortID,SortName from DocSorts S left join DocNames N on S.DocID=N.id where N.id= " & DocID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            DocSort = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            DocSort = DocSort
        End Try
        Return DocSort
    End Function

    Public Function GetDocNames() As DataTable
        Dim _DocNames As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " select id,Name from  DocNames "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _DocNames = Sql.SQLDS.Tables(0)
            Dim R As DataRow = _DocNames.NewRow
            R("id") = -1
            R("Name") = "الكل"
            _DocNames.Rows.Add(R)
        Catch ex As Exception
            _DocNames = _DocNames
        End Try
        Return _DocNames
    End Function

    Public Function GetReferences(RefStatus As Integer, RefType As Integer, UserID As String) As DataTable

        Dim AllReferences As New DataTable
        'If GlobalVariables._UserAccessType = 3 Then
        '    RefType = 2
        'End If
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

        '        If GlobalVariables.ConnectedWithTrueAccounting = True Then
        '            Try
        '                Dim Employees As New DataTable
        '                Dim SqlString As String
        '                Dim sql As New SQLControl
        '                SqlString = " Select EmployeeName as RefName,SalaryAccountNo as RefNo,N'موظفين' as RefTypeName,
        '                              99 as TypeID ,Mobile1 as RefMobile,'1' as Currency,
        ''0' as RefAccID 
        'from EmployeesData where SalaryAccountNo is not null and [CreditAccountNo] is not null "
        '                sql.SqlTrueTimeRunQuery(SqlString)
        '                Employees = sql.SQLDS.Tables(0)
        '                AllReferences.Merge(Employees)
        '            Catch ex As Exception
        '                MsgBox(ex.ToString)
        '            End Try
        '        End If



        Return AllReferences

    End Function

    Public Function GetReferancessTypes(WithAll As Boolean) As DataTable
        Dim ReferancessTypes As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select TypeID,RefTypeName from [ReferencesTypes]"
            If WithAll = True Then SqlString += " union select -1 as TypeID,N'الكل' as RefTypeName "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            ReferancessTypes = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return ReferancessTypes
    End Function

    Public Function GetCurrency() As DataTable
        Dim Currency As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select Code,CurrID from Currency"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Currency = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return Currency
    End Function
    Public Function GetCurrencyTableWithAll(WithAll As Boolean) As DataTable
        Dim Currency As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select Code,CurrID from Currency"
            If WithAll = True Then SqlString += " union select N'الكل' as Code, -1 as CurrID "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Currency = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return Currency
    End Function
    Public Function GetCurrencyCode(CurrID As Integer) As String
        Dim CurrencyCode As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select Code from Currency where CurrID=" & CurrID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            CurrencyCode = Sql.SQLDS.Tables(0).Rows(0).Item("Code")
        Catch ex As Exception
            CurrencyCode = "NIS"
        End Try
        Return CurrencyCode
    End Function

    Public Function GetRefranceData(RefNo As Integer) As (RefID As Integer, RefName As String, RefNo As Integer,
        RefType As Integer, RefMobile As String, RefPhone As String, RefAccID As String, RefTypeName As String, PriceCategory As Integer,
        currency_id As Integer, RefEmail As String, SearchCity As String, SubscribeAmount As Decimal, RefSort As String,
        RefBirthDate As String, RefMemo As String, StartDate As String, _IsActive As String, _Address As String, _ReferanceCode As String,
        _IdentityNo As String, _Nationality As String, _IdentityType As String, _TarkhesID As String, _TarkhesIssueDate As String,
        _TarkhesEndDate As String, SalesMan As Integer, ContactPerson As String, MaxDebit As Decimal, CityName As String, SalesManDay As Integer)
        Dim _RefID As Integer = 0
        Dim _RefName As String = String.Empty
        Dim _RefNo As Integer = 0
        Dim _RefType As Integer = 0
        Dim _RefMobile As String = 0
        Dim _RefPhone As String = String.Empty
        Dim _RefAccID As String = "0"
        Dim _RefTypeName As String = 0
        Dim _PriceCategory As Integer = 0
        Dim _currency_id As Integer = 0
        Dim _RefEmail As String = String.Empty
        Dim _SearchCity As String = String.Empty
        Dim _SubscribeAmount As Decimal = "0"
        Dim _RefSort As String = String.Empty
        Dim _RefBirthDate As DateTime = "1900-01-01"
        Dim _RefMemo As String = String.Empty
        Dim _Active As String = "0"
        Dim _StartDate As DateTime = "1900-01-01"
        Dim _Address As String = String.Empty
        Dim _ReferanceCode As String = String.Empty
        Dim _IdentityNo As String = ""
        Dim _Nationality As String = ""
        Dim _IdentityType As String = ""
        Dim _TarkhesID As String = ""
        Dim _TarkhesIssueDate As String = ""
        Dim _TarkhesEndDate As String = ""
        Dim _SalesMan As Integer = 0
        Dim _ContactPerson As String = ""
        Dim _MaxDebit As Decimal = 0
        Dim _CityName As String = ""
        Dim _SalesManDay As Integer = 0

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  Select   RefID,RefName,RefNo,RefType,RefMobile,RefPhone, 
                                    RefAccID,RefTypeName,PriceCategory,TypeID,A.Currency,RefEmail,SearchCity,C.[CITY] as CityName,SubscribeAmount,
                                    RefSort,RefBirthDate,RefMemo,R.[Active] as IsActive,R.DateStart,[Address],[ReferanceCode],
                                    [IdentityNo],Nationality,IdentityType,TarkhesID,TarkhesIssueDate,TarkhesEndDate,
                                    IsNull(SalesMan,0) as SalesMan,IsNull(ContactPerson,'') as ContactPerson,IsNull(MaxDebit,0) as MaxDebit,IsNull(SalesManDay,0) as SalesManDay
                           From Referencess R
                           Left join ReferencesTypes T on T.TypeID=R.RefType
                           left join [RefCities] C on C.[ID]=R.SearchCity
                           Left Join FinancialAccounts A on A.AccNo=R.RefAccID where RefNo = " & RefNo
            sql.SqlTrueAccountingRunQuery(SqlString)


            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefID"))) Then _RefID = sql.SQLDS.Tables(0).Rows(0).Item("RefID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefName"))) Then _RefName = sql.SQLDS.Tables(0).Rows(0).Item("RefName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefNo"))) Then _RefNo = sql.SQLDS.Tables(0).Rows(0).Item("RefNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefType"))) Then _RefType = sql.SQLDS.Tables(0).Rows(0).Item("RefType")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefMobile"))) Then _RefMobile = sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefPhone"))) Then _RefPhone = sql.SQLDS.Tables(0).Rows(0).Item("RefPhone")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefAccID"))) Then _RefAccID = sql.SQLDS.Tables(0).Rows(0).Item("RefAccID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefTypeName"))) Then _RefTypeName = sql.SQLDS.Tables(0).Rows(0).Item("RefTypeName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PriceCategory"))) Then _PriceCategory = sql.SQLDS.Tables(0).Rows(0).Item("PriceCategory")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Currency"))) Then _currency_id = sql.SQLDS.Tables(0).Rows(0).Item("Currency")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefEmail"))) Then _RefEmail = sql.SQLDS.Tables(0).Rows(0).Item("RefEmail")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SearchCity"))) Then _SearchCity = sql.SQLDS.Tables(0).Rows(0).Item("SearchCity")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SubscribeAmount"))) Then _SubscribeAmount = sql.SQLDS.Tables(0).Rows(0).Item("SubscribeAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefSort"))) Then _RefSort = sql.SQLDS.Tables(0).Rows(0).Item("RefSort")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefBirthDate"))) Then _RefBirthDate = sql.SQLDS.Tables(0).Rows(0).Item("RefBirthDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefMemo"))) Then _RefMemo = sql.SQLDS.Tables(0).Rows(0).Item("RefMemo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Address"))) Then _Address = sql.SQLDS.Tables(0).Rows(0).Item("Address")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ReferanceCode"))) Then _ReferanceCode = sql.SQLDS.Tables(0).Rows(0).Item("ReferanceCode")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IsActive"))) Then
                If sql.SQLDS.Tables(0).Rows(0).Item("IsActive") = True Then
                    _Active = "1"
                Else
                    _Active = "0"
                End If
            End If
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DateStart"))) Then _StartDate = sql.SQLDS.Tables(0).Rows(0).Item("DateStart")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IdentityNo"))) Then _IdentityNo = sql.SQLDS.Tables(0).Rows(0).Item("IdentityNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Nationality"))) Then _Nationality = sql.SQLDS.Tables(0).Rows(0).Item("Nationality")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IdentityType"))) Then _IdentityType = sql.SQLDS.Tables(0).Rows(0).Item("IdentityType")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesID"))) Then _TarkhesID = sql.SQLDS.Tables(0).Rows(0).Item("TarkhesID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesIssueDate"))) Then _TarkhesIssueDate = sql.SQLDS.Tables(0).Rows(0).Item("TarkhesIssueDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate"))) Then _TarkhesEndDate = sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesMan"))) Then _SalesMan = sql.SQLDS.Tables(0).Rows(0).Item("SalesMan")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ContactPerson"))) Then _ContactPerson = sql.SQLDS.Tables(0).Rows(0).Item("ContactPerson")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("MaxDebit"))) Then _MaxDebit = sql.SQLDS.Tables(0).Rows(0).Item("MaxDebit")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CityName"))) Then _CityName = sql.SQLDS.Tables(0).Rows(0).Item("CityName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesManDay"))) Then _SalesManDay = sql.SQLDS.Tables(0).Rows(0).Item("SalesManDay")


        Catch ex As Exception

        End Try
        'Try
        '    If GlobalVariables._HRSystemIsConnectedWithAccountingSystem = True And RefNo <> "0" Then
        '        Dim Sql As New SQLControl
        '        Dim SqlString As String
        '        SqlString = " Select [EmployeeName] as RefName from [dbo].[EmployeesData] where  [SalaryAccountNo]='" & RefNo & "'"
        '        Sql.SqlTrueTimeRunQuery(SqlString)
        '        If Not (IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("RefName"))) Then _RefName = Sql.SQLDS.Tables(0).Rows(0).Item("RefName")
        '        Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReferancesSalaryAccount'")
        '        If Not (IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))) Then _RefAccID = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        '    End If
        'Catch ex As Exception

        'End Try


        Return (_RefID, _RefName, _RefNo, _RefType, _RefMobile, _RefPhone, _RefAccID, _RefTypeName, _PriceCategory, _currency_id,
                _RefEmail, _SearchCity, _SubscribeAmount, _RefSort, _RefBirthDate, _RefMemo, _StartDate, _Active, _Address,
                _ReferanceCode, _IdentityNo, _Nationality, _IdentityType, _TarkhesID, _TarkhesIssueDate, _TarkhesEndDate, _SalesMan, _ContactPerson, _MaxDebit, _CityName, _SalesManDay)
    End Function
    Public Function GetWeekDaysNames() As DataTable
        Dim DaysList As New DataTable
        With DaysList
            .Columns.Add("ID", GetType(Integer))
            .Columns.Add("DayAr", GetType(String))
            .Columns.Add("DayEn", GetType(String))
            .Rows.Add(1, "السبت", "Saturday")
            .Rows.Add(2, "الأحد", "Sunday")
            .Rows.Add(3, "الاثنين", "Monday")
            .Rows.Add(4, "الثلاثاء", "Tuesday")
            .Rows.Add(5, "الأربعاء", "Wednesday")
            .Rows.Add(6, "الخميس", "Thursday")
            .Rows.Add(7, "الجمعة", "Friday")
        End With
        Return DaysList
    End Function
    Public Function GetEmpDataToAccounting(EmpID As Integer) As (RefID As Integer, RefName As String, RefNo As Integer,
        RefType As Integer, RefMobile As String, RefPhone As String, RefAccID As Integer, RefTypeName As String, currency_id As Integer)
        Dim _RefID As Integer = 0
        Dim _RefName As String = String.Empty
        Dim _RefNo As Integer = 0
        Dim _RefType As Integer = 0
        Dim _RefMobile As String = 0
        Dim _RefPhone As String = String.Empty
        Dim _RefAccID As Integer = 0
        Dim _RefTypeName As String = 0
        Dim _currency_id As Integer = 0

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "   Select ID AS RefID,EmployeeName AS RefName,SalaryAccountNo as RefNo,'99' as RefType,Mobile1 as RefMobile,PhoneNo as RefPhone, [CreditAccountNo] as RefAccID, 'موظف' as RefTypeName,'99' as TypeID,'1' as Currency
         from [TrueTime].[dbo].[EmployeesData]  where SalaryAccountNo = " & EmpID
            sql.SqlTrueTimeRunQuery(SqlString)


            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefID"))) Then _RefID = sql.SQLDS.Tables(0).Rows(0).Item("RefID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefName"))) Then _RefName = sql.SQLDS.Tables(0).Rows(0).Item("RefName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefNo"))) Then _RefNo = sql.SQLDS.Tables(0).Rows(0).Item("RefNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefType"))) Then _RefType = sql.SQLDS.Tables(0).Rows(0).Item("RefType")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefMobile"))) Then _RefMobile = sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefPhone"))) Then _RefPhone = sql.SQLDS.Tables(0).Rows(0).Item("RefPhone")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefAccID"))) Then _RefAccID = sql.SQLDS.Tables(0).Rows(0).Item("RefAccID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefTypeName"))) Then _RefTypeName = sql.SQLDS.Tables(0).Rows(0).Item("RefTypeName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Currency"))) Then _currency_id = sql.SQLDS.Tables(0).Rows(0).Item("Currency")
        Catch ex As Exception

        End Try


        Return (_RefID, _RefName, _RefNo, _RefType, _RefMobile, _RefPhone, _RefAccID, _RefTypeName, _currency_id)
    End Function



    Public Function GetFinancialAccounts(AccType As Integer, CurrID As Integer, WithFathers As Boolean, IsActive As Integer, FinancialSector As Integer) As DataTable
        Dim FinancialAccounts As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select CAST([AccNo] AS float) as AccNo, [AccID],[AccName],[Currency],[FinancialStatment],[FinancialSector],[AccType],[FatherAccount] ,[IsMain]
from [FinancialAccounts] where 1=1 "
            If AccType <> -1 Then SqlString += " and AccType =" & AccType
            If CurrID <> -1 Then SqlString += " and Currency =" & CurrID
            If FinancialSector <> -1 Then SqlString += " and FinancialSector =" & FinancialSector
            If IsActive <> -1 Then SqlString += " And [IsActive]=1 "
            If WithFathers = False Then SqlString += " and IsMain =0 "

            Sql.SqlTrueAccountingRunQuery(SqlString)
            FinancialAccounts = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return FinancialAccounts
    End Function

    Public Function GetFinancialAccountsData(AccNo As String) As _
        (AccName As String, Currency As Integer, FinancialStatment As Integer, FinancialSector As Integer, AccType As Integer, IsMain As Boolean, FatherAccount As String, IsActive As Boolean)
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  Select [AccID],CAST([AccNo] AS float) as AccNo,[AccName],[Currency],[FinancialStatment],[FinancialSector],
[AccType],[IsMain],[FatherAccount],[IsActive] from [FinancialAccounts] where AccNo='" & AccNo & "'"
        sql.SqlTrueAccountingRunQuery(SqlString)
        Dim _AccName As String = String.Empty
        Dim _Currency As Integer = 0
        Dim _FinancialStatment As Integer = 0
        Dim _FinancialSector As Integer = 0
        Dim _AccType As Integer = 0
        Dim _IsMain As Boolean = True
        Dim _FatherAccount As String = "0"
        Dim _IsActive As Boolean
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccName"))) Then _AccName = sql.SQLDS.Tables(0).Rows(0).Item("AccName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Currency"))) Then _Currency = sql.SQLDS.Tables(0).Rows(0).Item("Currency")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FinancialStatment"))) Then _FinancialStatment = sql.SQLDS.Tables(0).Rows(0).Item("FinancialStatment")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FinancialSector"))) Then _FinancialSector = sql.SQLDS.Tables(0).Rows(0).Item("FinancialSector")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccType"))) Then _AccType = sql.SQLDS.Tables(0).Rows(0).Item("AccType")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IsMain"))) Then _IsMain = sql.SQLDS.Tables(0).Rows(0).Item("IsMain")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FatherAccount"))) Then _FatherAccount = sql.SQLDS.Tables(0).Rows(0).Item("FatherAccount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IsActive"))) Then _IsActive = CBool(sql.SQLDS.Tables(0).Rows(0).Item("IsActive"))
        End If
        Return (_AccName, _Currency, _FinancialStatment, _FinancialSector, _AccType, _IsMain, _FatherAccount, _IsActive)
    End Function

    Public Function GetDefaultAccounts(AccType As Integer, Curr As Integer, UserID As Integer) As Integer
        Dim DefaultAcc As Integer = 0
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select CAST([AccNo] AS float) as AccNo from [FinancialAccountsDefault]
                          where AccTypeID =" & AccType & "and CurrencyID = " & Curr & " and UserID =" & UserID
            sql.SqlTrueAccountingRunQuery(SqlString)
            DefaultAcc = sql.SQLDS.Tables(0).Rows(0).Item("AccNo")
        Catch ex As Exception
            DefaultAcc = 0
        End Try
        Return DefaultAcc
    End Function



    Public Function GetCostCenter(With_All As Boolean) As DataTable
        Dim _CostCenter As New DataTable
        Dim _Table As DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "SELECT CostID, CostName FROM   CostCenter "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = Sql.SQLDS.Tables(0)

            If With_All = True Then
                Dim R As DataRow = _Table.NewRow
                R("CostID") = -1
                R("CostName") = "الكل"
                _Table.Rows.Add(R)
            End If
            _CostCenter = _Table
        Catch ex As Exception

        End Try

        Return _CostCenter
    End Function
    Public Function GetCostCentersType(With_All As Boolean) As DataTable
        Dim _types As New DataTable
        Dim _Table As DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT [ID],[Type] FROM [dbo].[CostCenterTypes] ")
            _Table = sql.SQLDS.Tables(0)

            If With_All = True Then
                Dim R As DataRow = _Table.NewRow
                R("ID") = -1
                R("Type") = "الكل"
                _Table.Rows.Add(R)
            End If
            _types = _Table
        Catch ex As Exception

        End Try
        Return _types
    End Function
    Public Function GetDocNo(DocName As Integer, IsNew As Boolean) As Integer
        Dim _DocNo As Integer = 0
        Select Case DocName
            Case 11, 10
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("select ISNULL(max(DocID)+1,0) as DocID from OrdersJournal where DocName=" & DocName)
                    _DocNo = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                    If _DocNo = 0 Then _DocNo = 1
                Catch ex As Exception
                    _DocNo = 0
                End Try
            Case Else
                Dim seqManager As New SequenceManager()
                If IsNew = False Then
                    Dim nextSequence As Integer = seqManager.GetNextSequence(DocName)
                    _DocNo = nextSequence
                Else
                    Dim currentSequence As Integer = seqManager.GetCurrentSequenceValue(DocName)
                    _DocNo = currentSequence
                End If
        End Select
        Return _DocNo
    End Function
    Public Function GetDocNoByDate(_month As Integer, _year As Integer) As Integer
        Dim _VoucherNo As Integer

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select MAX([DocID])+1 As VouchNo 
                            FROM JOURNAL
                            WHERE YEAR(DocDate) = " & _year & " AND MONTH(DocDate) = " & _month
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _VoucherNo = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("VouchNo"))
        Catch ex As Exception
            _VoucherNo = CInt(Right(CStr(_year), 2) & _month.ToString("00") & 1.ToString("0000"))
        End Try


        If _VoucherNo < CInt(Right(CStr(_year), 2) & _month.ToString("00") & 1.ToString("0000")) Then
            _VoucherNo = CInt(Right(CStr(_year), 2) & _month.ToString("00") & 1.ToString("0000"))
        End If

        Return _VoucherNo
    End Function
    Public Function GetMinDocNo(DocName As Integer) As Integer
        Dim _DocNo As Integer = -1
        Select Case DocName
            Case 11
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("select ISNULL(Min(DocID),0) as DocID from OrdersJournal where DocName=" & DocName)
                    _DocNo = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Catch ex As Exception
                    _DocNo = 1
                End Try
            Case Else
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("select ISNULL(Min(DocID),0) as DocID from journal where DocName=" & DocName)
                    _DocNo = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Catch ex As Exception
                    _DocNo = 1
                End Try
        End Select

        Return _DocNo

    End Function

    'Public Function GetDocNoForOrders(DocName As Integer) As Integer
    '    Dim _DocNo As Integer = -1
    '    Try
    '        Dim Sql As New SQLControl
    '        Sql.SqlTrueAccountingRunQuery("select ISNULL(max(DocID),0) as DocID from journal where DocName=" & DocName)
    '        _DocNo = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
    '    Catch ex As Exception
    '        _DocNo = -1
    '    End Try
    '    Return _DocNo + 1
    'End Function
    Public Function GetDocData(DocID As Integer, DocName As Integer) As _
                                (DocDate As Date, DocStatus As Integer, DocCostCenter As Integer,
                                DebitAcc As String, CredAcc As String, DocCurrency As Integer,
                                DocAmount As Decimal, ExchangePrice As Decimal, BaseAmount As Decimal,
                                DocSort As Integer, Referance As Integer, DocManualNo As String,
                                InputUser As String, DocNotes As String, ReferanceName As String,
                                DocMultiCurrency As Boolean, DocCode As String, DocStatusName As String,
                                LastDocCode As String, LastDataName As String, DocID As Integer,
                                PosNo As Integer, ShiftID As Integer, DocID2 As Integer, DeviceName As String, InputDateTime As String, DocTags As String, SalesPerson As Integer)

        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  Select DISTINCT DocID,DocDate,DocName,DocStatus,DocCostCenter,
                                DebitAcc,CredAcc,DocCurrency,DocAmount,ExchangePrice,
                                BaseCurrAmount,BaseAmount,DocSort,Referance,[DocManualNo],
                                InputUser,IsNull(InputDateTime,'1900-01-01') as InputDateTime ,IsNull(DeviceName,'') as DeviceName ,DocNotes,ReferanceName,DocMultiCurrency,DocCode,LastDocCode,LastDataName,
                                IsNull(PosNo,0) as PosNo,IsNull(ShiftID,0) as ShiftID,IsNull(DocID2,0) as DocID2,IsNull(DocTags,'') as DocTags,IsNull(SalesPerson,0) As SalesPerson  "
        SqlString += "   from  journal
                       Where   DocID= " & DocID & " and DocName=" & DocName
        Select Case DocName
            Case 3
                SqlString += " and DebitAcc <> '0'"
            Case 4, 1
                SqlString += " and CredAcc <> '0'"
        End Select
        sql.SqlTrueAccountingRunQuery(SqlString)
        Dim _DocDate As DateTime = CDate("1900-01-01")
        Dim _DocStatus As Integer = 1
        Dim _DocCostCenter As Integer = 0
        Dim _DebitAcc As String = "0"
        Dim _CredAcc As String = "0"
        Dim _DocCurrency As Integer = 0
        Dim _DocAmount As Decimal = 0
        Dim _ExchangePrice As Decimal = 0
        Dim _BaseAmount As Decimal = 0
        Dim _DocSort As Integer = 0
        Dim _Referance As Integer = 0
        Dim _DocManualNo As String = String.Empty
        Dim _InputUser As Integer = 0
        Dim _DocNotes As String = String.Empty
        Dim _ReferanceName As String = String.Empty
        Dim _DocMultiCurrency As Boolean = False
        Dim _DocCode As String = String.Empty
        Dim _DocStatusName As String = String.Empty
        Dim _LastDocCode As String = String.Empty
        Dim _LastDataName As String = String.Empty
        Dim _DocID As Integer = -1
        Dim _PosNo As Integer = 0
        Dim _ShiftID As Integer = 0
        Dim _DocID2 As Integer = 0
        Dim _DeviceName As String = ""
        Dim _InputDateTime As String = "1900-01-01"
        Dim _DocTags As String = ""
        Dim _SalesPerson As Integer = 0
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocDate"))) Then _DocDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocDate").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStatus"))) Then _DocStatus = sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter"))) Then _DocCostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc"))) Then _DebitAcc = sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CredAcc"))) Then _CredAcc = sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency"))) Then _DocCurrency = sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocAmount"))) Then _DocAmount = sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice"))) Then _ExchangePrice = sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount"))) Then _BaseAmount = sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocSort"))) Then _DocSort = sql.SQLDS.Tables(0).Rows(0).Item("DocSort")
            If (Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Referance")))) And (Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("Referance"))) Then
                _Referance = sql.SQLDS.Tables(0).Rows(0).Item("Referance")
            End If
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo"))) Then _DocManualNo = sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("InputUser"))) Then _InputUser = sql.SQLDS.Tables(0).Rows(0).Item("InputUser")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocNotes"))) Then _DocNotes = sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName"))) Then _ReferanceName = sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))) Then
                _DocMultiCurrency = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))
            End If
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCode"))) Then _DocCode = sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDataName"))) Then _LastDataName = sql.SQLDS.Tables(0).Rows(0).Item("LastDataName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode"))) Then _LastDocCode = sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocID"))) Then _DocID = sql.SQLDS.Tables(0).Rows(0).Item("DocID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PosNo"))) Then _PosNo = sql.SQLDS.Tables(0).Rows(0).Item("PosNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ShiftID"))) Then _ShiftID = sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocID2"))) Then _DocID2 = sql.SQLDS.Tables(0).Rows(0).Item("DocID2")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime"))) Then _InputDateTime = sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DeviceName"))) Then _DeviceName = sql.SQLDS.Tables(0).Rows(0).Item("DeviceName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocTags"))) Then _DocTags = sql.SQLDS.Tables(0).Rows(0).Item("DocTags")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson"))) Then _SalesPerson = sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")
            '  If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStatusName"))) Then _DocStatusName = sql.SQLDS.Tables(0).Rows(0).Item("DocStatusName")

        End If


        Return (_DocDate, _DocStatus, _DocCostCenter, _DebitAcc, _CredAcc, _DocCurrency, _DocAmount,
                _ExchangePrice, _BaseAmount, _DocSort, _Referance, _DocManualNo, _InputUser, _DocNotes,
                _ReferanceName, _DocMultiCurrency, _DocCode, _DocStatusName, _LastDocCode, _LastDataName, _DocID, _PosNo, _ShiftID, _DocID2, _DeviceName, Format(CDate(_InputDateTime), "yyyy-MM-dd HH:mm:ss"), _DocTags, _SalesPerson)
    End Function

    Public Function CheckIfHRSystemIsConnectedWithAccountingSystem() As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select SettingValue from Settings where SettingName='HRSystemIsConnectedWithAccountingSystem'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function GetAttConnectionType() As String
        Try
            Dim SQl As New SQLControl
            SQl.SqlTrueTimeRunQuery("select SettingValue  from Settings where SettingName='AttConnectionType'")
            Return SQl.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            Return "Access"
        End Try

    End Function

    Public Function RefreshMoneyTransList(_DocName As Integer, ShowDeletedDoc As Boolean, _TransCount As Integer) As DataTable
        'Dim _DateFrom As String = Format(DateFrom, "yyyy-MM-dd")
        'Dim _DateTo As String = Format(DateTo, "yyyy-MM-dd")
        Dim _DataTable As New DataTable
        Try
            If _DocName = 1 Or _DocName = 2 Or _DocName = 3 Or _DocName = 4 Or _DocName = 8 Or _DocName = 9 Or _DocName = 12 Or _DocName = 13 Or _DocName = 6 Or _DocName = 7 Or _DocName = 17 Or _DocName = 18 Then
                Dim SqlString As String
                Dim SQl As New SQLControl
                SqlString = " SELECT "
                If _TransCount <> -1 Then SqlString += " top(" & _TransCount & ") "
                SqlString += " J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,DocCode,
                                   C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,ISNULL(SUM(StockDiscount),0) AS StockDiscount,ISNULL(SUM(VoucherDiscount),0) AS VoucherDiscount,
                                   SUM(BaseAmount) AS BaseAmount,Sum(BaseCurrAmount) as BaseCurrAmount,Case when SUM(DocAmount) > 0 then SUM(BaseAmount)/SUM(DocAmount) end As ExchangePrice,
                                   OrderStatus,DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DocManualNo,R.ReferanceCode,E.EmployeeName As SalesPerson,DocStatus,DocID2,PaidStatus,PaidAmount,Rs.SortName as RefSort,DeviceName,DocTags,IsNull(Cs.CostName,0) as CostCenterName
                                  "
                If _DocName = 4 Or _DocName = 1 Or _DocName = 8 Or _DocName = 10 Or _DocName = 12 Or _DocName = 7 Or _DocName = 17 Then SqlString += ",CredAcc As Account "
                If _DocName = 3 Or _DocName = 2 Or _DocName = 9 Or _DocName = 11 Or _DocName = 13 Or _DocName = 6 Or _DocName = 18 Then SqlString += ",DebitAcc As Account"
                SqlString += "  from journal J
                            left join DocNames N on N.id =J.DocName
                            left join Currency C on C.CurrID = J.DocCurrency 
                            left Join DocSorts S on S.SortID =J.DocSort
                            left join Referencess R on R.[RefNo] = J.Referance
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson
                            Left Join [dbo].[RefSorts] Rs on Rs.ID=R.RefSort
                            Left Join [dbo].[CostCenter] Cs on Cs.CostID=J.DocCostCenter "
                SqlString += " where DocName = " & _DocName
                'If _TransCount <> -1 Then SqlString += " And DocDate Between '" & _DateFrom & "' and '" & _DateTo & "' "
                If ShowDeletedDoc = False Then SqlString += " and J.DocStatus > 0 "
                If _DocName = 4 Or _DocName = 1 Or _DocName = 8 Or _DocName = 10 Or _DocName = 12 Or _DocName = 7 Or _DocName = 17 Then SqlString += " and	 CredAcc<>'0' "
                If _DocName = 3 Or _DocName = 2 Or _DocName = 9 Or _DocName = 11 Or _DocName = 13 Or _DocName = 6 Or _DocName = 18 Then SqlString += " and	 DebitAcc<>'0' "
                SqlString += "  group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DocCode,DocManualNo,
                                     DocStatus,R.ReferanceCode,E.EmployeeName,DocID2,PaidStatus,PaidAmount,Rs.SortName,DeviceName,DocTags,Cs.CostName,OrderStatus "
                If _DocName = 4 Or _DocName = 1 Or _DocName = 8 Or _DocName = 10 Or _DocName = 12 Or _DocName = 7 Or _DocName = 17 Then SqlString += ",CredAcc "
                If _DocName = 3 Or _DocName = 2 Or _DocName = 9 Or _DocName = 11 Or _DocName = 13 Or _DocName = 6 Or _DocName = 18 Then SqlString += ",DebitAcc"
                SqlString += " order by DocID DESC"
                SQl.SqlTrueAccountingRunQuery(SqlString)
                _DataTable = SQl.SQLDS.Tables(0)
            End If

            If _DocName = 5 Then
                Dim SqlString As String
                Dim SQl As New SQLControl
                SqlString = " SELECT "
                If _TransCount <> -1 Then SqlString += " top(" & _TransCount & ") "
                SqlString += "J.DocID,DocDate,N.[Name] as DocNameText, J.DocName,Sum(BaseCurrAmount)/2 as BaseCurrAmount,
                          S.SortName as DocSort,DocNotes,DocCode,DocManualNo,DocStatus,E.EmployeeName As SalesPerson,DocID2,DocTags  "
                SqlString += "  from journal J
                            left join DocNames N on N.id =J.DocName
                            left Join DocSorts S on S.SortID =J.DocSort
                            left join Referencess R on R.[RefNo] = J.Referance
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson"
                SqlString += " where DocName = " & _DocName
                'If _TransCount <> -1 Then SqlString += " And DocDate Between '" & _DateFrom & "' and '" & _DateTo & "' "
                If ShowDeletedDoc = False Then SqlString += " and J.DocStatus > 0 "

                SqlString += "  group by DocDate,N.[Name],J.DocID,S.SortName,DocName,DocNotes,DocCode,DocManualNo,DocStatus,EmployeeName,DocID2,DocTags "
                SqlString += " order by DocID DESC"
                SQl.SqlTrueAccountingRunQuery(SqlString)
                _DataTable = SQl.SQLDS.Tables(0)
            End If

            If _DocName = 19 Then
                Dim SqlString As String
                Dim SQl As New SQLControl
                SqlString = "   SELECT  "
                If _TransCount <> -1 Then SqlString += " top(" & _TransCount & ") "
                SqlString += " J.DocID,DocDate,N.[Name] as DocNameText, J.DocName,Sum(BaseCurrAmount) as BaseCurrAmount,Referance,J.ReferanceName as ReferanceName,
                                     S.SortName as DocSort,DocNotes,DocCode,DocManualNo,DocStatus,E.EmployeeName As SalesPerson,J.StockID  As ItemNo,J.ItemName, J.[StockPrice]/IU.EquivalentToMain  As UnitPrice,DocID2,DocTags 
                            From journal J
                            left join DocNames N on N.id =J.DocName
                            left Join DocSorts S on S.SortID =J.DocSort
                            left join Referencess R on R.[RefNo] = J.Referance
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson
                            left join Items_Units IU on IU.item_id=J.StockID "
                SqlString += "  Where DocName=19 and J.DocStatus > 0 And DebitAcc<>'0' and IU.main_unit=1 "
                If ShowDeletedDoc = False Then SqlString += " and J.DocStatus > 0 "
                'If _TransCount <> -1 Then SqlString += " And DocDate Between '" & _DateFrom & "' and '" & _DateTo & "' "
                SqlString += "        Group by DocDate,N.[Name],J.DocID,S.SortName,DocName,DocNotes,DocCode,DocManualNo,DocStatus,EmployeeName,J.StockID,J.ItemName ,Referance,J.ReferanceName ,J.[StockPrice]/IU.EquivalentToMain,DocID2,DocTags
                            Order by DocID DESC "
                SQl.SqlTrueAccountingRunQuery(SqlString)
                _DataTable = SQl.SQLDS.Tables(0)
            End If

            If _DocName = 16 Then
                Dim SqlString As String
                Dim SQl As New SQLControl
                SqlString = " SELECT "
                If _TransCount <> -1 Then SqlString += " top(" & _TransCount & ") "
                SqlString += " J.DocID,DocDate,N.[Name] as DocNameText, J.DocName,Sum(BaseCurrAmount) as BaseCurrAmount,
                                   S.SortName as DocSort,DocNotes,DocCode,DocManualNo,DocStatus,DocID2,DocTags "
                SqlString += "  from journal J
                            left join DocNames N on N.id =J.DocName
                            left Join DocSorts S on S.SortID =J.DocSort"
                SqlString += " where DocName = " & _DocName
                If ShowDeletedDoc = False Then SqlString += " and J.DocStatus > 0 "
                'If _TransCount <> -1 Then SqlString += " And DocDate Between '" & _DateFrom & "' and '" & _DateTo & "' "
                SqlString += "  group by DocDate,N.[Name],J.DocID,S.SortName,DocName,DocNotes,DocCode,DocManualNo,DocStatus,DocID2,DocTags "
                SqlString += "  order by DocID DESC"
                SQl.SqlTrueAccountingRunQuery(SqlString)
                _DataTable = SQl.SQLDS.Tables(0)
            End If
        Catch ex As Exception

        End Try

        Return _DataTable
        '  GridControl1.DataSource = SQl.SQLDS.Tables(0)
        '  GridView1.BestFitColumns()
    End Function

    Public Function RefreshMoneyTransListFromOrderApp(_DocName As Integer, ShowDeletedDoc As Boolean, DocStatus As Integer) As DataTable
        Dim _DataTable As New DataTable
        Try
            Dim SqlString As String
            Dim SQl As New SQLControl
            SqlString = " SELECT J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,
C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,
SUM(BaseAmount) AS BaseAmount,Sum(BaseCurrAmount) as BaseCurrAmount,
DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DeviceName,OrderStatus,DocCode,[InputDateTime],[InputUser],SalesPerson,DeliverDate "
            SqlString += "  from OrdersAppJournal J
                            left join DocNames N on N.id =J.DocName
                            left join Currency C on C.CurrID = J.DocCurrency 
                            left Join DocSorts S on S.SortID =J.DocSort
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson"
            SqlString += " where J.ID > 0 "
            If _DocName <> -1 Then SqlString += " and DocName= " & _DocName
            If DocStatus <> -1 Then SqlString += " and OrderStatus= " & DocStatus
            If ShowDeletedDoc = False Then SqlString += " and DocStatus > 0 "
            SqlString += "  group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DeviceName,OrderStatus,DocCode,InputDateTime,[InputUser],SalesPerson,DeliverDate "
            SqlString += " order by InputDateTime DESC"
            SQl.SqlTrueAccountingRunQuery(SqlString)
            _DataTable = SQl.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _DataTable
    End Function
    Public Function RefreshLOrdersTransList(_DocName As Integer, ShowDeletedDoc As Boolean) As DataTable
        Dim _DataTable As New DataTable
        If _DocName = 11 Or _DocName = 10 Then
            Dim SqlString As String
            Dim SQl As New SQLControl
            SqlString = " SELECT   J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,
C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,
SUM(BaseAmount) AS BaseAmount,Sum(BaseCurrAmount) as BaseCurrAmount,
DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DocManualNo,OrderStatus,DocCode,E.EmployeeName As SalesPerson,DocStatus,DocTags "
            SqlString += "  from OrdersJournal J
                            left join DocNames N on N.id =J.DocName
                            left join Currency C on C.CurrID = J.DocCurrency 
                            left Join DocSorts S on S.SortID =J.DocSort
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson"
            SqlString += " where DocName = " & _DocName
            If ShowDeletedDoc = False Then SqlString += " and DocStatus > 0 "
            If _DocName = 10 Then SqlString += " and	 CredAcc<>'0' "
            If _DocName = 11 Then SqlString += " and	 DebitAcc<>'0' "
            SqlString += "  group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DocManualNo,OrderStatus,DocCode,E.EmployeeName,DocStatus,DocTags "
            SqlString += " order by DocID DESC"
            SQl.SqlTrueAccountingRunQuery(SqlString)
            _DataTable = SQl.SQLDS.Tables(0)
        End If

        Return _DataTable
        '  GridControl1.DataSource = SQl.SQLDS.Tables(0)
        '  GridView1.BestFitColumns()
    End Function
    Public Function GetAccTypes(DocName As Integer) As DataTable
        Dim AccTypes As New DataTable
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            Select Case DocName
                Case 3
                    SqlString = " select AccTypeID,AccTypeName from FinancialAccountsTypes Where AccTypeID=1 or AccTypeID=4 "
                Case Else
                    SqlString = " select AccTypeID,AccTypeName from FinancialAccountsTypes"
            End Select
            sql.SqlTrueAccountingRunQuery(SqlString)
            AccTypes = sql.SQLDS.Tables(0)
        Catch ex As Exception
        End Try
        Return AccTypes
    End Function
    Public Function GetWharehouses(With_All As Boolean) As DataTable
        Dim _Warehouses As New DataTable
        Try
            Dim _Table As New DataTable
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " SELECT [WarehouseID]      ,[WarehouseNameAR]      ,[WarehouseNameEn]
                          FROM [Warehouses]"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = sql.SQLDS.Tables(0)
            If With_All = True Then
                Dim R As DataRow = _Table.NewRow
                R("WarehouseID") = -1
                R("WarehouseNameAR") = "الكل"
                R("WarehouseNameEn") = "All"
                _Table.Rows.Add(R)
            End If
            _Warehouses = _Table
        Catch ex As Exception
        End Try
        Return _Warehouses
    End Function
    Public Function GetWareHouseName(WarehouseID As Integer) As String
        Dim _WareHouseName As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select WarehouseNameAR from Warehouses where WarehouseID =" & WarehouseID)
            _WareHouseName = sql.SQLDS.Tables(0).Rows(0).Item("WarehouseNameAR")
        Catch ex As Exception
            _WareHouseName = ""
        End Try
        Return _WareHouseName
    End Function
    Public Function GetShelves(WarehouseID As Integer) As DataTable
        Dim _Shelves As New DataTable
        Try
            Dim _Table As New DataTable
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " SELECT [ShelfID]      ,[ShelfCode]      ,[WareHouseID]  
                          FROM [dbo].[FinancialShelves] where WareHouseID=" & WarehouseID
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = sql.SQLDS.Tables(0)
            _Shelves = _Table
        Catch ex As Exception
        End Try
        Return _Shelves
    End Function

    Public Function GetDefaultWharehouse() As Integer
        Dim DefaultWharehouse As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select WarehouseID from Warehouses where IsDefault =1")
            DefaultWharehouse = sql.SQLDS.Tables(0).Rows(0).Item("WarehouseID")
        Catch ex As Exception
            DefaultWharehouse = 1
        End Try
        Return DefaultWharehouse

    End Function
    Public Function GetDefaultWharehouseForPos() As Integer
        Dim DefaultWharehouse As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select [Warehouse] from [dbo].[AccountingPOSNames] where ID =" & My.Settings.POSNo)
            DefaultWharehouse = sql.SQLDS.Tables(0).Rows(0).Item("Warehouse")
        Catch ex As Exception
            DefaultWharehouse = 1
            MsgBox("يجب تعريف نقطة بيع من شاشة الاعدادات  ")
        End Try
        Return DefaultWharehouse

    End Function
    Public Function GetDefaltWahreHouseForUser(UserId As Integer) As Integer
        Dim _result As Integer
        Try
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select DefaultWareHouse from [dbo].[EmployeesData] where [EmployeeID]=" & UserId
            Sql.SqlTrueAccountingRunQuery(sqlstring)
            _result = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("DefaultWareHouse"))
        Catch ex As Exception
            _result = 1
        End Try
        Return _result
    End Function

    Public Function GetDefaultCostCenter(_UserID As Integer) As Integer
        Dim DefaultCostCenter As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select DefaultCostCenter from EmployeesData where EmployeeID =" & _UserID)
            DefaultCostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DefaultCostCenter")
        Catch ex As Exception
            DefaultCostCenter = 1
        End Try
        Return DefaultCostCenter
    End Function
    Public Function GetDefaultCurrency() As Integer
        Dim DefaultCurrency As Integer

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select CurrID from Currency where IsDefault =1")
            DefaultCurrency = sql.SQLDS.Tables(0).Rows(0).Item("CurrID")
        Catch ex As Exception
            DefaultCurrency = 0
        End Try
        Return DefaultCurrency

    End Function

    'Public Function GetMaxDocNo(DocName As Integer) As Integer
    '    Dim _MaxDocID As Integer
    '    Try
    '        Dim Sql As New SQLControl
    '        Sql.SqlTrueAccountingRunQuery("Select Max(DocID) as DocID from Journal where DocName=" & DocName)
    '        _MaxDocID = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
    '    Catch ex As Exception
    '        _MaxDocID = 0
    '    End Try
    '    Return _MaxDocID
    'End Function

    Public Function InsertDataFromTempToJournal(_DocData As String, _DocID As Integer, _DocCode As String) As Boolean
        Try
            Dim SqlString3 As String
            Dim sql As New SQLControl
            SqlString3 = "   Insert into " & _DocData & " ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,BatchNo,
                                                PaidStatus,PaidAmount,PaidByDocID,PosNo,ShiftID,DocID2,DocTags,HasAttachment,[StockWidth],[StockLength],[StockCount],[IsVAT],[ItemVATPercentage])
                             Select  " & _DocID & ",[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,BatchNo,
                                                PaidStatus,PaidAmount,PaidByDocID,PosNo,ShiftID,DocID2,DocTags,HasAttachment,[StockWidth],[StockLength],[StockCount],[IsVAT],[ItemVATPercentage]
                                                from JournalTemp where DocCode='" & _DocCode & "'"
            Return sql.SqlTrueAccountingRunQuery(SqlString3)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function InsertDataFromTempToJournalWithLockTable(_DocName As Integer, _DocCode As String, _DocID_ As Integer) As Integer

        Dim _DocIdResult As Integer
        Try
            Dim sqlCon As SqlConnection
            sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand
                sqlComm.Connection = sqlCon
                sqlComm.CommandText = "InsertDataFromTempToJournal"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000
                sqlComm.Parameters.AddWithValue("DocName", _DocName)
                sqlComm.Parameters.AddWithValue("DocCode", _DocCode)
                sqlComm.Parameters.AddWithValue("UserID", GlobalVariables.CurrUser)
                sqlComm.Parameters.AddWithValue("DeviceName", GlobalVariables.CurrDevice)
                sqlComm.Parameters.AddWithValue("_DocID", _DocID_)
                Dim outputParameter As New SqlParameter("@DocID", SqlDbType.Int)
                outputParameter.Direction = ParameterDirection.Output
                sqlComm.Parameters.Add(outputParameter)
                sqlCon.Open()
                sqlComm.ExecuteNonQuery()
                If IsDBNull(sqlComm.Parameters("@DocID").Value) Then
                    _DocIdResult = 0
                Else
                    _DocIdResult = Convert.ToInt32(sqlComm.Parameters("@DocID").Value)
                End If
                sqlCon.Close()
            End Using
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "Delete from JournalTemp 
                         where DocName=" & _DocName & " and DocCode='" & _DocCode & "' 
                              And CurrentUserID= " & GlobalVariables.CurrUser & " 
                              And DeviceName='" & GlobalVariables.CurrDevice & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _DocIdResult = 0
        End Try
        Return _DocIdResult
    End Function
    Public Function DeleteFromJournalTemp(DocName As Integer, DocCode As String) As Boolean
        Dim _Result As Boolean
        Dim SqlString As String
        ' Delete TempJournal When OpenClose Document 
        SqlString = "Delete from JournalTemp where DocName=" & DocName & " 
                                           and DocCode='" & DocCode & "' and CurrentUserID= " & GlobalVariables.CurrUser

        'Select Case DocCode
        '    Case -1
        '        ' Delete TempJournal When OpenCloseApp  
        '        SqlString = "Delete from JournalTemp where CurrentUserID= " & GlobalVariables.CurrUser
        '    Case 0
        '        ' Delete TempJournal When OpenClose Document 
        '        SqlString = "Delete from JournalTemp where DocName=" & DocName & " 
        '                                    and CurrentUserID= " & GlobalVariables.CurrUser
        'End Select


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Result = True
        Catch ex As Exception
            _Result = False
        End Try
        Return _Result

    End Function


    Public Function DeleteFromJournal(DocName As Integer, DocID As Integer, ByVal Optional UpdateDateTime As String = "") As Boolean
        Dim _Result As Boolean
        Dim _CopyJouranl As Boolean
        Dim SqlString3 As String
        Select Case DocName
            Case 11, 10
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("Delete from OrdersJournal where DocName=" & DocName & " 
                                           and DocID=" & DocID)
                    _Result = True
                Catch ex As Exception
                    _Result = False
                End Try
            Case Else
                Try
                    Dim Sql As New SQLControl
                    Dim _UpdateDateTime As String
                    If String.IsNullOrEmpty(UpdateDateTime) Then
                        _UpdateDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                    Else
                        _UpdateDateTime = UpdateDateTime
                    End If
                    SqlString3 = "   Insert into JournalBeforeUpdate (ID,[DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                               [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,DocTags,[StockWidth],[StockLength],[StockCount],ItemVATPercentage)
                             Select  ID,DocID,[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,'" & _UpdateDateTime & "',StockID,StockUnit,
                                                [StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,DocTags,[StockWidth],[StockLength],[StockCount],ItemVATPercentage
                                                from Journal where DocName=" & DocName & " and DocID=" & DocID
                    _CopyJouranl = Sql.SqlTrueAccountingRunQuery(SqlString3)

                    If _CopyJouranl = True Then
                        Sql.SqlTrueAccountingRunQuery("Delete from Journal where DocName=" & DocName & " 
                                           and DocID=" & DocID)
                        Sql.SqlTrueAccountingRunQuery("Delete from checks where DocName=" & DocName & " 
                                           and DocID=" & DocID & " And [TransNoInJournal]=1 ")
                        _Result = True
                    Else
                        _Result = False
                    End If


                Catch ex As Exception
                    _Result = False
                End Try
        End Select
        Return _Result
    End Function
    Public Function DeleteVoucherFromJournalAndInsertFromTemp(DocName As Integer, DocID As Integer) As Boolean
        Dim _Result As Boolean
        Select Case DocName
            Case 11, 10
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("Delete from OrdersJournal where DocName=" & DocName & " 
                                           and DocID=" & DocID)
                    _Result = True
                Catch ex As Exception

                    _Result = False
                End Try
            Case Else
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("Delete from Journal where DocName=" & DocName & " 
                                           and DocID=" & DocID)
                    Sql.SqlTrueAccountingRunQuery("Delete from checks where DocName=" & DocName & " 
                                           and DocID=" & DocID)
                    _Result = True
                Catch ex As Exception
                    _Result = False
                End Try
        End Select
        Return _Result
    End Function

    Public Function InsertFromTempToJournal(DocName As Integer, DocID As Integer) As Boolean
        Dim _Result As Boolean
        Dim String1, String2 As String
        Select Case DocName
            Case 11, 10
                String1 = " INSERT INTO OrdersJournal
                                                SELECT * FROM JournalTemp
                                                where DocName=" & DocName & "  and DocID=" & DocID & " and CurrentUserID= " & GlobalVariables.CurrUser
                Try
                    Dim sql As New SQLControl
                    If sql.SqlTrueAccountingRunQuery(String1) = True Then
                        _Result = True
                    Else
                        _Result = False
                    End If
                Catch ex As Exception
                    _Result = False
                End Try
            Case Else
                String1 = " INSERT INTO Journal ([DocID]
                                ,[DocDate],[DocName],[DocStatus],[DocCostCenter]
                                ,[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency]
                                ,[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount]
                                ,[DocSort],[Referance],[DocManualNo],[DocMultiCurrency]
                                ,[InputUser],[InputDateTime],[ModifiedUser],[ModifiedDateTime]
                                ,[DocAuditDate],[DocAuditUser],[DocNotes],[StockID]
                                ,[StockUnit],[StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],[StockPrice]
                                ,[StockDiscount],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse]
                                ,[StockDriver],[StockCarNo],[SalesPerson],[CheckNo]
                                ,[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank]
                                ,[CheckCustBranch],[CheckCustAccountId],[AccountBank],[DeleteUser]
                                ,[DeleteDateTime],[CurrentUserID],[ReferanceName],[DocCode]
                                ,[CheckCode],[ItemName],[DocCheckTransID],[TransNoInJournal]
                                ,[ShiftID],[DocNoteByAccount],[StockBarcode],[PosNo]
                                ,[DeviceName],[OrderStatus],[ItemStatus],[ApprovedQuantity]
                                ,[LastDocCode],[LastDataName],[DeliverDate],[Color]
                                ,[Measure],[VoucherDiscount],[ItemVAT],[StockDebitShelve],[StockCreditShelve],[OrderID],[DocID2],PaidStatus,PaidAmount,TarteebID,DocTags,[StockWidth],[StockLength],[StockCount])
                             SELECT [DocID],[DocDate],[DocName],[DocStatus]
                                ,[DocCostCenter],[DebitAcc],[CredAcc],[AccountCurr]
                                ,[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount]
                                ,[BaseAmount],[DocSort],[Referance],[DocManualNo]
                                ,[DocMultiCurrency],[InputUser],[InputDateTime],[ModifiedUser]
                                ,[ModifiedDateTime],[DocAuditDate],[DocAuditUser],[DocNotes]
                                ,[StockID],[StockUnit],[StockQuantity],[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit]
                                ,[StockPrice],[StockDiscount],[StockItemPrice],[StockDebitWhereHouse]
                                ,[StockCreditWhereHouse],[StockDriver],[StockCarNo],[SalesPerson]
                                ,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate]
                                ,[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank]
                                ,[DeleteUser],[DeleteDateTime],[CurrentUserID],[ReferanceName]
                                ,[DocCode],[CheckCode],[ItemName],[DocCheckTransID]
                                ,[TransNoInJournal],[ShiftID],[DocNoteByAccount],[StockBarcode]
                                ,[PosNo],[DeviceName],[OrderStatus],[ItemStatus]
                                ,[ApprovedQuantity],[LastDocCode],[LastDataName],[DeliverDate]
                                ,[Color],[Measure],[VoucherDiscount],[ItemVAT],[StockDebitShelve],
                                [StockCreditShelve],[OrderID],[DocID2],PaidStatus,PaidAmount,TarteebID ,DocTags,[StockWidth],[StockLength],[StockCount]
                            FROM JournalTemp
                            WHERE DocName=" & DocName & "  and DocID=" & DocID & " and CurrentUserID= " & GlobalVariables.CurrUser

                String2 = " INSERT INTO Checks (DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckBank,CheckBranch,CheckAccountId,CheckStatus,CheckAmount,CheckCurr,CheckBaseAmount,DocCode,DocID,AccountBank,DocNoteByAccount,ChekInBoxAccount,Referance,RelatedAccount,TransNoInJournal)
                                                SELECT  DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckCustBank,CheckCustBranch,CheckCustAccountId,CheckStatus,DocAmount,DocCurrency,BaseCurrAmount,DocCode,DocID,AccountBank,DocNoteByAccount,DebitAcc,Referance,"
                If DocName = 3 Then String2 += " CredAcc,TransNoInJournal FROM JournalTemp"
                If DocName = 4 Then String2 += " DebitAcc,TransNoInJournal FROM JournalTemp"
                String2 += "     where DocName=" & DocName & "  and DocID=" & DocID & " and CurrentUserID= " & GlobalVariables.CurrUser & " and CheckNo <> 0 And [TransNoInJournal]=1 "
                If DocName = 4 Then String2 += " And CredAcc='0'  "
                If DocName = 3 Then String2 += " And DebitAcc='0'  "

                Try
                    Dim sql As New SQLControl
                    If sql.SqlTrueAccountingRunQuery(String1) = True Then
                        _Result = True
                    Else
                        _Result = False
                    End If

                    Try
                        If DocName = 4 Or DocName = 3 Then
                            If sql.SqlTrueAccountingRunQuery(String2) = True Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Cheques Input Error")
                    End Try
                Catch ex As Exception
                    _Result = False
                End Try
        End Select


        Return _Result
    End Function



    Public Function CheckIfDocInJournal(DocName As Integer, DocID As Integer) As Boolean
        Dim _Result As Boolean
        Select Case DocName
            Case 11, 10
                Try
                    Dim sql As New SQLControl
                    sql.SqlTrueAccountingRunQuery("  SELECT TOP (1) [ID] FROM OrdersJournal
                                             where DocName=" & DocName & "  and DocID=" & DocID)
                    If IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ID")) Then
                        _Result = False
                    Else
                        _Result = True
                    End If
                Catch ex As Exception
                    _Result = False
                End Try
            Case Else
                Try
                    Dim sql As New SQLControl
                    sql.SqlTrueAccountingRunQuery("  SELECT TOP (1) [ID] FROM Journal
                                             where DocName=" & DocName & "  and DocID=" & DocID)
                    If IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ID")) Then
                        _Result = False
                    Else
                        _Result = True
                    End If
                Catch ex As Exception
                    _Result = False
                End Try
        End Select

        Return _Result
    End Function

    Public Function CheckIfDocInJournalByDocCode(DocCode As String, DocData As String) As Boolean
        Dim _Result As Boolean
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  SELECT TOP (1) [ID] FROM " & DocData & "
                                             where DocCode='" & DocCode & "' and DocStatus<> 0 ")
            If IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ID")) Then
                _Result = False
            Else
                _Result = True
            End If
        Catch ex As Exception
            _Result = False
        End Try
        Return _Result
    End Function

    Public Function GetDocDataTable(DocName As Integer, DocID As Integer, DataName As String, Optional ModifiedDateTime As String = "") As (FirstTable As DataTable, SecondTable As DataTable)

        Dim _FirstTable As New DataTable
        Dim _SecondTable As New DataTable

        Try
            Select Case DocName
                Case 1, 2, 12, 13, 16, 17, 18, 8, 9
                    Dim Sql As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select   StockID,J.ItemName,StockUnit,CASE WHEN DocName IN (8,9) AND OrderStatus=99 then IsNull(DispatchQuantity,0) ELSE StockQuantity-IsNull([BonusQuantity],0) END AS StockQuantity,
                                        IsNull([BonusQuantity],0) as BonusQuantity ,IsNull([BonusQuantityByMainUnit],0) as BonusQuantityByMainUnit,
                                        CASE WHEN DocName IN (8,9) AND OrderStatus=99 THEN ISNULL(DispatchStockQuantityByMainUnit,0) Else StockQuantityByMainUnit-IsNull([BonusQuantityByMainUnit],0) END AS StockQuantityByMainUnit,
                                       StockPrice,DebitAcc,CredAcc,BaseAmount,BaseCurrAmount,(DocAmount+isnull(VoucherDiscount,0)) as DocAmount ,StockBarcode,
                                       Case when StockQuantity<>0 then StockQuantityByMainUnit/StockQuantity else 0 end as StockQuantityPerMainUnit ,
                                      isnull( StockDiscount,0) as StockDiscount,isnull(VoucherDiscount,0) as VoucherDiscount,StockCreditShelve,StockDebitShelve,Color,Measure,
                                      Isnull( ItemVAT,0) as ItemVAT, Isnull( ItemVATPercentage,0) as ItemVATPercentage  ,DocNoteByAccount,[DocCostCenter],ItemNo2,LastPurchasePrice,0 as Balance,BatchID,BatchNo,IsNull([StockWidth],0) As StockWidth ,IsNull([StockLength],0) As StockLength,IsNull([StockCount],0) As StockCount
                              From  " & DataName & " J
                              Where DocName= " & DocName & " and DocID= " & DocID & "
                                    And  StockID <> '0' and StockID <> '' "
                    If DataName = "JournalBeforeUpdate" Then SqlString += " And ModifiedDateTime='" & Format(CDate(ModifiedDateTime), "yyyy-MM-dd HH:mm:ss") & "'"
                    SqlString += " Order By J.OrderID"
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    _FirstTable = Sql.SQLDS.Tables(0)
                Case 4, 3
                    Try
                        Dim Sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Select   CheckNo,CheckDueDate,DocAmount,DocCurrency as DocCheksCurr,
                                           ExchangePrice,BaseAmount,BaseCurrAmount,CheckCustAccountId,
                                           CheckCustBank,CheckCustBranch,DebitAcc,AccountBank as AccountBank,CredAcc as FinancialAccount,DocNoteByAccount
                              From  " & DataName & " J
                              Left Join FinancialAccounts A on J.CredAcc=A.AccNo
                              Where 1=1 "
                        If DocName = 4 Then SqlString += " and CredAcc='0' "
                        If DocName = 3 Then SqlString += " and DebitAcc='0' "
                        SqlString += " and DocName= " & DocName & " and DocID= " & DocID & " and CheckNo<>0 "
                        SqlString += "Order by A.AccType "
                        Sql.SqlTrueAccountingRunQuery(SqlString)
                        _FirstTable = Sql.SQLDS.Tables(0)
                    Catch ex As Exception

                    End Try

                    Try
                        Dim Sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Select "
                        If DocName = 4 Then SqlString += "DebitAcc as DebitCredAcc,"
                        If DocName = 3 Then SqlString += "CredAcc as DebitCredAcc,"
                        SqlString += " AccountCurr,DocAmount,ExchangePrice
                                         BaseAmount,BaseCurrAmount,DocCurrency,A.AccType
                              From  " & DataName & " J
                              Left Join FinancialAccounts A on J.CredAcc=A.AccNo
                              Where 1=1 "
                        If DocName = 4 Then SqlString += " and CredAcc='0' "
                        If DocName = 3 Then SqlString += " and DebitAcc='0' "
                        SqlString += " and DocName= " & DocName & " and DocID= " & DocID & " and CheckNo=0 "
                        SqlString += " Order by A.AccType "
                        Sql.SqlTrueAccountingRunQuery(SqlString)
                        _SecondTable = Sql.SQLDS.Tables(0)
                    Catch ex As Exception

                    End Try

                Case 11, 10
                    Dim Sql As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select   StockID,J.ItemName,StockUnit,StockQuantity-IsNull([BonusQuantity],0)  AS StockQuantity,[BonusQuantity],StockQuantityByMainUnit-IsNull([BonusQuantityByMainUnit],0)  AS StockQuantityByMainUnit,IsNull([BonusQuantityByMainUnit],0) as BonusQuantityByMainUnit,
                                       StockPrice,DebitAcc,CredAcc,BaseAmount,BaseCurrAmount,(DocAmount+isnull(VoucherDiscount,0)) as DocAmount,StockBarcode,
                                       Isnull( StockDiscount,0) as StockDiscount,isnull(VoucherDiscount,0) as VoucherDiscount,Isnull( ItemVAT,0) as ItemVAT,[DocCostCenter],J.ItemNo2,J.LastPurchasePrice,J.BatchID,IsNull([StockWidth],0) As StockWidth ,IsNull([StockLength],0) As StockLength,IsNull([StockCount],0) As StockCount
                              From  " & DataName & " J
                              Left Join Items I on  J.StockID=I.ItemNo 
                              Where DocName= " & DocName & " and DocID= " & DocID & "
                                    And  StockID <> '0' and StockID <> '' "
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    _FirstTable = Sql.SQLDS.Tables(0)
            End Select
        Catch ex As Exception

        End Try



        Return (_FirstTable, _SecondTable)
    End Function

    Public Function GetDocDataTableFromAppSystem(DocName As Integer, DocCode As String) As (FirstTable As DataTable, SecondTable As DataTable)

        Dim _FirstTable As New DataTable
        Dim _SecondTable As New DataTable

        Select Case DocName
            Case 1, 2, 11, 12, 13, 14, 15, 16
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select   StockID,I.ItemName,StockUnit,(StockQuantity-BonusQuantity) As StockQuantity,BonusQuantity,(StockQuantityByMainUnit-BonusQuantityByMainUnit) As StockQuantityByMainUnit,BonusQuantityByMainUnit,
                                       StockPrice,DebitAcc,CredAcc,BaseAmount,BaseCurrAmount,
                                       (DocAmount+isnull(VoucherDiscount,0)) as DocAmount, IU.item_unit_bar_code as StockBarcode,
                                       Isnull( StockDiscount,0) as StockDiscount,isnull(VoucherDiscount,0) as VoucherDiscount, 
                                       Isnull( ItemVAT,0) as ItemVAT, Isnull( ItemVATPercentage,0) as ItemVATPercentage,StockCreditShelve,StockDebitShelve,DocNoteByAccount,[DocCostCenter],J.ItemNo2,IsNull([StockWidth],0) As StockWidth ,IsNull([StockLength],0) As StockLength,IsNull([StockCount],0) As StockCount
                              From  [OrdersAppJournal] J
                              Left Join Items I on  J.StockID=I.ItemNo 
                              Left join Items_units IU on J.StockID =IU.item_id and J.StockBarcode=IU.item_unit_bar_code 
                              Where DocName= " & DocName & " and DocCode= '" & DocCode & "'
                                    And  StockID <> '0' and StockID <> '' order by J.OrderID"
                Sql.SqlTrueAccountingRunQuery(SqlString)
                _FirstTable = Sql.SQLDS.Tables(0)
            Case 4, 3
                Try
                    Dim Sql As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select   CheckNo,CheckDueDate,DocAmount,DocCurrency as DocCheksCurr,
                                           ExchangePrice,BaseAmount,BaseCurrAmount,CheckCustAccountId,
                                           CheckCustBank,CheckCustBranch,DebitAcc,AccountBank as AccountBank,CredAcc as FinancialAccount,DocNoteByAccount
                              From  [OrdersAppJournal] J
                              Left Join FinancialAccounts A on J.CredAcc=A.AccNo
                              Where 1=1 "
                    If DocName = 4 Then SqlString += " and CredAcc='0' "
                    If DocName = 3 Then SqlString += " and DebitAcc='0' "
                    SqlString += " and DocName= " & DocName & " and DocID= '" & DocCode & "' and CheckNo<>0 "
                    SqlString += "Order by A.AccType "
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    _FirstTable = Sql.SQLDS.Tables(0)
                Catch ex As Exception

                End Try

                Try
                    Dim Sql As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select "
                    If DocName = 4 Then SqlString += "DebitAcc as DebitCredAcc,"
                    If DocName = 3 Then SqlString += "CredAcc as DebitCredAcc,"
                    SqlString += " AccountCurr,DocAmount,ExchangePrice
                                         BaseAmount,BaseCurrAmount,DocCurrency,A.AccType
                              From  [OrdersAppJournal] J
                              Left Join FinancialAccounts A on J.CredAcc=A.AccNo
                              Where 1=1 "
                    If DocName = 4 Then SqlString += " and CredAcc='0' "
                    If DocName = 3 Then SqlString += " and DebitAcc='0' "
                    SqlString += " and DocName= " & DocName & " and DocID= '" & DocCode & "' and CheckNo=0 "
                    SqlString += " Order by A.AccType "
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    _SecondTable = Sql.SQLDS.Tables(0)
                Catch ex As Exception

                End Try


        End Select

        Return (_FirstTable, _SecondTable)
    End Function

    Public Function GetDocChecksTable(DocName As Integer, DocID As Integer) As DataTable
        Dim _ChecksTable As New DataTable
        Select Case DocName
            Case 3, 4
                Try
                    Dim Sql As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select  CheckCode,CheckInOut,CheckNo,CheckDueDate, CheckBank as CheckCustBank ,CheckBranch as CheckCustBranch,CheckAccountId as CheckCustAccountId,
CheckStatus, CheckAmount as DocAmount   ,CheckCurr as DocCurrency ,CheckBaseAmount as BaseAmount,DocID,AccountBank,TransNoInJournal,DocNoteByAccount
                              From  Checks
                              Where 1=1 "
                    If DocName = 4 Then SqlString += " and CheckInOut='In' "
                    If DocName = 3 Then SqlString += " and CheckInOut='Out' "
                    SqlString += " and DocID= " & DocID
                    SqlString += " Order by CheckID "
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    _ChecksTable = Sql.SQLDS.Tables(0)
                Catch ex As Exception

                End Try
        End Select
        Return _ChecksTable
    End Function

    Public Function GetExchengPrice(CurrencyID As Integer, DocDate As String) As _
(PurchasePrice As Decimal, SalesPrice As Decimal)
        Dim _PurchasePrice As Decimal
        Dim _SalesPrice As Decimal
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  Select top(1) PurchasePrice,SalesPrice from CurrencyExchangePrice where  CONVERT(char(10), TheDate,126) ='" & DocDate & "' and CurrencyID=" & CurrencyID & " Order by id desc"

            sql.SqlTrueAccountingRunQuery(SqlString)


            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PurchasePrice"))) Then _PurchasePrice = CDec(sql.SQLDS.Tables(0).Rows(0).Item("PurchasePrice").ToString)
                If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPrice"))) Then _SalesPrice = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SalesPrice").ToString)
            Else
                Dim sql2 As New SQLControl
                Dim SqlString2 As String
                SqlString2 = "  Select top(1) PurchasePrice,SalesPrice from CurrencyExchangePrice where CurrencyID=" & CurrencyID & " Order by id desc"
                sql2.SqlTrueAccountingRunQuery(SqlString2)
                If Not (IsDBNull(sql2.SQLDS.Tables(0).Rows(0).Item("PurchasePrice"))) Then _PurchasePrice = CDec(sql2.SQLDS.Tables(0).Rows(0).Item("PurchasePrice").ToString)
                If Not (IsDBNull(sql2.SQLDS.Tables(0).Rows(0).Item("SalesPrice"))) Then _SalesPrice = CDec(sql2.SQLDS.Tables(0).Rows(0).Item("SalesPrice").ToString)
            End If
        Catch ex As Exception
            _PurchasePrice = 1
            _SalesPrice = 1
        End Try



        Return (_PurchasePrice, _SalesPrice)
    End Function
    Public Function DGVSumColumn(ByRef DGV As DataGridView, ByVal Col As Object) As Object
        Dim isum As Double = 0
        For Each Row As DataGridViewRow In DGV.Rows
            If String.IsNullOrEmpty(Row.Cells(Col).Value.ToString) Then
                isum += 0
            Else
                isum += Row.Cells(Col).Value
            End If
        Next
        Return isum
    End Function

    Public Function DeleteDoc(DocName As Integer, DocID As Integer, DocCode As String, SoftDelete As Boolean) As Boolean
        Dim _Deleted As Boolean
        Dim _AllowDelete As Boolean
        Dim _DocStatus As Integer
        Dim SqlString As String
        Dim sql As New SQLControl

        Select Case DocName
            Case 11, 10
                sql.SqlTrueAccountingRunQuery(" select top(1) DocStatus  from OrdersJournal where DocName=" & DocName & " and DocID=" & DocID)
                _DocStatus = sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")
            Case Else
                sql.SqlTrueAccountingRunQuery(" select top(1) DocStatus  from Journal where DocName=" & DocName & " and DocID=" & DocID)
                _DocStatus = sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")
        End Select

        If _DocStatus = 3 Or _DocStatus = 4 Then
            SqlString = " Select SettingValue from [dbo].[Settings] where SettingName='AllowCancelPostedDocuments' "
            sql.SqlTrueAccountingRunQuery(SqlString)
            _AllowDelete = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If _AllowDelete = False Then
                MsgBoxShowError(" السند مرحل ! لا يمكن حذف السند ")
                _Deleted = False
                Return _Deleted
            End If
        End If

        Select Case DocName
            Case 11, 10
                Try
                    If XtraMessageBox.Show("هل تريد الغاء السند ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        SqlString = " Update [dbo].[OrdersJournal] Set [DocStatus]=0 where DocName= " & DocName & " and DocID =" & DocID & " and DocCode='" & DocCode & "'"
                        sql.SqlTrueAccountingRunQuery(SqlString)
                        _Deleted = True
                    End If
                Catch ex As Exception
                    _Deleted = False
                End Try
            Case Else
                If SoftDelete Then
                    Try
                        If XtraMessageBox.Show("هل تريد الغاء السند ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                            SqlString = " Update [Journal] Set [DocStatus]=0 where DocName= " & DocName & " and DocID =" & DocID & " and DocCode='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            SqlString = " Update [Checks] Set CheckStatus=0  where DocName= " & DocName & " and DocID =" & DocID & " and DocCode='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            SqlString = " Delete from [PosVouchers]   where DocName= " & DocName & " and [VoucherID] =" & DocID & " and [VoucherCode]='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            PosAddLOG(DocCode, "Delete Voucher From Accounting ")
                            'SqlString = " Delete from [ItemsSerialTrans] Where DocName=" & DocName & " An"
                            'Sql.SqlTrueAccountingRunQuery(SqlString)
                            _Deleted = True
                        End If
                    Catch ex As Exception
                        _Deleted = False
                    End Try
                Else
                    Try
                        If XtraMessageBox.Show("هل تريد حذف السند ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                            SqlString = " Delete From [Journal]  where DocName= " & DocName & " and DocID =" & DocID & " and DocCode='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            SqlString = " Delet From [Checks]  where DocName= " & DocName & " and DocID =" & DocID & " and DocCode='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            SqlString = " Delete from [PosVouchers]   where DocName= " & DocName & " and [VoucherID] =" & DocID & " and [VoucherCode]='" & DocCode & "'"
                            sql.SqlTrueAccountingRunQuery(SqlString)
                            PosAddLOG(DocCode, "Delete Voucher From Accounting ")
                            Dim seqManager As New SequenceManager()
                            seqManager.ResetSingleSequence(DocName)
                            _Deleted = True
                        End If
                    Catch ex As Exception
                        _Deleted = False
                    End Try
                End If

        End Select

        If _Deleted = True Then
            Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            CreateDocLog("Document", DocCode, DocName, DocID, "Delete", "Delete Document", _LogDateTime)
            MsgBoxShowSuccess(" تم الغاء السند بنجاح ")
            MoneyTrans.GenerateMessage(DocName, "WhenDelete", DateTime.Parse(_LogDateTime).ToString("yyyy-MM-dd HH:mm"), "", "", "", "", DocID)

        End If

        Return _Deleted
    End Function

    Public Function GetBankAccounts(Currency As Integer) As DataTable
        Dim _BankAccounts As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select ID,BankName from BanksAccounts"
            If Currency <> -1 Then SqlString += " where Currency=" & Currency
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BankAccounts = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _BankAccounts

    End Function
    Public Function GetBankAccountsData(AccID As Integer) As _
        (_BankName As String, _BankID As String, _BranchID As String, _BankAccID As String, _Currency As String, _BankDepositAccount As String, _BankOutChequeAccount As String, _BankCheqsTahselAccount As String)
        Dim BankName As String = "0"
        Dim BankID As String = "0"
        Dim BranchID As String = "0"
        Dim BankAccID As String = "0"
        Dim Currency As String = "0"
        Dim BankDepositAccount As String = "0"
        Dim BankOutChequeAccount As String = "0"
        Dim BankCheqsTahselAccount As String = "0"

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select [BankName] ,[BankDepositAccount],[BankOutChequeAccount]
      ,[BankCheqsTahselAccount],[UserID],[BankID]
      ,[BranchID],[BankAccID],[Currency] from BanksAccounts where ID=" & AccID

            sql.SqlTrueAccountingRunQuery(SqlString)

            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankName"))) Then BankName = (sql.SQLDS.Tables(0).Rows(0).Item("BankName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankID"))) Then BankID = (sql.SQLDS.Tables(0).Rows(0).Item("BankID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BranchID"))) Then BranchID = (sql.SQLDS.Tables(0).Rows(0).Item("BranchID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankAccID"))) Then BankAccID = (sql.SQLDS.Tables(0).Rows(0).Item("BankAccID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Currency"))) Then Currency = (sql.SQLDS.Tables(0).Rows(0).Item("Currency").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankDepositAccount"))) Then BankDepositAccount = (sql.SQLDS.Tables(0).Rows(0).Item("BankDepositAccount").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankOutChequeAccount"))) Then BankOutChequeAccount = (sql.SQLDS.Tables(0).Rows(0).Item("BankOutChequeAccount").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankCheqsTahselAccount"))) Then BankCheqsTahselAccount = (sql.SQLDS.Tables(0).Rows(0).Item("BankCheqsTahselAccount").ToString)

        Catch ex As Exception
            BankName = "0"
            BankID = "0"
            BranchID = "0"
            BankAccID = "0"
            Currency = "0"
            BankDepositAccount = "0"
            BankOutChequeAccount = "0"
            BankCheqsTahselAccount = "0"
        End Try
        Return (BankName, BankID, BranchID, BankAccID, Currency, BankDepositAccount, BankOutChequeAccount, BankCheqsTahselAccount)
    End Function

    Public Function GetCheqsTrans(InOut As String) As DataTable
        Dim TransTypes As New DataTable
        Dim SqlString As String
        Dim sql As New SQLControl
        Try
            SqlString = " SELECT [TransID],[TransTypeEng],[TransTypeAr],[TransInOut]
                          FROM [CheksTransTypes] 
                          Where TransInOut='" & InOut & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            TransTypes = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return TransTypes

    End Function
    Public Function GetCheques(InOut As String, TransID As Integer, Currency As Integer, AccountBank As Integer) As DataTable
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim Cheques As New DataTable
        SqlString = " SELECT  [CheckID],[CheckInOut],[CheckNo]
                      ,[CheckDueDate],[CheckBank],Ba.[BankName] as CheckBankName,[CheckBranch],[CheckAccountId],B.BankName as BankAccountName
                      ,A.[CheckStatus] as CheckStatusNo,S.CheckStatus,[CheckAmount],[CheckCurr],[CheckBaseAmount]
                      ,[DocCode],[CheckCode],[DocID],[DocName],[AccountBank],S.CheckStatus as StatusName,
                      C.Code as CurrCode,RelatedAccount,F.AccName As RelatedAccountName,Referance,R.RefName,R.RefAccID,RelatedReferance, RR.RefName As  RelatedReferanceName,DocNoteByAccount,BB.BranchName
                     FROM [Checks] A
					  left join ChecksStatus S on A.CheckStatus=S.ID
					  left join Currency C on C.CurrID=A.CheckCurr 
                      left join Referencess R on R.RefNo=A.Referance
                      left join Referencess RR on RR.RefNo=A.RelatedReferance  
                      left join BanksAccounts B on B.ID=A.[AccountBank]
                      left join [dbo].[Bank] Ba on Ba.[ID]=A.CheckBank
                      left join BankBranche BB on BB.ID=A.CheckBranch
                      left join financialaccounts F on F.AccNo=A.RelatedAccount
        Where A.CheckStatus <> 0 "
        If InOut <> "-1" Then SqlString += " And CheckInOut ='" & InOut & "'"
        If Currency <> -1 Then SqlString += " And CheckCurr=" & CStr(Currency)
        If TransID <> 1 And TransID <> 8 Then If AccountBank <> -1 Then SqlString += " And AccountBank=" & AccountBank & "  "
        'If AccountBank = -1 And TransID = 1 Then Return Cheques
        Select Case TransID
            Case -1
                SqlString += " And 1=1 " 'استعلام الشيكات
            Case 0
                SqlString += " And 1<>1 " '
            Case 1 'ايداع الشيكات
                SqlString += " And ( A.CheckStatus=3 OR  A.CheckStatus=5 OR  A.CheckStatus=6 )" 'وارد او راجع او برسم التحصيل
            Case 2 ' ارجاع من البنك
                SqlString += " And ( A.CheckStatus=6 OR  A.CheckStatus=4 ) " ' برسم التحصيل او مودع
            Case 3 ' ارجاع للمرجع
                SqlString += " And (A.CheckStatus=5 OR  A.CheckStatus=3 )" 'وارد او راجع
            Case 4 'تجيير
                SqlString += " And  (A.CheckStatus=3 OR  A.CheckStatus=5) "
            Case 5 'سحب الشيك نقدا
                SqlString += " And ( A.CheckStatus=3 OR  A.CheckStatus=5  )" 'وارد او راجع 
            Case 9 'ارجاع شيك مجير
                SqlString += " And  A.CheckStatus=9   "
            Case 6  ' اخراج شيك صادر من البنك
                SqlString += " And  (A.CheckStatus=1  Or A.CheckStatus=10)  "
            Case 7 ' ارجاع شيك صادر من البنك الى المورد
                SqlString += " And  A.CheckStatus=2   "
            Case 8 ' استرجاع شيك من مورد
                SqlString += " And   (A.CheckStatus=1  Or A.CheckStatus=10)    "
        End Select
        SqlString += " Order by CheckDueDate "
        'SqlString += " Order By CheckDueDate "

        Sql.SqlTrueAccountingRunQuery(SqlString)
        Cheques = Sql.SQLDS.Tables(0)
        Return Cheques
    End Function
    Public Function GetChecksStatus(InOut As String) As DataTable
        Try
            Dim sqlString As String
            Dim Sql As New SQLControl
            sqlString = " Select [CheckStatus],[CheckInOutType],[ID] FROM [ChecksStatus] "
            If InOut <> "-1" Then sqlString += " Where [CheckInOutType]='" & InOut & "'"
            Sql.SqlTrueTimeRunQuery(sqlString)
            Return Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetChequeData(_ChequeID As Integer) As (ChequeNo As String, ChequeDueDate As String, ChequeStatusName As String,
        ChequeAmount As Decimal, CheckInOut As String, CheckStatusNo As Integer, RelatedReferance As Integer, Referance As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [CheckID],[CheckInOut],[CheckNo]
                      ,[CheckDueDate],[CheckBank],Ba.[BankName] as CheckBankName,[CheckBranch],[CheckAccountId],B.BankName as BankAccountName
                      ,A.[CheckStatus] as CheckStatusNo,S.CheckStatus As CheckStatusName,[CheckAmount],[CheckCurr],[CheckBaseAmount]
                      ,[DocCode],[CheckCode],[DocID],[DocName],[AccountBank],S.CheckStatus as StatusName,C.Code as CurrCode,RelatedAccount,Referance,R.RefName,R.RefAccID,RelatedReferance, RR.RefName As  RelatedReferanceName,DocNoteByAccount
                     FROM [Checks] A
					  left join ChecksStatus S on A.CheckStatus=S.ID
					  left join Currency C on C.CurrID=A.CheckCurr 
                      left join Referencess R on R.RefNo=A.Referance
                      left join Referencess RR on RR.RefNo=A.RelatedReferance  
                      left join BanksAccounts B on B.ID=A.[AccountBank]
                      left join [dbo].[Bank] Ba on Ba.[BankNo]=A.CheckBank where [CheckID]=" & _ChequeID
        sql.SqlTrueAccountingRunQuery(sqlstring)

        With sql.SQLDS.Tables(0).Rows(0)
            Return (.Item("CheckNo"),
        .Item("CheckDueDate"),
        .Item("CheckStatusName"),
        .Item("CheckAmount"),
        .Item("CheckInOut"),
        IIf(IsDBNull(.Item("CheckStatusNo")), 0, .Item("CheckStatusNo")),
        IIf(IsDBNull(.Item("RelatedReferance")), 0, .Item("RelatedReferance")),
        IIf(IsDBNull(.Item("Referance")), 0, .Item("Referance")))
        End With
    End Function
    Public Function CreateRandomCode() As String
        Dim sql As New SQLControl
        Dim _DocName As String
        Try
            sql.SqlTrueAccountingRunQuery("select Right(NEWID(),15) as DocID ")
            _DocName = sql.SQLDS.Tables(0).Rows(0).Item("DocID")
        Catch ex As Exception
            _DocName = RandomString()
        End Try
        Return _DocName
    End Function
    Public Function RandomString() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Public Function GetPriceCategory() As DataTable
        Dim PriceCategory As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select PriceID,PriceName From PriceCategories "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            PriceCategory = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return PriceCategory
        End Try
        Return PriceCategory
    End Function
    Public Function GetItemsPriceCategories(ItemNo As String) As DataTable
        Dim ItemsPriceCategories As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select IsNull(BB.ID,0) as ID,  PP.PriceID,PP.PriceName,IsNull(ItemPrice,0) as ItemPrice  from
                            (select PriceID,PriceName   from PriceCategories ) PP
                            left Join
                            (Select ID, ItemNo,ItemPrice,PriceCategoryID  from   ItemsPriceCategories  where ItemNo='" & ItemNo & "') BB
                            on PP.PriceID=BB.PriceCategoryID"

            Sql.SqlTrueAccountingRunQuery(SqlString)
            ItemsPriceCategories = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return ItemsPriceCategories
        End Try
        Return ItemsPriceCategories
    End Function

    Public Function GetItemPrice(ItemNo As String, unit_id As Integer, ReferanceID As String) As Decimal
        Dim ItemPrice As Decimal = 0
        Dim ItemPriceFromCategories As Decimal = 0
        Dim Price As Decimal
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " Select [Price1] as ItemPrice
                                            From Items_units
                                            Where item_id='" & ItemNo & "' and unit_id=" & unit_id
            sql.SqlTrueAccountingRunQuery(SqlString)
            ItemPrice = sql.SQLDS.Tables(0).Rows(0).Item("ItemPrice")
        Catch ex As Exception
            ItemPrice = 0
        End Try



        If ReferanceID <> "0" Then
            Try
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = "   Select ItemPrice  From ItemsPriceCategories I
                                Left join Referencess R on R.PriceCategory=I.PriceCategoryID 
                                Where ItemNo='" & ItemNo & "' and R.RefNo=" & ReferanceID
                Sql.SqlTrueAccountingRunQuery(SqlString)
                ItemPriceFromCategories = Sql.SQLDS.Tables(0).Rows(0).Item("ItemPrice")
            Catch ex As Exception
                ItemPriceFromCategories = 0
            End Try
        End If

        If ItemPriceFromCategories = 0 Then
            Price = ItemPrice
        Else
            Price = ItemPriceFromCategories
        End If

        Return Price
    End Function

    Public Function GetUsers(All As Boolean) As DataTable
        Dim _Users As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select EmployeeID,EmployeeName,IsNull(AccessType,'User') as AccessType  from [EmployeesData] "
            If All = False Then SqlString += " where AccessOnLogIn =1 "
            Sql.SqlTrueTimeRunQuery(SqlString)
            _Users = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Users
        End Try
        Return _Users
    End Function

    Public Function GetDocStatus(WithAll As Boolean) As DataTable
        Dim _DocStatus As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select ID,DocStatus from [dbo].[DocStatus] where ID<>-1 "
            If WithAll = True Then SqlString += " union select -1 as ID,N'الكل' as DocStatus order by ID "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _DocStatus = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _DocStatus
        End Try
        Return _DocStatus
    End Function
    Public Function GetDocPaidStatus(withAll As Boolean) As DataTable
        '  Dim _table As New DataTable
        Dim Table1 As New DataTable()
        Table1.Columns.Add("id", GetType(System.Int32))
        Table1.Columns.Add("name", GetType(System.String))
        If withAll = True Then Table1.Rows.Add("-1", "الكل")
        Table1.Rows.Add("0", "غير مسدد")
        Table1.Rows.Add("1", "مسدد جزئي")
        Table1.Rows.Add("2", "مسدد")
        Return Table1
    End Function
    Public Function GetDocStatusForInputDocument() As DataTable
        Dim _DocStatus As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select ID,DocStatus from [dbo].[DocStatus]  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _DocStatus = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _DocStatus
        End Try
        Return _DocStatus
    End Function

    'Public Function GetBaseAmountForAccount(_DocCurrency As Integer, _AccountCurr As Integer, _DocAmount As Decimal, _DocDate As Date) As Decimal
    '    Dim _DefaultCurr As Integer = GetDefaultCurrency()
    '    Dim _BaseAmount As Decimal
    '    If _AccountCurr = _DocCurrency Then
    '        _BaseAmount = _DocAmount
    '    ElseIf _AccountCurr = _DefaultCurr And _DocCurrency = _DefaultCurr Then
    '        _BaseAmount = _DocAmount / GetExchengPrice(_AccountCurr, Format(_DocDate, "yyyy-MM-dd")).PurchasePrice
    '    Else
    '        _BaseAmount = (_DocAmount * ExchangePrice.EditValue) / GetExchengPrice(_AccountCurr, Format(_DocDate, "yyyy-MM-dd")).PurchasePrice
    '    End If
    '    Return _BaseAmount
    'End Function

    Public Function GetSessonsTable(With_All As Boolean) As DataTable
        Dim _table As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select *  from [JardSessions] "
            Sql.SqlTrueTimeRunQuery(SqlString)
            _table = Sql.SQLDS.Tables(0)
            If With_All = True Then
                Dim R As DataRow = _table.NewRow
                R("ID") = -1
                R("SessionDetails") = "الكل"
                _table.Rows.Add(R)
            End If
        Catch ex As Exception
            Return _table
        End Try
        Return _table
    End Function
    Public Function GetCompanyData() As _
    (CompanyName As String, CompanyAddress As String, CompanyPhone As String, CompanyMobile As String, CompanyVAT As String, CompanyNameForWhattsUp As String)
        Dim _CompanyName As String = ""
        Dim _CompanyAddress As String = ""
        Dim _CompanyPhone As String = ""
        Dim _CompanyMobile As String = ""
        Dim _CompanyVAT As String = ""
        Dim _CompanyNameForWhattsUp As String = ""


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "SELECT CompanyName, CompanyAddress, CompanyPhone, CompanyMobile, 
                                CompanyFax, CompanyEmail, CompanyWebSite, CompanyFaceBook,
                                SoftwareID, TextRegistrationCode,CompanyVAT,CompanyNameForWhattsUp
                         FROM   CompanyData"

            sql.SqlTrueTimeRunQuery(SqlString)

            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyName"))) Then _CompanyName = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress"))) Then _CompanyAddress = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone"))) Then _CompanyPhone = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyMobile"))) Then _CompanyMobile = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyMobile").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyVAT"))) Then _CompanyVAT = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyVAT").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CompanyNameForWhattsUp"))) Then _CompanyNameForWhattsUp = (sql.SQLDS.Tables(0).Rows(0).Item("CompanyNameForWhattsUp").ToString) Else _CompanyNameForWhattsUp = _CompanyName
            If _CompanyNameForWhattsUp = "" Then _CompanyNameForWhattsUp = _CompanyName
        Catch ex As Exception
            _CompanyName = ""
            _CompanyAddress = ""
            _CompanyPhone = ""
            _CompanyMobile = ""
            _CompanyVAT = ""
            _CompanyNameForWhattsUp = ""
        End Try
        Return (_CompanyName, _CompanyAddress, _CompanyPhone, _CompanyMobile, _CompanyVAT, _CompanyNameForWhattsUp)
    End Function
    Public Function GetCompanyImage() As Image
        Dim _image As Image
        _image = Nothing
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            _image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
            Return _image
        Catch ex As Exception
            Return _image
        End Try
    End Function

    Public Function CheckIfFoundInTrueTime(RefNo As Integer) As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery("Select SalaryAccountNo from EmployeesData where SalaryAccountNo = " & RefNo)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GetBaseAmount(_AccountCurr As Integer, _DocAmount As Decimal, _DocCurrency As Integer, _DocDate As DateTime, _ExchangePrice As Decimal) As Decimal
        Dim _BaseAmount As Decimal
        Dim _DefaultCurr As Integer = GetDefaultCurrency()
        If _AccountCurr = _DocCurrency Then
            _BaseAmount = _DocAmount
        ElseIf _AccountCurr = _DefaultCurr And _DocCurrency = _DefaultCurr Then
            _BaseAmount = _DocAmount / GetExchengPrice(_AccountCurr, Format(_DocDate, "yyyy-MM-dd")).PurchasePrice
        Else
            _BaseAmount = (_DocAmount * _ExchangePrice) / GetExchengPrice(_AccountCurr, Format(_DocDate, "yyyy-MM-dd")).PurchasePrice
        End If
        Return _BaseAmount
    End Function

    Public Function GetRefCities() As DataTable
        Dim _RefCities As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT [ID],[CITY]  FROM [dbo].[RefCities]")
            _RefCities = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _RefCities
            MsgBox(ex.ToString)
        End Try
        Return _RefCities
    End Function
    Public Function GetRefSorts(WithAll As Boolean) As DataTable
        Dim _RefSorts As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "SELECT [ID],[SortName]  FROM [dbo].[RefSorts]"
            If WithAll = True Then SqlString += " union select -1 as ID, N'الكل' as SortName "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _RefSorts = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return _RefSorts
        End Try
        Return _RefSorts
    End Function
    Public Function GetItemsCategories() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT CategoryID,CategoryName  FROM [dbo].[ItemsCategories]")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return _Table
        End Try
        Return _Table
    End Function
    Public Function GetItemsTradeMark() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT [TradeMarkID],[TradeMarkName]  FROM [dbo].[ItemsTradeMark]")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return _Table
        End Try
        Return _Table
    End Function
    Public Function GetReferanceMax() As Integer
        Dim _No As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select max(RefNo) as NO from [Referencess]")
            _No = Sql.SQLDS.Tables(0).Rows(0).Item("NO")
        Catch ex As Exception
            _No = 0
        End Try
        Return _No
    End Function
    Public Function GetItemsGroups(With_All As Boolean) As DataTable
        'Dim _Table As New DataTable
        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" select GroupID,GroupName,AvailableOnPOS,GroupImage 
        '                                    from [ItemsGroups]  ")
        '    _Table = Sql.SQLDS.Tables(0)
        'Catch ex As Exception
        '    Return _Table
        'End Try
        'Return _Table

        Dim _Groups As New DataTable
        Try
            Dim _Table As New DataTable
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select GroupID,GroupName,AvailableOnPOS,GroupImage from [ItemsGroups]"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = sql.SQLDS.Tables(0)
            If With_All = True Then
                Dim R As DataRow = _Table.NewRow
                R("GroupID") = -1
                R("GroupName") = "الكل"
                _Table.Rows.Add(R)
            End If
            _Groups = _Table
        Catch ex As Exception
        End Try
        Return _Groups



    End Function

    Public Function GetItemsSubGroupsForMatjar() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" select [ID],[SubGroupName],[MainGroup],[ShowInMatjar] 
                                            from [dbo].[ItemsSubGroup]  ")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
        Return _Table
    End Function
    Public Function GetItemsColors() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select [ID],[ColorName] from [dbo].[ItemsColors]")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
        Return _Table
    End Function
    Public Function GetItemsMeasures() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select [ID],[MeasureName] from [dbo].[ItemsMeasures]")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
        Return _Table
    End Function
    Public Function GetReferanceBalance(ReferanceNo As Integer) As Decimal
        Dim _Debit As Decimal
        Dim _Credit As Decimal
        Dim RefData = GetRefranceData(ReferanceNo)
        Dim _RefAccount As String = RefData.RefAccID
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select sum(BaseCurrAmount) as DebitAmount 
                                            From [dbo].[Journal] 
                                            Where DocStatus<>0 And Referance=" & ReferanceNo & " and CredAcc='0' and 
                                            (DebitAcc = '" & _RefAccount & "' OR CredAcc= '" & _RefAccount & "')")
            _Debit = Sql.SQLDS.Tables(0).Rows(0).Item("DebitAmount")
        Catch ex As Exception
            _Debit = 0
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select sum(BaseCurrAmount) as CreditAmount 
                                            From [dbo].[Journal] 
                                            Where DocStatus<>0 And Referance=" & ReferanceNo & " and DebitAcc='0' and 
                                            (DebitAcc = '" & _RefAccount & "' OR CredAcc= '" & _RefAccount & "')")
            _Credit = Sql.SQLDS.Tables(0).Rows(0).Item("CreditAmount")
        Catch ex As Exception
            _Credit = 0
        End Try

        Return Math.Round((_Debit - _Credit) * 2, MidpointRounding.AwayFromZero) / 2
    End Function

    Public Function GetReferanceBalanceBtyDate(ReferanceNo As Integer, _date As Date) As Decimal
        Dim _Debit As Decimal
        Dim _Credit As Decimal
        Dim RefData = GetRefranceData(ReferanceNo)
        Dim _RefAccount As String = RefData.RefAccID
        Dim _StrDate As String = Format(_date, "yyyy-MM-dd")
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select sum(BaseCurrAmount) as DebitAmount 
                                            From [dbo].[Journal] 
                                            Where docdate <='" & _StrDate & "' And DocStatus<>0 And Referance=" & ReferanceNo & " and CredAcc='0' and 
                                            (DebitAcc = '" & _RefAccount & "' OR CredAcc= '" & _RefAccount & "')")
            _Debit = Sql.SQLDS.Tables(0).Rows(0).Item("DebitAmount")
        Catch ex As Exception
            _Debit = 0
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select sum(BaseCurrAmount) as CreditAmount 
                                            From [dbo].[Journal] 
                                            Where docdate <='" & _StrDate & "' And DocStatus<>0 And Referance=" & ReferanceNo & " and DebitAcc='0' and 
                                            (DebitAcc = '" & _RefAccount & "' OR CredAcc= '" & _RefAccount & "')")
            _Credit = Sql.SQLDS.Tables(0).Rows(0).Item("CreditAmount")
        Catch ex As Exception
            _Credit = 0
        End Try

        Return Math.Round((_Debit - _Credit) * 2, MidpointRounding.AwayFromZero) / 2
    End Function

    Public Function GetRefBalances(_FromDate As Date, _ToDate As Date, _RefNo As Integer) As (BegBalance As Decimal, DebitAmount As Decimal, RecieptAmount As Decimal, EndBalance As Decimal)
        Dim BegBalance As Decimal = 0
        Dim DebitAmount As Decimal = 0
        Dim RecieptAmount As Decimal = 0
        Dim EndBalance As Decimal = 0

        Try
            Dim sql As New SQLControl()
            Dim sqlstring As String = "
Declare @FromDate date ; Declare @ToDate date ; Declare @RefNo int
Set @FromDate='" & Format(_FromDate, "yyyy-MM-dd") & "'; Set @ToDate ='" & Format(_ToDate, "yyyy-MM-dd") & "' ; Set @RefNo=" & _RefNo & "
SELECT 
    R.RefNo AS ReferanceNo,
    R.RefName,
    ISNULL(B.BegBalance, 0) AS BegBalance,
    ISNULL(B.EndBalance, 0) AS EndBalance,
    ISNULL(B.DebitAmount, 0) AS DebitAmount,
    ISNULL(B.RecepitAmount, 0) AS RecepitAmount
FROM Referencess R
LEFT JOIN (
    SELECT 
        J.Referance AS RefNo,
        SUM(CASE WHEN J.DocDate < @FromDate AND J.CredAcc = '0' THEN J.BaseCurrAmount
                 WHEN J.DocDate < @FromDate AND J.DebitAcc = '0' THEN -J.BaseCurrAmount ELSE 0 END) AS BegBalance,
        SUM(CASE WHEN J.DocDate <= @ToDate AND J.CredAcc = '0' THEN J.BaseCurrAmount
                 WHEN J.DocDate <= @ToDate AND J.DebitAcc = '0' THEN -J.BaseCurrAmount ELSE 0 END) AS EndBalance,
        SUM(CASE WHEN J.DocDate BETWEEN @FromDate AND @ToDate AND J.CredAcc = '0' THEN J.BaseCurrAmount ELSE 0 END) AS DebitAmount,
        SUM(CASE WHEN J.DocDate BETWEEN @FromDate AND @ToDate AND J.DebitAcc = '0' THEN J.BaseCurrAmount ELSE 0 END) AS RecepitAmount
    FROM journal J
    INNER JOIN Referencess R2 ON R2.RefNo = J.Referance
    WHERE R2.RefNo = @RefNo
      AND J.DocStatus <> 0
      AND (J.DebitAcc = R2.RefAccID OR J.CredAcc = R2.RefAccID)
    GROUP BY J.Referance
) B ON R.RefNo = B.RefNo
WHERE R.RefNo = @RefNo;
"

            sql.SqlTrueAccountingRunQuery(sqlstring)

            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim row = sql.SQLDS.Tables(0).Rows(0)
                BegBalance = Convert.ToDecimal(row("BegBalance"))
                DebitAmount = Convert.ToDecimal(row("DebitAmount"))
                RecieptAmount = Convert.ToDecimal(row("RecepitAmount"))
                EndBalance = Convert.ToDecimal(row("EndBalance"))
            End If

        Catch ex As Exception
            ' ✅ Log error or handle it properly
            Console.WriteLine("Error in GetRefBalances: " & ex.Message)
        End Try

        Return (BegBalance, DebitAmount, RecieptAmount, EndBalance)
    End Function


    '    Public Function GetRefBalances(_FromDate As Date, _ToDate As Date, _RefNo As Integer) As _
    '            (_BegBalance As Decimal, _DebitAmount As Decimal, _RecieptAmount As Decimal, _EndBalance As Decimal)
    '        Dim BegBalance As Decimal = 0, DebitAmount As Decimal = 0, RecieptAmount As Decimal = 0, EndBalance As Decimal = 0
    '        Dim sql As New SQLControl
    '        Dim sqlstring As String
    '        sqlstring = "  Declare @FromDate date ; Declare @ToDate date ; Declare @RefNo int
    'Set @FromDate='" & Format(_FromDate, "yyyy-MM-dd") & "'; Set @ToDate ='" & Format(_ToDate, "yyyy-MM-dd") & "' ; Set @RefNo=" & _RefNo & "
    'select A.ReferanceNo,A.RefName,B.EndBalance,IsNull(C.BegBalance,0) As BegBalance ,D.DebitAmount,E.RecepitAmount  from 
    '(
    'select RefNo as ReferanceNo,RefName  from Referencess where RefNo=@RefNo 
    ') A
    'left join 
    '(
    'SELECT J.Referance AS RefNo,
    '	(CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END)) -CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) ) as EndBalance
    '	FROM journal J
    '	LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '	WHERE R.RefNo=@RefNo and J.DocDate <=@ToDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '	GROUP BY Referance
    ') B
    'on A.ReferanceNo=B.RefNo
    'left join 
    '(
    'SELECT J.Referance AS RefNo,
    '	(CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END)) -CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) ) as BegBalance
    '	FROM journal J
    '	LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '	WHERE R.RefNo=@RefNo and J.DocDate <@FromDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '	GROUP BY Referance
    ') C
    'on A.ReferanceNo=C.RefNo
    'left Join
    '(
    'SELECT J.Referance AS RefNo,
    '	(CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END))  ) as DebitAmount
    '	FROM journal J
    '	LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '	WHERE R.RefNo=@RefNo And  J.DocDate between @FromDate and @ToDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '	GROUP BY Referance
    ') D
    'on A.ReferanceNo=D.RefNo
    'left Join
    '(
    'SELECT J.Referance AS RefNo,
    '	(CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END))  ) as RecepitAmount
    '	FROM journal J
    '	LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '	WHERE R.RefNo=@RefNo And  J.DocDate between @FromDate and @ToDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '	GROUP BY Referance
    ') E
    'on A.ReferanceNo=E.RefNo "
    '        Try
    '            sql.SqlTrueAccountingRunQuery(sqlstring)
    '            BegBalance = sql.SQLDS.Tables(0).Rows(0).Item("BegBalance")
    '            DebitAmount = sql.SQLDS.Tables(0).Rows(0).Item("DebitAmount")
    '            RecieptAmount = sql.SQLDS.Tables(0).Rows(0).Item("RecepitAmount")
    '            EndBalance = sql.SQLDS.Tables(0).Rows(0).Item("EndBalance")
    '        Catch ex As Exception

    '        End Try

    '        Return (BegBalance, DebitAmount, RecieptAmount, EndBalance)
    '    End Function
    Public Function GetAccountBalance(AccNo As String) As Decimal
        Dim _Debit As Decimal
        Dim _Credit As Decimal

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" select sum(BaseAmount) as DebitAmount 
                                            from Journal 
                                            where DocStatus<>0 and DebitAcc='" & AccNo & "' ")
            _Debit = Sql.SQLDS.Tables(0).Rows(0).Item("DebitAmount")
        Catch ex As Exception
            _Debit = 0
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" select sum(BaseAmount) as CreditAmount 
                                            from Journal 
                                            where DocStatus<>0 and CredAcc='" & AccNo & "'")
            _Credit = Sql.SQLDS.Tables(0).Rows(0).Item("CreditAmount")
        Catch ex As Exception
            _Credit = 0
        End Try

        Return Math.Round((_Debit - _Credit) * 2, MidpointRounding.AwayFromZero) / 2
    End Function
    Public Function GetAccountBalanceWithPeriod(AccNo As String, dateFrom As Date, dateTo As Date) As Decimal
        Dim _Debit As Decimal
        Dim _Credit As Decimal
        Dim _StrDateFrom As String = Format(dateFrom, "yyyy-MM-dd")
        Dim _StrDateTo As String = Format(dateTo, "yyyy-MM-dd")
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" select sum(BaseAmount) as DebitAmount 
                                            from Journal 
                                            where DocStatus<>0 and DebitAcc='" & AccNo & "' and DocDate between '" & _StrDateFrom & "' and '" & _StrDateTo & "'")
            _Debit = Sql.SQLDS.Tables(0).Rows(0).Item("DebitAmount")
        Catch ex As Exception
            _Debit = 0
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" select sum(BaseAmount) as CreditAmount 
                                            from Journal 
                                            where DocStatus<>0 and CredAcc='" & AccNo & "' and DocDate between '" & _StrDateFrom & "' and '" & _StrDateTo & "'")
            _Credit = Sql.SQLDS.Tables(0).Rows(0).Item("CreditAmount")
        Catch ex As Exception
            _Credit = 0
        End Try

        Return Math.Round((_Debit - _Credit) * 2, MidpointRounding.AwayFromZero) / 2
    End Function



    Public Function GetFinancialAccountForRefType(_AccountType As Integer) As String
        Dim _FinancialAccount As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select DefaultAccount from [dbo].[ReferencesTypes]
                                            where [TypeID]=" & _AccountType)
            _FinancialAccount = Sql.SQLDS.Tables(0).Rows(0).Item("DefaultAccount")
        Catch ex As Exception
            _FinancialAccount = "0"
        End Try
        Return _FinancialAccount
    End Function

    Public Function ActiveNotActive() As DataTable
        Dim table As New DataTable
        table.Columns.Add("StatusValue", GetType(Integer))
        table.Columns.Add("StatusName", GetType(String))
        table.Columns.Add("StatusNameE", GetType(String))
        table.Rows.Add(2, "الكل", "All")
        table.Rows.Add(1, "فعال", "Active")
        table.Rows.Add(0, "غير فعال", "NotActive")
        Return table
    End Function


    Public Function GetDocDataByDocCode(DocCode As String, DataName As String, Optional ModifiedDateTime As String = "") As _
    (DocDate As Date, DocStatus As Integer, DebitAcc As String, CredAcc As String,
    DocCurrency As Integer, DocAmount As Decimal, ExchangePrice As Decimal,
    BaseAmount As Decimal, DocSort As Integer, Referance As Integer, DocManualNo As String,
    InputUser As String, DocNotes As String, ReferanceName As String, DocMultiCurrency As Boolean,
    DocCode As String, DocStatusName As String, DeviceName As String, RefAccID As String, OrderStatus As Integer,
    DeliverDate As DateTime, DocID As Integer, DocName As Integer, LastDocCode As String, LastDataName As String,
    Account As String, AccountName As String, DocCurrencyName As String, SalesPerson As Integer, OtherAccountName As String,
    InputDateTime As String, PaidStatus As Integer, PaidAmount As Decimal, PaidByDocID As Integer,
    PosNo As Integer, ShiftID As Integer, DocID2 As Integer, DocTags As String, SalesPersonName As String, StockCarNo As String, StockDriver As String, TaxDate As Date)
        Dim __DocName As Integer = GetDocNameByDocCode(DocCode, DataName)
        Dim _DocDate As DateTime = CDate("1900-01-01")
        Dim _TaxDate As DateTime = CDate("1900-01-01")
        Dim _DocStatus As Integer = 1
        Dim _DebitAcc As String = "0"
        Dim _CredAcc As String = "0"
        Dim _DocCurrency As Integer = 0
        Dim _DocAmount As Decimal = 0
        Dim _ExchangePrice As Decimal = 0
        Dim _BaseAmount As Decimal = 0
        Dim _DocSort As Integer = 0
        Dim _Referance As Integer = 0
        Dim _DocManualNo As String = String.Empty
        Dim _InputUser As Integer = 0
        Dim _DocNotes As String = String.Empty
        Dim _ReferanceName As String = String.Empty
        Dim _DocMultiCurrency As Boolean = False
        Dim _DocCode As String = String.Empty
        Dim _DocStatusName As String = String.Empty
        Dim _DeviceName As String = String.Empty
        Dim _RefAccID As String = String.Empty
        Dim _OrderStatus As Integer = 0
        Dim _DeliverDate As DateTime = CDate("1900-01-01")
        Dim _DocID As Integer = 0

        Dim _LastDocCode As String = String.Empty
        Dim _LastDataName As String = String.Empty
        Dim _Account As String = String.Empty
        Dim _AccountName As String = String.Empty
        Dim _DocCurrencyName As String = String.Empty
        Dim _SalesPerson As Integer
        Dim _OtherAccountName As String = ""
        Dim _InputDateTime As String = String.Empty
        Dim _PaidStatus As Integer = 0
        Dim _PaidAmount As Decimal = 0
        Dim _PaidByDocID As Integer = 0
        Dim _PosNo As Integer = 0
        Dim _ShiftID As Integer = 0
        Dim _DocID2 As Integer = 0
        Dim _DocTags As String = ""
        Dim _SalesPersonName As String = ""
        Dim _StockCarNo As String = ""
        Dim _StockDriver As String = ""

        Dim sql As New SQLControl
        Dim SqlString As String
        If String.IsNullOrEmpty(DataName) Then DataName = "Journal"


        SqlString = "  Select DISTINCT DocID,DocDate,DocName,DocStatus,
                              DebitAcc,F.AccName as DebitAccName,CredAcc,FF.AccName as CredAccName,
                              DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocSort,
                              Referance,[DocManualNo],InputUser,DocNotes,R.RefName as RefReferanceName,J.[ReferanceName] As ReferanceName,
                              DocMultiCurrency,DocCode,DeviceName,R.RefAccID as RefAccID,OrderStatus,
                              DeliverDate,LastDocCode,LastDataName,IsNull(VoucherDiscount,0) as VoucherDiscount ,C.[Code] as DocCurrencyName,
                              Case when DebitAcc='0' then CredAcc else DebitAcc end as Account ,
                              Case when DebitAcc='0' then FF.AccName else F.AccName end as AccountName,SalesPerson,E.EmployeeName as SalesPersonName,InputDateTime,IsNull(PaidStatus,0) as PaidStatus ,
                              IsNull(PaidAmount,0) as PaidAmount,IsNull(PaidByDocID,0) as PaidByDocID,IsNull(PosNo,0) as PosNo,IsNull(ShiftID,0) as ShiftID,IsNull(DocID2,0) as DocID2,IsNull(DocTags,'') As DocTags,
                              IsNull(StockDriver,'') as StockDriver,IsNull(StockCarNo,'') as StockCarNo, IsNull(TaxDate,'1900-01-01') as TaxDate"
        SqlString += " From  " & DataName
        SqlString += "  J Left Join [dbo].[Referencess] R on J.Referance=R.[RefNo]"
        SqlString += "  left join dbo.FinancialAccounts F on F.AccNo=J.DebitAcc "
        SqlString += "  left Join dbo.FinancialAccounts FF on FF.AccNo=J.CredAcc"
        SqlString += "  left Join dbo.Currency C on C.CurrID=J.DocCurrency"
        SqlString += "  left Join dbo.EmployeesData E on E.EmployeeID=J.SalesPerson"
        SqlString += "  Where   DocCode= '" & DocCode & "'  "
        If __DocName = 4 Or __DocName = 1 Or __DocName = 10 Or __DocName = 12 Or __DocName = 7 Or __DocName = 17 Then SqlString += " and	 CredAcc<>'0' "
        If __DocName = 3 Or __DocName = 2 Or __DocName = 13 Or __DocName = 6 Or __DocName = 18 Then SqlString += " and	 DebitAcc<>'0' "
        If DataName = "JournalBeforeUpdate" Then SqlString += " And  ModifiedDateTime='" & Format(CDate(ModifiedDateTime), "yyyy-MM-dd HH:mm:ss") & "'"

        sql.SqlTrueAccountingRunQuery(SqlString)

        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocDate"))) Then _DocDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocDate").ToString)
            If DataName = "JournalBeforeUpdate" Then
                _DocStatus = -2
            Else
                If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStatus"))) Then _DocStatus = sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")
            End If

            'If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter"))) Then _DocCostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc"))) Then _DebitAcc = sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CredAcc"))) Then _CredAcc = sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency"))) Then _DocCurrency = sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocAmount"))) Then
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")) Then
                    _DocAmount = sql.SQLDS.Tables(0).Rows(0).Item("DocAmount") + sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")
                Else
                    _DocAmount = sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")
                End If
            End If
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice"))) Then _ExchangePrice = sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount"))) Then _BaseAmount = sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocSort"))) Then _DocSort = sql.SQLDS.Tables(0).Rows(0).Item("DocSort")
            If (Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Referance"))) AndAlso (Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("Referance").ToString())) Then
                _Referance = sql.SQLDS.Tables(0).Rows(0).Item("Referance")
            End If
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo"))) Then _DocManualNo = sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("InputUser"))) Then _InputUser = sql.SQLDS.Tables(0).Rows(0).Item("InputUser")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocNotes"))) Then _DocNotes = sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName"))) Then _ReferanceName = sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))) Then _DocMultiCurrency = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCode"))) Then _DocCode = sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DeviceName"))) Then _DeviceName = sql.SQLDS.Tables(0).Rows(0).Item("DeviceName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefAccID"))) Then _RefAccID = CStr(sql.SQLDS.Tables(0).Rows(0).Item("RefAccID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("OrderStatus"))) Then _OrderStatus = sql.SQLDS.Tables(0).Rows(0).Item("OrderStatus")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DeliverDate"))) Then _DeliverDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DeliverDate").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocID"))) Then _DocID = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocName"))) Then __DocName = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode"))) Then _LastDocCode = CStr(sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDataName"))) Then _LastDataName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("LastDataName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Account"))) Then _Account = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Account").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccountName"))) Then _AccountName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AccountName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCurrencyName"))) Then _DocCurrencyName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("DocCurrencyName").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson"))) Then _SalesPerson = CInt(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime"))) Then _InputDateTime = CStr(Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime").ToString), "yyyy-MM-dd HH:mm:ss"))
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaidStatus"))) Then _PaidStatus = CStr(sql.SQLDS.Tables(0).Rows(0).Item("PaidStatus").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaidAmount"))) Then _PaidAmount = CStr(sql.SQLDS.Tables(0).Rows(0).Item("PaidAmount").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaidByDocID"))) Then _PaidByDocID = CStr(sql.SQLDS.Tables(0).Rows(0).Item("PaidByDocID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PosNo"))) Then _PosNo = CInt(sql.SQLDS.Tables(0).Rows(0).Item("PosNo").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ShiftID"))) Then _ShiftID = CInt(sql.SQLDS.Tables(0).Rows(0).Item("ShiftID").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocID2"))) Then _DocID2 = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocID2").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocTags"))) Then _DocTags = CStr(sql.SQLDS.Tables(0).Rows(0).Item("DocTags").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPersonName"))) Then _SalesPersonName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalesPersonName").ToString)
            _StockCarNo = CStr(sql.SQLDS.Tables(0).Rows(0).Item("StockCarNo").ToString)
            _StockDriver = CStr(sql.SQLDS.Tables(0).Rows(0).Item("StockDriver").ToString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TaxDate"))) Then _TaxDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("TaxDate").ToString)
        End If

        Return (_DocDate, _DocStatus, _DebitAcc, _CredAcc, _DocCurrency,
                _DocAmount, _ExchangePrice, _BaseAmount, _DocSort, _Referance, _DocManualNo,
                _InputUser, _DocNotes, _ReferanceName, _DocMultiCurrency, _DocCode, _DocStatusName,
                _DeviceName, _RefAccID, _OrderStatus, _DeliverDate, _DocID, __DocName, _LastDocCode,
                _LastDataName, _Account, _AccountName, _DocCurrencyName, _SalesPerson, _OtherAccountName,
                _InputDateTime, _PaidStatus, _PaidAmount, _PaidByDocID, _PosNo, _ShiftID, _DocID2, _DocTags,
                _SalesPersonName, _StockCarNo, _StockDriver, _TaxDate)
    End Function

    'Public Function GetDocDataFromOrders(DocID As String, DocName As Integer) As _
    '(DocDate As Date, DocStatus As Integer, DocCostCenter As Integer, DebitAcc As String,
    'CredAcc As String, DocCurrency As Integer, DocAmount As Decimal, ExchangePrice As Decimal _
    ', BaseAmount As Decimal, DocSort As Integer, Referance As Integer, DocManualNo As String,
    'InputUser As String, DocNotes As String, ReferanceName As String, DocMultiCurrency As Boolean,
    'DocCode As String, DocStatusName As String, DeviceName As String, OrderStatus As Integer,
    'RefAccID As String, DeliverDate As DateTime, LastDocCode As String, LastDataName As String)

    '    Dim sql As New SQLControl
    '    Dim SqlString As String
    '    SqlString = "  Select DISTINCT DocID,DocDate,DocName,DocStatus,DocCostCenter,
    '                          DebitAcc,CredAcc,DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,
    '                          BaseAmount,DocSort,Referance,[DocManualNo],InputUser,DocNotes,R.[RefName] as
    '                          ReferanceName,DocMultiCurrency,DocCode,DeviceName,OrderStatus,R.RefAccID as RefAccID,DeliverDate,LastDocCode,LastDataName"
    '    SqlString += " from  [OrdersJournal] J Left Join [dbo].[Referencess] R on J.Referance=R.[RefNo]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '    sql.SqlTrueAccountingRunQuery(SqlString)
    '    Dim _DocDate As DateTime = CDate("1900-01-01")
    '    Dim _DocStatus As Integer = 1
    '    Dim _DocCostCenter As Integer = 0
    '    Dim _DebitAcc As String = "0"
    '    Dim _CredAcc As String = "0"
    '    Dim _DocCurrency As Integer = 0
    '    Dim _DocAmount As Decimal = 0
    '    Dim _ExchangePrice As Decimal = 0
    '    Dim _BaseAmount As Decimal = 0
    '    Dim _DocSort As Integer = 0
    '    Dim _Referance As Integer = 0
    '    Dim _DocManualNo As String = String.Empty
    '    Dim _InputUser As Integer = 0
    '    Dim _DocNotes As String = String.Empty
    '    Dim _ReferanceName As String = String.Empty
    '    Dim _DocMultiCurrency As Boolean = False
    '    Dim _DocCode As String = String.Empty
    '    Dim _DocStatusName As String = String.Empty
    '    Dim _DeviceName As String = String.Empty
    '    Dim _OrderStatus As String = 0
    '    Dim _RefAccID As String = String.Empty
    '    Dim _DeliverDate As DateTime = CDate("1900-01-01")
    '    Dim _LastDocCode As String = String.Empty
    '    Dim _LastDataName As String = String.Empty

    '    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocDate"))) Then _DocDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocDate").ToString)
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStatus"))) Then _DocStatus = sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter"))) Then _DocCostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc"))) Then _DebitAcc = sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CredAcc"))) Then _CredAcc = sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency"))) Then _DocCurrency = sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocAmount"))) Then _DocAmount = sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice"))) Then _ExchangePrice = sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount"))) Then _BaseAmount = sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocSort"))) Then _DocSort = sql.SQLDS.Tables(0).Rows(0).Item("DocSort")
    '        If (Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Referance")))) And (Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("Referance"))) Then _Referance = sql.SQLDS.Tables(0).Rows(0).Item("Referance")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo"))) Then _DocManualNo = sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("InputUser"))) Then _InputUser = sql.SQLDS.Tables(0).Rows(0).Item("InputUser")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocNotes"))) Then _DocNotes = sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName"))) Then _ReferanceName = sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))) Then _DocMultiCurrency = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DocMultiCurrency"))
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocCode"))) Then _DocCode = sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DeviceName"))) Then _DeviceName = sql.SQLDS.Tables(0).Rows(0).Item("DeviceName")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("OrderStatus"))) Then _OrderStatus = sql.SQLDS.Tables(0).Rows(0).Item("OrderStatus")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefAccID"))) Then _RefAccID = sql.SQLDS.Tables(0).Rows(0).Item("RefAccID")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DeliverDate"))) Then _DeliverDate = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DeliverDate").ToString)
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode"))) Then _LastDocCode = sql.SQLDS.Tables(0).Rows(0).Item("LastDocCode")
    '        If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("LastDataName"))) Then _LastDataName = sql.SQLDS.Tables(0).Rows(0).Item("LastDataName")
    '        '  If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStatusName"))) Then _DocStatusName = sql.SQLDS.Tables(0).Rows(0).Item("DocStatusName")

    '    End If


    '    Return (_DocDate, _DocStatus, _DocCostCenter, _DebitAcc, _CredAcc, _DocCurrency, _DocAmount, _ExchangePrice,
    '        _BaseAmount, _DocSort, _Referance, _DocManualNo, _InputUser, _DocNotes, _ReferanceName, _DocMultiCurrency,
    '        _DocCode, _DocStatusName, _DeviceName, _OrderStatus, _RefAccID, _DeliverDate, _LastDocCode, _LastDataName)
    'End Function

    Public Function GetOrdersStatus() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select [ID],[OrderStatus],[OrderStatusE] from [dbo].[OrdersStatus]")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
        Return _Table
    End Function

    'Public Function OpenDocumentsByDocCode(DocCode As String, DataName As String, OpenFrom As String, Optional ByVal _ModifiedDateTime As String = "") As String
    '    Dim postService As New DocumentsPostService()
    '    Dim stopwatch As New System.Diagnostics.Stopwatch()
    '    If GlobalVariables._UserAccessType = 98 Then
    '        Return False
    '        Exit Function
    '    End If
    '    Dim start_time As DateTime
    '    Dim stop_time As DateTime
    '    Dim elapsed_time As TimeSpan
    '    My.Forms.Main.ItemElapseTime.Caption = (0)
    '    start_time = Now

    '    Dim _DocName As Integer
    '    _DocName = GetDocNameByDocCode(DocCode, DataName)
    '    If _DocName = 0 Then
    '        Return "DocName Cannot Found"
    '        Exit Function
    '    End If
    '    Select Case DataName
    '        Case "InsuranceDoc"
    '            Dim F3 As New InsuranceDoc()
    '            With F3
    '                .DocCode.Text = DocCode
    '                .TextDocNewOld.Text = "Old"
    '                .Show()
    '            End With
    '        Case "OrdersAppJournal"
    '            Select Case _DocName
    '                Case 11 ' طلبية مبيعات
    '                    Dim F3 As New AccStockMove()
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName)
    '                    With F3
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 2 Or .DocStatus.EditValue = 3 Then
    '                            .DocStatus.BackColor = Color.Red
    '                        End If
    '                        .DocID.EditValue = DocData.DocID
    '                        .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .TextReferanceName.EditValue = DocData.ReferanceName
    '                        .DocNotes.Text = DocData.DocNotes
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        Dim _FirstTable As DataTable
    '                        _FirstTable = GetDocDataTableFromAppSystem(DocData.DocName, DocCode).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        .RepositoryUnit.DataSource = GetAllItemsUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouseByDocCode(DocData.DocName, DocCode).WahreHouse
    '                        .AccountForRefranace.EditValue = GetOtherAccountByDocCode(DocData.DocName, DocCode)
    '                        .Text = "طلبية مبيعات موبايل"
    '                        .BarBarConvertToSalesVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarSubItemSetItemPrices.Visibility = XtraBars.BarItemVisibility.Never
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = 1
    '                        .ExchangePrice.Text = 1
    '                        .TextOpenFrom.Text = OpenFrom
    '                        If DocData.DocStatus = 0 Then
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        .DocCode.Text = DocData.DocCode
    '                        .TextEditDocSource.Text = "OrdersAppJournal"
    '                        .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .GridView1.OptionsBehavior.Editable = False
    '                        .DocManualNo.ReadOnly = True
    '                        .DocDate.ReadOnly = True
    '                        .DocCurrency.ReadOnly = True
    '                        .Referance.ReadOnly = True
    '                        .LookCostCenter.ReadOnly = True
    '                        .TextReferanceName.ReadOnly = True
    '                        .StockDebitWhereHouse.ReadOnly = True
    '                        .StockCreditWhereHouse.ReadOnly = True
    '                        .DocNotes.ReadOnly = True
    '                        .AccountForRefranace.ReadOnly = True
    '                        .DateDeliverDate.ReadOnly = True
    '                        .SalesPerson.ReadOnly = True
    '                        .TextVoucherDiscount.ReadOnly = True
    '                        .LayoutCancellAppDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .TextOrderStatus.Text = DocData.OrderStatus
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        .HyperLinkEdit1.Text = "Mobile Application, from Device :" & DocData.DeviceName
    '                        If DocData.OrderStatus = 1 Then .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        If .DocCode.Text = "0" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'If .DocStatus.EditValue = 3 Then
    '                        '    .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'End If
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        ._DocTagsToOpen = DocData.DocTags
    '                        .Show()
    '                    End With
    '                Case 14
    '                    Dim F3 As New AccStockMove()
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName)
    '                    With F3

    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 2 Or .DocStatus.EditValue = 3 Then
    '                            .DocStatus.BackColor = Color.Red
    '                        End If
    '                        .DocID.EditValue = DocData.DocID
    '                        .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .TextReferanceName.EditValue = DocData.ReferanceName
    '                        .DocNotes.Text = DocData.DocNotes
    '                        Dim _FirstTable As DataTable
    '                        _FirstTable = GetDocDataTableFromAppSystem(DocData.DocName, DocCode).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        '.TextVoucherDiscount.EditValue = Convert.ToInt32(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        .RepositoryUnit.DataSource = GetAllItemsUnits()
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouseForAppDocByDocCode(DocData.DocName, DocCode)
    '                        .AccountForRefranace.EditValue = GetOtherAccountByDocCode(DocData.DocName, DocCode)
    '                        .Text = "سند استلام بضاعة"
    '                        .SimpleButton4.Text = "تصدير الى فاتورة مشتريات"
    '                        .BarSubItemConvertDocuments.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarConvertToInputVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarBarConvertToPurchaseVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarConvertToRetSalesVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarSubItemSetItemPrices.Visibility = XtraBars.BarItemVisibility.Never
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = 1
    '                        .ExchangePrice.Text = 1
    '                        .TextOpenFrom.Text = OpenFrom
    '                        If DocData.OrderStatus = 0 And DocData.DocStatus = 1 Then
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocCode.Text = DocData.DocCode
    '                        .TextEditDocSource.Text = "OrdersAppJournal"
    '                        .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        ' .LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .GridView1.OptionsBehavior.Editable = False
    '                        .DocManualNo.ReadOnly = True
    '                        .DocDate.ReadOnly = True
    '                        .DocCurrency.ReadOnly = True
    '                        .Referance.ReadOnly = True
    '                        .LookCostCenter.ReadOnly = True
    '                        .TextReferanceName.ReadOnly = True
    '                        .StockDebitWhereHouse.ReadOnly = True
    '                        .StockCreditWhereHouse.ReadOnly = True
    '                        .DocNotes.ReadOnly = True
    '                        .AccountForRefranace.ReadOnly = True
    '                        .DateDeliverDate.ReadOnly = True
    '                        .SalesPerson.ReadOnly = True
    '                        .TextVoucherDiscount.ReadOnly = True
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .TextOrderStatus.Text = DocData.OrderStatus
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Always

    '                        .BarDocCode.Caption = DocData.DocCode
    '                        .HyperLinkEdit1.Text = ".., from Device :" & DocData.DeviceName
    '                        If DocData.OrderStatus = 1 Then .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        If .DocCode.Text = "0" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'If .DocStatus.EditValue = 3 Then
    '                        '    .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'End If
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        ._DocTagsToOpen = DocData.DocTags
    '                        .Show()
    '                    End With
    '                Case 15
    '                    Dim F3 As New AccStockMove()
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName)
    '                    With F3
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 2 Or .DocStatus.EditValue = 3 Then
    '                            .DocStatus.BackColor = Color.Red
    '                        End If
    '                        .DocID.EditValue = DocData.DocID
    '                        .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .TextReferanceName.EditValue = DocData.ReferanceName
    '                        .DocNotes.Text = DocData.DocNotes
    '                        Dim _FirstTable As DataTable
    '                        _FirstTable = GetDocDataTableFromAppSystem(DocData.DocName, DocCode).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        '.TextVoucherDiscount.EditValue = Convert.ToInt32(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        .RepositoryUnit.DataSource = GetAllItemsUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouseForAppDocByDocCode(DocData.DocName, DocCode)
    '                        .AccountForRefranace.EditValue = GetOtherAccountByDocCode(DocData.DocName, DocCode)
    '                        .Text = "سند تسليم بضاعة"
    '                        .SimpleButton4.Text = "تصدير الى فاتورة مبيعات"
    '                        .BarSubItemConvertDocuments.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarConvertToOutVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarBarConvertToSalesVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarConvertToRetPurchaseVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarSubItemSetItemPrices.Visibility = XtraBars.BarItemVisibility.Never
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = 1
    '                        .ExchangePrice.Text = 1
    '                        .TextOpenFrom.Text = OpenFrom
    '                        If DocData.OrderStatus = 0 And DocData.DocStatus = 1 Then
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .TextEditDocSource.Text = "OrdersAppJournal"
    '                        .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        ' .LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .GridView1.OptionsBehavior.Editable = False
    '                        .DocManualNo.ReadOnly = True
    '                        .DocDate.ReadOnly = True
    '                        .DocCurrency.ReadOnly = True
    '                        .Referance.ReadOnly = True
    '                        .LookCostCenter.ReadOnly = True
    '                        .TextReferanceName.ReadOnly = True
    '                        .StockDebitWhereHouse.ReadOnly = True
    '                        .StockCreditWhereHouse.ReadOnly = True
    '                        .DocNotes.ReadOnly = True
    '                        .AccountForRefranace.ReadOnly = True
    '                        .DateDeliverDate.ReadOnly = True
    '                        .SalesPerson.ReadOnly = True
    '                        .TextVoucherDiscount.ReadOnly = True
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .TextOrderStatus.Text = DocData.OrderStatus
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        .HyperLinkEdit1.Text = ".., from Device :" & DocData.DeviceName
    '                        If DocData.OrderStatus = 1 Then .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        If .DocCode.Text = "0" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'If .DocStatus.EditValue = 3 Then
    '                        '    '.LayoutPostDocument.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        '    .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'End If
    '                        ' .LayoutPostDocument.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'Set the Parent Form of the Child window.
    '                        '.MdiParent = My.Forms.Main
    '                        ' .WindowState = FormWindowState.Normal
    '                        'Display the new form.
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        ._DocTagsToOpen = DocData.DocTags
    '                        .Show()
    '                    End With
    '                Case 16
    '                    Dim F3 As New AccStockMove()
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName)
    '                    With F3
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 2 Or .DocStatus.EditValue = 3 Then
    '                            .DocStatus.BackColor = Color.Red
    '                        End If
    '                        .DocID.EditValue = DocData.DocID
    '                        .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = "0"
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .TextReferanceName.EditValue = DocData.ReferanceName
    '                        .DocNotes.Text = DocData.DocNotes
    '                        Dim _FirstTable As DataTable
    '                        _FirstTable = GetDocDataTableFromAppSystem(DocData.DocName, DocCode).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        '.TextVoucherDiscount.EditValue = Convert.ToInt32(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        .RepositoryUnit.DataSource = GetAllItemsUnits()
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouseForAppDocByDocCode16(DocData.DocName, DocCode).StockDebitWhereHouse
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouseForAppDocByDocCode16(DocData.DocName, DocCode).StockCreditWhereHouse
    '                        .LayoutDebitHouse.Text = "إلى مستودع"
    '                        .LayoutCreditHouse.Text = "من مستودع"
    '                        .LayoutDebitHouse.Location = New Point(0, 24)
    '                        .LayoutCreditHouse.Location = New Point(0, 48)
    '                        '.AccountForRefranace.EditValue = GetOtherAccountByDocCode(DocData.DocName, DocCode)
    '                        .Text = "ارسالية داخلية"
    '                        .SimpleButton4.Text = "تصدير الى ارسالية داخلية"
    '                        .BarSubItemConvertDocuments.Visibility = XtraBars.BarItemVisibility.Always
    '                        .BarConvertToStockMoveVoucher.Visibility = XtraBars.BarItemVisibility.Always
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = 1
    '                        .ExchangePrice.Text = 1
    '                        .TextOpenFrom.Text = OpenFrom
    '                        If DocData.OrderStatus = 0 And DocData.DocStatus = 1 Then
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .TextEditDocSource.Text = "OrdersAppJournal"
    '                        .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .BarSubItemSetItemPrices.Visibility = XtraBars.BarItemVisibility.Never
    '                        ' .LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .GridView1.OptionsBehavior.Editable = False
    '                        .DocManualNo.ReadOnly = True
    '                        .DocDate.ReadOnly = True
    '                        .DocCurrency.ReadOnly = True
    '                        .Referance.ReadOnly = True
    '                        .LookCostCenter.ReadOnly = True
    '                        .TextReferanceName.ReadOnly = True
    '                        .StockDebitWhereHouse.ReadOnly = True
    '                        .StockCreditWhereHouse.ReadOnly = True
    '                        .DocNotes.ReadOnly = True
    '                        .AccountForRefranace.ReadOnly = True
    '                        .DateDeliverDate.ReadOnly = True
    '                        .SalesPerson.ReadOnly = True
    '                        .TextVoucherDiscount.ReadOnly = True
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .TextOrderStatus.Text = DocData.OrderStatus
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        .HyperLinkEdit1.Text = ".., from Device :" & DocData.DeviceName
    '                        If DocData.OrderStatus = 1 Then .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        If .DocCode.Text = "0" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'If .DocStatus.EditValue = 3 Then
    '                        '    '.LayoutPostDocument.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        '    .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'End If
    '                        ' .LayoutPostDocument.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        'Set the Parent Form of the Child window.
    '                        '.MdiParent = My.Forms.Main
    '                        ' .WindowState = FormWindowState.Normal
    '                        'Display the new form.
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        ._DocTagsToOpen = DocData.DocTags
    '                        .Show()
    '                    End With
    '            End Select
    '        Case Else
    '            Select Case _DocName
    '                Case 1, 17, 8
    '                    stopwatch.Start()
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        If GlobalVariables._UseSerials = True Then
    '                            If CheckIfDocOpend(DocCode) = True Then
    '                                MsgBox("The Voucher Already Opend")
    '                                Return "Error"
    '                                Exit Function
    '                            Else
    '                                If InsertSerialsToTempWhenOpenDoc(DocCode, _DocName) = False Then
    '                                    MsgBox("Error: Serials Cannot Loaded")
    '                                    Return "Error"
    '                                    Exit Function
    '                                End If
    '                            End If
    '                        End If
    '                        .Show() 'Show form first to initialize all controls
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 3 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                        End If
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocID.EditValue = DocData.DocID
    '                        '.DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        '.Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        '.RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouse(_DocName, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(_DocName, DocData.DocID)
    '                        If _DocName = 1 Then .Text = "فاتورة مشتريات"
    '                        If _DocName = 17 Then .Text = "سند ادخال بضاعة"
    '                        If _DocName = 8 Then .Text = "ارسالية مشتريات"
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarInputDateTime.Caption = DocData.InputDateTime
    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2

    '                        .ProgressBarControl1.EditValue = 100
    '                        .ProgressBarControl1.Update()
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If
    '                        If _DocName = 8 Then
    '                            .ColStockPrice.Visible = False
    '                            .colDocAmount.Visible = False
    '                            .ColLastPurchasePrice.Visible = False
    '                            .LayoutControlItemDriver.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                            .LayoutControlItemPlate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                            .ColStockDiscount.Visible = False
    '                            If DocData.DocStatus = 3 Then
    '                                If DocData.OrderStatus = 99 Then
    '                                    .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                                Else
    '                                    .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                                End If
    '                            Else
    '                                .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            End If
    '                        End If
    '                        stopwatch.Stop()
    '                        .BarPeriod.Caption = "Time Elapsed: " & stopwatch.Elapsed.TotalSeconds.ToString("0.00") & " seconds"
    '                        .BarPeriod.Visibility = XtraBars.BarItemVisibility.Always
    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If
    '                    End With
    '                Case 2, 18, 9
    '                    stopwatch.Start()
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        If GlobalVariables._UseSerials = True Then
    '                            If CheckIfDocOpend(DocCode) = True Then
    '                                MsgBox("The Voucher Already Opend")
    '                                Return "Error"
    '                                Exit Function
    '                            Else
    '                                If InsertSerialsToTempWhenOpenDoc(DocCode, _DocName) = False Then
    '                                    MsgBox("Error: Serials Cannot Loaded")
    '                                    Return "Error"
    '                                    Exit Function
    '                                End If
    '                            End If
    '                        End If
    '                        .Show()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 3 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            '.BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                        End If
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocID.EditValue = DocData.DocID
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable

    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        '.RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouse(_DocName, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(_DocName, DocData.DocID)
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        If _DocName = 2 Then .Text = "فاتورة مبيعات"
    '                        If _DocName = 18 Then .Text = "سند اخراج بضاعة"
    '                        If _DocName = 9 Then .Text = "ارسالية مبيعات"
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        .ProgressBarControl1.EditValue = 100
    '                        .ProgressBarControl1.Update()
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarInputDateTime.Caption = DocData.InputDateTime

    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2

    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If

    '                        If _DocName = 9 Then
    '                            .ColStockDiscount.Visible = False
    '                            .ColStockPrice.Visible = False
    '                            .colDocAmount.Visible = False
    '                            .ColLastPurchasePrice.Visible = False
    '                            .LayoutControlItemDriver.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                            .LayoutControlItemPlate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                            .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                            If DocData.DocStatus = 3 Then
    '                                If DocData.OrderStatus = 99 Then
    '                                    .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                                Else
    '                                    .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                                End If
    '                            Else
    '                                .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            End If
    '                        End If
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .JournalGridControl.ForceInitialize()
    '                        '.Show()
    '                        stopwatch.Stop()
    '                        .BarPeriod.Caption = "Time Elapsed: " & stopwatch.Elapsed.TotalSeconds.ToString("0.00") & " seconds"
    '                        .BarPeriod.Visibility = XtraBars.BarItemVisibility.Always
    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If
    '                    End With
    '                Case 12
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        .Show()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 3 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                        End If
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocID.EditValue = DocData.DocID
    '                        ' .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        '.RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouse(_DocName, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(_DocName, DocData.DocID)
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .Text = " مردودات مبيعات"
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .ProgressBarControl1.EditValue = 100
    '                        .ProgressBarControl1.Update()
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarInputDateTime.Caption = DocData.InputDateTime

    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson

    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If
    '                    End With

    '                Case 13
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        .Show()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 3 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            '.BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                        End If
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocID.EditValue = DocData.DocID
    '                        ' .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        ' .RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouse(_DocName, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(_DocName, DocData.DocID)
    '                        .Text = "مردودات  مشتريات"
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .ProgressBarControl1.EditValue = 100
    '                        .ProgressBarControl1.Update()
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarInputDateTime.Caption = DocData.InputDateTime

    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson

    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If

    '                    End With

    '                Case 3, 4
    '                    ' Dim F3 As New MoneyTrans
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    ' With F3
    '                    '.TextDocID.EditValue = DocData.DocID
    '                    '    .DocName.EditValue = DocData.DocName
    '                    '    .TextOpenFrom.Text = MoneyTrans.Name
    '                    '    .Show()
    '                    '    .TextDocIDQuery.EditValue = DocData.DocID
    '                    ' End With
    '                    My.Forms.MoneyTrans.Show()
    '                    My.Forms.MoneyTrans.DocName.EditValue = DocData.DocName
    '                    My.Forms.MoneyTrans.TextDocIDQuery.EditValue = DocData.DocID

    '                Case 6
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    My.Forms.CreditDebitNotes.TextDocName.EditValue = DocData.DocName
    '                    My.Forms.CreditDebitNotes.TextDocID.EditValue = DocData.DocID
    '                    My.Forms.CreditDebitNotes.Show()

    '                Case 7
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    My.Forms.CreditDebitNotes.TextDocName.EditValue = DocData.DocName
    '                    My.Forms.CreditDebitNotes.TextDocID.EditValue = DocData.DocID
    '                    My.Forms.CreditDebitNotes.Show()
    '                Case 5
    '                    Dim F3 As New Journal
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        '.TextDocIDQuery.EditValue = DocData.DocID
    '                        .TextDocID.EditValue = DocData.DocID
    '                        .DocName.EditValue = DocData.DocName
    '                        .TextDocIDQuery.EditValue = DocData.DocID
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        .DocCode.Text = DocCode
    '                        .GridJournal.Select()
    '                        .Show()
    '                    End With
    '                Case 11 ' طلبية مبيعات
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        .Show()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        .DocID.EditValue = DocData.DocID
    '                        ' .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        ' .RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouse(11, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(11, DocData.DocID)
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .Text = "طلبية مبيعات"
    '                        .SimpleButton2.Text = " F3 حفظ الطلبية "
    '                        If DocData.DocStatus = 3 Or DocData.DocStatus = 4 Then
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            .SimpleButton5.Text = "اعتماد الطلبية"
    '                        End If
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .SearchOrderStatus.EditValue = DocData.OrderStatus
    '                        .AccountForRefranace.EditValue = DocData.RefAccID
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        ' .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        If DocData.OrderStatus = 99 Or DocData.DocStatus = 3 Then
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DateDeliverDate.ReadOnly = True
    '                            .SalesPerson.ReadOnly = True
    '                            ._PosNo = DocData.PosNo
    '                            ._ShiftID = DocData.ShiftID
    '                            ._DocID2 = DocData.DocID2

    '                            .TextVoucherDiscount.ReadOnly = True
    '                            .ProgressBarControl1.PerformStep()
    '                            .ProgressBarControl1.Update()
    '                        End If
    '                        If DocData.OrderStatus <> 99 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        .BarInputDateTime.Caption = DocData.InputDateTime

    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If

    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If

    '                    End With
    '                Case 10 ' طلبية مشتريات 
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        .Show()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        .DocID.EditValue = DocData.DocID
    '                        ' .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = GetCostCenterForDocument(_DocName, DocData.DocID)
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        .TextVoucherDiscount.EditValue = Convert.ToDecimal(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        ' .RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouse(10, DocData.DocID)
    '                        .AccountForRefranace.EditValue = GetOtherAccount(10, DocData.DocID)
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .Text = "طلبية مشتريات"
    '                        .SimpleButton2.Text = " F3 حفظ الطلبية "
    '                        If DocData.DocStatus = 3 Or DocData.DocStatus = 4 Then
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            .SimpleButton5.Text = "اعتماد الطلبية"
    '                        End If
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .SearchOrderStatus.EditValue = DocData.OrderStatus
    '                        .AccountForRefranace.EditValue = DocData.RefAccID
    '                        .DateDeliverDate.DateTime = CDate(DocData.DeliverDate)
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        ' .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        If DocData.OrderStatus = 99 Or DocData.DocStatus = 3 Then
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DateDeliverDate.ReadOnly = True
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                            .ProgressBarControl1.PerformStep()
    '                            .ProgressBarControl1.Update()
    '                        End If
    '                        If DocData.OrderStatus <> 99 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        Else
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        End If
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        .BarInputDateTime.Caption = DocData.InputDateTime

    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If

    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If

    '                    End With
    '                Case 16
    '                    Dim F3 As New AccStockMove
    '                    Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                    With F3
    '                        .DocName.EditValue = DocData.DocName
    '                        .Show()
    '                        If GlobalVariables._UseSerials = True Then
    '                            If CheckIfDocOpend(DocCode) = True Then
    '                                MsgBox("The Voucher Already Opend")
    '                                Return "Error"
    '                            Else
    '                                If InsertSerialsToTempWhenOpenDoc(DocCode, _DocName) = False Then
    '                                    MsgBox("Error: Serials Cannot Loaded")
    '                                    Return "Error"
    '                                End If
    '                            End If
    '                        End If
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocStatus.EditValue = DocData.DocStatus
    '                        If .DocStatus.EditValue = 3 Then
    '                            .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .GridView1.OptionsBehavior.Editable = False
    '                            .DocManualNo.ReadOnly = True
    '                            .SearchOrderStatus.ReadOnly = True
    '                            .DocStatus.ReadOnly = True
    '                            .DocDate.ReadOnly = True
    '                            .Referance.ReadOnly = True
    '                            .TextReferanceName.ReadOnly = True
    '                            .LookCostCenter.ReadOnly = True
    '                            .StockDebitWhereHouse.ReadOnly = True
    '                            .StockCreditWhereHouse.ReadOnly = True
    '                            .DocNotes.ReadOnly = True
    '                            .AccountForRefranace.ReadOnly = True
    '                            .DocCurrency.ReadOnly = True
    '                            .ExchangePrice.ReadOnly = True
    '                            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .DocStatus.BackColor = Color.Red
    '                            '.BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                            .SalesPerson.ReadOnly = True
    '                            .TextVoucherDiscount.ReadOnly = True
    '                        End If
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .DocID.EditValue = DocData.DocID
    '                        ' .DocName.EditValue = DocData.DocName
    '                        .DocDate.DateTime = CDate(DocData.DocDate)
    '                        .LookCostCenter.EditValue = "0"
    '                        .DocManualNo.Text = DocData.DocManualNo
    '                        .DocSort.EditValue = DocData.DocSort
    '                        .Referance.EditValue = DocData.Referance
    '                        .DocNotes.Text = DocData.DocNotes
    '                        ' .Show()
    '                        Dim _FirstTable As New DataTable
    '                        _FirstTable = GetDocDataTable(_DocName, DocData.DocID, DataName, _ModifiedDateTime).FirstTable
    '                        .JournalGridControl.DataSource = _FirstTable
    '                        ' .TextVoucherDiscount.EditValue = Convert.ToInt32(_FirstTable.Compute("SUM(VoucherDiscount)", String.Empty))
    '                        ' .RepositoryUnit.DataSource = GetAllUnits()
    '                        .StockCreditWhereHouse.EditValue = GetWhareHouseFor16(_DocName, DocData.DocID).CreditWareHouse
    '                        .StockDebitWhereHouse.EditValue = GetWhareHouseFor16(_DocName, DocData.DocID).DebitWahreHouse
    '                        .LayoutDebitHouse.Location = New Point(0, 48)
    '                        .LayoutCreditHouse.Location = New Point(0, 24)
    '                        .LayoutDebitHouse.Text = "إلى مستودع"
    '                        .LayoutCreditHouse.Text = "من مستودع"
    '                        '.AccountForRefranace.EditValue = GetOtherAccount(_DocName, DocData.DocID)
    '                        .Text = "ارسالية داخلية"
    '                        .SimpleButton4.Text = "تصدير الى ارسالية داخلية "
    '                        .ProgressBarControl1.PerformStep()
    '                        .ProgressBarControl1.Update()
    '                        .TextReferanceName.Text = DocData.ReferanceName
    '                        .DocCurrency.EditValue = DocData.DocCurrency
    '                        .ExchangePrice.Text = DocData.ExchangePrice
    '                        .TextOpenFrom.Text = MoneyTrans.Name
    '                        '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '                        .DocCode.Text = DocData.DocCode
    '                        .ProgressBarControl1.EditValue = 100
    '                        .ProgressBarControl1.Update()
    '                        If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
    '                        .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    '                        .LastDataName.Text = DocData.LastDataName
    '                        .LastDocCode.Text = DocData.LastDocCode
    '                        .BarDocCode.Caption = DocData.DocCode
    '                        If Not String.IsNullOrEmpty(.LastDocCode.Text) Then .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    '                        .BarDeviceName.Caption = DocData.DeviceName
    '                        .BarInputUser.Caption = DocData.InputUser
    '                        .ProgressBarControl1.EditValue = 0
    '                        .ProgressBarControl1.Update()
    '                        .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    '                        .SalesPerson.EditValue = DocData.SalesPerson
    '                        .SalesPerson.ReadOnly = True
    '                        .BarInputDateTime.Caption = DocData.InputDateTime
    '                        ._PosNo = DocData.PosNo
    '                        ._ShiftID = DocData.ShiftID
    '                        ._DocID2 = DocData.DocID2
    '                        If Not IsNothing(DocData.DocTags) Then
    '                            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
    '                            If customHeaderButton IsNot Nothing Then
    '                                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
    '                                customHeaderButtonTyped.Caption = DocData.DocTags
    '                            End If
    '                        Else
    '                            DocData.DocTags = ""
    '                        End If
    '                        .BarPaidStatus.Caption = DocData.PaidStatus
    '                        .BarPaidSAmount.Caption = DocData.PaidAmount
    '                        .BarPaidByDocID.Caption = DocData.PaidByDocID
    '                        .StockDriver.Text = DocData.StockDriver
    '                        .StockCarNo.Text = DocData.StockCarNo

    '                        If Not postService.TryLockDocument(DocCode) Then
    '                            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
    '                            .askBeforeClose = False
    '                            .Close()
    '                            Return "Error"
    '                        End If

    '                    End With
    '                Case 19
    '                    Try
    '                        Dim DocData = GetDocDataByDocCode(DocCode, DataName, _ModifiedDateTime)
    '                        Dim F As New ProductionDocument
    '                        With F
    '                            .TextNewOld.Text = "old"
    '                            .Show()
    '                            .TextQueryID.EditValue = DocData.DocID
    '                            'MsgBox(.TextQueryID.EditValue)
    '                        End With
    '                    Catch ex As Exception
    '                        MsgBoxShowError(" لا يمكن فتح السند ")
    '                    End Try


    '            End Select
    '    End Select
    '    stop_time = Now
    '    elapsed_time = stop_time.Subtract(start_time)
    '    My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
    '    Return "Success"

    'End Function

    Public Function GetDocNameByDocCode(DocCode As String, DataName As String) As Integer
        Dim _DocName As Integer
        Dim SqlString As String
        Dim sql As New SQLControl
        Try
            SqlString = " Select top(1) DocName from " & DataName & " where DocCode='" & DocCode & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _DocName = sql.SQLDS.Tables(0).Rows(0).Item("DocName")
        Catch ex As Exception
            _DocName = 0
        End Try
        Return _DocName
    End Function
    Public Function GetDocNameTextByDocNameID(NameID As Integer) As String
        Dim SqlString As String
        Dim sql As New SQLControl
        Try
            SqlString = "select [Name] from DocNames where id=" & NameID
            sql.SqlTrueAccountingRunQuery(SqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("Name")
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function OpenProgram(ByVal ThisOne As Form) As Form
        Return CType(Activator.CreateInstance(ThisOne.GetType()), Form)
    End Function

    Public Function GetAllItemsUnits() As DataTable
        Dim _GetAllUnits As New DataTable
        Dim sql As New SQLControl
        Try
            Dim SqlString As String
            SqlString = " Select id,name from Units "
            sql.SqlTrueAccountingRunQuery(SqlString)
            _GetAllUnits = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _GetAllUnits
    End Function

    Public Function GetWhareHouse(DocName As Integer, DocID As Integer) As Integer
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _OtherAccount As Integer = 0

        Select Case DocName
            Case 1, 12, 14, 17, 8
                SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [Journal]
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and DebitAcc <> '0' AND IsVAT = 0 "
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
            Case 2, 13, 15, 18, 9
                SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [Journal]
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and CredAcc <> '0' AND IsVAT = 0"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
            Case 11
                SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [OrdersJournal]
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and CredAcc <> '0' AND IsVAT = 0"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
            Case 10
                SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [OrdersJournal]
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and DebitAcc <> '0' AND IsVAT = 0"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
        End Select

        Return _OtherAccount
    End Function
    'Public Function GetSalesMan(DocName As Integer, DocID As Integer) As Integer
    '    Dim sql As New SQLControl
    '    Dim SqlString As String
    '    Dim _OtherAccount As Integer = 0
    '    Select Case DocName
    '        Case 1, 12, 14
    '            SqlString = "  Select top(1) SalesPerson from [Journal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and DebitAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")) Then
    '                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")
    '            Else
    '                _OtherAccount = 0
    '            End If
    '        Case 2, 13, 15
    '            SqlString = "  Select top(1) SalesPerson from [Journal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and CredAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")) Then
    '                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")
    '            Else
    '                _OtherAccount = 0
    '            End If

    '        Case 11
    '            SqlString = "  Select top(1) SalesPerson from [Journal]
    '                   Where   DocID= " & DocID & " and DocName=" & DocName
    '            SqlString += " and CredAcc <> '0'"
    '            sql.SqlTrueAccountingRunQuery(SqlString)
    '            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")) Then
    '                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("SalesPerson")
    '            Else
    '                _OtherAccount = 0
    '            End If
    '    End Select

    '    Return _OtherAccount
    'End Function
    Public Function GetWhareHouseFor16(DocName As Integer, DocID As Integer) _
        As (DebitWahreHouse As Integer, CreditWareHouse As Integer, DebitWahreHouseName As String, CreditWareHouseName As String)
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _DebitWahreHouse As Integer
        Dim _CreditWareHouse As Integer
        Dim _DebitWahreHouseName As String
        Dim _CreditWareHouseName As String
        SqlString = "  Select Top(1) [StockDebitWhereHouse],[StockCreditWhereHouse],W.WarehouseNameAR as DebitWahreHouseName ,WW.WarehouseNameAR as CreditWareHouseName
                       from [Journal] J 
                       left Join [dbo].[Warehouses] W on J.StockDebitWhereHouse=W.[WarehouseID]
                       left Join [dbo].[Warehouses] WW on J.StockCreditWhereHouse=WW.[WarehouseID]
                       Where   DocID= " & DocID & " and DocName=" & DocName
        sql.SqlTrueAccountingRunQuery(SqlString)
        _DebitWahreHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
        _CreditWareHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
        _DebitWahreHouseName = sql.SQLDS.Tables(0).Rows(0).Item("DebitWahreHouseName")
        _CreditWareHouseName = sql.SQLDS.Tables(0).Rows(0).Item("CreditWareHouseName")
        Return (_DebitWahreHouse, _CreditWareHouse, _DebitWahreHouseName, _CreditWareHouseName)
    End Function
    Public Function GetOtherAccount(DocName As Integer, DocID As Integer) As String
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _OtherAccount As String = "0"
        SqlString = "  Select DISTINCT DebitAcc,CredAcc from  journal
                       Where   DocID= " & DocID & " and DocName=" & DocName
        Select Case DocName
            Case 4, 2, 13, 18, 9
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")
            Case 3, 1, 12, 17, 8
                SqlString += " and CredAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")
            Case 11
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = "1104010000"
        End Select

        Return _OtherAccount
    End Function
    Private Function GetOtherAccountByDocCode(DocName As Integer, DocCode As String) As String
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _OtherAccount As String = "0"
        SqlString = "  Select DISTINCT DocID,DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocSort,Referance,[DocManualNo],InputUser,DocNotes from  journal
                       Where   DocCode= '" & DocCode & "' and DocName=" & DocName
        Select Case DocName
            Case 4, 2, 13, 18, 9
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")
            Case 3, 1, 12, 17, 8
                SqlString += " and CredAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")
            Case 11
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = "1104010000"
        End Select

        Return _OtherAccount
    End Function
    Public Function GetCostCenterForDocument(DocName As Integer, DocID As Integer) As Integer
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _CostCenter As String = "0"

        Select Case DocName
            Case 4, 2, 13, 18, 9
                SqlString = "  Select top(1) DocCostCenter from  journal
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _CostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
            Case 3, 1, 12, 17, 8
                SqlString = "  Select top(1) DocCostCenter from  journal
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and CredAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _CostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
            Case 10
                SqlString = "  Select top(1) DocCostCenter from  OrdersJournal
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and CredAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _CostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
            Case 11
                SqlString = "  Select top(1) DocCostCenter from  OrdersJournal
                       Where   DocID= " & DocID & " and DocName=" & DocName
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _CostCenter = sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")
        End Select

        Return _CostCenter
    End Function

    Public Function GetWhareHouseByDocCode(DocName As Integer, DocCode As String) _
        As (WahreHouse As Integer, WahreHouseName As String)
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _WahreHouse As Integer = 1
        Dim _WahreHouseName As String = ""
        SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse],
                              W.WarehouseNameAR As StockDebitWhereHouseName ,WW.WarehouseNameAR As StockCreditWhereHouseName 
                       from [Journal] J
                       left Join [dbo].[Warehouses] W on J.StockDebitWhereHouse=W.[WarehouseID]
                       left Join [dbo].[Warehouses] WW on J.StockCreditWhereHouse=WW.[WarehouseID]
                       Where IsVAT=0 AND DocCode= '" & DocCode & "' and DocName=" & DocName
        Select Case DocName
            Case 1, 12, 14, 17, 8
                SqlString += " and DebitAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _WahreHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
                _WahreHouseName = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouseName")
            Case 2, 13, 15, 18, 9
                SqlString += " and CredAcc <> '0'"
                sql.SqlTrueAccountingRunQuery(SqlString)
                _WahreHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
                _WahreHouseName = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouseName")
            Case 11
                _WahreHouse = GetDefaultWharehouse()
            Case Else
                _WahreHouse = 1
                _WahreHouseName = "الرئيسي"
        End Select

        Return (_WahreHouse, _WahreHouseName)
    End Function
    Public Function GetWhareHouseForAppDocByDocCode(DocName As Integer, DocCode As String) As Integer
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _OtherAccount As Integer = 0
        SqlString = "  Select DISTINCT [StockDebitWhereHouse],[StockCreditWhereHouse] from [OrdersAppJournal]
                       Where   DocCode= '" & DocCode & "' and DocName=" & DocName
        Select Case DocName
            Case 1, 12, 14, 17, 8
                SqlString += " "
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
            Case 2, 13, 15, 18, 9
                SqlString += " "
                sql.SqlTrueAccountingRunQuery(SqlString)
                _OtherAccount = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
            Case 11
                _OtherAccount = GetDefaultWharehouse()
        End Select

        Return _OtherAccount
    End Function
    Public Function GetWhareHouseForAppDocByDocCode16(DocName As Integer, DocCode As String) As _
        (StockDebitWhereHouse As Integer, StockCreditWhereHouse As Integer)
        Dim _StockDebitWhereHouse As Integer
        Dim _StockCreditWhereHouse As Integer
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _OtherAccount As Integer = 0
        SqlString = "  Select  [StockDebitWhereHouse],[StockCreditWhereHouse] from [OrdersAppJournal]
                       Where   DocCode= '" & DocCode & "' and DocName=" & DocName
        sql.SqlTrueAccountingRunQuery(SqlString)
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")) Then
            _StockDebitWhereHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockDebitWhereHouse")
        Else
            _StockDebitWhereHouse = 0
        End If
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")) Then
            _StockCreditWhereHouse = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
        Else
            _StockCreditWhereHouse = 0
        End If
        Return (_StockDebitWhereHouse, _StockCreditWhereHouse)
    End Function


    Public Function PostDocument(DocCode As String, DocData As String) As Boolean
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "Update " & DocData & " Set DocStatus=3 where DocCode='" & DocCode & "'"
        If Sql.SqlTrueAccountingRunQuery(SqlString) = "True" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function AuditDocument(DocCode As String, DocID As Integer, DocName As Integer, DocData As String) As Boolean
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        SqlString = "Update " & DocData & " Set DocStatus=2,[DocAuditUser]=" & GlobalVariables.CurrUser & ",[DocAuditDate]='" & _LogDateTime & "' where DocCode=N'" & DocCode & "' And DocID=" & DocID
        If Sql.SqlTrueAccountingRunQuery(SqlString) = "True" Then
            CreateDocLog("Document", DocCode, DocName, DocID, "Audit", "Audit Document", _LogDateTime)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetOnlyUnitsTable()
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select id,name from Units")
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return _Table
        End Try
        Return _Table
    End Function

    Public Function CalcAge(_Birthday As Date) As String
        Dim _Age As String
        Try
            Dim birthdate As Date = _Birthday
            Dim ageInYears As Integer = Date.Today.Year - birthdate.Year
            If birthdate.AddYears(ageInYears) > Date.Today Then ageInYears -= 1

            Dim ageInMonths As Integer = Date.Today.Month - birthdate.Month
            If ageInMonths < 0 Then ageInMonths += 12

            'Return ("Age: " & ageInYears & " years, " & ageInMonths & " months")
            _Age = ageInYears & " سنة, " & ageInMonths & " شهر "
        Catch ex As Exception
            _Age = ""
        End Try

        Return _Age

    End Function

    Public Function CalcAgeDesc(_Enddate As Date) As String
        Dim _Age As String
        Try
            Dim birthdate As Date = _Enddate
            Dim ageInYears As Integer = Date.Today.Year - birthdate.Year
            If birthdate.AddYears(ageInYears) < Date.Today Then ageInYears -= 1

            Dim ageInMonths As Integer = Date.Today.Month - birthdate.Month
            If ageInMonths > 0 Then ageInMonths += 12

            'Return ("Age: " & ageInYears & " years, " & ageInMonths & " months")
            _Age = Math.Abs(ageInYears) & " سنة, " & Math.Abs(ageInMonths) & " شهر "
        Catch ex As Exception
            _Age = ""
        End Try

        Return _Age
    End Function
    Public Sub PrintDoc(IsOrigional As Boolean, _DocCode As String, _DocData As String, _Preview As Boolean, _PDF As Boolean)
        Dim _PrintHeaderInVouchers As Boolean
        Dim _PrintBarcodeInVoucher As String
        Dim _PrintRefBalanceInVoucher As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintHeaderInVouchers'")
            _PrintHeaderInVouchers = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _PrintHeaderInVouchers = "True"
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintBarcodeInVoucher'")
            _PrintBarcodeInVoucher = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _PrintBarcodeInVoucher = "StockID"
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintRefBalanceInVoucher'")
            _PrintRefBalanceInVoucher = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _PrintRefBalanceInVoucher = "False"
        End Try

        Dim TheDocData = GetDocDataByDocCode(_DocCode, _DocData)
        Dim _DocName As Integer
        _DocName = TheDocData.DocName
        Dim _MyCompanyData = GetCompanyData()
        Select Case _DocName
            Case 1, 2, 12, 13, 17, 18
                Dim Report As New StockInvoiceReport
                With Report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    If _PrintBarcodeInVoucher = "BarCode" Or _PrintBarcodeInVoucher = "BarCode+StockID" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "الباركود"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    ElseIf _PrintBarcodeInVoucher = "StockID" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "رقم الصنف"
                        .XrTableCellItemNo.WidthF = 80
                        .XrTableCellItemNo_.WidthF = 80
                    ElseIf _PrintBarcodeInVoucher = "ItemNo2" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "كود الصنف"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    End If
                    ' .Parameters("DocType").Value = DocType.Text
                    ' .Parameters("DocSort").Value = DocSort.EditValue
                    If IsOrigional = True Then .DocOriginal.Text = "أصلية"

                    Select Case _DocName
                        Case "2"
                            .XrLabelDocName.Text = " فاتورة ضريبية"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("CreditWhereHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            Dim _RefData = GetRefranceData(TheDocData.Referance)
                            .AccountAddressLabel.Text = _RefData.CityName & " ، " & _RefData._Address
                            .AccountMobileLabel.Text = _RefData.RefMobile
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                            .XrLabelCurrency.Visible = True
                        Case "1"
                            .XrLabelDocName.Text = " مشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("DebitWahreHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = True
                            .XrLabel10.Visible = False
                            .XrLabel11.LocationF = New Point(24.72, 124.58)
                            .XrLabelCreditName.LocationF = New Point(90.34, 124.58)
                            .XrLabelCurrency.Visible = True
                        Case "12"
                            .XrLabelDocName.Text = " مردودات مبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("DebitWahreHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            Dim _RefData = GetRefranceData(TheDocData.Referance)
                            .AccountAddressLabel.Text = _RefData.CityName & " ، " & _RefData._Address
                            .AccountMobileLabel.Text = _RefData.RefMobile
                            .XrLabel11.Visible = True
                            .XrLabel10.Visible = False
                            .XrLabel11.LocationF = New Point(24.72, 124.58)
                            .XrLabelCreditName.LocationF = New Point(90.34, 124.58)
                            .XrLabelCurrency.Visible = True
                        Case "13"
                            .XrLabelDocName.Text = " مردودات مشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("CreditWhereHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                            .XrLabelCurrency.Visible = True
                        Case "11"
                            .XrLabelDocName.Text = " طلبية مبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            Dim _RefData = GetRefranceData(TheDocData.Referance)
                            .AccountAddressLabel.Text = _RefData.CityName & " ، " & _RefData._Address
                            .AccountMobileLabel.Text = _RefData.RefMobile
                            '.Parameters("CreditWhereHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                            .XrLabelCurrency.Visible = True
                        Case "17"
                            .XrLabelDocName.Text = " سند ادخال بضاعة"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("DebitWahreHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = True
                            .XrLabel10.Visible = False
                            .XrLabel11.LocationF = New Point(24.72, 124.58)
                            .XrLabelCreditName.LocationF = New Point(90.34, 124.58)
                        Case "18"
                            .XrLabelDocName.Text = " سند اخراج بضاعة"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("CreditWhereHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                    End Select
                    .XrTableCell30.Value = 0
                    .XrTableCell31.Value = 0
                    .Parameters("DebitWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .Parameters("CreditWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    .XrLabel5.Text = TheDocData.DocNotes
                    .XrLabelVatNo.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    .XrLabelCurrency.Text = " العملة " & " : " & TheDocData.DocCurrencyName
                    If _PrintRefBalanceInVoucher = "True" Then
                        .XrLabelBalance.Text = GetReferanceBalance(TheDocData.Referance)
                    Else
                        .XrLabelBalance.Visible = False
                        .XrLabelTextForBalance.Visible = False
                        .XrLabelCurrencyBalance.Visible = False
                    End If

                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    If _PrintHeaderInVouchers = "False" Then
                        .XrLabel6.Visible = False
                        .XrLabel7.Visible = False
                        .XrLabel22.Visible = False
                        .XrLabel23.Visible = False
                        ' .XrLabelVatNo.Visible = False
                        .XrPictureBox1.Visible = False
                    End If

                End With
                Report.PrintingSystem.ShowMarginsWarning = False
                If _Preview = True And _PDF = False Then
                    Report.ShowPreview()
                End If
                If _PDF = True Then
                    Report.ExportToPdf("Document.pdf")
                End If
                If _Preview = False And _PDF = False Then
                    Report.Print()
                End If
                'If IsOrigional = True Then
                '    Report.Print()
                'Else
                '    Report.ShowPreview()
                'End If

            Case 10, 11
                Dim BarCodePrint As Integer
                If _PrintBarcodeInVoucher = "BarCode" Then
                    BarCodePrint = 1
                Else
                    BarCodePrint = 0
                End If
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = "  Declare @BarCodePrint int
                                                Set @BarCodePrint = " & BarCodePrint & " 
select OrdersJournal.DocID, OrdersJournal.DocDate,
       OrdersJournal.DocName, OrdersJournal.DebitAcc,
       OrdersJournal.CredAcc,       OrdersJournal.AccountCurr,
       OrdersJournal.DocCurrency,       (OrdersJournal.DocAmount + isnull
       (OrdersJournal.VoucherDiscount,       0)) as DocAmount, case when
       (@BarCodePrint = 0) then        CAST(OrdersJournal.StockID AS varchar(50)) else
       OrdersJournal.StockBarcode end as StockID,
       OrdersJournal.StockUnit,       OrdersJournal.StockQuantity-OrdersJournal.BonusQuantity As StockQuantity ,OrdersJournal.BonusQuantity,OrdersJournal.BonusQuantityByMainUnit,
       OrdersJournal.StockQuantityByMainUnit,       OrdersJournal.StockPrice,
       OrdersJournal.StockItemPrice,       OrdersJournal.StockDebitWhereHouse,
       OrdersJournal.StockCreditWhereHouse,       OrdersJournal.ItemName, OrdersJournal.DocNotes,
       Units.name as UnitName,       OrdersJournal.StockDiscount, isnull
       (OrdersJournal.VoucherDiscount,       0) as VoucherDiscount
  from (dbo.OrdersJournal OrdersJournal  inner join dbo.Units Units
       on (Units.id = OrdersJournal.StockUnit)) where ((OrdersJournal.DocID = " & TheDocData.DocID & ")
       and (OrdersJournal.DocName = " & _DocName & ")
       and (OrdersJournal.StockID <> N'0')) "
                Sql.SqlTrueAccountingRunQuery(SqlString)
                Dim report As New StockOrderReport() With {.DataSource = Sql.SQLDS.Tables(0)}
                With report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    If _PrintBarcodeInVoucher = "BarCode" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "الباركود"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    ElseIf _PrintBarcodeInVoucher = "StockID" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "رقم الصنف"
                        .XrTableCellItemNo.WidthF = 80
                        .XrTableCellItemNo_.WidthF = 80
                    ElseIf _PrintBarcodeInVoucher = "ItemNo2" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "كود الصنف"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    End If
                    ' .Parameters("DocType").Value = DocType.Text
                    ' .Parameters("DocSort").Value = DocSort.EditValue
                    If IsOrigional = True Then .DocOriginal.Text = "أصلية"
                    Select Case _DocName
                        Case "10"
                            .XrLabelDocName.Text = "طلبية مشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .XrLabel11.Visible = True
                            .XrLabel10.Visible = False
                        Case "11"
                            .XrLabelDocName.Text = " طلبية مبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                    End Select
                    .XrTableCell30.Value = 0
                    .XrTableCell31.Value = 0
                    .Parameters("DebitWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .Parameters("CreditWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    Dim _RefData = GetRefranceData(TheDocData.Referance)
                    .AccountAddressLabel.Text = _RefData.CityName & " ، " & _RefData._Address
                    .AccountMobileLabel.Text = _RefData.RefMobile
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    If _MyCompanyData.CompanyMobile <> "" Then .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    If " هاتف " & " : " & _MyCompanyData.CompanyPhone <> "" Then .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    .XrLabel5.Text = TheDocData.DocNotes
                    If _MyCompanyData.CompanyVAT <> "" Then .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    If TheDocData.StockDriver <> "" Then .XrLabelDriver.Text = TheDocData.StockDriver
                    If TheDocData.StockCarNo <> "" Then .XrLabelCarNo.Text = TheDocData.StockCarNo

                    If _PrintRefBalanceInVoucher = "True" Then
                        .XrLabelBalance.Text = GetReferanceBalance(TheDocData.Referance)
                    Else
                        .XrLabelBalance.Visible = False
                        .XrLabelTextForBalance.Visible = False
                        .XrLabelCurrencyBalance.Visible = False
                    End If

                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try
                    If _PrintHeaderInVouchers = "False" Then
                        .XrLabel6.Visible = False
                        .XrLabel7.Visible = False
                        .XrLabel22.Visible = False
                        .XrLabel23.Visible = False
                        .XrLabel17.Visible = False
                        .XrPictureBox1.Visible = False
                    End If

                End With
                report.PrintingSystem.ShowMarginsWarning = False
                If _Preview = True And _PDF = False Then
                    report.ShowPreview()
                End If
                If _PDF = True Then
                    report.ExportToPdf("Document.pdf")
                End If
                If _Preview = False And _PDF = False Then
                    report.Print()
                End If
            Case 3, 4
                Dim Report As New MoneyTransReport
                Dim _referance As String = "0"
                With Report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocCode").Value = _DocCode
                    ' .Parameters("Account").Value = _DocCode
                    If IsOrigional = True Then .DocOriginal.Text = "أصلية"
                    If TheDocData.Referance = "0" Then _referance = "" Else _referance = TheDocData.Referance & " / "
                    .Parameters("Account").Value = _referance & TheDocData.ReferanceName
                    .XrLabelManualDocID.Text = TheDocData.DocManualNo

                    '.Parameters("FinancialAccountName").Value = TheDocData.AccountName
                    ' If TheDocData.Referance <> "0" Then .Parameters("AccountID").Value = TheDocData.Referance
                    ' .XrLabelAccountID.Text = GetAccountForMoneyTrans(_DocName, TheDocData.DocID).AccountID
                    .XrLabelAccountName.Text = GetAccountForMoneyTrans(_DocName, TheDocData.DocID).AccountID & " / " & GetAccountForMoneyTrans(_DocName, TheDocData.DocID).AccountName
                    Select Case _DocName
                        Case "3"
                            .XrLabelDocName.Text = " سند صرف"
                            .XrLabelPayOrRec.Text = " المدفوع له: "
                            .XrLabelSalesManLabel.Visible = False
                        Case "4"
                            .XrLabelDocName.Text = " سند قبض"
                            .XrLabelPayOrRec.Text = " المقبوض منه: "
                            If _PrintRefBalanceInVoucher = "True" Then
                                If _referance <> "0" Then .XrLabelRefBalance.Text = " رصيدكم لدينا لتاريخ هذا السند :  " & GetReferanceBalance(TheDocData.Referance)
                            Else
                                .XrLabelRefBalance.Visible = False
                            End If
                            .XrLabelAccountName.Visible = False
                            .XrLabelAccountNameLabel.Visible = False
                    End Select
                    .Parameters("Currency").Value = TheDocData.DocCurrencyName
                    .Parameters("ExchangeRate").Value = TheDocData.ExchangePrice
                    .Parameters("InputUser").Value = GetEmployeeData(TheDocData.InputUser).EmployeeName
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    If _MyCompanyData.CompanyMobile <> "" Then .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile Else .XrLabel22.Visible = False
                    If _MyCompanyData.CompanyPhone <> "" Then .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone Else .XrLabel23.Visible = False
                    .XrLabel5.Text = TheDocData.DocNotes
                    .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    If _PrintHeaderInVouchers = "False" Then
                        .XrLabel6.Visible = False
                        .XrLabel7.Visible = False
                        .XrLabel22.Visible = False
                        .XrLabel23.Visible = False
                        .XrLabel17.Visible = False
                        .XrPictureBox1.Visible = False
                    End If

                End With
                Report.PrintingSystem.ShowMarginsWarning = False
                If _Preview = True And _PDF = False Then
                    Report.ShowPreview()
                End If
                If _PDF = True Then
                    Report.ExportToPdf("Document.pdf")
                End If
                If _Preview = False And _PDF = False Then
                    Report.Print()
                End If

            Case 6, 7
                Dim Report As New DebitCreditNotesReport
                With Report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    If IsOrigional = True Then .DocOriginal.Text = "أصلية"
                    Select Case _DocName
                        Case "6"
                            .XrLabelDocName.Text = " اشعار مدين"
                        Case "7"
                            .XrLabelDocName.Text = " اشعار دائن"
                    End Select
                    .XrLabelNotes.Text = TheDocData.DocNotes
                    .XrLabelRefNo.Text = TheDocData.Referance
                    .XrLabelRefName.Text = TheDocData.ReferanceName
                    .XrLabelInputUser.Text = TheDocData.InputUser
                    ' .XrLabelnputDateTime.Text = TheDocData.inp
                    .XrLabeldate.Text = TheDocData.DocDate
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    .XrLabelAccountNo.Text = TheDocData.Account
                    .XrLabelAccountName.Text = TheDocData.AccountName
                    .XrLabelAmount.Text = TheDocData.DocAmount & " /  " & TheDocData.DocCurrencyName
                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    If _PrintHeaderInVouchers = "False" Then
                        .XrLabel6.Visible = False
                        .XrLabel7.Visible = False
                        .XrLabel22.Visible = False
                        .XrLabel23.Visible = False
                        .XrLabel17.Visible = False
                        .XrPictureBox1.Visible = False
                    End If

                End With
                Report.PrintingSystem.ShowMarginsWarning = False
                If _Preview = True And _PDF = False Then
                    Report.ShowPreview()
                End If
                If _PDF = True Then
                    Report.ExportToPdf("Document.pdf")
                End If
                If _Preview = False And _PDF = False Then
                    Report.Print()
                End If
            Case 5
                Dim Report As New XtraReportJournal
                With Report

                    .XrLabelNotes.Text = TheDocData.DocNotes
                    .XrLabelInputUser.Text = " المستخدم: " & TheDocData.InputUser
                    ' .XrLabelnputDateTime.Text = TheDocData.inp
                    .XrLabelDate.Text = TheDocData.DocDate
                    .XrLabelCompanyName.Text = _MyCompanyData.CompanyName
                    .XrLabelAdress.Text = _MyCompanyData.CompanyAddress
                    .XrLabelMobile.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    ' .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    '  .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    ' .XrLabelAccountNo.Text = TheDocData.Account
                    '.XrLabelAccountName.Text = TheDocData.AccountName
                    '.XrLabelAmount.Text = TheDocData.DocAmount & " /  " & TheDocData.DocCurrencyName
                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    .XrLabelJournalID.Text = " رقم السند: " & TheDocData.DocID
                    .Parameters("DocID").Value = TheDocData.DocID
                    .PrintingSystem.ShowMarginsWarning = False
                    If _Preview = True And _PDF = False Then
                        Report.ShowPreview()
                    End If
                    If _PDF = True Then
                        Report.ExportToPdf("Document.pdf")
                    End If
                    If _Preview = False And _PDF = False Then
                        Report.Print()
                    End If
                End With
            Case 8, 9, 16
                Dim Report As New StockDispatchReport
                With Report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    If _PrintBarcodeInVoucher = "BarCode" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "الباركود"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    ElseIf _PrintBarcodeInVoucher = "StockID" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "رقم الصنف"
                        .XrTableCellItemNo.WidthF = 80
                        .XrTableCellItemNo_.WidthF = 80
                    ElseIf _PrintBarcodeInVoucher = "ItemNo2" Then
                        .Parameters("BarcodePrint").Value = _PrintBarcodeInVoucher
                        .XrTableCellItemNo.Text = "كود الصنف"
                        .XrTableCellItemNo.WidthF = 95
                        .XrTableCellItemNo_.WidthF = 95
                    End If
                    ' .Parameters("DocType").Value = DocType.Text
                    ' .Parameters("DocSort").Value = DocSort.EditValue
                    If IsOrigional = True Then .DocOriginal.Text = "أصلية"

                    Select Case _DocName
                        Case "8"
                            .XrLabelDocName.Text = " ارسالية مشتريات "
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("CreditWhereHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            Dim _RefData = GetRefranceData(TheDocData.Referance)
                            .AccountAddressLabel.Text = _RefData.CityName & " ، " & _RefData._Address
                            .AccountMobileLabel.Text = _RefData.RefMobile
                            .XrLabel11.Visible = False
                            .XrLabel10.Visible = True
                            .XrLabel10.Text = " الى مستودع: "
                            .XrLabelCurrency.Visible = True
                        Case "9"
                            .XrLabelDocName.Text = " ارسالية مبيعات "
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                            .Parameters("DebitWahreHouseName").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouseName
                            .XrLabel11.Visible = True
                            .XrLabel11.Text = " من مستودع: "
                            .XrLabel10.Visible = False
                            .XrLabel11.LocationF = New Point(24.72, 124.58)
                            .XrLabelCreditName.LocationF = New Point(90.34, 124.58)
                        Case 16
                            .XrLabelDocName.Text = "ارسالية داخلية"
                            '.Parameters("Account").Value = TheDocData.ReferanceName
                            '.Parameters("AccountID").Value = TheDocData.Referance
                            .XrLabel10.Visible = True
                            .XrLabel10.Text = " من مستودع: "
                            .XrLabel11.Text = " الى مستودع: "
                            .XrLabel39.Visible = False
                            '.XrLabel37.Visible = False
                            '.XrLabel41.Visible = False
                            .XrLabel27.Visible = False
                            .AccountMobileLabel.Visible = False
                            .XrLabel13.Visible = False
                            .XrLabel16.Visible = False
                            .XrLabel14.Visible = False
                            .XrLabel26.Visible = False
                            .AccountAddressLabel.Visible = False
                            .XrLabel11.Visible = True
                            .XrLabelDebit.Visible = True
                            .XrLabelDebitName.Visible = True
                            '  .XrLabelCredit.Visible = True
                            .XrLabelCreditName.Visible = True
                            .ReportHeaderBand1.HeightF = 50
                            .Parameters("CreditWhereHouseName").Value = GetWhareHouseFor16(16, TheDocData.DocID).CreditWareHouseName
                            .Parameters("DebitWahreHouseName").Value = GetWhareHouseFor16(16, TheDocData.DocID).DebitWahreHouseName
                            .Parameters("CreditWhereHouse").Value = GetWhareHouseFor16(16, TheDocData.DocID).CreditWareHouse
                            .Parameters("DebitWhereHouse").Value = GetWhareHouseFor16(16, TheDocData.DocID).DebitWahreHouse
                    End Select
                    .Parameters("DebitWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .Parameters("CreditWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    .XrLabel5.Text = TheDocData.DocNotes
                    .XrLabelVatNo.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    .XrLabelCurrency.Text = " العملة " & " : " & TheDocData.DocCurrencyName
                    .Parameters("Driver").Value = TheDocData.StockDriver
                    .Parameters("CarNo").Value = TheDocData.StockCarNo
                    .Parameters("SalesPersonName").Value = TheDocData.SalesPersonName

                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                    If _PrintHeaderInVouchers = "False" Then
                        .XrLabel6.Visible = False
                        .XrLabel7.Visible = False
                        .XrLabel22.Visible = False
                        .XrLabel23.Visible = False
                        ' .XrLabelVatNo.Visible = False
                        .XrPictureBox1.Visible = False
                    End If

                End With
                Report.PrintingSystem.ShowMarginsWarning = False
                If _Preview = True And _PDF = False Then
                    Report.ShowPreview()
                End If
                If _PDF = True Then
                    Report.ExportToPdf("Document.pdf")
                End If
                If _Preview = False And _PDF = False Then
                    Report.Print()
                End If
                'If IsOrigional = True Then
                '    Report.Print()
                'Else
                '    Report.ShowPreview()
                'End If
        End Select


        'If ShowPrintPreview = False Then
        '  Report.Print()
        ' Else
        ''  StockReportViwer.Show()
        ' Report.Print(printerName:="Brother MFC-L2710DN series Printer")



        ' End If
    End Sub

    Public Function GetAccountForMoneyTrans(_DocName As Integer, _DocID As Integer) As (AccountID As String, AccountName As String)
        Dim _AccountID As String
        Dim _AccountName As String
        _AccountID = "0"
        _AccountName = "0"
        Dim sql As New SQLControl
        Dim sqlstring As String
        Try
            Select Case _DocName
                Case 3
                    sqlstring = "   Select top(1) DebitAcc as AccountID, A.AccName As AccountName  
                                From journal J
                                Left join FinancialAccounts A  on J.DebitAcc = A.AccNo
                                Where DocName=" & _DocName & " And DebitAcc <>'0'  and DocID=" & _DocID
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                    _AccountID = sql.SQLDS.Tables(0).Rows(0).Item("AccountID")
                    _AccountName = sql.SQLDS.Tables(0).Rows(0).Item("AccountName")
            End Select
        Catch ex As Exception
            _AccountID = ""
            _AccountName = ""
        End Try

        Return (_AccountID, _AccountName)
    End Function
    Public Sub PrintDocDetails(_DocCode As String, _DocData As String)
        Dim TheDocData = GetDocDataByDocCode(_DocCode, _DocData)
        Dim _DocName As Integer
        _DocName = TheDocData.DocName
        Dim _MyCompanyData = GetCompanyData()
        Select Case _DocName
            Case 1, 2, 12, 13, 17, 18
                Dim Report As New StockInvoiceReportDetails
                With Report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    ' .Parameters("DocType").Value = DocType.Text
                    ' .Parameters("DocSort").Value = DocSort.EditValue
                    Select Case _DocName
                        Case "2"
                            .XrLabelDocName.Text = " تفاصيل سند المبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "1"
                            .XrLabelDocName.Text = " تفاصيل سند المشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "12"
                            .XrLabelDocName.Text = " تفاصيل سند مردودات مبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "13"
                            .XrLabelDocName.Text = " تفاصيل سند مردودات مشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "17"
                            .XrLabelDocName.Text = " تفاصيل سند ادخال بضاعة"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "18"
                            .XrLabelDocName.Text = " تفاصيل سند اخراج بضاعة"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                    End Select
                    .Parameters("SalesPersonName").Value = TheDocData.SalesPersonName
                    '.XrTableCell30.Value = 0
                    ' .XrTableCell31.Value = 0
                    .Parameters("DebitWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .Parameters("CreditWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    If _MyCompanyData.CompanyMobile <> "" Then
                        .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    Else
                        .XrLabel22.Visible = False
                    End If
                    If _MyCompanyData.CompanyPhone <> "" Then
                        .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    Else
                        .XrLabel23.Visible = False
                    End If
                    If _MyCompanyData.CompanyVAT <> "" Then
                        .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    Else
                        .XrLabel17.Visible = False
                    End If
                    .XrLabel5.Text = TheDocData.DocNotes

                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                End With
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.ShowPreview()

            Case 10, 11
                Dim Sql As New SQLControl
                Sql.SqlTrueAccountingRunQuery(" select OrdersJournal.DocID, OrdersJournal.DocDate,
       OrdersJournal.DocName, OrdersJournal.DebitAcc,       OrdersJournal.CredAcc,
       OrdersJournal.AccountCurr,       OrdersJournal.DocCurrency,
       OrdersJournal.DocAmount, OrdersJournal.StockID,       OrdersJournal.StockUnit,
       OrdersJournal.StockQuantity,OrdersJournal.BonusQuantity,OrdersJournal.BonusQuantityByMainUnit,OrdersJournal.StockQuantityByMainUnit,
       OrdersJournal.StockPrice,       OrdersJournal.StockItemPrice,
       OrdersJournal.StockDebitWhereHouse,       OrdersJournal.StockCreditWhereHouse,
       OrdersJournal.ItemName, OrdersJournal.DocNotes,       Units.name as UnitName,
       Items.ItemImage, case when       (OrdersJournal.StockBarcode = N'0') then N''
       else OrdersJournal.StockBarcode       end as StockBarcode
  from ((dbo.OrdersJournal OrdersJournal  inner join dbo.Units Units
       on (Units.id = OrdersJournal.StockUnit))  inner join dbo.Items Items
       on (Items.ItemNo = OrdersJournal.StockID)) where ((OrdersJournal.DocID = " & TheDocData.DocID & ")
       and (OrdersJournal.DocName = " & _DocName & ")       and (OrdersJournal.StockID <> N'0')) ")
                Dim report As New StockOrderReportDetails() With {.DataSource = Sql.SQLDS.Tables(0)}
                With report
                    .Parameters("DocID").Value = TheDocData.DocID
                    .Parameters("DocName").Value = _DocName
                    Select Case _DocName
                        Case "10"
                            .XrLabelDocName.Text = " تفاصيل سند طلبية المشتريات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                        Case "11"
                            .XrLabelDocName.Text = " تفاصيل سند طلبية المبيعات"
                            .Parameters("Account").Value = TheDocData.ReferanceName
                            .Parameters("AccountID").Value = TheDocData.Referance
                    End Select
                    .Parameters("DebitWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .Parameters("CreditWhereHouse").Value = GetWhareHouseByDocCode(_DocName, _DocCode).WahreHouse
                    .XrLabel6.Text = _MyCompanyData.CompanyName
                    .XrLabel7.Text = _MyCompanyData.CompanyAddress
                    If _MyCompanyData.CompanyMobile <> "" Then
                        .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
                    Else
                        .XrLabel22.Visible = False
                    End If
                    If _MyCompanyData.CompanyPhone <> "" Then
                        .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
                    Else
                        .XrLabel23.Visible = False
                    End If
                    If _MyCompanyData.CompanyVAT <> "" Then
                        .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT
                    Else
                        .XrLabel17.Visible = False
                    End If
                    .XrLabel5.Text = TheDocData.DocNotes

                    Try
                        Dim cn As SqlConnection
                        cn = New SqlConnection
                        cn.ConnectionString = My.Settings.TrueTimeConnectionString
                        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                        cn.Open()
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                        .XrPictureBox1.Image = Image.FromStream(ImgStream)
                        ImgStream.Dispose()
                        cmd.Connection.Close()
                        cn.Close()
                    Catch ex As Exception

                    End Try

                End With
                report.PrintingSystem.ShowMarginsWarning = False
                report.ShowPreview()
        End Select


        'If ShowPrintPreview = False Then
        '  Report.Print()
        ' Else
        ''  StockReportViwer.Show()
        ' Report.Print(printerName:="Brother MFC-L2710DN series Printer")



        ' End If
    End Sub

    Public Sub PrintDebitCreditDoc(IsOrigional As Boolean, _DocName As String, _DocID As Integer, _DocDate As String,
                                   _ReferanceNo As String, _ReferanceName As String, _AccountNo As String, _AccountName As String,
                                   _DocNote As String, _InputdateTime As String, _InputUser As String)

        Dim _MyCompanyData = GetCompanyData()
        Dim Report As New DebitCreditNotesReport
        With Report
            .Parameters("DocID").Value = _DocID
            .Parameters("DocName").Value = _DocName
            .Parameters("DocDate").Value = _DocDate
            If IsOrigional = True Then .DocOriginal.Text = "أصلية"
            Select Case _DocName
                Case "6"
                    .XrLabelDocName.Text = " اشعار مدين"
                Case "7"
                    .XrLabelDocName.Text = " اشعار دائن"
            End Select

            .XrLabelNotes.Text = _DocNote
            .XrLabelRefNo.Text = _ReferanceNo
            .XrLabelRefName.Text = _ReferanceName
            .XrLabelAccountNo.Text = _AccountNo
            .XrLabelAccountName.Text = _AccountName
            .XrLabelnputDateTime.Text = _InputdateTime
            .XrLabelInputUser.Text = _InputUser


            .XrLabel6.Text = _MyCompanyData.CompanyName
            .XrLabel7.Text = _MyCompanyData.CompanyAddress
            .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
            .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
            .XrLabel17.Text = " مشتغل مرخص " & " : " & _MyCompanyData.CompanyVAT

            Try
                Dim cn As SqlConnection
                cn = New SqlConnection
                cn.ConnectionString = My.Settings.TrueTimeConnectionString
                Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                .XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception

            End Try
            '  .Parameters("Driver").Value = StockDriver.Text
            ' .Parameters("SalesPerson").Value = SalesPerson.EditValue
            ' .Parameters("SalesPersonName").Value = SearchSalesPerson.Text
        End With

        '   Report.CreateDocument()
        Report.PrintingSystem.ShowMarginsWarning = False
        If IsOrigional = True Then
            Report.Print()
        Else
            Report.ShowPreview()
        End If

        'If ShowPrintPreview = False Then
        '  Report.Print()
        ' Else
        ''  StockReportViwer.Show()
        ' Report.Print(printerName:="Brother MFC-L2710DN series Printer")



        ' End If
    End Sub
    Public Function GetJournalForTrans(DocName As Integer, DocID As Integer) As DataTable
        Dim _Table As New DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        Try
            'SqlString = "   SELECT    J.[ID],[DocID],[DocDate],N.Name as DocName ,
            '                      Case when [DebitAcc]<> '0' then A.AccName End as DebitAcc,
            '                      Case when [CredAcc]<> '0' then AA.AccName End as CredAcc  ,C.Code as DocCurrency,
            '                      DocAmount,[ExchangePrice],
            '                      BaseCurrAmount ,
            '                      ReferanceName,[DocManualNo],[InputUser],DocNotes,X.[CostName] as DocCostCenter
            '                   from [Journal] J
            '                   left join [FinancialAccounts] A	  on A.AccNo=J.DebitAcc
            '                   left join [FinancialAccounts] AA	  on AA.AccNo=J.CredAcc
            '                   left Join DocNames N on N.id=J.DocName 
            '                   Left Join Referencess R on R.RefNo=J.Referance 
            '                   left Join Currency C on C.CurrID=J.DocCurrency 
            '                      left Join [CostCenter] X on X.CostID=J.DocCostCenter 
            '            Where  [DocID]=" & DocID & " AND DocName=" & DocName
            SqlString = "   SELECT    J.[ID],[DocID],[DocDate],N.Name as DocName ,
                                      Case when [DebitAcc]<> '0' then A.AccName
                                      when [CredAcc]<> '0' then AA.AccName End as Account,
Case when [DebitAcc]<> '0' then  DocAmount end as DebitAmount ,
Case when [CredAcc] <> '0' then  DocAmount end as CreditAmount ,
                                  C.Code as DocCurrency,
                                  DocAmount,[ExchangePrice],
                                  BaseCurrAmount ,
                                  ReferanceName,[DocManualNo],[InputUser],DocNotes,X.[CostName] as DocCostCenter
	                              from [Journal] J
	                              left join [FinancialAccounts] A	  on A.AccNo=J.DebitAcc
	                              left join [FinancialAccounts] AA	  on AA.AccNo=J.CredAcc
	                              left Join DocNames N on N.id=J.DocName 
	                              Left Join Referencess R on R.RefNo=J.Referance 
	                              left Join Currency C on C.CurrID=J.DocCurrency 
                                  left Join [CostCenter] X on X.CostID=J.DocCostCenter 
                        Where  [DocID]=" & DocID & " AND DocName=" & DocName & " Order By OrderID "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    Public Function CheckIfBarcodeFound(_Barcode As String) As Boolean
        Dim _Result As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select top 1 item_unit_bar_code,id from [dbo].[Items_units] where item_unit_bar_code =N'" & _Barcode & "'")
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Result = True
            Else
                _Result = False
            End If
        Catch ex As Exception
            _Result = False
        End Try
        Return _Result
    End Function
    Public Function GetItemShelfLocationByBarcode(ItemBarcode As String, ItemNo As Integer, ShowAllBarcodes As Boolean, WahreHouse As Integer, GroupByBarcode As Boolean) As DataTable
        Dim _Table As New DataTable

        Try
            If String.IsNullOrEmpty(ItemBarcode) And ItemNo = 0 Then Return _Table
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "
                         Declare @ItemBarCode varchar(50);
                         Declare @ItemNo int;
                         Declare @Shelve int;
                         Declare @WahreHouse as int;
                         Set  @WahreHouse=" & WahreHouse & ";
                         Set @ItemBarCode='" & ItemBarcode & "';
                         "
            If ItemNo = 0 Then
                SqlString += " Set @ItemNo= (Select top(1) item_id  from Items_units where item_unit_bar_code=@ItemBarCode) ;"
            Else
                SqlString += " Set @ItemNo= " & ItemNo & ";"
            End If


            SqlString += "Select ID into #Temp from
					     (Select DISTINCT  StockDebitShelve as ID  from Journal where StockDebitShelve<>0 And StockID =@ItemNo
						 union 
						 Select DISTINCT  StockCreditShelve as ID  from Journal where StockCreditShelve<>0 And StockID =@ItemNo) A;

                         Declare @Id int;
               
                         While (Select Count(*) From #Temp) > 0
                         Begin

                         Select Top 1 @Id = Id From #Temp; 

                         Set @Shelve=@Id;"


            SqlString += " Insert Into ShelvesReportTemp (StockID,ItemName,ShelvID,balance,ItemNo2,UserID,Barcode)
                         SELECT StockID,I.ItemName As ItemName , @Shelve As ShelvID,
                         isnull(sum(case when StockDebitShelve  = @Shelve then [StockQuantityByMainUnit] end),0) -isnull(sum(case when StockCreditShelve  = @Shelve then [StockQuantityByMainUnit] end) ,0) as balance,
                         I.ItemNo2," & GlobalVariables.CurrUser
            If GroupByBarcode = True Then
                SqlString += " ,J.StockBarcode  "
            Else
                SqlString += " ,'0' as StockBarcode "
            End If
            SqlString += "     
                         FROM [Journal] J
                         left join Items I on I.ItemNo=J.StockID
                         where DocStatus<>0 and StockID > '0' and I.itemNo=@ItemNo And I.[Type]=0 and (StockDebitShelve= @Shelve or StockCreditShelve =@Shelve)"

            SqlString += " Group by StockID,I.ItemName,I.ItemNo2 "
            If GroupByBarcode = True Then
                SqlString += " ,J.StockBarcode  "
            End If

            SqlString += " 
   
                         Delete #Temp Where Id = @Id;

                         End

                         Drop Table #Temp;

                        Select StockID,ItemName,ShelvID,balance,S.ShelfCode ,w.WarehouseNameAR,ItemNo2,Barcode
                        From ShelvesReportTemp R 
                        Left Join FinancialShelves S on R.ShelvID=S.ShelfID
                        left join Warehouses W on w.WarehouseID=S.WareHouseID 
                         Where  balance <> 0 And UserID=" & GlobalVariables.CurrUser & " And W.WarehouseID =@WahreHouse "
            If ShowAllBarcodes = False And ItemNo = 0 Then SqlString += " and  Barcode='" & ItemBarcode & "'"
            SqlString += " Delete from ShelvesReportTemp where  UserID= " & GlobalVariables.CurrUser
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return _Table

    End Function
    Public Function GetItemBalanceByShelf(itemNo As Integer, shelf As Integer) As Decimal
        Dim balance As Decimal
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select isnull(sum(case when StockDebitShelve  = " & shelf & " then [StockQuantityByMainUnit] end),0) -isnull(sum(case when StockCreditShelve  = " & shelf & " then [StockQuantityByMainUnit] end) ,0) as balance
                     From [Journal] J
                     where DocStatus<>0 and StockID=" & itemNo & " and (StockDebitShelve= " & shelf & " or StockCreditShelve =" & shelf & ")"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                balance = Sql.SQLDS.Tables(0).Rows(0).Item("balance")
            Else
                balance = 0
            End If
        Catch ex As Exception
            balance = 0
        End Try
        Return balance
    End Function
    Public Function InsertSerialsToTempWhenOpenDoc(DocCode As String, DocName As Integer) As Boolean
        Dim Sql As New SQLControl
        Dim SqlString1 As String
        Dim _Result As Boolean = False
        Select Case DocName
            Case 1, 2, 17, 18, 16
                SqlString1 = " Insert Into [ItemsSerialTransTemp] (
                                 TransIDInSerialTrans,[SerialNumber],[DocCode],[ItemNo],[SerialID],
                                 UserNo,[SerialDebitWhereHouse],[SerialCreditWhereHouse],[DocName],
                                 [DocDate],[AddedDate],[AddedUser],[Notes],[DocNo],TempTransType,
                                 [PurchaseWarrantyStart] ,[PurchaseWarrantyEnd],[SaleWarrantyStart] ,[SaleWarrantyEnd],IDInSerials,SerialStatus) 
                              Select  T.TransID,T.[SerialNumber],T.[DocCode],T.[ItemNo],T.[SerialID],'" & GlobalVariables.CurrUser & "' ,
                              T.[SerialDebitWhereHouse],T.[SerialCreditWhereHouse],T.[DocName],T.[DocDate],T.[AddedDate],T.[AddedUser],
                              T.[Notes],T.[DocNo],'Update',S.[PurchaseWarrantyStart] ,S.[PurchaseWarrantyEnd],S.[SaleWarrantyStart] ,S.[SaleWarrantyEnd],S.ID ,S.SerialStatus
                              From [ItemsSerialTrans] T 
                              left join ItemsSerials S On S.SerialNumber=T.SerialNumber and S.ItemNo = T.ItemNo
                              Where T.DocCode='" & DocCode & "'"
                _Result = Sql.SqlTrueAccountingRunQuery(SqlString1)
        End Select
        Return _Result
    End Function
    Public Function CheckIfDocOpend(DocCode As String) As Boolean
        Dim _Count As Integer
        Dim SQl As New SQLControl
        Dim SqlString As String
        Try
            SqlString = " Select IsNull(count(TransID),0) as Count from [ItemsSerialTransTemp] where DocCode='" & DocCode & "'"
            SQl.SqlTrueAccountingRunQuery(SqlString)
            _Count = SQl.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _Count = 0
        End Try
        If _Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ClearTempTables(DocCode As String)
        If GlobalVariables._UseSerials = True Then
            Dim Sql As New SQLControl
            Dim SqlString As String
            If String.IsNullOrEmpty(DocCode) Then
                SqlString = " Delete from ItemsSerialTransTemp where UserNo='" & GlobalVariables.CurrUser & "'"
            Else
                SqlString = "Delete from ItemsSerialTransTemp where UserNo='" & GlobalVariables.CurrUser & "' And DocCode like '%" & DocCode & "%'"
            End If
            Sql.SqlTrueAccountingRunQuery(SqlString)
        End If
    End Sub

    Public Function GetSerialStatusTable() As DataTable
        Dim Sr As New DataTable
        Sr.Columns.Add("ID", GetType(Integer))
        Sr.Columns.Add("SerialStatus", GetType(String))
        Sr.Rows.Add(-1, "الكل")
        Sr.Rows.Add(0, "جديد")
        Sr.Rows.Add(1, "متوفر")
        Sr.Rows.Add(2, "مباع")
        Sr.Rows.Add(3, "ملغي")
        Return Sr
    End Function

    Public Sub CeateOrderTable()
        Try
            _OrderTable.Columns.Add("StockID", GetType(Integer))
            _OrderTable.Columns.Add("StockBarcode", GetType(String))
            _OrderTable.Columns.Add("ItemNo2", GetType(String))
            _OrderTable.Columns.Add("ItemName", GetType(String))
            _OrderTable.Columns.Add("StockUnit", GetType(Integer))
            _OrderTable.Columns.Add("StockQuantity", GetType(Decimal))
            _OrderTable.Columns.Add("BonusQuantity", GetType(Decimal))
            _OrderTable.Columns.Add("BonusQuantityByMainUnit", GetType(Decimal))
            _OrderTable.Columns.Add("StockPrice", GetType(Decimal))
            _OrderTable.Columns.Add("StockDiscount", GetType(Decimal))
            _OrderTable.Columns.Add("DocAmount", GetType(Decimal))
            _OrderTable.Columns.Add("StockQuantityByMainUnit", GetType(Decimal))
            _OrderTable.Columns.Add("DocCostCenter", GetType(Integer))
            _OrderTable.Columns.Add("VoucherDiscount", GetType(Decimal))
            _OrderTable.Columns.Add("ItemVAT", GetType(Decimal))
        Catch ex As Exception

        End Try
        'Sr.Rows.Add(-1, "الكل")
        'Sr.Rows.Add(0, "جديد")
        'Sr.Rows.Add(1, "متوفر")
        'Sr.Rows.Add(2, "مباع")
        'Sr.Rows.Add(3, "ملغي")
        'Return Sr
    End Sub
    Public Sub CreateDocLog(LogType As String, DocCode As String, DocName As Integer, DocID As Integer, LogName As String,
                            LogDetails As String, LogDateTime As String)
        ' Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType])
     VALUES
           ('" & DocCode & "'
           ,'" & DocName & "'
           ,'" & DocID & "'
           ,'" & LogName & "'
           ,'" & GlobalVariables.CurrUser & "'
           ,'" & LogDateTime & "'
           ,'" & GlobalVariables.CurrDevice & "'
           ,N'" & GlobalVariables.EmployeeName & "'
           ,N'" & LogDetails & "'
           ,'" & LogType & "')"
        Sql.SqlTrueAccountingRunQuery(SqlString)
    End Sub

    Public Function GetDocumentsLogs(DocCode As String, DocName As Integer) As DataTable
        Dim _LogsTable As New DataTable
        Dim Sql As New SQLControl
        Try
            Dim SqlString As String = " SELECT    U.[ID] As LogID
                                             ,[DocCode]      ,N.Name As DocName
                                             ,[DocID]      ,[LogName]
                                             ,[UserID]	  ,[UserName]
                                             ,[LogDateTime]      ,[DeviceName]
                                             ,[LogDetails]      ,[LogType],U.DocName as DocNameID
                                     FROM [dbo].[UsersLogs] U
                                     Left join DocNames N on N.id=U.DocName Where 1=1 "

            If DocCode <> "--1" Then SqlString += " And DocCode='" & DocCode & "'"

            If DocName <> -1 Then SqlString += " And U.DocName='" & DocName & "'"


            SqlString += " Order By U.[ID] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Return Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetItemsHaveProductionEquation() As DataTable
        Dim _Items As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select ItemNo,ItemName from Items where HasProductionEquation=1 and  ItemStatus=1 "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Items = sql.SQLDS.Tables(0)
            End If
        Catch ex As Exception

        End Try
        Return _Items
    End Function


    Public Function GetItemBalance(ItemNo As Integer, Warehouse As Integer) As Decimal
        Dim _Balance As Decimal
        Dim sqlstring As String
        Dim sql As New SQLControl
        Dim _type As Integer = GetItemType(ItemNo)
        If _type = 0 Then
            Select Case Warehouse
                Case <> -1
                    sqlstring = "   Select Sum(Quantity) as Quantity from 
                        (select sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & ItemNo & " and StockDebitWhereHouse=" & Warehouse & " And DocStatus<>0
                        Union All
                        select -1 * sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & ItemNo & " and StockCreditWhereHouse=" & Warehouse & " And DocStatus<>0 ) A "
                Case Else
                    sqlstring = "   Select Sum(Quantity) as Quantity from 
                        (select sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & ItemNo & "  And DocStatus<>0
                        Union All
                        select -1 * sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & ItemNo & "  And DocStatus<>0 ) A "
            End Select
            Try
                sql.SqlTrueAccountingRunQuery(sqlstring)
                _Balance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Quantity"))
            Catch ex As Exception
                _Balance = 0
            End Try
        Else
            _Balance = 99999999
        End If

        Return _Balance
    End Function
    Public Function GetItemType(_ItemNo As Integer) As Integer
        Dim _type As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select [Type] from Items where ItemNo='" & _ItemNo & "'"
        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _type = sql.SQLDS.Tables(0).Rows(0).Item("Type")
        Catch ex As Exception
            _type = 0
        End Try
        Return _type
    End Function
    Public Function GetPrintingProperites(_DocName As String) _
        As (Margins_Top As Decimal, Margins_Bottom As Decimal, Margins_Right As Decimal, Margins_Left As Decimal)
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim ReportStatmentTop As Decimal = 50
        Dim ReportStatmentBottom As Decimal = 50
        Dim ReportStatmentRight As Decimal = 50
        Dim ReportStatmentLeft As Decimal = 50
        If _DocName = "AccountStatment" Then
            SqlString = "  Select [SettingValue] from [dbo].[Settings] where [SettingName]='ReportStatmentTop';
                       Select [SettingValue] from [dbo].[Settings] where [SettingName]='ReportStatmentBottom'; 
                       Select [SettingValue] from [dbo].[Settings] where [SettingName]='ReportStatmentRight';
                       Select [SettingValue] from [dbo].[Settings] where [SettingName]='ReportStatmentLeft'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            With sql.SQLDS
                ReportStatmentTop = .Tables(0).Rows(0).Item("SettingValue")
                ReportStatmentBottom = .Tables(1).Rows(0).Item("SettingValue")
                ReportStatmentRight = .Tables(2).Rows(0).Item("SettingValue")
                ReportStatmentLeft = .Tables(3).Rows(0).Item("SettingValue")
            End With
        End If
        Return (ReportStatmentTop, ReportStatmentBottom, ReportStatmentRight, ReportStatmentLeft)
    End Function
    Public Function GetEquationTableForItem(_ItemNo As Integer) As Integer
        Dim sqlstring As String
        Dim sql As New SQLControl
        Dim _EquationID As Integer
        Try
            sqlstring = "  select top(1) EquationID from [dbo].[ProductionEquation] where [ItemNo] = " & _ItemNo
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
        Return _EquationID
    End Function

    Public Function RefreshMoneyTransListForPayVouchers(_DocName As Integer) As DataTable
        Dim _DataTable As New DataTable
        If _DocName = 1 Or _DocName = 2 Or _DocName = 3 Or _DocName = 4 Or _DocName = 12 Or _DocName = 13 Or _DocName = 6 Or _DocName = 7 Or _DocName = 17 Or _DocName = 18 Then
            Dim SqlString As String
            Dim SQl As New SQLControl
            SqlString = " SELECT   J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,DocCode,
C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,
SUM(BaseAmount) AS BaseAmount,Sum(BaseCurrAmount) as BaseCurrAmount,Case when SUM(DocAmount) > 0 then SUM(BaseAmount)/SUM(DocAmount) end As ExchangePrice,
DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DocManualNo,R.ReferanceCode,E.EmployeeName As SalesPerson,DocStatus,DocID2 "
            SqlString += "  from journal J
                            left join DocNames N on N.id =J.DocName
                            left join Currency C on C.CurrID = J.DocCurrency 
                            left Join DocSorts S on S.SortID =J.DocSort
                            left join Referencess R on R.[RefNo] = J.Referance
                            Left Join EmployeesData E on E.EmployeeID = J.SalesPerson"
            SqlString += " where DocName = " & _DocName
            If _DocName = 4 Or _DocName = 1 Or _DocName = 10 Or _DocName = 12 Or _DocName = 7 Or _DocName = 17 Then SqlString += " and	 CredAcc<>'0' "
            If _DocName = 3 Or _DocName = 2 Or _DocName = 11 Or _DocName = 13 Or _DocName = 6 Or _DocName = 18 Then SqlString += " and	 DebitAcc<>'0' "
            SqlString += "  group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DocCode,DocManualNo,DocStatus,R.ReferanceCode,E.EmployeeName,DocID2 "
            If _DocName = 4 Or _DocName = 1 Or _DocName = 10 Or _DocName = 12 Or _DocName = 7 Or _DocName = 17 Then SqlString += ",CredAcc "
            If _DocName = 3 Or _DocName = 2 Or _DocName = 11 Or _DocName = 13 Or _DocName = 6 Or _DocName = 18 Then SqlString += ",DebitAcc"
            SqlString += " order by DocID DESC"
            SQl.SqlTrueAccountingRunQuery(SqlString)
            _DataTable = SQl.SQLDS.Tables(0)
        End If
        Return _DataTable
        '  GridControl1.DataSource = SQl.SQLDS.Tables(0)
        '  GridView1.BestFitColumns()
    End Function
    Public Sub TextEditSelectText(_textedit As TextEdit)
        If _textedit.Text <> "" Then
            _textedit.SelectionStart = 0
            _textedit.SelectionLength = _textedit.Text.Length
        End If
    End Sub

    Public Function GetBanksTable() As DataTable
        Dim table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT [ID]
      ,[BankNo]
      ,[BankName]
  FROM [dbo].[Bank]  ")
            table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return table
    End Function
    Public Function GetBanksBranches() As DataTable
        Dim table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT  [ID]
      ,[BranchNo]
      ,[BranchName]
      ,[BankID]
  FROM [dbo].[BankBranche] ")
            table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return table
    End Function

    Public Function GetPosTypes() As DataTable
        Dim table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [ID],[PosType] FROM [dbo].[AccountingPosTypes] ")
            table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return table
    End Function

    Public Function GetAccountingBranches()
        Dim table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [ID],[BranchName],[BranchNameE],[BranchCode]  FROM [dbo].[AccountingBranches] ")
            table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return table
    End Function
    Public Function GetAccountingPosNamesTable() As DataTable
        Dim table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [ID],[POSCode],[POSName],[CostCenter],[PrefixCode],
	                                            [BranchID],[Warehouse],[OnlineOnly],[Note1],
	                                            [Note2],[PaperSize],[OpenCashDrawerOnSave],[POSQr],
	                                            [ServerAddress],[DefaultPrinter],[Tickets],[UseDirectProduction],
	                                            [SamabaPos],[TempAccounting],[ItemsGroups],[PosType]
                                            FROM [dbo].[AccountingPOSNames] ")
            table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return table
    End Function

    Public Sub MsgBoxShowError(_Text)
        'Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
        'args.Caption = "خطأ"
        'args.Text = _Text
        'args.Buttons = New DialogResult() {DialogResult.OK}
        'args.Icon = System.Drawing.SystemIcons.[Error]
        'XtraMessageBox.Show(args)

        Dim args As New XtraMessageBoxArgs()
        args.HtmlTemplate.Assign(My.Forms.Main.HtmlTemplateCollection1(1))
        args.Text = _Text
        args.Caption = " خطأ "
        args.ImageOptions.SvgImage = My.Forms.Main.SvgImageCollection1(1)
        ' Other "args" settings
        XtraMessageBox.Show(args)

    End Sub

    Public Sub MsgBoxShowSuccess(_Text)
        'Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
        'Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
        'Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حفظ الاعدادات بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
        'XtraMessageBox.Show(args)

        'Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
        'Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
        'args.Caption = "تم"
        'args.Text = _Text
        'args.Buttons = New DialogResult() {DialogResult.OK}
        'args.Icon = Icon.FromHandle(bitmap.GetHicon())
        'XtraMessageBox.Show(args)

        'Dim bitmap As Bitmap = New Bitmap(My.Forms.Main.SvgImageCollection1(0))
        Dim args As New XtraMessageBoxArgs()
        args.HtmlTemplate.Assign(My.Forms.Main.HtmlTemplateCollection1(0))
        args.Text = _Text
        args.Caption = " رائع "
        args.ImageOptions.SvgImage = My.Forms.Main.SvgImageCollection1(2)
        ' Other "args" settings
        XtraMessageBox.Show(args)

    End Sub
    Public Sub PrintFinancialClaim(_DocID As Integer, _DocName As Integer, WithOldBalance As Boolean)

        Dim Report As New FinancialClaimReport
        With Report
            '   .Parameters("DocID").Value = New Integer() {1, 3}
            .Parameters("DocID").Value = _DocID
            .Parameters("DocName").Value = _DocName
            Dim _MyCompanyData = GetCompanyData()
            If _MyCompanyData.CompanyName = "" Then
                .XrLabel6.Visible = False
            Else
                .XrLabel6.Text = _MyCompanyData.CompanyName
            End If
            If _MyCompanyData.CompanyAddress = "" Then
                .XrLabel7.Visible = False
            Else
                .XrLabel7.Text = _MyCompanyData.CompanyAddress
            End If
            If _MyCompanyData.CompanyMobile = "" Then
                .XrLabel22.Visible = False
            Else
                .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
            End If
            If _MyCompanyData.CompanyPhone = "" Then
                .XrLabel23.Visible = False
            Else
                .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone
            End If

            .XrLabelDocDate.Text = Today()
            Dim _RefNo, _ReferanceName As String
            Dim _Amount As Decimal
            Dim _Currency As String
            Dim _ClaimText As String
            Dim _DocNote As String
            Dim _RefBalance As Decimal
            Dim _DocData = GetDocumentHeaderData(_DocID, _DocName)
            _ReferanceName = _DocData._ReferanceName
            .XrLabelRefName.Text = "السادة: " & _ReferanceName
            _RefNo = _DocData._RefNo
            _DocNote = _DocData._DocNote
            Dim _RefData = GetRefranceData(_RefNo)
            If _RefData._Address = "" Then
                .XrLabelAddress.Visible = False
            Else
                .XrLabelAddress.Text = "العنوان: " & _RefData._Address
            End If
            If _RefData.RefMobile = "" Then
                .XrLabelMobile.Visible = False
            Else
                .XrLabelMobile.Text = "موبايل: " & _RefData.RefMobile
            End If

            If _RefNo <> "" And WithOldBalance = True Then
                _RefBalance = GetReferanceBalance(_RefNo)
            Else
                _RefBalance = 0
            End If
            _Amount = _DocData._DocAmount
            _Currency = _DocData._DocCurrency
            '.XrLabelAddress.Text = _ref
            Try
                Dim cn As SqlConnection
                cn = New SqlConnection
                cn.ConnectionString = My.Settings.TrueTimeConnectionString
                Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                .XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception

            End Try
            _ClaimText = ""
            ' _ClaimText = " السادة:  "
            ' _ClaimText += _ReferanceName
            _ClaimText += " بناء على الموضوع أعلاه يرجى من حضرتكم تسديد مبلغ  "
            If WithOldBalance = True Then
                _ClaimText += CStr(_RefBalance.ToString("N2"))
                .XrLabelPrevBalance.Visible = True
                .XrLabelRequirdAmount.Visible = True
                .XrLabelPrevBalanceLabel.Visible = True
                .XrLabelRequirdAmountLabel.Visible = True
            Else
                _ClaimText += CStr(_Amount.ToString("N2"))
                .XrLabelPrevBalance.Visible = False
                .XrLabelRequirdAmount.Visible = False
                .XrLabelPrevBalanceLabel.Visible = False
                .XrLabelRequirdAmountLabel.Visible = False
            End If
            _ClaimText += " " + _Currency
            _ClaimText += " وذلك عن التفاصيل المرفقة أدناه "
            If CStr(_Amount) <> "" And CStr(_RefBalance) <> "" Then
                .XrLabelPrevBalance.Text = (CDec(_RefBalance) - CDec(_Amount)).ToString("N2")
                .XrLabelRequirdAmount.Text = CDec(_RefBalance).ToString("N2")
            Else
                .XrLabelPrevBalance.Text = ""
                .XrLabelRequirdAmount.Text = ""
            End If


            .XrLabelClaimDetails.Text = _ClaimText
            .XrLabelDocNotes.Text = _DocNote


        End With
        Report.PrintingSystem.ShowMarginsWarning = False
        Report.ShowPreview()
        ' Dim Sql As New SQLControl


    End Sub

    Public Function GetDocumentHeaderData(_DocID As Integer, _DocName As Integer) As _
        (_DocAmount As Decimal, _DocCurrency As String, _DocDate As String, _ReferanceName As String, _RefNo As String, _DocNote As String,
        _InputUserID As Integer, _InputDateTime As String)
        Dim __DocAmount As Integer = 0
        Dim __DocCurrency As String = ""
        Dim __ReferanceName As String = ""
        Dim __RefNo As String = ""
        Dim __DocNotes As String = ""
        Dim __InputUserID As Integer = 0
        Dim __InputDateTime As String = ""
        Dim __DocDate As String = ""
        Dim sqlString As String
        Dim sql As New SQLControl
        sqlString = " Select  top(1) DocAmount,C.name as CurrencyName,ReferanceName,Referance,J.DocNotes,InputUser,InputDateTime,J.DocDate
                      From Journal J 
                      left join Currency C on J.DocCurrency = C.CurrID  
                      Where DocName=" & _DocName & " and docid=" & _DocID & ""
        Select Case _DocName
            Case 2
                sqlString += "  and DebitAcc<>'0' "
            Case 4
                sqlString += "  and DebitAcc<>'0' "
        End Select

        Try
            sql.SqlTrueAccountingRunQuery(sqlString)
            With sql.SQLDS.Tables(0).Rows(0)
                If Not IsDBNull(.Item("DocAmount")) Then __DocAmount = .Item("DocAmount")
                If Not IsDBNull(.Item("CurrencyName")) Then __DocCurrency = .Item("CurrencyName")
                If Not IsDBNull(.Item("ReferanceName")) Then __ReferanceName = .Item("ReferanceName")
                If Not IsDBNull(.Item("Referance")) Then __RefNo = .Item("Referance")
                If Not IsDBNull(.Item("DocNotes")) Then __DocNotes = .Item("DocNotes")
                If Not IsDBNull(.Item("InputUser")) Then __InputUserID = .Item("InputUser")
                If Not IsDBNull(.Item("InputDateTime")) Then __InputDateTime = .Item("InputDateTime")
                If Not IsDBNull(.Item("DocDate")) Then __DocDate = .Item("DocDate")
            End With
        Catch ex As Exception
            __DocAmount = 0
            __DocCurrency = ""
            __ReferanceName = ""
            __RefNo = ""
            __DocNotes = ""
            __InputUserID = 0
            __InputDateTime = "1900-01-01"
            __DocDate = "1900-01-01"
        End Try

        Return (__DocAmount, __DocCurrency, __DocDate, __ReferanceName, __RefNo, __DocNotes, __InputUserID, __InputDateTime)
    End Function

    Public Function GetOrderDetails(_ItemNo As Integer) As (_Minimun As Decimal, _Maximum As Decimal, _Vendor As Integer)
        Dim __Minimun As Decimal = 0.0
        Dim __Maximum As Decimal = 0.0
        Dim __Vendor As Decimal = 0.0


        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT IsNull([ReOrderQuantity],0) as ReOrderQuantity ,IsNull([MaxQuantity],0) as MaxQuantity,IsNull([Vendor],0) as Vendor FROM [dbo].[Items] where ItemNo=" & _ItemNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ReOrderQuantity")) Then
                __Minimun = sql.SQLDS.Tables(0).Rows(0).Item("ReOrderQuantity")
            End If
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("MaxQuantity")) Then
                __Maximum = sql.SQLDS.Tables(0).Rows(0).Item("MaxQuantity")
            End If
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Vendor")) Then
                __Vendor = sql.SQLDS.Tables(0).Rows(0).Item("Vendor")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return (__Minimun, __Maximum, __Vendor)
    End Function
    Public Function GetCarRentDeials(_CarID As Integer) As (CarNo As String, TarkhesEndDate As String, _CarTypeDet As String, _DailyAmount As Integer)
        Dim _CarNo As Integer = 0
        Dim _TarkhesEndDate As String = "1900-01-01"
        Dim _CarTypeDet As String = ""
        Dim _DailyAmount As Decimal = 0
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  SELECT  [CarID]      ,[CARNO]      ,[ChassiNoCar]      ,C.[CarType] as MarkaCar     ,C.[CarModel] as ModelCar,CONCAT(M.CarModel , '-' , T.CarType) as CarTypeDet,
                              [YearCar]      ,[ColorCar]      ,[FuelsCar]      ,[ReferanceID]      ,[DatePurchase]      ,[CostCar],
                              [Vender]      ,[DateSale]      ,[SaleCar]      ,[Customer]      ,[CarImage] as  Picture   ,[SortCar],
                              [active]      ,[BegSpedometaer]      ,[CarDetails]      ,[Rented]      ,[MaintenanceAccountNo]      ,[AssetsAccountNo],[DailyAmount],
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsTarkhes] T   WHERE     T.CarID=C.[CarID]     ORDER BY [EndDate] desc) as TarkhesEndDate,
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsInsurance] I WHERE     I.CarID=C.[CarID]     ORDER BY [EndDate] desc) as InsuranceEndDat,
                              (SELECT top 1 [DocID] FROM [dbo].[CarRentDocuments] R WHERE   [DocStatus]=1  and R.CarID=C.[CarID]     ORDER BY [DocID] desc) as LastDocID
                    FROM [dbo].[CarsRent] C 					
                    left join CarsModel M on C.CarModel=M.CarModelID 
					left join CarsTypes T on C.CarType = T.CarTypeID  Where CarID=" & _CarID
            sql.SqlTrueAccountingRunQuery(SqlString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CARNO"))) Then _CarNo = sql.SQLDS.Tables(0).Rows(0).Item("CARNO")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate"))) Then _TarkhesEndDate = sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CarTypeDet"))) Then _CarTypeDet = sql.SQLDS.Tables(0).Rows(0).Item("CarTypeDet")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DailyAmount"))) Then _DailyAmount = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DailyAmount"))

        Catch ex As Exception

        End Try

        Return (_CarNo, _TarkhesEndDate, _CarTypeDet, _DailyAmount)
    End Function
    Public Sub CreateNewDocument(TextEditDocName As Integer, _RefNo As Integer, Amount As Decimal, Note As String, CloseAfterSave As Boolean)

        Select Case TextEditDocName
            Case 1, 17
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                '  f.DocName.EditValue = TextEditDocName
                '  ctr = ctr + 1
                ' f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = TextEditDocName
                    .DocName.Text = TextEditDocName
                    .Show()
                    .DocStatus.Text = -1
                    .LoadDefault()
                    If TextEditDocName = 1 Then .Text = "فاتورة مشتريات"
                    If TextEditDocName = 17 Then .Text = "سند ادخال بضاعة"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(TextEditDocName, True)
                    If TextEditDocName = 17 Then .AccountForRefranace.EditValue = "4020000000"
                End With

               ' f.Show()

            Case 2, 18
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                'f.DocName.EditValue = TextEditDocName
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 1
                    .DocName.Text = TextEditDocName
                    .Show()
                    .LoadDefault()
                    If TextEditDocName = 2 Then .Text = "فاتورة مبيعات"
                    If TextEditDocName = 18 Then .Text = "سند اخراج بضاعة"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(TextEditDocName, True)
                    If TextEditDocName = 18 Then .AccountForRefranace.EditValue = "4020000000"
                    If TextEditDocName = 2 Then .Referance.EditValue = _RefNo
                End With



            Case 12
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                'f.DocName.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 12
                    .DocName.Text = 12
                    .Show()
                    .LoadDefault()
                    .Text = "مردودات مبيعات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(12, True)

                End With

            Case 13
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                'f.DocName.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 13
                    .Show()
                    .LoadDefault()
                    .Text = "مردودات مشتريات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(13, True)

                End With

            Case 16
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                'f.DocName.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 16
                    .DocName.Text = 16
                    .Show()
                    .LoadDefault()
                    .Text = "ارسالية داخلية"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LayoutDebitHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    .LayoutCreditHouse.Text = "من مستودع"
                    .LayoutCreditHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    .LayoutDebitHouse.Text = "الى مستودع"
                    If GlobalVariables._WareHouseUseShelf = False Then
                        .ColStockDebitShelve.Visible = False
                        .ColStockCreditShelve.Visible = False
                    Else
                        .ColStockDebitShelve.VisibleIndex = 10
                        .ColStockCreditShelve.VisibleIndex = 9
                    End If
                    .ColStockDiscount.Visible = False
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .DocID.EditValue = GetDocNo(16, True)
                End With

            Case 19
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As ProductionDocument = New ProductionDocument()
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .Show()
                    .Text = "سند انتاج"
                    .TextNewOld.Text = "new"
                End With

            Case 3
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As MoneyTrans = New MoneyTrans()
                'f.TextDocID.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 3
                    .DocName.Text = 3
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "سند صرف"
                    .TextDocIDQuery.EditValue = -1
                    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .TextDocID.EditValue = GetDocNo(3, True)
                    .DocCashAmount.EditValue = Amount
                    .Referance.EditValue = _RefNo
                    .TextDocNotes.Text = Note
                    ._ForceCloseAfterSaved = CloseAfterSave
                End With
                ' f.Show()        
                f.TextMultiCurrency.Text = False

            Case 4
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As New MoneyTrans
                'f.TextDocID.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 4
                    .DocName.Text = 4
                    .Show()
                    .DocStatus.Text = -1
                    .TextDocIDQuery.EditValue = -1
                    .Text = "سند قبض"
                    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .TextDocID.EditValue = GetDocNo(4, True)
                    .DocCashAmount.EditValue = Amount
                    .Referance.EditValue = _RefNo
                    .TextDocNotes.Text = Note
                    ._ForceCloseAfterSaved = CloseAfterSave
                End With
                ' f.Show()
                f.TextMultiCurrency.Text = False

            Case 5
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As Journal = New Journal()
                'f.TextDocID.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .Show()
                    .DocName.EditValue = 5
                    .DocName.Text = 5
                    .DocStatus.Text = -1
                    .TextDocIDQuery.EditValue = -1
                    .Text = "سند قيد"
                    .TextDocID.EditValue = GetDocNo(5, True)
                    .BarButtonMaximize.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonMinimize.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonRestore.Visibility = XtraBars.BarItemVisibility.Never
                    .BarButtonMDI.Visibility = XtraBars.BarItemVisibility.Never
                    '  .LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                End With
               ' f.Show()
            Case 6
                'Dim ctr As Integer = 0
                'Dim child As Form = Nothing
                Dim f As CreditDebitNotes = New CreditDebitNotes()
                f.TextDocName.EditValue = TextEditDocName
                'ctr = ctr + 1
                With f
                    .TextDocStatus.EditValue = -1
                    .TextDocName.EditValue = TextEditDocName
                    .ShowDialog()
                    '  .TextDocID.EditValue = GetDocNo(TextEditDocName)
                End With
            Case 7
                'Dim ctr As Integer = 0
                'Dim child As Form = Nothing
                Dim f As CreditDebitNotes = New CreditDebitNotes()
                f.TextDocName.EditValue = TextEditDocName
                'ctr = ctr + 1
                With f
                    .TextDocStatus.EditValue = -1
                    .TextDocName.EditValue = TextEditDocName
                    .ShowDialog()
                    '  .TextDocID.EditValue = GetDocNo(TextEditDocName)
                End With

            Case 10
                'Dim ctr As Integer = 0
                'Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 10
                    .DocName.Text = 10
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "طلبية مشتريات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .SearchOrderStatus.EditValue = 0
                    .SearchOrderStatus.ReadOnly = True
                    .LoadDefault()
                    .DocID.EditValue = GetDocNo(10, True)
                End With
            Case 11
                'Dim ctr As Integer = 0
                'Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                'ctr = ctr + 1
                'f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 11
                    .DocName.Text = 11
                    .Show()
                    .DocStatus.Text = -1
                    .Text = "طلبية مبيعات"
                    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                    .SearchOrderStatus.EditValue = 0
                    .SearchOrderStatus.ReadOnly = True
                    .LoadDefault()
                    .DocID.EditValue = GetDocNo(11, True)
                End With

        End Select

        'DeleteFromJournalTemp(TextEditDocName, -1)

    End Sub
    Public Sub PaidVoucher(_DocID As Integer, DocName As Integer, PaidStatus As Integer, PaidAmount As Decimal, PaidByDocNo As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Journal Set
                      PaidStatus=" & PaidStatus & ",PaidAmount=" & PaidAmount & ",PaidByDocID=" & PaidByDocNo & " 
                      where DocID=" & _DocID & " and DocName=" & DocName
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub
    Public Sub UnPaidVoucher(_DocID As Integer, DocName As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Journal Set
                      PaidStatus=0,PaidAmount=0,PaidByDocID=0 
                      where DocID=" & _DocID & " and DocName=" & DocName
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub


    Public Enum ColorFormat
        NamedColor
        ARGBColor
    End Enum
    Public Function SerializeColor(ByVal color As Color) As String
        If color.IsNamedColor Then
            Return String.Format("{0}:{1}", ColorFormat.NamedColor, color.Name)
        Else
            Return String.Format("{0}:{1}:{2}:{3}:{4}", ColorFormat.ARGBColor, color.A, color.R, color.G, color.B)
        End If
    End Function
    Public Function CheckIfDocManualExisit(DocName As Integer, DocManualNo As String) As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select top(1) DocID from Journal 
                          where DocManualNo='" & DocManualNo & "' And DocName=" & DocName & " And DocStatus <> 0 "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return sql.SQLDS.Tables(0).Rows(0).Item("DocID")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function GetMaxNoForNewItem() As Integer
        Dim NewNo As Integer
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = "   select max(cast((CASE WHEN [ItemNo] NOT LIKE '%[^0-9]%' THEN [ItemNo] END) as int)) AS max  from [dbo].[Items] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            NewNo = Sql.SQLDS.Tables(0).Rows(0).Item("max")
        Catch ex As Exception
            NewNo = 0
        End Try
        NewNo += 1
        Return NewNo
    End Function
    Public Function GetLastPurchasePrice(_ItemNo As Integer, _UnitId As Integer) As Decimal
        Dim _LastPurchasePrice As Decimal
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select Case When IU.EquivalentToMain>0 then (LastPurchasePrice)/IU.EquivalentToMain Else 0 End As LastPurchasePrice 
                                            From Items I 
					                        Left Join  [dbo].[Items_units] IU on I.ItemNo=IU.item_id
                                            Where [ItemNo]=" & _ItemNo & " and [unit_id]=" & _UnitId)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _LastPurchasePrice = sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
            Else
                _LastPurchasePrice = 0
            End If
        Catch ex As Exception
            _LastPurchasePrice = 0
        End Try
        Return _LastPurchasePrice
    End Function
    Public Function GetLastPurchasePriceByAverage(_ItemNo As Integer, _UnitId As Integer) As Decimal
        Dim _PurchasePrice As Decimal
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Declare @ItemNo int
Declare @UnitID int
Declare @QuantityPerUnit float
Set @ItemNo=" & _ItemNo & "
Set @UnitID=" & _UnitId & "
Set @QuantityPerUnit = ( Select EquivalentToMain from Items_units Where item_id =@ItemNo And unit_id = @UnitID )
Select case when sum(StockQuantityByMainUnit) > 0 then Sum(BaseAmount)* @QuantityPerUnit / ( sum(StockQuantityByMainUnit) ) else 0 end As Average 
From Journal J
Left Join  [dbo].[Items_units] IU on J.StockID=IU.item_id and J.StockUnit=IU.unit_id
where StockID=@ItemNo And DocStatus <> 0 And DocName in (1,17,19) ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _PurchasePrice = sql.SQLDS.Tables(0).Rows(0).Item("Average")
            Else
                _PurchasePrice = 0
            End If
        Catch ex As Exception
            _PurchasePrice = 0
        End Try
        Return _PurchasePrice
    End Function
    Public Function UpdateItemsLastPurchasePrice(_Date As Date) As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String
        'Dim sqlstring As String = " UPDATE Items 
        '                            SET LastPurchasePrice = (SELECT  TOP 1 StockPrice  
        '                                                     FROM Journal 
        '                                                     WHERE Journal.StockID = Items.ItemNo And DocStatus<>0 
        '                                                           And Items.Type<>3 And DocName in (1,17) ORDER BY DocDate DESC)  "
        sqlstring = " DECLARE @Date DATE = '" & Format(_Date, "yyyy-MM-dd") & "';
UPDATE i
SET i.LastPurchasePrice = j.ComputedPrice
FROM Items i
CROSS APPLY (
    SELECT TOP 1 
        ((CASE 
            WHEN j.DocAmount > 0 THEN j.BaseCurrAmount / j.DocAmount 
            ELSE j.BaseCurrAmount 
         END) * j.StockPrice) 
        / (j.StockQuantityByMainUnit / j.StockQuantity) AS ComputedPrice
    FROM Journal j
    WHERE j.StockID = i.ItemNo
      AND j.DocStatus <> 0
      AND j.StockQuantity > 0
      AND j.StockQuantityByMainUnit > 0
      AND j.DocDate <= @Date
      AND j.DocName IN (1, 17, 19)
      AND j.StockDebitWhereHouse IS NOT NULL
      AND j.StockDebitWhereHouse <> 0
    ORDER BY j.DocDate DESC
) j
WHERE i.Type <> 3;
"

        Return sql.SqlTrueAccountingRunQuery(sqlstring)
    End Function

    Public Function UpdateItemsNetLastPurchasePrice(_Date As Date) As Boolean
        Dim sql As New SQLControl
        Dim sqlString As String
        'Dim sqlstring As String = " Declare @Date date
        '                            set @Date='" & Format(_Date, "yyyy-MM-dd") & "'
        '                            UPDATE Items 
        '                            SET LastNetPurchasePrice = (SELECT  TOP 1 ([BaseCurrAmount]/ABS([StockQuantityByMainUnit]))/(StockQuantityByMainUnit/StockQuantity ) 
        '                            FROM Journal 
        '                            WHERE Journal.StockID = Items.ItemNo And DocStatus<>0 And StockQuantity > 0 And StockQuantityByMainUnit>0 And DocDate <=@Date
        '                            And Items.Type<>3 And DocName in (1,17,19) And StockDebitWhereHouse <> 0 And StockDebitWhereHouse Is Not Null
        '                            ORDER BY DocDate DESC)"
        sqlString = " DECLARE @Date DATE = '" & Format(_Date, "yyyy-MM-dd") & "';
                        UPDATE i
                        SET i.LastNetPurchasePrice = j.NewNetPrice
                        FROM Items i
                        CROSS APPLY (
                            SELECT TOP 1 
                                (j.BaseCurrAmount / NULLIF(j.StockQuantityByMainUnit, 0)) AS NewNetPrice
                            FROM Journal j
                            WHERE j.StockID = i.ItemNo
                              AND j.DocStatus <> 0 
                              AND j.StockQuantity > 0 
                              AND j.StockQuantityByMainUnit > 0 
                              AND j.DocDate <= @Date
                              AND j.DocName IN (1, 17, 19)
                              AND j.StockDebitWhereHouse IS NOT NULL
                              AND j.StockDebitWhereHouse <> 0
                            ORDER BY j.DocDate DESC
                        ) j
                        WHERE i.Type <> 3;;        "
        Return sql.SqlTrueAccountingRunQuery(sqlstring)
    End Function

    Public Function GetPrintersDataTable() As DataTable
        ' Create a new DataTable to store printer information
        Dim printersDataTable As New DataTable()
        printersDataTable.Columns.Add("PrinterName", GetType(String))

        ' Get the list of installed printers
        Dim printerSettings As New PrinterSettings()
        For Each printer As String In printerSettings.InstalledPrinters
            printersDataTable.Rows.Add(printer)
        Next

        Return printersDataTable
    End Function

    Public Function SetTagsColor(_String) As String

        Dim _sstring As String = ""
        Dim parts As String() = _String.ToString().Split(","c)
        ' Define the colors
        Dim colors As String() = {"@WarningFill", "@Success", "@Critical", "@DisabledText", "@WarningFill", "@Success", "@Critical", "@DisabledText"}

        For i As Integer = 0 To parts.Length - 1
            Dim textPart As String = parts(i).Trim()
            ' Dim textColor As Color = colors(i Mod colors.Length)
            _sstring += "<b><backcolor=0,0,0,0>" & "" & "   </b>"
            _sstring += "<backcolor=" & colors(i + 1) & "><b><color=255, 255, 255>" & textPart & "   </b>"

        Next
        Return _sstring
    End Function
    Public Function CheckIfDocumentHasAttachment(_DocCode As String) As Boolean
        Dim _HasAttachment As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select top(1) DocID From [dbo].[ArchiveDocs] Where LinkDocNo=N'" & _DocCode & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _HasAttachment = True
            End If
        Catch ex As Exception
            _HasAttachment = False
        End Try
        Return _HasAttachment
    End Function
    Public Function GetItemsClassification() As DataTable
        Dim Sr As New DataTable
        Sr.Columns.Add("id", GetType(Integer))
        Sr.Columns.Add("Type", GetType(String))
        Sr.Rows.Add(1, "بضاعة")
        Sr.Rows.Add(2, "بضاعة مصنعة")
        Sr.Rows.Add(3, "مواد خام")
        Return Sr
    End Function
    Public Function IssueSalesOrPurchaseFromDispatch(ByVal dispatchDocName As Integer, ByVal docIDs As List(Of Integer), ByVal dispatchDocCode As String) As Integer
        Dim docName As Integer
        Dim docCode As String = CreateRandomCode()
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        If dispatchDocName = 8 Then
            docName = 1
        ElseIf dispatchDocName = 9 Then
            docName = 2
        End If
        Dim newDocID As Integer = 0
        Dim sql As StringBuilder = New StringBuilder()
        Try
            Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
                con.Open()

                ' بناء قائمة مع أسماء المعاملات الخاصة بالـ DocID لإستخدامها في عبارة IN.
                Dim docIDParams As New List(Of String)
                For i As Integer = 0 To docIDs.Count - 1
                    docIDParams.Add("@DocID" & i)
                Next
                Dim inClause As String = String.Join(",", docIDParams)

                ' تحديد تسلسل الوثيقة بناءً على قيمة dispatchDocName
                Dim sequenceSql As String
                If dispatchDocName = 8 Then
                    sequenceSql = "SET @NewDocID = NEXT VALUE FOR PurchaseInvoiceSeq; "
                ElseIf dispatchDocName = 9 Then
                    sequenceSql = "SET @NewDocID = NEXT VALUE FOR SalesInvoiceSeq; "
                Else
                    Throw New ArgumentException("Invalid dispatchDocName value")
                End If

                ' جملة الإدخال مع إعلان متغير @NewDocID على سطرين منفصلين.
                Dim insertSql As String =
                    "DECLARE @NewDocID INT; " & sequenceSql &
                    "INSERT INTO [dbo].[Journal] " &
                    "([DocID], [DocDate], [DocName], [DocStatus], [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency], [DocAmount], " &
                    "[ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], [InputUser], [InputDateTime], " &
                    "[ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], [StockQuantity], [StockQuantityByMainUnit], " &
                    "[StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], [StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], " &
                    "[CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], " &
                    "[CurrentUserID], [ReferanceName], [DocCode], [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], " &
                    "[StockDiscount], [StockBarcode], [PosNo], [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], [LastDocCode], [LastDataName], " &
                    "[DeliverDate], [Color], [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], " &
                    "[DocID2], [DocDueDate], [VoucherCounter], [AuditNote], [TarteebID], [LastPurchasePrice], [BatchID], [PaidStatus], [PaidAmount], [PaidByDocID], " &
                    "[BatchNo], [DocTags], [POSVoucherPayType], [HasAttachment], [BonusQuantity],[BonusQuantityByMainUnit], [OldTransID], [TableID], [RecordDateTime], " &
                    "[DispatchQuantity], [DispatchStockQuantityByMainUnit] ) " &
                    "OUTPUT @NewDocID " &
                    "SELECT @NewDocID, [DocDate], @DocName, 1, [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], " &
                    "[DocCurrency], [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], " &
                    "[InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], " &
                    "[StockQuantity], [StockQuantityByMainUnit], [StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], " &
                    "[StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], " &
                    "[CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], [CurrentUserID], [ReferanceName], @DocCode, [CheckCode], " &
                    "[ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], [StockDiscount], [StockBarcode], [PosNo], " &
                    "[DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], @DispatchDocCode, N'Journal', [DeliverDate], [Color], [Measure], " &
                    "[VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], [DocID2], [DocDueDate], " &
                    "[VoucherCounter], [AuditNote], [TarteebID], [LastPurchasePrice], [BatchID], [PaidStatus], [PaidAmount], [PaidByDocID], [BatchNo], " &
                    "[DocTags], [POSVoucherPayType], [HasAttachment], [BonusQuantity],[BonusQuantityByMainUnit], [OldTransID], [TableID], [RecordDateTime], " &
                    "[DispatchQuantity], [DispatchStockQuantityByMainUnit] " &
                    "FROM [dbo].[Journal] " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"

                Dim result As Object = Nothing
                Using insertCmd As New SqlCommand(insertSql, con)
                    insertCmd.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                    insertCmd.Parameters.AddWithValue("@DocName", docName)
                    insertCmd.Parameters.AddWithValue("@DispatchDocCode", dispatchDocCode)
                    insertCmd.Parameters.AddWithValue("@DocCode", docCode)
                    ' إضافة معامل لكل DocID في القائمة
                    For i As Integer = 0 To docIDs.Count - 1
                        insertCmd.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                    Next

                    result = insertCmd.ExecuteScalar()
                End Using

                If result IsNot Nothing Then
                    newDocID = Convert.ToInt32(result)
                    ' نقل الكميات الى الاعمدة الجديدة وادخال رقم الفاتورة التي صدرت
                    Dim updateSql As String =
                    "UPDATE [dbo].[Journal] " &
                    "SET [DispatchQuantity] = [StockQuantity], " &
                    "[DispatchStockQuantityByMainUnit] = [StockQuantityByMainUnit], " &
                    "[DispatchVoucherID] = @NewDocID, " &
                    "[OrderStatus] = 99 " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"
                    Using updateCmd As New SqlCommand(updateSql, con)
                        updateCmd.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                        updateCmd.Parameters.AddWithValue("@NewDocID", newDocID)
                        For i As Integer = 0 To docIDs.Count - 1
                            updateCmd.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                        Next
                        result = updateCmd.ExecuteScalar()
                    End Using
                    ' تصفير الكميات في الارسالية القديمة
                    updateSql =
                    "UPDATE [dbo].[Journal] " &
                    "SET [StockQuantity] = 0, " &
                    "[StockQuantityByMainUnit] = 0 " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"
                    Using updateCmd As New SqlCommand(updateSql, con)
                        updateCmd.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                        For i As Integer = 0 To docIDs.Count - 1
                            updateCmd.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                        Next
                        result = updateCmd.ExecuteScalar()
                    End Using
                    Console.WriteLine("تم إدراج سجل جديد بالـ DocID الجديد: " & newDocID.ToString())
                End If
            End Using
            For i As Integer = 0 To docIDs.Count - 1
                CreateDocLog("Document", dispatchDocCode, dispatchDocName, docIDs(i), "Update", "Approve Dispatch No." & docIDs(i).ToString & " To Voucher No." & newDocID.ToString, _LogDateTime)
                CreateDocLog("Document", docCode, docName, newDocID, "Insert", "New Voucher From Dispatch No." & newDocID.ToString, _LogDateTime)
            Next

        Catch ex As Exception
            Console.WriteLine("خطأ: " & ex.Message)
            newDocID = -1
        End Try

        Return newDocID
    End Function
    Public Sub PrintShalashItem(itemNo As String, barcode As String)
        If itemNo = "0" Then
            MsgBoxShowError("لا يمكن طباعة باركود فارغ")
            Return
        End If
        'Dim itemData = GetItemsData(itemNo, False)
        Dim repo As New ItemRepository()
        Dim itemData As ItemDetails = repo.GetItem(itemNo, False)

        Dim report As New ShalashItemDataLabel
        With report
            .XrLabelItemName.Text = itemData.ItemName
            Dim _len As Integer = 0
            _len = itemData.ItemName.Length
            Select Case _len
                Case < 14
                    .XrLabelItemName.Font = New Font("Arial", 24, FontStyle.Bold)
                Case < 50
                    .XrLabelItemName.Font = New Font("Arial", 20, FontStyle.Bold)
                Case Else
                    .XrLabelItemName.Font = New Font("Arial", 14, FontStyle.Bold)
            End Select
            .XrLabelItemNo2.Text = itemData.ItemNo2 & " / " & "OE. " & itemData.ItemNo4
            .XrBarCode.Text = barcode
            If GlobalVariables._Shalash Then
                .XrLabelDetails.Text = "P. " & ShalashNumbersToLetters(CInt(2 * itemData.LastPurchasePrice)) & " XS " & GetLastShelfNameByWahreHouse(itemNo, 1) & " / " & GetLastShelfNameByWahreHouse(itemNo, 3)
            Else
                .XrLabelDetails.Text = "P: " & itemData.Price1.ToString("n2") & "  " & GetLastShelfNameByWahreHouse(itemNo, 1) & "  " & GetLastShelfNameByWahreHouse(itemNo, 3)
            End If

            .XrLabelDateTime.Text = "Date: " & itemData.LastPurchaseDate & " ItemNo: " & itemNo
            'If CDate(itemData._LastPurchaseDate) < Today() Then

            'End If
            Dim days As Long
            If itemData.LastPurchaseDate = "0" Then
                itemData.LastPurchaseDate = "1900-01-01"
            End If
            days = DateDiff(DateInterval.Day, CDate(itemData.LastPurchaseDate), Today())
            If days > 10 Then
                report.BackColor = Color.Red
            Else
                report.BackColor = Color.White
            End If
            ' Set printer to a specific printer
            Dim F As New PrintItemBarcodeForShalash
            With F
                .TxtItemNo.Text = itemNo
                .TxtBarcode.Text = barcode
                .DateEditLastPurchaseDate.DateTime = CDate(itemData.LastPurchaseDate)
                .DocumentViewer1.DocumentSource = report
                .txtQuantity.Text = 1
                report.CreateDocument()
                .ShowDialog()
            End With
            'report.PrinterName = "itemsprinter2"
            'report.CreateDocument()    ' Optional: forces document generation first
            'report.Print()
        End With
    End Sub
    Public Function ShalashNumbersToLetters(number As String) As String
        Dim mapping() As String = {"E", "I", "S", "H", "R", "T", "A", "W", "M", "F"}
        Dim sb As New StringBuilder()

        For Each ch As Char In number
            If Char.IsDigit(ch) Then
                ' Convert digit-char to its integer value 0–9
                Dim idx As Integer = CInt(Char.GetNumericValue(ch))
                sb.Append(mapping(idx))
            Else
                Throw New ArgumentException($"Invalid character '{ch}'. Only digits 0–9 are allowed.")
            End If
        Next

        Return sb.ToString()
    End Function
    Public Function GetLastShelfNameByWahreHouse(itemNo As Integer, wahreHouse As Integer) As String
        Dim shelf As String = ""
        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = " SELECT TOP (1) S.ShelfCode  
                          FROM [dbo].[Journal] J  left join FinancialShelves S on J.StockDebitShelve=S.ShelfID   
                          WHERE  S.WareHouseID=" & wahreHouse & " AND J.StockID='" & itemNo & "' and DocStatus<>0 AND S.ShelfID Not IN (1396,1397)
                          ORDER BY DocID desc  "
            sql.SqlTrueAccountingRunQuery(sqlString)
            shelf = sql.SQLDS.Tables(0).Rows(0).Item("ShelfCode")
        Catch ex As Exception
            shelf = ""
        End Try
        Return shelf
    End Function




    Public Function IssueSalesOrPurchaseFromDispatch2(ByVal dispatchDocName As Integer, ByVal docIDs As List(Of Integer), ByVal dispatchDocCode As String) As Integer
        Dim docName As Integer
        Dim docCode As String = CreateRandomCode()
        Dim logDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        ' تحديد قيمة DocName بناءً على dispatchDocName
        If dispatchDocName = 8 Then
            docName = 1 ' Purchase
        ElseIf dispatchDocName = 9 Then
            docName = 2 ' Sales
        Else
            Throw New ArgumentException("Invalid dispatchDocName value")
        End If

        Dim newDocID As Integer = 0

        Try
            Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
                con.Open()
                ' بناء قائمة مع أسماء المعاملات الخاصة بالـ DocID لإستخدامها في عبارة IN.
                Dim docIDParams As New List(Of String)
                For i As Integer = 0 To docIDs.Count - 1
                    docIDParams.Add("@DocID" & i)
                Next
                Dim inClause As String = String.Join(",", docIDParams)

                Using trans As SqlTransaction = con.BeginTransaction()
                    Try
                        ' تحديد تسلسل الوثيقة بناءً على النوع
                        Dim sequenceSql As String
                        If dispatchDocName = 8 Then
                            sequenceSql = "SELECT NEXT VALUE FOR PurchaseInvoiceSeq"
                        Else
                            sequenceSql = "SELECT NEXT VALUE FOR SalesInvoiceSeq"
                        End If

                        ' الحصول على رقم DocID الجديد
                        Using cmdSeq As New SqlCommand(sequenceSql, con, trans)
                            newDocID = Convert.ToInt32(cmdSeq.ExecuteScalar())
                        End Using

                        ' إدراج سجل جديد في جدول Journal
                        Dim insertSql As String =
                    "DECLARE @NewDocID INT; Set @NewDocID= " & newDocID & " " &
                    "INSERT INTO [dbo].[Journal] " &
                    "([DocID], [DocDate], [DocName], [DocStatus], [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency], [DocAmount], " &
                    "[ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], [InputUser], [InputDateTime], " &
                    "[ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], [StockQuantity], [StockQuantityByMainUnit], " &
                    "[StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], [StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], " &
                    "[CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], " &
                    "[CurrentUserID], [ReferanceName], [DocCode], [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], " &
                    "[StockDiscount], [StockBarcode], [PosNo], [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], [LastDocCode], [LastDataName], " &
                    "[DeliverDate], [Color], [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], " &
                    "[DocID2], [DocDueDate], [VoucherCounter], [AuditNote], [TarteebID], [LastPurchasePrice], [BatchID], [PaidStatus], [PaidAmount], [PaidByDocID], " &
                    "[BatchNo], [DocTags], [POSVoucherPayType], [HasAttachment], [BonusQuantity],[BonusQuantityByMainUnit], [OldTransID], [TableID], [RecordDateTime], " &
                    "[DispatchQuantity], [DispatchStockQuantityByMainUnit] ) " &
                    "OUTPUT @NewDocID " &
                    "SELECT @NewDocID, [DocDate], @DocName, 1, [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], " &
                    "[DocCurrency], [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], " &
                    "[InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], " &
                    "[StockQuantity], [StockQuantityByMainUnit], [StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], " &
                    "[StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], " &
                    "[CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], [CurrentUserID], [ReferanceName], @DocCode, [CheckCode], " &
                    "[ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], [StockDiscount], [StockBarcode], [PosNo], " &
                    "[DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], @DispatchDocCode, N'Journal', [DeliverDate], [Color], [Measure], " &
                    "[VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], [DocID2], [DocDueDate], " &
                    "[VoucherCounter], [AuditNote], [TarteebID], [LastPurchasePrice], [BatchID], [PaidStatus], [PaidAmount], [PaidByDocID], [BatchNo], " &
                    "[DocTags], [POSVoucherPayType], [HasAttachment], [BonusQuantity],[BonusQuantityByMainUnit], [OldTransID], [TableID], [RecordDateTime], " &
                    "[DispatchQuantity], [DispatchStockQuantityByMainUnit] " &
                    "FROM [dbo].[Journal] " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"

                        Using cmdInsert As New SqlCommand(insertSql, con, trans)
                            cmdInsert.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                            cmdInsert.Parameters.AddWithValue("@DocName", docName)
                            cmdInsert.Parameters.AddWithValue("@DispatchDocCode", dispatchDocCode)
                            cmdInsert.Parameters.AddWithValue("@DocCode", docCode)
                            For i As Integer = 0 To docIDs.Count - 1
                                cmdInsert.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                            Next
                            cmdInsert.ExecuteNonQuery()
                        End Using

                        ' تحديث تفاصيل الوثيقة وربطها بالـ DocID الجديد
                        Dim updateSql As String =
                    "UPDATE [dbo].[Journal] " &
                    "SET [DispatchQuantity] = [StockQuantity], " &
                    "[DispatchStockQuantityByMainUnit] = [StockQuantityByMainUnit], " &
                    "[DispatchVoucherID] = @NewDocID, " &
                    "[OrderStatus] = 99 " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"
                        Using cmdUpdate As New SqlCommand(updateSql, con, trans)
                            cmdUpdate.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                            cmdUpdate.Parameters.AddWithValue("@NewDocID", newDocID)
                            For i As Integer = 0 To docIDs.Count - 1
                                cmdUpdate.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                            Next
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        updateSql =
                    "UPDATE [dbo].[Journal] " &
                    "SET [StockQuantity] = 0, " &
                    "[StockQuantityByMainUnit] = 0 " &
                    "WHERE [DocName] = @DispatchDocName AND [DocID] IN (" & inClause & ")"
                        Using cmdUpdate As New SqlCommand(updateSql, con, trans)
                            cmdUpdate.Parameters.AddWithValue("@DispatchDocName", dispatchDocName)
                            For i As Integer = 0 To docIDs.Count - 1
                                cmdUpdate.Parameters.AddWithValue("@DocID" & i, docIDs(i))
                            Next
                            cmdUpdate.ExecuteNonQuery()
                        End Using



                        trans.Commit()
                        For i As Integer = 0 To docIDs.Count - 1
                            CreateDocLog("Document", dispatchDocCode, dispatchDocName, docIDs(i), "Update", "Approve Dispatch No." & docIDs(i).ToString & " To Voucher No." & newDocID.ToString, logDateTime)
                            CreateDocLog("Document", docCode, docName, newDocID, "Insert", "New Voucher From Dispatch No." & newDocID.ToString, logDateTime)
                        Next
                    Catch ex As Exception
                        trans.Rollback()
                        Throw New Exception("Transaction Failed: " & ex.Message)
                    End Try
                End Using
            End Using

            Return newDocID

        Catch ex As Exception
            Throw New Exception("Error In IssueSalesOrPurchaseFromDispatch: " & ex.Message)
        End Try
    End Function




End Module

Public Module AccountingVariables


End Module
