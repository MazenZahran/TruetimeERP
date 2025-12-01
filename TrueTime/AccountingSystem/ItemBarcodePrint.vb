Imports DevExpress.XtraPrinting
Imports System.Drawing.Printing
Imports Microsoft.Graph
Imports DevExpress.XtraReports.UI

Public Class ItemBarcodePrint
    Public _FormID As Integer = 1
    Private _PrintUnit As Boolean
    Private Sub ItemBarcodePrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetFormsTable()
        GetDefaultForm()
        GetSettings()
    End Sub
    Private Sub GetSettings()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select * from [BarcodePrinterSettings] where ID=" & SearchFormName.EditValue
            sql.SqlTrueTimeRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                _PrintUnit = CBool(.Item("PrintUnit"))
            End With
        Catch ex As Exception
            _PrintUnit = False
        End Try

    End Sub
    Private Sub GetItems()
        Dim Sql As New SQLControl
        Dim SqlString As String   '               "
        SqlString = "   SELECT   [ItemNo]      ,[ItemName]	  ,U.[name] As UnitName
	                          ,CAST(IU.Price1 AS DECIMAL(7,2) )  As UnitPrice,[item_unit_bar_code] as Barcode,G.GroupName,C.CategoryName,IU.unit_id
                      FROM [Items_units] IU
                            left join Items I On I.ItemNo=IU.item_id
                            left Join Units U on U.id=IU.unit_id
                            left Join [dbo].[ItemsGroups] G on G.GroupID=I.GroupID
							left Join [dbo].ItemsCategories C on C.CategoryID=I.CategoryID
                     Where [ItemStatus]=1  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txtItemName.EditValueChanged
        'Me.txtBarcode.Text = CStr(Me.txtItemName.EditValue)
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Preview(True)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Preview(False)
    End Sub
    Private Sub Preview(_Print As Boolean)
        GetSettings()

        Select Case SearchFormName.EditValue
            Case 1
                Dim _Report As New ItemBarcodePrintReport50_25
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = Me.txtItemName.Text & "/" & Me.TxtUnitName.Text
                    Else
                        .lblItemName.Text = Me.txtItemName.Text
                    End If
                    ' .lblItemName.Text = Me.txtItemName.Text
                    .XrBarCode1.Text = Me.txtBarcode.Text
                    .lblPrice.Text = Me.txtPrice.Text
                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)
                    If _Print = True Then
                        For i = 1 To CInt(txtQuantity.EditValue)
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
                End With
            Case 2
                Dim _Report As New ItemBarcodePrintReport50_25_2C
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = Me.txtItemName.Text & "/" & Me.TxtUnitName.Text
                        .lblItemName2.Text = Me.txtItemName.Text & "/" & Me.TxtUnitName.Text
                    Else
                        .lblItemName.Text = Me.txtItemName.Text
                        .lblItemName2.Text = Me.txtItemName.Text
                    End If

                    .XrBarCode1.Text = Me.txtBarcode.Text
                    .lblPrice.Text = Me.txtPrice.Text

                    .XrBarCode2.Text = Me.txtBarcode.Text
                    .lblPrice2.Text = Me.txtPrice.Text
                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)

                    Dim _Count As Integer
                    If _Print = True Then
                        Select Case txtQuantity.EditValue
                            Case 1
                                _Count = txtQuantity.EditValue
                            Case txtQuantity.EditValue Mod 2 = 0
                                _Count = txtQuantity.EditValue
                            Case Else
                                _Count = txtQuantity.EditValue + 1
                        End Select

                        For i = 1 To CInt(_Count) / 2
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
                End With
            Case 3
                Dim _Report As New ItemBarcodePrintReport50_100
                With _Report
                    .lblItemName.Text = Me.txtItemName.Text
                    .XrBarCode1.Text = Me.txtBarcode.Text
                    .XrLabelItemCode.Text = Me.txtItemCode.Text
                    .XrLabelOtherCodes.Text = Me.txtOtherCodes.Text
                    .XrLabelProductCompany.Text = Me.txtProductCompany.Text
                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)
                    If _Print = True Then
                        For i = 1 To CInt(txtQuantity.EditValue)
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
                End With
            Case 9
                Dim _Report As New ItemBarcodePrintReport60_40
                With _Report
                    .lblItemName.Text = Me.txtItemName.Text
                    .XrBarCode1.Text = Me.txtBarcode.Text
                    .lblPrice.Text = Me.txtPrice.Text
                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)
                    If _Print = True Then
                        For i = 1 To CInt(txtQuantity.EditValue)
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
                End With
            Case 10
                Dim _Report As New ItemBarcodePrintReport30_15_3C
                With _Report
                    ._SettingsFromDataBase = False
                    If _PrintUnit Then
                        .lblItemName.Text = Me.txtItemName.Text
                        .lblItemName2.Text = Me.txtItemName.Text
                        .lblItemName3.Text = Me.txtItemName.Text
                    Else
                        .lblItemName.Text = Me.txtItemName.Text
                        .lblItemName2.Text = Me.txtItemName.Text
                        .lblItemName3.Text = Me.txtItemName.Text
                    End If

                    .XrBarCode1.Text = Me.txtBarcode.Text
                    .lblPrice.Text = Me.txtPrice.Text

                    .XrBarCode2.Text = Me.txtBarcode.Text
                    .lblPrice2.Text = Me.txtPrice.Text

                    .XrBarCode3.Text = Me.txtBarcode.Text
                    .lblPrice3.Text = Me.txtPrice.Text

                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)
                    Dim _Count As Integer
                    If _Print = True Then
                        _Count = RoundUpToNextDivisibleBy3(CInt(txtQuantity.EditValue))
                        For i = 1 To CInt(_Count) / 3
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
                End With
            Case 11
                Dim _Report As New ItemBarcodePrintReport60_40Label
                With _Report
                    .lblItemName.Text = Me.txtItemName.Text
                    Dim priceValue As Decimal
                    If Decimal.TryParse(Convert.ToString(Me.txtPrice.EditValue), priceValue) Then
                        .lblPrice.Text = priceValue.ToString("0.##") & " ₪"
                    Else
                        .lblPrice.Text = Me.txtPrice.Text   ' fallback if parse fails
                    End If
                    ._SettingsFromDataBase = True
                    ._FormID = Me.SearchFormName.EditValue
                    Dim printTool As New ReportPrintTool(_Report)
                    If _Print = True Then
                        For i = 1 To CInt(txtQuantity.EditValue)
                            printTool.Print(GetDefaultPrinter)
                        Next
                    Else
                        Me.DocumentViewer1.DocumentSource = _Report
                        _Report.CreateDocument()
                    End If
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
    Private Sub txtPageWidth_EditValueChanged(sender As Object, e As EventArgs)
        Preview(False)
    End Sub

    Private Sub txtPageHeight_EditValueChanged(sender As Object, e As EventArgs)
        Preview(False)
    End Sub
    Private Sub GetFormsTable()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select ID,FormName from BarcodePrinterSettings  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        SearchFormName.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Function GetDefaultPrinter() As String
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select DefaultPrinter from [BarcodePrinterSettings] where ID=" & SearchFormName.EditValue
            sql.SqlTrueTimeRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("DefaultPrinter")
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub GetDefaultForm()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select top(1) ID from BarcodePrinterSettings where IsDefault=1"
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            SearchFormName.Text = sql.SQLDS.Tables(0).Rows(0).Item("ID")
        Else
            SearchFormName.Text = 1
        End If

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim F As New ItemBarcodePrinterSettings()
        With F
            .ShowDialog()
        End With
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Preview(False)
    End Sub

    Private Sub SearchFormName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchFormName.EditValueChanged
        Select Case SearchFormName.EditValue
            Case 1, 2, 9
                LayoutControlItemItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItemCount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemItemCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItemOtherNumbers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItemXrLabelProductCompany.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 3
                LayoutControlItemItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemBarcode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemCount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemItemCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemOtherNumbers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemXrLabelProductCompany.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Select
    End Sub

    Private Sub txtQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles txtQuantity.MouseUp
        If txtQuantity.Text <> "" Then
            txtQuantity.SelectionStart = 0
            txtQuantity.SelectionLength = txtQuantity.Text.Length
        End If
    End Sub
End Class