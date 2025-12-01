Imports DevExpress.XtraReports.UI

Public Class PrintBarcodeForItems
    Private _PrintUnit As Boolean
    Private _DefaultFormID As Integer
    Public _Table As New DataTable
    Private Sub PrintBarcodeForItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()

    End Sub
    Private Sub RefreshData()
        GetItemsWithBarcoeds()
        CreateItemsDataTable()
        Me.GridItems.DataSource = _ItemsDataTable
        GetDefaultForm()
        GetSettings()
        If _Table.Rows.Count > 0 Then
            _ItemsDataTable = _Table
            Me.GridItems.DataSource = _ItemsDataTable
        End If
    End Sub
    Private Sub GetItemsWithBarcoeds()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "   Select ItemNo,ItemName,IU.item_unit_bar_code As Barcode ,0 as Quantity,U.name as UnitName,IU.Price1 as Price1,T.TradeMarkName
                      
                          from [dbo].[Items] I
                          left Join Items_units IU on I.ItemNo=IU.item_id
                          left join Units U on U.id=IU.unit_id
                          Left Join ItemsTradeMark T on  T.TradeMarkID=I.TradeMarkID
                          where [ItemStatus]=1 And item_unit_bar_code <>'0' "
        sql.SqlTrueAccountingRunQuery(sqlString)
        Me.SearchItems.Properties.DataSource = sql.SQLDS.Tables(0)

    End Sub


    Private _ItemsDataTable As New DataTable
    Private Sub CreateItemsDataTable()
        Dim dt As New DataTable
        dt.Columns.Add("ItemNo")
        dt.Columns.Add("ItemName")
        dt.Columns.Add("Barcode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("UnitName")
        dt.Columns.Add("Price")
        dt.Columns.Add("Balance")
        _ItemsDataTable = dt
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim selectedRows = Me.SearchItems.Properties.View.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            Dim _Barcode As String = CStr(Me.SearchItems.Properties.View.GetRowCellValue(rowHandle, "Barcode"))
            Dim _ItemData = GetItemDataByItemBaroce(_Barcode)
            Dim newRow As DataRow = _ItemsDataTable.NewRow()
            newRow("ItemNo") = _ItemData.ItemNo
            newRow("ItemName") = _ItemData.ItemName
            newRow("Barcode") = _Barcode
            newRow("UnitName") = _ItemData.UnitName
            newRow("Price") = _ItemData.Price1
            newRow("Balance") = GetItemBalance(_ItemData.ItemNo, GetDefaltWahreHouseForUser(GlobalVariables.CurrUser))
            newRow("Quantity") = "1"

            _ItemsDataTable.Rows.Add(newRow)
        Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim i As Integer
        For i = 0 To Integer.Parse(_ItemsDataTable.Rows.Count) - 1
            PrintBarcode(_ItemsDataTable.Rows(i).Item("ItemNo"), _ItemsDataTable.Rows(i).Item("ItemName"), _ItemsDataTable.Rows(i).Item("Barcode"), _ItemsDataTable.Rows(i).Item("UnitName"), _ItemsDataTable.Rows(i).Item("Price"), _ItemsDataTable.Rows(i).Item("Quantity"))
        Next
    End Sub
    Private Sub GetSettings()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select * from [BarcodePrinterSettings] where ID=" & _DefaultFormID
            sql.SqlTrueTimeRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                _PrintUnit = CBool(.Item("PrintUnit"))
            End With
        Catch ex As Exception
            _PrintUnit = False
        End Try
    End Sub
    Private Sub GetDefaultForm()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select top(1) ID from BarcodePrinterSettings where IsDefault=1"
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _DefaultFormID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
        Else
            _DefaultFormID = 1
        End If

    End Sub
    Private Sub PrintBarcode(_ItemNo As Integer, _ItemName As String, _Barcode As String, _UnitName As String, _Price As Decimal, _Quantity As Decimal)
        Select Case _DefaultFormID
            Case 1
                Dim _Report As New ItemBarcodePrintReport50_25
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = _ItemName & "/" & _UnitName
                    Else
                        .lblItemName.Text = _ItemName
                    End If
                    ' .lblItemName.Text = _ItemName
                    .XrBarCode1.Text = _Barcode
                    .lblPrice.Text = _Price
                    ._SettingsFromDataBase = True
                    ._FormID = _DefaultFormID
                    Dim printTool As New ReportPrintTool(_Report)
                    For i = 1 To CInt(_Quantity)
                        printTool.Print(GetDefaultPrinter)
                    Next
                End With
            Case 2
                Dim _Report As New ItemBarcodePrintReport50_25_2C
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = _ItemName & "/" & _UnitName
                        .lblItemName2.Text = _ItemName & "/" & _UnitName
                    Else
                        .lblItemName.Text = _ItemName
                        .lblItemName2.Text = _ItemName
                    End If

                    .XrBarCode1.Text = _Barcode
                    .lblPrice.Text = _Price

                    .XrBarCode2.Text = _Barcode
                    .lblPrice2.Text = _Price
                    ._SettingsFromDataBase = True
                    ._FormID = _DefaultFormID
                    Dim printTool As New ReportPrintTool(_Report)

                    Dim _Count As Integer
                    Select Case _Quantity
                        Case 1
                            _Count = _Quantity
                        Case _Quantity Mod 2 = 0
                            _Count = _Quantity
                        Case Else
                            _Count = _Quantity + 1
                    End Select

                    For j = 1 To CInt(_Count) / 2
                        printTool.Print(GetDefaultPrinter)
                    Next
                End With
            Case 3
                Dim _Report As New ItemBarcodePrintReport50_100
                With _Report
                    .lblItemName.Text = _ItemName
                    .XrBarCode1.Text = _Barcode
                    '.XrLabelItemCode.Text = Me.txtItemCode.Text
                    '.XrLabelOtherCodes.Text = Me.txtOtherCodes.Text
                    '.XrLabelProductCompany.Text = Me.txtProductCompany.Text
                    ._SettingsFromDataBase = True
                    ._FormID = _DefaultFormID
                    Dim printTool As New ReportPrintTool(_Report)

                    For i = 1 To CInt(_Quantity)
                        printTool.Print(GetDefaultPrinter)
                    Next
                End With
            Case 9
                Dim _Report As New ItemBarcodePrintReport60_40
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = _ItemName & "/" & _UnitName
                    Else
                        .lblItemName.Text = _ItemName
                    End If
                    ' .lblItemName.Text = _ItemName
                    .XrBarCode1.Text = _Barcode
                    .lblPrice.Text = _Price.ToString("N2")
                    ._SettingsFromDataBase = True
                    ._FormID = _DefaultFormID
                    Dim printTool As New ReportPrintTool(_Report)
                    For i = 1 To CInt(_Quantity)
                        printTool.Print(GetDefaultPrinter)
                    Next
                End With
            Case 10
                Dim _Report As New ItemBarcodePrintReport30_15_3C
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = _ItemName
                        .lblItemName2.Text = _ItemName
                        .lblItemName3.Text = _ItemName
                    Else
                        .lblItemName.Text = _ItemName
                        .lblItemName2.Text = _ItemName
                        .lblItemName3.Text = _ItemName
                    End If

                    .XrBarCode1.Text = _Barcode
                    .lblPrice.Text = _Price

                    .XrBarCode2.Text = _Barcode
                    .lblPrice2.Text = _Price

                    .XrBarCode3.Text = _Barcode
                    .lblPrice3.Text = _Price

                    ._SettingsFromDataBase = True
                    ._FormID = _DefaultFormID
                    Dim printTool As New ReportPrintTool(_Report)
                    Dim _Count As Integer
                    _Count = RoundUpToNextDivisibleBy3(CInt(_Quantity))
                    For j = 1 To CInt(_Count) / 3
                        printTool.Print(GetDefaultPrinter)
                    Next
                End With
        End Select
    End Sub
    Private Function RoundUpToNextDivisibleBy3(ByVal number As Integer) As Integer
        If number Mod 3 = 0 Then
            Return number
        Else
            Return number + (3 - (number Mod 3))
        End If
    End Function
    Private Function GetDefaultPrinter() As String
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select DefaultPrinter from [BarcodePrinterSettings] where ID=" & _DefaultFormID
            sql.SqlTrueTimeRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("DefaultPrinter")
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        ' delete cuurent row
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridItems.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        view.DeleteRow(view.FocusedRowHandle)

    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        GetItemsWithBarcoeds()
    End Sub

    'Private Function GetItemDataFromBarcode()

    'End Function
End Class