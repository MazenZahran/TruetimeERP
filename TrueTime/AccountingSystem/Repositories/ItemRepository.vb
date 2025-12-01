Public Class ItemRepository

    Public Function GetItem(searchNo As String, searchByBarcode As Boolean) As ItemDetails
        ' Empty/zero → return empty object (same logic as your original code)
        If String.IsNullOrEmpty(searchNo) OrElse searchNo = "0" Then
            Return CreateEmptyItem()
        End If

        Dim sql As New SQLControl()
        Dim query As String =
"SELECT TOP(1) I.id,
       ItemName,
       [Type],
       HasExpireDate,
       LastPurchasePrice,
       LastPurchaseDate,
       IU.Price1,
       IU.Price2,
       IU.Price3,
       ReOrderQuantity,
       AccSales,
       AccPurches,
       AccRetSales,
       AccRetPurches,
       unit_id AS DefaultUnit,
       notes,
       CategoryID,
       TradeMarkID,
       [GroupID],
       SaleOnScale,
       IU.item_unit_bar_code,
       I.ItemNo,
       IU.EquivalentToMain,
       Color,
       Measure,
       ItemNo2,
       ItemNo3,
       ItemNo4,
       ProductCompany,
       WebSite1,
       WebSite2,
       VisibleInAPP,
       HasSerial,
       HasProductionEquation,
       CostCenter,
       MaxQuantity,
       Vendor,
       classification,
       WithAdditions,
       UseBatchNo,
       SaleOnSamba,
       RequirePriceInPOS,
       PeriodType,
       PeriodCount,
       ISNULL(ItemColor,0) AS ItemColor,
       ISNULL(ItemSize,0) AS ItemSize,
       ISNULL(LastNetPurchasePrice,0) AS LastNetPurchasePrice,
       ISNULL(VisibleInPOS,1) AS VisibleInPOS,
       ISNULL(TaxPercentage,0) AS TaxPercentage
