Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class StockMoveReport
    Private Sub StockMoveReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchItems.Properties.DataSource = GetItems(-1)
        Warehouses.Properties.DataSource = GetWharehouses(True)
        '  Warehouses.EditValue = GetDefaultWharehouse()
        Warehouses.EditValue = -1
        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today
        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEdit__To.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        SearchDocNames.Properties.DataSource = GetDocNamesTables()
        Me.SearchDocNames.EditValue = -1
        Me.KeyPreview = True
        ColItemNo2.Visible = GlobalVariables._ShowItemNo2
        LoadSettings()
        ColDocCurrency.VisibleIndex = -1
        ColDocAmount.VisibleIndex = -1
        ColCostName.Visible = False
        If GlobalVariables._UserAccessType = 94 Then
            ColPrice.Visible = False
            ColDocCurrency.Visible = False
            ColDocAmount.Visible = False
            ColDocID.Visible = False
            GridView1.OptionsCustomization.AllowQuickHideColumns = False
            GridView1.HideCustomization()
        End If
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub LoadSettings()
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInStockMoveDoc'")
            ColDocNoteByAccount.Visible = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Function GetDocNamesTables() As DataTable
        Dim _DocNames As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " select id,Name from  DocNames where id=1 or id=2 or id=8 or id=9 or id=12 or id=13  "
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

    Public Sub RefreshData()
        If IsNothing(Warehouses.EditValue) Then
            MsgBox("يجب اختيار مستودع")
            Exit Sub
        End If

        If IsNothing(SearchItems.EditValue) Then
            MsgBox("يجب اختيار صنف")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(SearchItems.Text) Then
            MsgBox("يجب اختيار صنف")
            Exit Sub
        End If


        If String.IsNullOrWhiteSpace(SearchDocNames.Text) Then
            MsgBox("يجب اختيار السند")
            Exit Sub
        End If

        Dim RefNo As Integer
        If String.IsNullOrWhiteSpace(Me.SearchReferance.Text) Then
            RefNo = -1
        Else
            RefNo = SearchReferance.EditValue
        End If

        Dim _DateFrom As String = Format(CDate(DateEditFrom.DateTime), "yyyy-MM-dd")
        Dim _Date__To As String = Format(CDate(DateEdit__To.DateTime), "yyyy-MM-dd")
        ColPrice.Caption = " <size=-3> " & GetCurrencyCode(GetDefaultCurrency()) & " </size> السعر "

        Try
            Dim _StockMoves As DataTable
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select * from (SELECT  CASE WHEN DebitAcc='0' THEN FF.AccName ELSE F.AccName END AS AccountName ,J.DocCode,DocID, 
                                        CONVERT(DECIMAL(10,2), 0.0)  as Balance, StockID,J.ItemName ,Co.CostName,
                                        [DocDate],D.Name as DocName,case when StockQuantityByMainUnit > 0 then DocAmount/StockQuantityByMainUnit end as DocPrice,
                                        C.Code as DocCurrency,[BaseCurrAmount],[BaseAmount],R.RefName as RefName ,J.Referance,
                                        J.[StockUnit],U.name as UnitName,[StockQuantity],[SalesPerson],[StockBarcode],
                                        [DeviceName],J.[Color],J.[Measure],BN.BatchNo,BN.ExpireDate,
                                        IsNull(BonusQuantity,0.00) As BonusQuantity ,IsNULL(BonusQuantityByMainUnit,0.00) As BonusQuantityByMainUnit ,"
            If Warehouses.EditValue <> -1 Then
                SqlString += " isnull(case when    [StockDebitWhereHouse] = " & Warehouses.EditValue & " then [StockQuantityByMainUnit] end,0.00)  as 'QIn',
                               isnull(case when   StockCreditWhereHouse = " & Warehouses.EditValue & " then [StockQuantityByMainUnit] end ,0.00) as 'QOut'"
            Else
                SqlString += " isnull(case when    [StockDebitWhereHouse]  between  1 and 999 then CONVERT(DECIMAL(10,2), [StockQuantityByMainUnit])  end,0.00)  as 'QIn',
                               isnull(case when    [StockCreditWhereHouse] between  1 and 999 then CONVERT(DECIMAL(10,2), [StockQuantityByMainUnit])  end ,0.00) as 'QOut'"
            End If
            SqlString += ",WW.WarehouseNameAR As StockDebitWhereHouse , W.WarehouseNameAR As  StockCreditWhereHouse "
            SqlString += "  ,[DocNotes],case when StockQuantityByMainUnit > 0 then BaseAmount/StockQuantityByMainUnit end as Price,DocNoteByAccount
                          ,(Select Units.[name]    from Items_units  left Join Units on Items_units.unit_id=Units.id  where item_id=J.StockID and main_unit=1) as MainUnit
                      FROM [Journal] J
                           left join Items I on I.ItemNo=J.StockID 
                           left join DocNames D on D.id=J.DocName 
                           left join Referencess R on R.RefNo=J.Referance 
                           left join Warehouses W on W.WarehouseID=J.StockCreditWhereHouse 
                           left join Warehouses WW on WW.WarehouseID=J.StockDebitWhereHouse 
                           left join Units U on U.id=J.StockUnit
                           left Join Currency C on C.CurrID=J.DocCurrency
                           left join CostCenter Co on J.DocCostCenter=Co.[CostID]
                           left Join ItemBatchNo BN on BN.ID=J.BatchID
		                   left Join FinancialAccounts F on F.AccNo=DebitAcc
		                   left Join FinancialAccounts FF on FF.AccNo=CredAcc
                      where (J.[DocDate] between '" & _DateFrom & "' and '" & _Date__To & "')  And StockID= '" & SearchItems.EditValue & "' and DocStatus<>0 "
            If SearchDocNames.EditValue <> -1 Then SqlString += " and DocName=" & SearchDocNames.EditValue
            If LookCostCenter.Text <> "" Then SqlString += " and DocCostCenter=" & LookCostCenter.EditValue
            If RefNo <> -1 Then SqlString += " and J.Referance=" & RefNo
            SqlString += "  ) A "
            SqlString += " Where QIn<>0 or QOut<>0  order by DocDate  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _StockMoves = Sql.SQLDS.Tables(0)


            If CheckCalcOpenBalance.Checked = True Then
                Dim BegBalce As Decimal
                Dim R As DataRow = _StockMoves.NewRow
                BegBalce = GetItemBalance(SearchItems.EditValue, Warehouses.EditValue, _DateFrom, Me.LookCostCenter.EditValue)
                If BegBalce > 0 Then R("QIn") = BegBalce
                If BegBalce < 0 Then R("QOut") = Math.Abs(BegBalce)
                R("DocDate") = CDate(_DateFrom).AddDays(-1)
                R("DocName") = "  رصيد مدور"
                _StockMoves.Rows.Add(R)
            End If


            _StockMoves.DefaultView.Sort = "DocDate ASC"
            _StockMoves = _StockMoves.DefaultView.ToTable()

            For i As Integer = 0 To _StockMoves.Rows.Count - 1
                Dim row As DataRow = _StockMoves.Rows(i)
                Dim QIn As Decimal = 0, QOut As Decimal = 0, previousBalance As Decimal = 0
                Decimal.TryParse(row("QIn").ToString(), QIn)
                Decimal.TryParse(row("QOut").ToString(), QOut)
                If i > 0 Then Decimal.TryParse(_StockMoves.Rows(i - 1)("Balance").ToString(), previousBalance)
                row("Balance") = If(i = 0, QIn - QOut, previousBalance - QOut + QIn)
            Next
            GridControl1.DataSource = _StockMoves
        Catch ex As Exception
            GridControl1.DataSource = ""
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If GridControl1.IsPrintingAvailable = False Then Exit Sub
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If GridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
        Else
            If GridView1.RowCount = 0 Then MsgBox("Empty Report ") : Exit Sub
        End If
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = " "
        Dim Tawqe3_2 As String = " "

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)

        ' TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add()

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {" تقرير حركة صنف " & ":" & Me.SearchItems.Text, "المستودع: " & Warehouses.Text, ""})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)


    End Sub

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 15001 Then
                e.TotalValue = ColQIn.SummaryItem.SummaryValue - ColQOut.SummaryItem.SummaryValue
            End If
        End If
    End Sub
    Private Function GetItemBalance(itemNo As String, whereHouse As Integer, dateFrom As String, costCenter As Integer) As Decimal
        ' Initialize return value
        Dim _Balance As Decimal = 0

        Dim RefNo As Integer
        If String.IsNullOrWhiteSpace(Me.SearchReferance.Text) Then
            RefNo = -1
        Else
            RefNo = SearchReferance.EditValue
        End If

        Try
            ' Set warehouse range based on input parameter
            Dim warehouseStart As Integer = If(whereHouse = -1, 1, whereHouse)
            Dim warehouseEnd As Integer = If(whereHouse = -1, 9999999, whereHouse)

            ' Use parameterized query for better security and performance
            Dim parameters As New Dictionary(Of String, Object) From {
            {"@itemNo", itemNo},
            {"@dateFrom", dateFrom},
            {"@costCenter", costCenter},
            {"@referance", RefNo}
        }

            ' Build SQL query with consistent formatting
            Dim sqlString As String = "
