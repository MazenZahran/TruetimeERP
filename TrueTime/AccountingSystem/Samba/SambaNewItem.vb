Imports System.Data.SqlTypes
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Linq
Imports System.Threading

Public Class SambaNewItem
    Private branchID As Integer
    Private ItemID As Integer
    Private BranchName As String
    Private GroupID As String
    Sub New(_BranchID As Integer, _BranchName As String, _ItemID As Integer, _GroupID As Integer)
        InitializeComponent()
        branchID = _BranchID
        ItemID = _ItemID
        GroupID = _GroupID
        LoadData()
    End Sub
    Private Sub LoadData()
        Dim sql As New SQLControl
        If ItemID <> 0 Then
            Dim sqlstring As String
            sqlstring = " select * from  "
        Else
            TileViewItems.Text = ""
            txtBarcode.Text = ""
            txtPrice.EditValue = 0
        End If
        sql.SqlPosRunQuery(" select Id,[Name] from [ScreenMenuCategories]  ", branchID)
        srchGroups.Properties.DataSource = sql.SQLDS.Tables(0)
        srchGroups2.Properties.DataSource = sql.SQLDS.Tables(0)
        srchGroups.EditValue = GroupID
        srchGroups2.EditValue = GroupID

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'Select Case TabbedControlGroup1.SelectedTabPage
        '    Case LayoutControlGroup1
        '        DefineBulkItemsTosamba()
        'End Select
        Dim sql As New SQLControl
        Dim sqlstring As String

        If String.IsNullOrEmpty(TileViewItems.Text) Then
            MsgBoxShowError(" الاسم فارغ ")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TileViewItems.Text) Then
            MsgBoxShowError("  الباركود فارغ ")
            Exit Sub
        End If

        If CheckSambaItemNameExists(txtItemName.Text, branchID) = True Then
            MsgBoxShowError(" الاسم معرف مسبقا ")
            Exit Sub
        End If

        If CheckBarcodeExists(txtBarcode.Text) = True Then
            MsgBoxShowError(" الباركود معرف مسبقا ")
            Exit Sub
        End If



        sqlstring = "   Declare @ItemName nvarchar(Max)
                        Declare @ItemGroup nvarchar(Max)
                        Declare @Barcode nvarchar(Max)
                        Declare @Price decimal(18,2)
                        Declare @GroupID int

                        Set @ItemName=N'" & txtItemName.Text & "'
                        Set @ItemGroup=N'" & srchGroups.Text & "'
                        Set @Barcode=N'" & txtBarcode.Text & "'
                        Set @Price=" & txtPrice.Text & "
                        Set @GroupID=" & srchGroups.EditValue & "
                        BEGIN TRANSACTION;

                        DECLARE @InsertedItemIDs TABLE (ID INT);
                        INSERT INTO [dbo].[MenuItems] ([GroupCode], [Barcode], [Tag], [CustomTags], [ItemType], [Name])
                        OUTPUT inserted.ID INTO @InsertedItemIDs
                        VALUES (@ItemGroup, @Barcode, NULL, NULL, 0, @ItemName);
                        DECLARE @ItemID INT;
                        SELECT @ItemID = ID FROM @InsertedItemIDs;

                        DECLARE @InsertedPortionIDs TABLE (ID INT);
                        INSERT INTO [dbo].[MenuItemPortions] ([Name], [MenuItemId], [Multiplier])
                        OUTPUT inserted.ID INTO @InsertedPortionIDs
                        VALUES (N'Normal', @ItemID, 1);
                        DECLARE @PortionID INT;
                        SELECT @PortionID = ID FROM @InsertedPortionIDs;


                        INSERT INTO [dbo].[MenuItemPrices] ([MenuItemPortionId], [PriceTag], [Price])
                        VALUES (@PortionID, NULL, @Price);

                        INSERT [dbo].[ScreenMenuItems]([Name], [Header], [Appearance], [ScreenMenuCategoryId], [MenuItemId], [SortOrder], [AutoSelect], [ButtonColor], [Quantity], [ImagePath], [FontSize], [SubMenuTag], [ItemPortion], [OrderTags], [OrderStates], [AutomationCommand], [AutomationCommandValue], [DisablePortionSelection], [GroupTag])
                        VALUES (@ItemName, NULL, 0, @GroupID, @ItemID, (select IsNull(Max(SortOrder)+10,10) from ScreenMenuItems where ScreenMenuCategoryId=@GroupID), 0, NULL, 1, NULL, 1, '', NULL, NULL, NULL, NULL, NULL, 0, NULL)

                        IF @@ERROR <> 0
						BEGIN
							ROLLBACK TRANSACTION;
						END
						ELSE
						BEGIN
						    COMMIT TRANSACTION;
						End "

        If sql.SqlPosRunQuery(sqlstring, branchID) = False Then
            MsgBoxShowError(" error  ")
        Else
            Me.Close()
        End If
    End Sub

    Private Function CheckBarcodeExists(_Barcode As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " select COUNT(*) As count FROM [dbo].[MenuItems] WHERE [Barcode]=N'" & _Barcode & "'"
            If sql.SqlPosRunQuery(sqlstring, branchID) = True Then
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

    Private Sub SambaNewItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUniqueItems()
    End Sub
    Private Sub LoadItems()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   select ItemNo,ItemName,IU.Price1,IU.item_unit_bar_code as Barcode
                        from Items I 
                        left join Items_units IU on IU.item_id=I.ItemNo 
                        where I.SaleOnSamba=1 and IU.item_unit_bar_code<>'0' and I.ItemStatus=1 "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        TileViewItems.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub srchItemName_EditValueChanged(sender As Object, e As EventArgs) Handles TileViewItems.EditValueChanged
        Try
            'Dim _ItemData = GetItemsData(TileViewItems.EditValue, True)
            Dim repo As New ItemRepository()
            Dim _ItemData As ItemDetails = repo.GetItem(TileViewItems.EditValue, True)
            txtBarcode.Text = _ItemData.UnitBarcode
            txtPrice.EditValue = _ItemData.Price1
            txtItemName.Text = _ItemData.ItemName
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub LoadUniqueItems()
        Dim sql As New SQLControl
        Dim sqlstring As String

        Dim itemsDataTable As DataTable ' Your "Items" DataTable
        Dim itemFromSambaDataTable As DataTable ' Your "ItemFromSamba" DataTable
        sqlstring = "   select ItemNo,ItemName,IU.Price1,IU.item_unit_bar_code as Barcode,G.GroupName
                        from Items I 
                        left join Items_units IU on IU.item_id=I.ItemNo 
                        left join ItemsGroups G on G.GroupID=I.GroupID 
                        where I.SaleOnSamba=1 and IU.item_unit_bar_code<>'0' and I.ItemStatus=1 "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        itemsDataTable = sql.SQLDS.Tables(0)

        sqlstring = " select [GroupCode], [Barcode], [Tag], [CustomTags], [ItemType], [Name] from MenuItems "
        sql.SqlPosRunQuery(sqlstring, branchID)
        itemFromSambaDataTable = sql.SQLDS.Tables(0)

        ' Use LINQ to get the rows from "Items" that don't exist in "ItemFromSamba"
        Dim query = From row In itemsDataTable.AsEnumerable()
                    Where Not itemFromSambaDataTable.AsEnumerable().Any(Function(x) x.Field(Of String)("Barcode") = row.Field(Of String)("Barcode"))
                    Select row

        ' Create a new DataTable to store the result
        Dim resultDataTable As New DataTable()
        resultDataTable = query.CopyToDataTable()

        GridControl1.DataSource = resultDataTable
        TileViewItems.Properties.DataSource = resultDataTable
    End Sub
    Private Sub DefineBulkItemsTosamba(_ItemName As String, _GroupName As String, _Barcode As String, _Price As Decimal, _GroupNo As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String

        If CheckSambaItemNameExists(_ItemName, branchID) = True Then
            ' MsgBoxShowError(" الاسم معرف مسبقا ")
            Exit Sub
        End If

        If CheckBarcodeExists(_Barcode) = True Then
            ' MsgBoxShowError(" الباركود معرف مسبقا ")
            Exit Sub
        End If

        sqlstring = "   Declare @ItemName nvarchar(Max)
                        Declare @ItemGroup nvarchar(Max)
                        Declare @Barcode nvarchar(Max)
                        Declare @Price decimal(18,2)
                        Declare @GroupID int

                        Set @ItemName=N'" & _ItemName & "'
                        Set @ItemGroup=N'" & _GroupName & "'
                        Set @Barcode=N'" & _Barcode & "'
                        Set @Price=" & _Price & "
                        Set @GroupID=" & _GroupNo & "
                        BEGIN TRANSACTION;

                        DECLARE @InsertedItemIDs TABLE (ID INT);
                        INSERT INTO [dbo].[MenuItems] ([GroupCode], [Barcode], [Tag], [CustomTags], [ItemType], [Name])
                        OUTPUT inserted.ID INTO @InsertedItemIDs
                        VALUES (@ItemGroup, @Barcode, NULL, NULL, 0, @ItemName);
                        DECLARE @ItemID INT;
                        SELECT @ItemID = ID FROM @InsertedItemIDs;

                        DECLARE @InsertedPortionIDs TABLE (ID INT);
                        INSERT INTO [dbo].[MenuItemPortions] ([Name], [MenuItemId], [Multiplier])
                        OUTPUT inserted.ID INTO @InsertedPortionIDs
                        VALUES (N'Normal', @ItemID, 1);
                        DECLARE @PortionID INT;
                        SELECT @PortionID = ID FROM @InsertedPortionIDs;


                        INSERT INTO [dbo].[MenuItemPrices] ([MenuItemPortionId], [PriceTag], [Price])
                        VALUES (@PortionID, NULL, @Price);

                        INSERT [dbo].[ScreenMenuItems]([Name], [Header], [Appearance], [ScreenMenuCategoryId], [MenuItemId], [SortOrder], [AutoSelect], [ButtonColor], [Quantity], [ImagePath], [FontSize], [SubMenuTag], [ItemPortion], [OrderTags], [OrderStates], [AutomationCommand], [AutomationCommandValue], [DisablePortionSelection], [GroupTag])
                        VALUES (@ItemName, NULL, 0, @GroupID, @ItemID, (select IsNull(Max(SortOrder)+10,10) from ScreenMenuItems where ScreenMenuCategoryId=@GroupID), 0, NULL, 1, NULL, 1, '', NULL, NULL, NULL, NULL, NULL, 0, NULL)

                        IF @@ERROR <> 0
						BEGIN
							ROLLBACK TRANSACTION;
						END
						ELSE
						BEGIN
						    COMMIT TRANSACTION;
						End "

        If sql.SqlPosRunQuery(sqlstring, branchID) = False Then
            'MsgBoxShowError(" error  ")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim selectedRows() As Integer = GridViewItems.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                Dim _ItemNo As Integer = CInt(GridViewItems.GetRowCellValue(rowHandle, "ItemNo"))
                Dim _ItemName As String = CStr(GridViewItems.GetRowCellValue(rowHandle, "ItemName"))
                Dim _Price1 As Decimal = CDec(GridViewItems.GetRowCellValue(rowHandle, "Price1"))
                Dim _Barcode As String = CStr(GridViewItems.GetRowCellValue(rowHandle, "Barcode"))
                DefineBulkItemsTosamba(_ItemName, srchGroups2.Text, _Barcode, _Price1, srchGroups2.EditValue)
                'Thread.Sleep(2000)
            End If
        Next rowHandle
    End Sub

    Private Sub HyperlinkLabelControl1_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelControl1.Click
        AddNewItem()
    End Sub
    Private Sub AddNewItem()
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

        NewNo = NewNo + 1

        My.Forms.Items.ItemName.Select()
        My.Forms.Items.ItemNo.EditValue = NewNo
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            LoadUniqueItems()
        End If
    End Sub
End Class