Imports System.Data.SqlTypes
Imports System.Drawing.Printing
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI
Imports TrueTime.SinglePageReport

Public Class OrdersWaitScreen
    Private _SelectedPage As String = ""
    Private _OldBicycleCount As Integer
    Private _OldMotorCount As Integer
    Private _NewBicycleCount As Integer
    Private _NewMotorCount As Integer
    Private _Printer As String
    Private _WareHouseID As Integer
    Private _WareHouseName As String
    Private Sub OrdersWaitScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _WareHouseID = GetDefaltWahreHouseForUser(CInt(GlobalVariables.CurrUser))
        _WareHouseName = GetWareHouseName(_WareHouseID)
        GetOrders()
        Timer1.Enabled = True

        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='WaitOrdersPrinter' ")
            _Printer = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Me.BarPrinterName.Caption = _Printer
        Catch ex As Exception
            _Printer = ""
        End Try
        ' MsgBox(_Printer)
    End Sub

    Private Sub GetOrders()
        Dim _OrderStatus As Integer
        Dim _OrderType As Integer
        'MsgBox(TileBar1.SelectedItem.Name)
        Select Case TileBar1.SelectedItem.Name
            Case "TileBarBybicycle"
                _OrderStatus = 0
                _OrderType = 4
                _SelectedPage = "TileBarBybicycle"
            Case "TileBarByMotor"
                _OrderStatus = 0
                _OrderType = 3
                _SelectedPage = "TileBarByMotor"
            Case "TileBarOrderByCar"
                _OrderStatus = 0
                _OrderType = 2
                _SelectedPage = "TileBarOrderByCar"
            Case "TileBarAllPendingOrders"
                _OrderStatus = 0
                _OrderType = -1
                _SelectedPage = "TileBarAllPendingOrders"
            Case "TileBarDeliverdOrder"
                _OrderStatus = 1
                _OrderType = -1
                _SelectedPage = "TileBarDeliverdOrder"
        End Select

        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT [ID],[ItemNo],[ItemName],[Quantity],[OrderDate],
                             [OrderByUser],[AcceptByUser],[AcceptDate],[Orderstatus],'' as Shelf ,OrderType,ItemNo2,'' as ShelfID,ReceivedQuantity
                      FROM [dbo].[InternalOrders] 
                      Where WarehouseID=" & _WareHouseID & " and Orderstatus=" & _OrderStatus
        If _OrderType <> -1 Then sqlstring += " and OrderType=" & _OrderType
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)

        _OldMotorCount = CInt(Me.TileBarByMotor.Elements(1).Text)
        _OldBicycleCount = CInt(Me.TileBarBybicycle.Elements(1).Text)

        sqlstring = " SELECT Count([ID]) As AllSub From [dbo].[InternalOrders] where Orderstatus=0 AND WarehouseID=" & _WareHouseID & ";
        SELECT Count([ID]) As ByCarOrders From [dbo].[InternalOrders] Where Orderstatus=0 and OrderType=2 AND WarehouseID=" & _WareHouseID & ";
                      SELECT Count([ID]) As ByMotorOrders From [dbo].[InternalOrders] Where Orderstatus=0 and OrderType=3 AND WarehouseID=" & _WareHouseID & ";
                      SELECT Count([ID]) As ByBicycleOrders From [dbo].[InternalOrders] Where Orderstatus=0 and OrderType=4 AND WarehouseID=" & _WareHouseID & ";
                      SELECT Count([ID]) As DeliverdOrder From [dbo].[InternalOrders] where Orderstatus=1 AND WarehouseID=" & _WareHouseID & ";"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.TileBarAllPendingOrders.Elements(1).Text = sql.SQLDS.Tables(0).Rows(0).Item("AllSub")
        Me.TileBarOrderByCar.Elements(1).Text = sql.SQLDS.Tables(1).Rows(0).Item("ByCarOrders")
        Me.TileBarByMotor.Elements(1).Text = sql.SQLDS.Tables(2).Rows(0).Item("ByMotorOrders")
        Me.TileBarBybicycle.Elements(1).Text = sql.SQLDS.Tables(3).Rows(0).Item("ByBicycleOrders")
        Me.TileBarDeliverdOrder.Elements(1).Text = sql.SQLDS.Tables(4).Rows(0).Item("DeliverdOrder")
        'TileBar1.SelectedItem = TileBarByMotor
        _NewBicycleCount = CInt(sql.SQLDS.Tables(3).Rows(0).Item("ByBicycleOrders"))
        _NewMotorCount = CInt(sql.SQLDS.Tables(2).Rows(0).Item("ByMotorOrders"))
        If _NewBicycleCount > _OldBicycleCount Then
            TileBar1.SelectedItem = TileBarBybicycle

            Try
                My.Computer.Audio.Play(Application.StartupPath & "\NewOrder.wav", AudioPlayMode.Background)
            Catch ex As Exception

            End Try
        End If
        If _NewMotorCount > _OldMotorCount Then
            TileBar1.SelectedItem = TileBarByMotor

            Try
                My.Computer.Audio.Play(Application.StartupPath & "\NewOrder2.wav", AudioPlayMode.Background)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RepositoryItemShelf_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If GridView1.OptionsSelection.MultiSelectMode <> GridMultiSelectMode.CheckBoxRowSelect Then
            '    'My.Computer.Audio.Play(My.Resources.beep2, AudioPlayMode.Background)
            '    'Dim _oldrowscount, _newrowscount As Integer
            '    '_oldrowscount = GridView1.RowCount
            GetOrders()
            '    '_newrowscount = GridView1.RowCount
            '    'If _newrowscount > _oldrowscount Then
            '    '    'My.Computer.Audio.Play(My.Resources.beep2, AudioPlayMode.Background)
            '    '    Try
            '    '        My.Computer.Audio.Play(Application.StartupPath & "\NewOrder.wav", AudioPlayMode.Background)
            '    '    Catch ex As Exception

            '    '    End Try


            '    'End If
        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell

        Dim ImageIN As Image = My.Resources.motorcycle_delivery_single_box_32
        Dim ImageOut As Image = My.Resources.delivery_32
        Dim View As GridView = CType(sender, GridView)


        If e.Column.FieldName = "OrderType" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OrderType"))
            If category = 1 Then
                e.Graphics.DrawImage(ImageIN, e.Bounds.Location)
                e.DisplayText = ""
                e.Appearance.Options.CancelUpdate()
            End If
            If category = 2 Then
                e.Graphics.DrawImage(ImageOut, e.Bounds.Location)
                e.DisplayText = ""
            End If
            If category = String.Empty Then
            End If
        End If




    End Sub

    Private Sub TileBarByMotor_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarByMotor.ItemClick
        GetOrders()
    End Sub

    Private Sub TileBarOrderByCar_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarOrderByCar.ItemClick
        GetOrders()
    End Sub

    Private Sub TileBarAllPendingOrders_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarAllPendingOrders.ItemClick
        GetOrders()
    End Sub

    Private Sub TileBarDeliverdOrder_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarDeliverdOrder.ItemClick
        GetOrders()
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Close"
                Me.Close()
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "Copy"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.SelectAll()
                GridView1.CopyToClipboard()
                GridView1.OptionsSelection.MultiSelect = False
            Case "CancelItem"
                Dim sql As New SQLControl
                Dim _OrderID As Integer
                _OrderID = GridView1.GetFocusedRowCellValue("ID")
                sql.SqlTrueAccountingRunQuery(" update InternalOrders Set Orderstatus=-1 where ID=" & _OrderID)
                GetOrders()
            Case "ApproveTheOrder"
                Dim _DocCode As String = CreateRandomCode()
                Dim _DocID As Integer = GetDocNo(16, False)
                Dim J As Integer = 0
                Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
                If selectedRowHandles.Length = 0 Then Exit Sub
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _Shelf As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ShelfID")
                    Dim _ItemNo As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo")
                    Dim _ItemName As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ItemName")
                    Dim _Quantity As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "Quantity")
                    Dim _ID As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ID")
                    Dim _ItemNo2 As String = "0"
                    If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo2")) Then
                        _ItemNo2 = CStr(GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo2"))
                    End If

                    If CStr(_Shelf) <> "" Then
                        If PostToJournal(_ItemNo, _Shelf, _Quantity, _ItemName, _DocCode, _DocID, _ID, _ItemNo2) = True Then
                            J += 1
                        End If
                    End If
                    If GetItemBalance(_ItemNo, _WareHouseID) <= 0 Then
                        SendSMSMessage("120363402134953527", _ItemName & " " & _ItemNo2 & " " & " رصيد الصنف انتهى في مستودع  " & _WareHouseName, "WhatsApp", True, "")
                    End If
                Next
                If J > 0 Then
                    PrintOrders(_DocCode) ' بسبب مشكلة في الطباعة عند شلش تم تاجيل تغهيل الكود الطباعة
                    XtraMessageBox.Show(" تم اعتماد  " & J & " من الاصناف  ")
                    GetOrders()
                    AddHandler WindowsUIButtonPanel1.ButtonChecked, AddressOf WindowsUIButtonPanel1_ButtonChecked

                End If
                Dim tag2 As String = CType(e.Button, WindowsUIButton).Tag.ToString()
                If WindowsUIButtonPanel1.Buttons(8).IsChecked = True Then
                    WindowsUIButtonPanel1.Buttons(8).Properties.Checked = False
                End If
                'Case "test"
                '    Dim tag2 As String = CType(e.Button, WindowsUIButton).Tag.ToString()
                '    If WindowsUIButtonPanel1.Buttons(8).IsChecked = True Then
                '        WindowsUIButtonPanel1.Buttons(8).Properties.Checked = False
                '    End If
        End Select
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonChecked(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonChecked
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Pushing"
                XtraMessageBox.Show(" تم ايقاف التحديث التلقائي ")
            Case "Prepare"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        End Select
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonUnChecked(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonUnchecked
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Pushing"
                XtraMessageBox.Show(" تم تفعيل التحديث التلقائي ")
            Case "Prepare"
                GridView1.OptionsSelection.MultiSelect = False
                GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
        End Select
    End Sub

    Private Sub RepositoryItemButtonShelf_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonShelf.ButtonClick
        If GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect Then
            XtraMessageBox.Show(" يجب اختيار تحضير الطلبية ")
            Exit Sub
        End If
        Dim f As New PosSelectShelf
        With f
            .StockCreditWhereHouse.EditValue = _WareHouseID
            .TextItemNo.EditValue = GridView1.GetFocusedRowCellValue("ItemNo")
            .GetDataForPosSelectShelf()
            .TextOpenFrom.Text = Me.Name
            If .ShowDialog() <> DialogResult.OK Then
                If .TextShelf.Text <> "" Then
                    Me.GridView1.SetFocusedRowCellValue("ShelfID", .TextShelf.Text)
                    Me.GridView1.SetFocusedRowCellValue("Shelf", .ShelfCode.Text)
                    Me.GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
            End If
        End With
        '  PosSelectShelf.ShowDialog()
    End Sub
    Private Function PostToJournal(_ItemNo As Integer, _Shelf As Integer, _Quantity As Decimal, _ItemName As String, _DocCode As String, _DocID As Integer, _ID As Integer, ItemNo2 As String) As Boolean
        Dim _result As Boolean
        _result = False
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _DocDate As String = Format(Now(), "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Insert into [Journal]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                                       [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,ItemName,DocCode,
                                       DeviceName,[StockDebitShelve], [StockCreditShelve], ItemNo2,[StockBarcode] ) Values  "
        sqlstring += "( "
        sqlstring += _DocID & ","
        sqlstring += "'" & _DocDate & "',"
        sqlstring += "16,"
        sqlstring += "1,"
        sqlstring += "1,"
        sqlstring += "'4020000000',"
        sqlstring += "'4020000000',"
        sqlstring += "1,"
        sqlstring += "1,"
        sqlstring += "0,"
        sqlstring += "1,"
        sqlstring += "0,"
        sqlstring += "0,"
        sqlstring += "0,"
        sqlstring += "N'ارسالية داخلية',"
        sqlstring += "'" & GlobalVariables.CurrUser & "',"
        sqlstring += "'" & _LogDateTime & "',"
        sqlstring += "'" & _ItemNo & "',"
        sqlstring += "'" & 1 & "',"
        sqlstring += "'" & _Quantity & "',"
        sqlstring += "'" & _Quantity & "',"
        sqlstring += "'" & 0 & "',"
        sqlstring += "'" & 2 & "',"
        sqlstring += "'" & _WareHouseID & "',"
        sqlstring += "N'" & _ItemName & "',"
        sqlstring += "'" & _DocCode & "',"
        sqlstring += "'" & GlobalVariables.CurrDevice & "',"
        sqlstring += "'" & 1397 & "',"
        sqlstring += "'" & _Shelf & "',"
        sqlstring += "'" & ItemNo2 & "',"
        sqlstring += " ( select top(1) [item_unit_bar_code] from [Items_units] where [item_id]=" & _ItemNo & " and [main_unit]=1 ) "
        sqlstring += " )"
        Try
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                sql.SqlTrueAccountingRunQuery(" Update  InternalOrders Set Orderstatus=1 where ID=" & _ID)
                _result = True
            Else
                _result = False
            End If
        Catch ex As Exception
            _result = False
        End Try

        Return _result
    End Function
    Private Sub PrintOrders(_Doccode As String)
        If _SelectedPage = "TileBarByMotor" Or _SelectedPage = "TileBarBybicycle" Then
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select [DocID],J.[ItemName],I.ItemNo2,DocName,J.InputDateTime,
[StockQuantity] as Quantity , S.ShelfCode as StockCreditShelve,J.ItemNo2
[DocCode],D.EmployeeName as UserName
From [dbo].[Journal] J 
Left join EmployeesData D  on D.EmployeeID = J.CurrentUserID 
Left join FinancialShelves S on J.StockCreditShelve=S.ShelfID 
left join Items I on I.ItemNo=J.StockID 
Where 1=1 and DocName=16 "
            sqlstring += "  And [CredAcc]  <> '0' "
            sqlstring += "  And [DocCode]='" & _Doccode & "'"
            sqlstring += "  Order by S.ShelfCode "
            Sql.SqlTrueAccountingRunQuery(sqlstring)

            Dim report As New ShalashInternal() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                .XrLabelUserName.Text = "الموظف: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""
            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)

            If _WareHouseID = 3 Then
                report.ExportToPdf("Document.pdf")
                'SendFileToWhatsAppGroup(CStr("120363419397314141"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName) ' طلبيات مستودع POS
                SendFileToWhatsApp(CStr("120363419397314141"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName, "0") ' طلبيات مستودع POS
            Else
                Dim isInstalled As Boolean = PrinterSettings.InstalledPrinters.Cast(Of String)().Any(Function(p) p = _Printer)
                If isInstalled Then
                    printTool.Print(printerName:=_Printer)
                    'printTool.Print(printerName:=_Printer)
                Else
                    MsgBoxShowError("الطابعة المحددة غير موجودة: " & _Printer)
                End If

                report.ExportToPdf("Document.pdf")
                'SendFileToWhatsAppGroup(CStr("120363400317275471"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName) ' طلبيات مستودع رئيسي
                SendFileToWhatsApp(CStr("120363400317275471"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName, "") ' طلبيات مستودع رئيسي
            End If

        ElseIf _SelectedPage = "TileBarOrderByCar" Then
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select [DocID],J.[ItemName],I.ItemNo2,DocName,J.InputDateTime,
                                [StockQuantity] as Quantity , S.ShelfCode as StockCreditShelve,J.ItemNo2
                                [DocCode],D.EmployeeName as UserName
                                From [dbo].[Journal] J 
                                Left join EmployeesData D  on D.EmployeeID = J.CurrentUserID 
                                Left join FinancialShelves S on J.StockCreditShelve=S.ShelfID 
                                left join Items I on I.ItemNo=J.StockID 
                                Where 1=1 and DocName=16 "
            sqlstring += "  And [CredAcc]  <> '0' "
            sqlstring += "  And [DocCode]='" & _Doccode & "'"
            sqlstring += "  Order by S.ShelfCode "
            Sql.SqlTrueAccountingRunQuery(sqlstring)

            Dim report As New ShalashInternalOrderA4() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelVoucher.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                .XrLabelUserName.Text = "الموظف: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""
                .XrLabelDocDateTime.Text = "التاريخ: " & Sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime") & ""
            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)

            If _WareHouseID = 3 Then
                report.ExportToPdf("Document.pdf")
                'SendFileToWhatsApp(CStr("120363402134953527"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName, "")
                SendFileToWhatsApp(CStr("120363402134953527"), "Document.pdf", 1, "طلبية" & ":" & "-" & _WareHouseName, "")
            Else
                printTool.ShowPreview() ' تم تاجيل الطباعة بسبب مشكلة في الطباعة عند شلش
            End If

        End If
    End Sub
    Private Sub PrintOrdersA4(_Doccode As String)

    End Sub

    Private Sub TileBarBybicycle_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBarBybicycle.ItemClick
        GetOrders()
    End Sub

    'Private Sub S0000ToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Me.GridView1.SetFocusedRowCellValue("ShelfID", 1364)
    '    Me.GridView1.SetFocusedRowCellValue("Shelf", "S-00-00")
    '    Me.GridView1.SelectRow(GridView1.FocusedRowHandle)
    'End Sub
    Private Sub MyGridView_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles GridView1.MouseUp
        If e.Button <> MouseButtons.Right Then Return
        Dim hitInfo As GridHitInfo = GridView1.CalcHitInfo(e.Location)
        If hitInfo.InDataRow Then PopupMenu1.ShowPopup(Control.MousePosition)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Me.GridView1.SetFocusedRowCellValue("ShelfID", 1364)
        Me.GridView1.SetFocusedRowCellValue("Shelf", "S-00-00")
        Me.GridView1.SelectRow(GridView1.FocusedRowHandle)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        '  SendWhatsAppMessage("0597505029", "gffdgfdg f")
    End Sub
End Class