FROM Items I
LEFT JOIN Items_units IU ON I.ItemNo = IU.item_id "

        If Not searchByBarcode Then
            query &= " WHERE (ItemNo = '" & searchNo & "') AND main_unit = 1"
        Else
            query &= " WHERE (IU.item_unit_bar_code = '" & searchNo & "')"
        End If

        sql.SqlTrueAccountingRunQuery(query)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Return CreateEmptyItem()
        End If

        Dim row As DataRow = sql.SQLDS.Tables(0).Rows(0)
        Dim item As New ItemDetails()

        ' --- Safe mappings with same default behavior as your old code ---
        item.ItemName = If(IsDBNull(row("ItemName")), "0", row("ItemName").ToString())
        item.HasExpireDate = If(IsDBNull(row("HasExpireDate")), False, CBool(row("HasExpireDate")))
        item.LastPurchasePrice = If(IsDBNull(row("LastPurchasePrice")), 0D, CDec(row("LastPurchasePrice")))
        item.LastPurchaseDate = If(IsDBNull(row("LastPurchaseDate")), "0", row("LastPurchaseDate").ToString())

        item.Price1 = If(IsDBNull(row("Price1")), 0D, CDec(row("Price1")))
        item.Price2 = If(IsDBNull(row("Price2")), 0D, CDec(row("Price2")))
        item.Price3 = If(IsDBNull(row("Price3")), 0D, CDec(row("Price3")))

        item.AccSales = If(IsDBNull(row("AccSales")), "0", row("AccSales").ToString())
        item.AccPurches = If(IsDBNull(row("AccPurches")), "0", row("AccPurches").ToString())
        item.AccRetSales = If(IsDBNull(row("AccRetSales")), "0", row("AccRetSales").ToString())
        item.AccRetPurches = If(IsDBNull(row("AccRetPurches")), "0", row("AccRetPurches").ToString())

        item.DefaultUnit = If(IsDBNull(row("DefaultUnit")), 0, CInt(row("DefaultUnit")))
        item.ItemNote = If(IsDBNull(row("notes")), "0", row("notes").ToString())
        item.ItemType = If(IsDBNull(row("Type")), "0", row("Type").ToString())
        item.CategoryID = If(IsDBNull(row("CategoryID")), "0", row("CategoryID").ToString())
        item.TradeMarkID = If(IsDBNull(row("TradeMarkID")), 0, CInt(row("TradeMarkID")))
        item.GroupID = If(IsDBNull(row("GroupID")), 0, CInt(row("GroupID")))

        item.SaleOnScale = If(IsDBNull(row("SaleOnScale")), False, CBool(row("SaleOnScale")))
        item.UnitBarcode = If(IsDBNull(row("item_unit_bar_code")), "0", row("item_unit_bar_code").ToString())
        item.ItemNo = If(IsDBNull(row("ItemNo")), "0", row("ItemNo").ToString())
        item.EquivalentToMain = If(IsDBNull(row("EquivalentToMain")), 0D, CDec(row("EquivalentToMain")))

        item.Color = If(IsDBNull(row("Color")), 0, CInt(row("Color")))
        item.Measure = If(IsDBNull(row("Measure")), 0, CInt(row("Measure")))

        item.ItemNo2 = If(IsDBNull(row("ItemNo2")), String.Empty, row("ItemNo2").ToString())
        item.ItemNo3 = If(IsDBNull(row("ItemNo3")), String.Empty, row("ItemNo3").ToString())
        item.ItemNo4 = If(IsDBNull(row("ItemNo4")), String.Empty, row("ItemNo4").ToString())

        item.ProductCompany = If(IsDBNull(row("ProductCompany")), String.Empty, row("ProductCompany").ToString())
        item.WebSite1 = If(IsDBNull(row("WebSite1")), String.Empty, row("WebSite1").ToString())
        item.WebSite2 = If(IsDBNull(row("WebSite2")), String.Empty, row("WebSite2").ToString())

        item.MaxQuantity = If(IsDBNull(row("MaxQuantity")), 0D, CDec(row("MaxQuantity")))
        item.DefaultColor = CInt(row("ItemColor"))       ' already ISNULL() in SQL
        item.DefaultSize = CInt(row("ItemSize"))         ' already ISNULL() in SQL
        item.LastNetPurchasePrice = CDec(row("LastNetPurchasePrice"))
        item.VisibleInPOS = CBool(row("VisibleInPOS"))

        ' Same default logic as your code
        If IsDBNull(row("VisibleInAPP")) Then
            item.VisibleInAPP = True
        Else
            item.VisibleInAPP = CBool(row("VisibleInAPP"))
        End If

        item.ReOrderQuantity = If(IsDBNull(row("ReOrderQuantity")), 0D, CDec(row("ReOrderQuantity")))

        If IsDBNull(row("HasSerial")) Then
            item.HasSerial = True   ' your original default
        Else
            item.HasSerial = CBool(row("HasSerial"))
        End If

        If IsDBNull(row("HasProductionEquation")) Then
            item.HasProductionEquation = False
        Else
            item.HasProductionEquation = CBool(row("HasProductionEquation"))
        End If

        If IsDBNull(row("CostCenter")) Then
            item.CostCenter = 0
        Else
            item.CostCenter = CInt(row("CostCenter"))
        End If

        If IsDBNull(row("Vendor")) Then
            item.Vendor = 0
        Else
            item.Vendor = CInt(row("Vendor"))
        End If

        If IsDBNull(row("classification")) Then
            item.Classification = 1
        Else
            item.Classification = CInt(row("classification"))
        End If

        If IsDBNull(row("WithAdditions")) Then
            item.WithAdditions = False
        Else
            item.WithAdditions = CBool(row("WithAdditions"))
        End If

        If IsDBNull(row("UseBatchNo")) Then
            item.UseBatchNo = False
        Else
            item.UseBatchNo = CBool(row("UseBatchNo"))
        End If

        If IsDBNull(row("SaleOnSamba")) Then
            item.SaleOnSamba = False
        Else
            item.SaleOnSamba = CBool(row("SaleOnSamba"))
        End If

        If IsDBNull(row("RequirePriceInPOS")) Then
            item.RequirePriceInPOS = False
        Else
            item.RequirePriceInPOS = CBool(row("RequirePriceInPOS"))
        End If

        If IsDBNull(row("PeriodType")) Then
            item.PeriodType = String.Empty
        Else
            item.PeriodType = row("PeriodType").ToString()
        End If

        If IsDBNull(row("PeriodCount")) Then
            item.PeriodCount = 0D
        Else
            item.PeriodCount = CDec(row("PeriodCount"))
        End If

        item.TaxPercentage = CDec(row("TaxPercentage"))

        ' Load Units list only when not searching by barcode
        If Not searchByBarcode Then
            item.Units = LoadItemUnits(searchNo)
        Else
            item.Units = New List(Of ItemUnit)()
        End If

        Return item
    End Function

    Private Function LoadItemUnits(itemNo As String) As List(Of ItemUnit)
        Dim sql As New SQLControl()
        Dim query As String =