SELECT 
    StockID,
    ISNULL(SUM(CASE WHEN [StockDebitWhereHouse] BETWEEN " & warehouseStart & " AND " & warehouseEnd & " 
                   THEN [StockQuantityByMainUnit] END), 0) -
    ISNULL(SUM(CASE WHEN StockCreditWhereHouse BETWEEN " & warehouseStart & " AND " & warehouseEnd & " 
                   THEN [StockQuantityByMainUnit] END), 0) AS balance
FROM 
    [Journal] J
LEFT JOIN 
    Items I ON I.ItemNo = J.StockID
WHERE 
    DocDate < @dateFrom AND 
    I.ItemNo = @itemNo AND 
    DocStatus <> 0 "
            If costCenter <> -1 And costCenter <> 0 Then
                sqlString += " AND DocCostCenter=@costCenter"
            End If

            If RefNo <> -1 Then
                sqlString += " AND Referance=@referance"
            End If


            sqlString += " GROUP BY StockID, I.ItemName"

            ' Execute query and process results
            Dim sql As New SQLControl
            Dim result = sql.ExecuteSqlQuery(sqlString, parameters)

            ' Check for valid results and extract balance
            If result.Success AndAlso result.RowCount > 0 AndAlso
           Not IsDBNull(sql.SQLDS.Tables(0).Rows(0)("balance")) Then
                _Balance = CDec(sql.SQLDS.Tables(0).Rows(0)("balance"))
            End If
        Catch ex As Exception
            ' Silently handle errors and return zero balance
            ' Consider adding logging here if needed
            _Balance = 0
        End Try

        Return _Balance
    End Function


    Private Sub RepositoryItemDocID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemDocID.OpenLink
        Dim _DocCode As String
        _DocCode = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")
        OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name)
    End Sub

    Private Sub CheckShowCurrencies_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowCurrencies.CheckedChanged
        If CheckShowCurrencies.Checked = True Then
            ColDocCurrency.VisibleIndex = ColBalance.VisibleIndex - 3
            ColDocAmount.Visible = ColBalance.VisibleIndex - 4
        Else
            ColDocCurrency.VisibleIndex = -1
            ColDocAmount.VisibleIndex = -1
        End If

    End Sub

    Private Sub LookCostCenter_BeforePopup(sender As Object, e As EventArgs) Handles LookCostCenter.BeforePopup
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
    End Sub

    Private Sub CheckShowCostCenter_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowCostCenter.CheckedChanged
        ColCostName.Visible = CheckShowCostCenter.Checked
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            GridView1.OptionsView.ColumnAutoWidth = True
        Else
            GridView1.OptionsView.ColumnAutoWidth = False
        End If
        GridView1.BestFitColumns()
    End Sub
End Class