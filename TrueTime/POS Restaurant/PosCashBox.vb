Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

''' <summary>
''' Handles POS cash box operations for different payment methods
''' </summary>
Public Class PosCashBox
    Private ReadOnly _defaultCurr As Integer = GetDefaultCurrency()
    Private ReadOnly _paymentTable As New DataTable()

    ''' <summary>
    ''' Initializes the form components and settings
    ''' </summary>
    Private Sub PosCashBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetMethods()
        RepositoryItemLookUpEdit1.DataSource = GetCurrency()
        InitializePaymentTable()
        ConfigureUIComponents()
        Me.KeyPreview = True
    End Sub

    ''' <summary>
    ''' Configure UI components with default settings
    ''' </summary>
    Private Sub ConfigureUIComponents()
        ' Hide account column
        GridColumnAccount.Visible = False

        ' Configure masks for amount text boxes
        SetNumericMask(TextVoucherAmount, "#,##0.0 NIS")
        SetNumericMask(TextReturned, "#,##0.0 NIS")
        SetNumericMask(TextPaid, "#,##0.0 NIS")
    End Sub

    ''' <summary>
    ''' Sets numeric mask properties for a TextEdit control
    ''' </summary>
    Private Sub SetNumericMask(textEdit As TextEdit, editMask As String)
        textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        textEdit.Properties.Mask.EditMask = editMask
    End Sub

    ''' <summary>
    ''' Retrieves and loads payment methods into grid
    ''' </summary>
    Private Sub GetMethods()
        Try
            Dim dataTable As DataTable
            Dim sql As New SQLControl

            ' Get currency data for cash payment method
            sql.SqlTrueAccountingRunQuery("SELECT [CurrID], [name], 'Cash' as MethodType, [Code] as CurrencyCode FROM [dbo].[Currency]")
            dataTable = sql.SQLDS.Tables(0)

            ' Add other payment methods
            AddPaymentMethod(dataTable, "100", "فيزا", "Other")
            AddPaymentMethod(dataTable, "99", "ذمم", "Debit")
            AddPaymentMethod(dataTable, "98", "زبون نقدي", "CashCustomer")

            GridMethods.DataSource = dataTable
        Catch ex As Exception
            XtraMessageBox.Show("Error loading payment methods: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Adds a payment method to the data table
    ''' </summary>
    Private Sub AddPaymentMethod(table As DataTable, currID As String, name As String, methodType As String)
        Dim row As DataRow = table.NewRow
        row("CurrID") = currID
        row("name") = name
        row("MethodType") = methodType
        table.Rows.Add(row)
    End Sub

    ''' <summary>
    ''' Initializes the payment summary table structure
    ''' </summary>
    Private Sub InitializePaymentTable()
        _paymentTable.Columns.Add("CurrID", GetType(Integer))
        _paymentTable.Columns.Add("Amount", GetType(Decimal))
        _paymentTable.Columns.Add("ExchangeRate", GetType(Decimal))
        _paymentTable.Columns.Add("AmountBaseCurrency", GetType(Decimal))
        _paymentTable.Columns.Add("Account", GetType(String))
    End Sub

    ''' <summary>
    ''' Retrieves currency images for the specified currency group
    ''' </summary>
    Private Sub GetAll(currencyGroup As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT [ID], [CurrencyName], [CurrencyValue], [CurrencyGroupID], [CurrncyImage] " &
                                         "FROM [dbo].[PosCurrencyImages] "

            If currencyGroup <> -1 Then
                sqlString += " WHERE [CurrencyGroupID] = " & currencyGroup
            End If

            sql.SqlLocalTrueTimeRunQuery(sqlString)
            GridImages.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show("Error loading currency images: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Handles payment method selection change event
    ''' </summary>
    Private Sub TileView2_GotFocus(sender As Object, e As EventArgs) Handles TileViewMethodNames.FocusedRowChanged
        Try
            Dim methodType As String = TileViewMethodNames.GetRowCellValue(TileViewMethodNames.FocusedRowHandle, "MethodType")
            Dim currID As Integer = TileViewMethodNames.GetRowCellValue(TileViewMethodNames.FocusedRowHandle, "CurrID")

            Select Case methodType
                Case "Cash"
                    LoadCashPaymentView(currID)
                Case "Other"
                    LoadCardPaymentView()
                Case "Debit"
                    LoadCustomerCreditView()
                Case "CashCustomer"
                    LoadCashCustomerView()
            End Select
        Catch ex As Exception
            XtraMessageBox.Show("Error loading payment method: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Loads the cash payment view
    ''' </summary>
    Private Sub LoadCashPaymentView(currencyID As Integer)
        Dim sqlString As String = "SELECT [ID], [CurrencyName], [CurrencyValue], [CurrencyGroupID], [CurrncyImage] " &
                                     "FROM [dbo].[PosCurrencyImages] " &
                                     "WHERE [CurrencyGroupID] = -1 OR [CurrencyGroupID] = " & currencyID & " " &
                                     "ORDER BY [CurrencyValue] DESC"

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(sqlString)

        GridImages.DataSource = sql.SQLDS.Tables(0)
        GridImages.MainView = TileViewCash

        ' Hide additional control items
        LayoutControlItemAddCashCustomers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItemAddReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    ''' <summary>
    ''' Loads the card payment (Visa) view
    ''' </summary>
    Private Sub LoadCardPaymentView()
        Dim sqlString As String = "SELECT [MethodNo] AS [ID], [PaidMethodName] AS [CurrencyName], " &
                                      "CAST(1 AS Decimal(19, 3)) AS [CurrencyValue], F.Currency AS CurrID, " &
                                      "C.Code AS CuurencyCode, M.AccountNO " &
                                      "FROM [dbo].[PosPaidMethods] M " &
                                      "LEFT JOIN FinancialAccounts F ON F.AccNo = M.AccountNO " &
                                      "LEFT JOIN Currency C ON F.Currency = C.CurrID " &
                                      "ORDER BY [MethodNo]"

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(sqlString)

        GridImages.DataSource = sql.SQLDS.Tables(0)
        GridImages.MainView = TileViewVisa

        ' Hide additional control items
        LayoutControlItemAddCashCustomers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItemAddReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    ''' <summary>
    ''' Loads the customer credit view
    ''' </summary>
    Private Sub LoadCustomerCreditView()
        GetReferances()
        GridImages.MainView = GridViewCustomers

        ' Configure visibility of control items
        LayoutControlItemAddCashCustomers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItemAddReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        ' Reset payment values
        TextPaid.EditValue = 0
        TextCalcText.Text = ""
    End Sub

    ''' <summary>
    ''' Loads the cash customer view
    ''' </summary>
    Private Sub LoadCashCustomerView()
        GetCashCustomers()
        GridImages.MainView = GridViewCashCustomer

        ' Configure visibility of control items
        LayoutControlItemAddCashCustomers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItemAddReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    ''' <summary>
    ''' Retrieves cash customers from database
    ''' </summary>
    Private Sub GetCashCustomers()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT * FROM CashCustomer WHERE [IsActive] = 1"
            sql.SqlTrueAccountingRunQuery(sqlString)
            GridImages.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show("Error loading cash customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Retrieves customer references from database
    ''' </summary>
    Private Sub GetReferances()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT RefName, RefNo, RefAccID AS AccountNo, RefMobile " &
                                         "FROM Referencess WHERE [Active] = 1 AND RefType IN (2, 99)"
            sql.SqlTrueAccountingRunQuery(sqlString)
            GridImages.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show("Error loading references: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Event handler for XtraInputBox display
    ''' </summary>
    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub

    ''' <summary>
    ''' Handles selection from payment methods grid
    ''' </summary>
    Private Sub TileView1_GotFocus(sender As Object, e As EventArgs) Handles GridImages.Click
        Try
            Dim viewName As String = GridImages.MainView.Name
            Dim title As String = ""

            Select Case viewName
                Case "TileViewCash"
                    title = HandleTileViewCash()

                Case "TileViewVisa"
                    title = HandleTileViewVisa()

                Case "GridViewCustomers"
                    title = HandleGridViewCustomers()

                Case "GridViewCashCustomer"
                    title = HandleGridViewCashCustomer()
            End Select

            LabelControlTitle.Text = title
        Catch ex As Exception
            XtraMessageBox.Show("Error processing selection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Handles cash payment selection
    ''' </summary>
    Private Function HandleTileViewCash() As String
        ' Reset text direction if needed
        If TextCalcText.RightToLeft = RightToLeft.Yes Then
            TextCalcText.Text = ""
            TextCalcText.RightToLeft = RightToLeft.No
        End If

        ' Get currency information
        Dim amount As Decimal = TileViewCash.GetRowCellValue(TileViewCash.FocusedRowHandle, "CurrencyValue")
        Dim currID As Integer = TileViewCash.GetRowCellValue(TileViewCash.FocusedRowHandle, "CurrencyGroupID")
        Dim exchangeRate As Decimal = GetExchengPrice(currID, Format(Today(), "yyyy-MM-dd")).PurchasePrice
        Dim currName As String = TileViewCash.GetRowCellValue(TileViewCash.FocusedRowHandle, "CurrencyName")

        ' Set account information
        BarAccountNo.Caption = _DefaultBaseCashAccount
        BarAccountName.Caption = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
        BarRefNo.Caption = "0"
        BarRefName.Caption = ""

        ' Get currency code
        Dim currCode As String = ""
        If TileViewMethodNames.GetRowCellValue(TileViewMethodNames.FocusedRowHandle, "MethodType") <> "Other" Then
            currCode = TileViewMethodNames.GetRowCellValue(TileViewMethodNames.FocusedRowHandle, "CurrencyCode")
        End If

        ' Process the amount
        If amount <> 0 Then
            Dim amountBaseCurrency As Decimal = amount * exchangeRate
            If TextCalcText.Text <> "" Then TextPaid.EditValue += amountBaseCurrency Else TextPaid.EditValue = amountBaseCurrency
            TextCalcText.Text += currName & "*" & exchangeRate & "  |  "
        Else
            GetManualAmountInput(currCode, exchangeRate)
        End If

        Return " مبيعات نقدية "
    End Function

    ''' <summary>
    ''' Handles card payment selection
    ''' </summary>
    Private Function HandleTileViewVisa() As String
        ' Reset calculation text
        TextCalcText.Text = " مبيعات فيزا :  "

        ' Get payment information
        Dim amount As Decimal = TextVoucherAmount.EditValue
        Dim currID As Integer = TileViewVisa.GetRowCellValue(TileViewVisa.FocusedRowHandle, "CurrID")
        Dim exchangeRate As Decimal = GetExchengPrice(currID, Format(Today(), "yyyy-MM-dd")).PurchasePrice
        Dim account As String = TileViewVisa.GetRowCellValue(TileViewVisa.FocusedRowHandle, "AccountNO")
        Dim currCode As String = TileViewVisa.GetRowCellValue(TileViewVisa.FocusedRowHandle, "CuurencyCode")
        Dim currName As String = TileViewVisa.GetRowCellValue(TileViewVisa.FocusedRowHandle, "CurrencyName")

        ' Set account information
        BarAccountNo.Caption = account
        BarAccountName.Caption = GetFinancialAccountsData(BarAccountNo.Caption).AccName
        BarRefNo.Caption = "0"
        BarRefName.Caption = ""

        ' Calculate and display payment information
        If exchangeRate <> 0 Then
            Dim methodAmount As Decimal = amount / exchangeRate
            TextCalcText.Text = currName & " : " & Math.Round(amount, 2) & "/" & exchangeRate & "  =  " & Math.Round(methodAmount, 2) & " " & currCode
            TextPaid.EditValue = amount
            GlobalVariables._PayCardName = TileViewVisa.GetRowCellValue(TileViewVisa.FocusedRowHandle, "ID")
        Else
            TextCalcText.Text = currName & " :  Error "
            TextPaid.EditValue = 0
        End If

        Return " مبيعات فيزا "
    End Function

    ''' <summary>
    ''' Handles customer credit selection
    ''' </summary>
    Private Function HandleGridViewCustomers() As String
        ' Set customer reference information
        BarAccountNo.Caption = GridViewCustomers.GetRowCellValue(GridViewCustomers.FocusedRowHandle, "AccountNo")
        BarAccountName.Caption = GetFinancialAccountsData(BarAccountNo.Caption).AccName
        BarRefNo.Caption = GridViewCustomers.GetRowCellValue(GridViewCustomers.FocusedRowHandle, "RefNo")
        BarRefName.Caption = GridViewCustomers.GetRowCellValue(GridViewCustomers.FocusedRowHandle, "RefName")

        ' Clear cash customer info
        BarCashCustomerName.Caption = ""
        BarCashCustomerID.Caption = ""

        ' Enable save buttons
        ButtonSaveAndPrint.Enabled = True
        ButtonSave.Enabled = True

        Return " مبيعات ذمم للزبون " & " " & BarRefName.Caption
    End Function

    ''' <summary>
    ''' Handles cash customer selection
    ''' </summary>
    Private Function HandleGridViewCashCustomer() As String
        ' Get customer information
        Dim customerID As Integer = GridViewCashCustomer.GetRowCellValue(GridViewCashCustomer.FocusedRowHandle, "CustomerID")
        Dim customerName As String = GridViewCashCustomer.GetRowCellValue(GridViewCashCustomer.FocusedRowHandle, "CustomerName")

        ' Set cash customer information
        BarCashCustomerID.Caption = customerID.ToString()
        BarCashCustomerName.Caption = customerName

        Return " مبيعات نقدية للزبون النقدي  " & " " & customerName
    End Function

    ''' <summary>
    ''' Opens dialog for manual amount input
    ''' </summary>
    Private Sub GetManualAmountInput(currencyCode As String, exchangeRate As Decimal)
        Try
            Dim args As New XtraInputBoxArgs()
            args.Caption = "ادخل المبلغ المقبوض"
            args.DefaultButtonIndex = 0
            AddHandler args.Showing, AddressOf Args_Showing

            ' Configure input editor
            Dim editor As New TextEdit()
            editor.BackColor = Color.FromArgb(1, 55, 99)
            editor.ForeColor = Color.FromArgb(255, 80, 0)
            editor.Font = New System.Drawing.Font("Tahoma", 25)
            editor.Properties.Mask.EditMask = "#,##0.0 " & currencyCode
            editor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            editor.EditValue = TextVoucherAmount.EditValue

            args.Editor = editor
            args.DefaultResponse = TextVoucherAmount.EditValue

            ' Get and process input amount
            Dim amountFromArg As Object = XtraInputBox.Show(args)
            If amountFromArg IsNot Nothing Then
                Dim inputAmount As Decimal = Convert.ToDecimal(amountFromArg)
                Dim baseCurrencyAmount As Decimal = inputAmount * exchangeRate
                TextCalcText.Text = inputAmount & " " & currencyCode & "*" & exchangeRate & "  |  "
                TextPaid.EditValue = baseCurrencyAmount
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Error processing input: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextPaid.EditValue += 0
        End Try
    End Sub

    ''' <summary>
    ''' Handles cancel button click
    ''' </summary>
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles ButtonCancell.Click
        My.Forms.POSRestCashier.TextReady.Text = "No"
        GlobalVariables._PayCardName = ""
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Updates calculation when paid amount changes
    ''' </summary>
    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextPaid.EditValueChanged
        CalculateReturnAmount()
    End Sub

    ''' <summary>
    ''' Calculates the return amount based on paid and voucher amounts
    ''' </summary>
    Private Sub CalculateReturnAmount()
        Try
            Dim returnedAmount As Decimal = Val(TextPaid.EditValue) - Val(TextVoucherAmount.EditValue)
            TextReturned.EditValue = FormatTemperature2(returnedAmount)
        Catch ex As Exception
            ' Silently handle calculation errors
        End Try
    End Sub

    ''' <summary>
    ''' Formats a decimal number to nearest half
    ''' </summary>
    Private Function FormatTemperature2(ByVal value As Double) As String
        Return FormatNumber((Math.Round(value * 2) / 2), 1)
    End Function

    ''' <summary>
    ''' Updates calculation when voucher amount changes
    ''' </summary>
    Private Sub TextVoucherAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextVoucherAmount.EditValueChanged
        CalculateReturnAmount()
    End Sub

    ''' <summary>
    ''' Resets payment fields
    ''' </summary>
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        TextReturned.EditValue = 0
        TextPaid.EditValue = 0
        TextCalcText.Text = ""
    End Sub

    ''' <summary>
    ''' Handles save button click
    ''' </summary>
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Saving(False)
    End Sub

    ''' <summary>
    ''' Processes payment saving with print option
    ''' </summary>
    Private Sub Saving(printReceipt As Boolean)
        If TextReturned.EditValue < 0 Then
            If BarRefNo.Caption = "0" Then
                XtraMessageBox.Show("خطا: يجب دفع المزيد من المال")
                My.Forms.POSRestCashier.TextReady.Text = "No"
            Else
                SaveToJournal(printReceipt)
            End If
        Else
            SaveToJournal(printReceipt)
        End If
    End Sub

    ''' <summary>
    ''' Saves payment data to journal and closes form
    ''' </summary>
    Private Sub SaveToJournal(printReceipt As Boolean)
        ' Transfer payment data to main cashier form
        With My.Forms.POSRestCashier
            .TextPaidAmount.EditValue = Me.TextPaid.EditValue
            .TextReturnAmount.EditValue = Me.TextReturned.EditValue
            .TextOtherAccountNo.Caption = BarAccountNo.Caption
            .TextOtherAccountName.Caption = BarAccountName.Caption
            .TextReady.Text = "Yes"
            .CheckPrint.Checked = printReceipt
        End With

        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Key down event handler for shortcut keys
    ''' </summary>
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Saving(False)
        ElseIf e.KeyCode = Keys.F4 Then
            Saving(True)
        End If
    End Sub

    ''' <summary>
    ''' Handles save and print button click
    ''' </summary>
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles ButtonSaveAndPrint.Click
        Saving(True)
    End Sub

    ''' <summary>
    ''' Updates UI labels and button states based on returned amount
    ''' </summary>
    Private Sub TextReturned_EditValueChanged(sender As Object, e As EventArgs) Handles TextReturned.EditValueChanged
        If TextReturned.EditValue < 0 Then
            LayoutControlItem6.Text = "المبلغ المتبقي:"
            ButtonSaveAndPrint.Enabled = False
            ButtonSave.Enabled = False
        Else
            LayoutControlItem6.Text = "المبلغ للارجاع:"
            ButtonSaveAndPrint.Enabled = True
            ButtonSave.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Opens form to add new cash customer
    ''' </summary>
    Private Sub ButtonAddNewCashCustomer_Click(sender As Object, e As EventArgs) Handles ButtonAddNewCashCustomer.Click
        Dim newCustomerForm As New CashCustomerDetails
        newCustomerForm.Text = "اضافة زبون نقدي حديد"

        If newCustomerForm.ShowDialog() <> DialogResult.OK Then
            GetCashCustomers()
        End If
    End Sub

    ''' <summary>
    ''' Opens form to add new customer reference
    ''' </summary>
    Private Sub ButtonAddNewReferance_Click(sender As Object, e As EventArgs) Handles ButtonAddNewReferance.Click
        ' Initialize reference form with default values
        With ReferancessAddNew
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .TextRefName.Select()
            .LookRefType.EditValue = 2
            ._AddNewOrSave = "AddNew"
            .CheckActive.Checked = True

            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                GetReferances()
            End If
        End With
    End Sub
End Class