"SELECT id, unit_id, main_unit, EquivalentToMain, item_unit_bar_code, Price1
 FROM Items_units
 WHERE item_id = '" & itemNo & "'"

        sql.SqlTrueAccountingRunQuery(query)

        Dim units As New List(Of ItemUnit)()

        If sql.SQLDS.Tables.Count = 0 OrElse sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Return units
        End If

        For Each r As DataRow In sql.SQLDS.Tables(0).Rows
            Dim u As New ItemUnit() With {
                .Id = CInt(r("id")),
                .UnitId = CInt(r("unit_id")),
                .IsMainUnit = CBool(r("main_unit")),
                .EquivalentToMain = CDec(r("EquivalentToMain")),
                .Barcode = r("item_unit_bar_code").ToString(),
                .Price1 = CDec(r("Price1"))
            }
            units.Add(u)
        Next

        Return units
    End Function

    Private Function CreateEmptyItem() As ItemDetails
        Return New ItemDetails With {
            .ItemNo = "0",
            .ItemName = "0",
            .HasExpireDate = False,
            .LastPurchasePrice = 0D,
            .LastNetPurchasePrice = 0D,
            .Price1 = 0D,
            .Price2 = 0D,
            .Price3 = 0D,
            .AccSales = "0",
            .AccPurches = "0",
            .AccRetSales = "0",
            .AccRetPurches = "0",
            .DefaultUnit = 0,
            .Units = New List(Of ItemUnit)(),
            .ItemNote = "0",
            .ItemType = "0",
            .CategoryID = "0",
            .TradeMarkID = 0,
            .GroupID = 0,
            .SaleOnScale = False,
            .UnitBarcode = "0",
            .EquivalentToMain = 0D,
            .LastPurchaseDate = "0",
            .Color = 0,
            .Measure = 0,
            .ItemNo2 = String.Empty,
            .ItemNo3 = String.Empty,
            .ItemNo4 = String.Empty,
            .ProductCompany = String.Empty,
            .WebSite1 = String.Empty,
            .WebSite2 = String.Empty,
            .VisibleInAPP = True,
            .VisibleInPOS = True,
            .ReOrderQuantity = 0D,
            .HasSerial = False,
            .HasProductionEquation = False,
            .CostCenter = 0,
            .MaxQuantity = 0D,
            .Vendor = 0,
            .Classification = 1,
            .WithAdditions = False,
            .UseBatchNo = False,
            .SaleOnSamba = False,
            .RequirePriceInPOS = False,
            .PeriodType = String.Empty,
            .PeriodCount = 0D,
            .DefaultColor = 0,
            .DefaultSize = 0,
            .TaxPercentage = 0D
        }
    End Function

End Class
