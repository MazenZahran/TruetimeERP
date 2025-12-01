Public Class PosAddParcodeToItem
    Private Sub PosAddParcodeToItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetItems()
    End Sub
    Private Sub GetItems()
        Dim Sql As New SQLControl
        Dim SqlString As String
        'SqlString = " SELECT   [ItemNo]      ,[ItemName]	  ,U.[name] As UnitName
        '                   ,IU.Price1 As UnitPrice,[item_unit_bar_code] as Barcode
        '              FROM [Items] I
        '                    left join Items_units IU On I.ItemNo=IU.item_id
        '                    left Join Units U on U.id=IU.unit_id
        '                    left Join [dbo].[ItemsGroups] C on C.GroupID=I.GroupID
        '               "
        SqlString = "   SELECT   [ItemNo]      ,[ItemName]	  ,U.[name] As UnitName
	                          ,IU.Price1 As UnitPrice,[item_unit_bar_code] as Barcode,G.GroupName,C.CategoryName,IU.unit_id
                      FROM [Items_units] IU
                            left join Items I On I.ItemNo=IU.item_id
                            left Join Units U on U.id=IU.unit_id
                            left Join [dbo].[ItemsGroups] G on G.GroupID=I.GroupID
							left Join [dbo].ItemsCategories C on C.CategoryID=I.CategoryID
                     Where [ItemStatus]=1  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        LookItem.Properties.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub GridLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs)
    End Sub
End Class