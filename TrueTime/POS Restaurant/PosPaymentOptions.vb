Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout

Public Class PosPaymentOptions
    Private PaymentTable As DataTable
    Private VoucherAmount As Decimal
    Public Property SelectedPayments As List(Of Payment)
    Public Property TotalPaidAmount As Decimal
    Public Property ReturnAmount As Decimal
    Public Property DefualtCashCurrency As String

    Public Sub New(amount As Decimal, cashAccount As String)
        InitializeComponent()
        SelectedPayments = New List(Of Payment)()
        VoucherAmount = amount
        TabbedControlGroup2.SelectedTabPageIndex = 0
        DefualtCashCurrency = cashAccount
    End Sub

    'Inistialize
    Private Sub PosPaymentOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextTotal.EditValue = VoucherAmount
        TxtPaid.Text = ""
        TxtRest.EditValue = VoucherAmount
        InitializePaymentTable()
        BindGrid()
        SetupGrid()
    End Sub
    Private Sub InitializePaymentTable()
        PaymentTable = New DataTable()
        PaymentTable.Columns.Add("PaymentOption", GetType(String))
        PaymentTable.Columns.Add("Amount", GetType(Decimal))
        PaymentTable.Columns.Add("ColDelete", GetType(String))
        PaymentTable.Columns.Add("AccountNO", GetType(String))
        PaymentTable.Columns.Add("RefNo", GetType(Integer))
        PaymentTable.Columns.Add("RefName", GetType(String))
        PaymentTable.Columns.Add("CustomerID", GetType(Integer))
        PaymentTable.Columns.Add("CardMethodID", GetType(Integer))
    End Sub
    Private Sub BindGrid()
        GridControl1.DataSource = PaymentTable

        For Each colName As String In {"AccountNO", "RefName", "CardMethodID", "CustomerID", "RefNo"}
            Dim col = GridView1.Columns.ColumnByFieldName(colName)
            If col IsNot Nothing Then
                col.Visible = False
                col.OptionsColumn.ShowInCustomizationForm = False
            End If
        Next
    End Sub
    Private Sub SetupGrid()
        GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        GridView1.OptionsView.ShowGroupPanel = False
        GridView1.OptionsBehavior.Editable = False


        GridControl1.DataSource = PaymentTable
        GridView1.PopulateColumns()

        If GridView1.Columns.ColumnByFieldName("PaymentOption") IsNot Nothing Then
            GridView1.Columns("PaymentOption").Caption = "طريقة الدفع"
        End If
        If GridView1.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
            GridView1.Columns("Amount").Caption = "المبلغ"
        End If
        If GridView1.Columns.ColumnByFieldName("ColDelete") IsNot Nothing Then
            GridView1.Columns("ColDelete").Caption = "حذف"
        End If

        For Each colName As String In {"AccountNO", "RefName", "CardMethodID", "CustomerID", "RefNo"}
            Dim col = GridView1.Columns.ColumnByFieldName(colName)
            If col IsNot Nothing Then
                col.Visible = False
                col.OptionsColumn.ShowInCustomizationForm = False
            End If
        Next


        GridView1.BestFitColumns()
    End Sub

    'Keypad Buttons
    Private Sub KeypadButton_Click(sender As Object, e As EventArgs) Handles _
         BtnOne.Click, BtnTwo.Click,
        BtnFour.Click, BtnFive.Click, BtnSix.Click, BtnSeven.Click,
        BtnEight.Click, BtnNine.Click, BtnThree.Click, BtnPoint.Click, BtnZero.Click

        Dim btn As SimpleButton = CType(sender, SimpleButton)
        TxtPaid.Text &= btn.Text
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If TxtPaid.Text.Length > 0 Then
            TxtPaid.Text = TxtPaid.Text.Substring(0, TxtPaid.Text.Length - 1)
        End If
    End Sub
    Private Sub RestorePaymentOptions()
        ' Switch to main payment buttons tab (Cash, Card, Credit,CashCustomer)
        TabbedControlGroup2.SelectedTabPageIndex = 0
    End Sub

    '--------------------------------------------------------------
    'Payment Options Buttons
    '--------------------------------------------------------------

    'Cash Payment
    Private Sub BtnCash_Click(sender As Object, e As EventArgs) Handles BtnCash.Click
        ShowCurrenciesAsButtons()
    End Sub
    Private Sub ShowCurrenciesAsButtons()
        Try
            ' Load currencies
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT [CurrID], [Code], [name] FROM [dbo].[Currency]"
            sql.SqlTrueAccountingRunQuery(sqlString)
            Dim dtCurrencies As DataTable = sql.SQLDS.Tables(0)

            ' Select tab page
            Dim tab As LayoutControlGroup = TabbedControlGroup2.TabPages(1)
            tab.Clear()
            tab.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table
            tab.OptionsTableLayoutGroup.ColumnDefinitions.Clear()
            tab.OptionsTableLayoutGroup.RowDefinitions.Clear()

            ' Get Cash button size
            Dim cashLayout As LayoutControlItem = CType(BtnCash.Parent, LayoutControl).GetItemByControl(BtnCash)
            Dim cashSize As Size = cashLayout.MaxSize
            Dim spacingHeight As Integer = 8

            ' Single column
            tab.OptionsTableLayoutGroup.ColumnDefinitions.Add(
            New ColumnDefinition With {.SizeType = SizeType.Absolute, .Width = cashSize.Width})

            ' Predefine all rows: button row + spacing row for each currency
            For i As Integer = 0 To dtCurrencies.Rows.Count - 1
                tab.OptionsTableLayoutGroup.RowDefinitions.Add(New RowDefinition With {.Height = cashSize.Height})  ' Button
                tab.OptionsTableLayoutGroup.RowDefinitions.Add(New RowDefinition With {.Height = spacingHeight})   ' Space
            Next

            ' Add buttons and empty spaces
            For i As Integer = 0 To dtCurrencies.Rows.Count - 1
                Dim row As DataRow = dtCurrencies.Rows(i)

                ' Create button
                Dim btn As New SimpleButton()
                btn.StyleController = BtnCash.StyleController
                btn.Size = cashSize
                btn.MinimumSize = cashSize
                btn.MaximumSize = cashSize

                Dim currencyName As String = row("name").ToString().ToLower()
                Dim currencyCode As String = row("Code").ToString().ToUpper()

                Select Case True
                    Case currencyName.Contains("شيقل") Or currencyCode = "ILS"
                        btn.Appearance.BackColor = Color.FromArgb(39, 174, 96)
                    Case currencyName.Contains("دولار") Or currencyCode = "USD"
                        btn.Appearance.BackColor = Color.FromArgb(46, 134, 193)
                    Case currencyName.Contains("يورو") Or currencyCode = "EUR"
                        btn.Appearance.BackColor = Color.FromArgb(155, 89, 182)
                    Case currencyName.Contains("دينار") Or currencyCode = "JD"
                        btn.Appearance.BackColor = Color.Brown
                    Case Else
                        btn.Appearance.BackColor = Color.Gray
                End Select

                btn.Appearance.ForeColor = Color.White
                btn.Appearance.Options.UseBackColor = True
                btn.Appearance.Options.UseForeColor = True
                btn.Appearance.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
                btn.Appearance.Options.UseFont = True

                btn.Text = $"{row("name")} ({row("Code")})"
                btn.Tag = row("CurrID")
                AddHandler btn.Click, AddressOf CurrencyButton_Click

                ' Add button
                Dim btnItem As LayoutControlItem = tab.AddItem("", btn)
                btnItem.TextVisible = False
                btnItem.OptionsTableLayoutItem.ColumnIndex = 0
                btnItem.OptionsTableLayoutItem.RowIndex = i * 2      ' Button row
                btnItem.SizeConstraintsType = SizeConstraintsType.Custom
                btnItem.MinSize = cashSize
                btnItem.MaxSize = cashSize

                ' Add empty space
                Dim space As New DevExpress.XtraLayout.EmptySpaceItem()
                space.AllowHotTrack = False
                Dim spaceItem As LayoutControlItem = tab.AddItem(space)
                spaceItem.OptionsTableLayoutItem.ColumnIndex = 0
                spaceItem.OptionsTableLayoutItem.RowIndex = i * 2 + 1  ' Spacer row
            Next

            TabbedControlGroup2.SelectedTabPageIndex = 1

        Catch ex As Exception
            XtraMessageBox.Show("Error loading currencies: " & ex.Message)
        End Try
    End Sub
    Private Sub CurrencyButton_Click(sender As Object, e As EventArgs)
        Dim btn As SimpleButton = CType(sender, SimpleButton)
        Dim currID As Integer = CInt(btn.Tag)

        Dim foreignAmount As Decimal
        If Not Decimal.TryParse(TxtPaid.Text, foreignAmount) OrElse foreignAmount <= 0 Then
            XtraMessageBox.Show("الرجاء إدخال مبلغ صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Convert to Shekels
        Dim exchangeRate As Decimal = GetExchengPrice(currID, Format(Today(), "yyyy-MM-dd")).PurchasePrice
        Dim amountInShekel As Decimal = foreignAmount * exchangeRate

        ' Set the converted amount
        TxtPaid.Text = amountInShekel.ToString()

        ' Add payment
        AddPayment("نقدي (شيكل)")

        ' Reset input
        TxtPaid.Text = ""
        UpdateTotals()
        RestorePaymentOptions()
    End Sub

    'Card Payment
    Private Sub BtnCard_Click(sender As Object, e As EventArgs) Handles BtnCard.Click
        ShowCardMethodsAsButtons()
    End Sub
    Private Sub ShowCardMethodsAsButtons()
        Try

            Dim sql As New SQLControl
            Dim sqlString As String =
            "SELECT [MethodNo] AS [ID], [PaidMethodName] AS [Name], 
                    F.Currency AS CurrID, C.Code AS CurrencyCode, M.AccountNO
             FROM [dbo].[PosPaidMethods] M
             LEFT JOIN FinancialAccounts F ON F.AccNo = M.AccountNO
             LEFT JOIN Currency C ON F.Currency = C.CurrID
             ORDER BY [MethodNo]"

            sql.SqlTrueAccountingRunQuery(sqlString)
            Dim dtCards As DataTable = sql.SQLDS.Tables(0)


            Dim tab As LayoutControlGroup = TabbedControlGroup2.TabPages(2)
            tab.Clear()
            tab.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table
            tab.OptionsTableLayoutGroup.ColumnDefinitions.Clear()
            tab.OptionsTableLayoutGroup.RowDefinitions.Clear()


            Dim cashLayout As LayoutControlItem =
            CType(BtnCash.Parent, LayoutControl).GetItemByControl(BtnCash)
            Dim cashSize As Size = cashLayout.MaxSize
            Dim cashPadding As DevExpress.XtraLayout.Utils.Padding = cashLayout.Padding

            tab.OptionsTableLayoutGroup.ColumnDefinitions.Add(
            New ColumnDefinition With {.SizeType = SizeType.Absolute, .Width = cashSize.Width}
        )

            Dim rowIndex As Integer = 0
            Dim spacingHeight As Integer = 8

            Dim colors As Color() = {
            Color.FromArgb(52, 152, 219),
            Color.FromArgb(46, 204, 113),
            Color.FromArgb(231, 76, 60),
            Color.FromArgb(155, 89, 182),
            Color.FromArgb(241, 196, 15),
            Color.FromArgb(26, 188, 156)
        }

            Dim i As Integer = 0


            For Each row As DataRow In dtCards.Rows
                tab.OptionsTableLayoutGroup.RowDefinitions.Add(
                New RowDefinition With {.Height = cashSize.Height, .SizeType = SizeType.Absolute}
            )

                Dim btn As New SimpleButton()
                btn.StyleController = BtnCash.StyleController
                btn.Size = cashSize
                btn.MinimumSize = cashSize
                btn.MaximumSize = cashSize

                btn.Text = $"{row("Name")} ({row("CurrencyCode")})"
                btn.Tag = New With {
                .ID = row("ID"),
                .AccountNO = row("AccountNO")
                }
                btn.Appearance.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
                btn.Appearance.Options.UseFont = True
                btn.Appearance.BackColor = colors(i Mod colors.Length)
                btn.Appearance.Options.UseBackColor = True
                btn.Appearance.ForeColor = Color.White
                btn.Appearance.Options.UseForeColor = True
                AddHandler btn.Click, AddressOf CardMethod_Click

                Dim btnItem As LayoutControlItem = tab.AddItem("", btn)
                btnItem.TextVisible = False
                btnItem.OptionsTableLayoutItem.ColumnIndex = 0
                btnItem.OptionsTableLayoutItem.RowIndex = rowIndex
                btnItem.SizeConstraintsType = SizeConstraintsType.Custom
                btnItem.MinSize = cashSize
                btnItem.MaxSize = cashSize

                rowIndex += 1

                tab.OptionsTableLayoutGroup.RowDefinitions.Add(
                New RowDefinition With {.Height = spacingHeight, .SizeType = SizeType.Absolute}
            )
                Dim emptySpace As New DevExpress.XtraLayout.EmptySpaceItem()
                emptySpace.AllowHotTrack = False
                emptySpace.OptionsTableLayoutItem.ColumnIndex = 0
                emptySpace.OptionsTableLayoutItem.RowIndex = rowIndex
                tab.AddItem(emptySpace)

                rowIndex += 1
                i += 1
            Next

            TabbedControlGroup2.SelectedTabPageIndex = 2

        Catch ex As Exception
            XtraMessageBox.Show("Error loading card methods: " & ex.Message)
        End Try
    End Sub
    Private Sub CardMethod_Click(sender As Object, e As EventArgs)
        Dim btn As SimpleButton = CType(sender, SimpleButton)
        Dim data = btn.Tag

        Dim methodID As Integer = data.ID
        Dim accountNo As String = data.AccountNO

        If String.IsNullOrWhiteSpace(TxtPaid.Text) Then
            XtraMessageBox.Show("ادخل المبلغ أولاً", "تنبيه", MessageBoxButtons.OK)
            Return
        End If
        AddPayment(btn.Text, accountNo, -1, "", -1, methodID)
        TxtPaid.Text = ""
        RestorePaymentOptions()

        ' Return to main buttons
        'LoadPaymentOptions()
    End Sub

    'Credit Customer Payment
    Private Sub BtnCredit_Click1(sender As Object, e As EventArgs) Handles BtnCredit.Click
        ShowCreditCustomersAsGrid()
    End Sub
    Private Sub ShowCreditCustomersAsGrid()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "
            SELECT RefName AS [الاسم], 
                   RefNo AS [الرقم], 
                   RefAccID AS [رقم الحساب], 
                   RefMobile AS [الموبايل] 
            FROM Referencess 
            WHERE [Active] = 1 AND RefType IN (2, 99)
            "

            sql.SqlTrueAccountingRunQuery(sqlString)
            Dim dtCredits As DataTable = sql.SQLDS.Tables(0)

            GridControl2.DataSource = dtCredits
            GridView2.PopulateColumns()
            Dim editColumn As New DevExpress.XtraGrid.Columns.GridColumn()
            editColumn.Caption = "تعديل"
            editColumn.FieldName = "EditRow"
            editColumn.Visible = True
            editColumn.OptionsColumn.AllowEdit = True

            Dim editButton As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            editButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            editButton.Buttons(0).Caption = "✏️"
            editButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

            GridControl2.RepositoryItems.Add(editButton)
            editColumn.ColumnEdit = editButton

            GridView2.Columns.Add(editColumn)

            ' Handle button click event
            AddHandler editButton.ButtonClick, AddressOf EditCreditCustomer

            Dim colName = GridView2.Columns.ColumnByFieldName("الاسم")
            If colName IsNot Nothing Then colName.Visible = True

            Dim colNum = GridView2.Columns.ColumnByFieldName("الرقم")
            If colNum IsNot Nothing Then colNum.Visible = False

            Dim colAccNo = GridView2.Columns.ColumnByFieldName("رقم الحساب")
            If colAccNo IsNot Nothing Then colAccNo.Visible = False

            Dim colMobile = GridView2.Columns.ColumnByFieldName("الموبايل")
            If colMobile IsNot Nothing Then colMobile.Visible = False

            TabbedControlGroup2.SelectedTabPageIndex = 4

        Catch ex As Exception
            XtraMessageBox.Show("Error loading credit customers: " & ex.Message)
        End Try
    End Sub
    Private Sub GridView2_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView2.RowClick
        If e.RowHandle < 0 Then
            Debug.WriteLine("RowHandle < 0, exiting")
            Exit Sub
        End If

        Dim view As GridView = CType(sender, GridView)
        Dim hi = view.CalcHitInfo(e.Location)
        Debug.WriteLine($"HitInfo: InRow={hi.InRow}, InRowCell={hi.InRowCell}, Column={If(hi.Column IsNot Nothing, hi.Column.FieldName, "NULL")}")

        ' Ensure a cell was clicked
        If Not hi.InRowCell Then
            Debug.WriteLine("Not a cell click, exiting")
            Exit Sub
        End If

        Dim clickedColumn As GridColumn = hi.Column

        ' If Edit column was clicked → OPEN EDIT FORM
        If clickedColumn.FieldName = "EditRow" Then
            Debug.WriteLine("Edit column clicked")
            EditCreditCustomer()
            Exit Sub
        End If

        ' -------- Original payment code --------
        Dim refName As String = view.GetRowCellValue(e.RowHandle, "الاسم").ToString()
        Dim refNo As Integer = CInt(view.GetRowCellValue(e.RowHandle, "الرقم"))
        Dim accNo As Integer = CInt(view.GetRowCellValue(e.RowHandle, "رقم الحساب"))

        Debug.WriteLine($"Adding payment for customer: {refName}, RefNo={refNo}, AccNo={accNo}")

        If String.IsNullOrWhiteSpace(TxtPaid.Text) Then
            Debug.WriteLine("TxtPaid is empty")
            XtraMessageBox.Show("الرجاء إدخال المبلغ أولاً.")
            Return
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(TxtPaid.Text, amount) OrElse amount <= 0 Then
            Debug.WriteLine($"Invalid amount: {TxtPaid.Text}")
            XtraMessageBox.Show("الرجاء إدخال مبلغ صالح.")
            Return
        End If

        Debug.WriteLine($"Amount entered: {amount}")
        AddPayment($"ذمم - {refName}", accNo, refNo, refName)

        TxtPaid.Text = ""
        RestorePaymentOptions()
        UpdateTotals()
        Debug.WriteLine("Payment added successfully")
    End Sub
    Private Sub EditCreditCustomer()
        Dim rowHandle As Integer = GridView2.FocusedRowHandle
        Debug.WriteLine($"EditCreditCustomer called, rowHandle={rowHandle}")
        If rowHandle < 0 Then
            Debug.WriteLine("Focused row handle < 0, exiting")
            Exit Sub
        End If

        Dim name As String = GridView2.GetRowCellValue(rowHandle, "الاسم").ToString()
        Dim refNo As Integer = Convert.ToInt32(GridView2.GetRowCellValue(rowHandle, "الرقم"))
        Dim mobile As String = GridView2.GetRowCellValue(rowHandle, "الموبايل").ToString()
        Dim accId As Integer? = Nothing

        If Not IsDBNull(GridView2.GetRowCellValue(rowHandle, "رقم الحساب")) Then
            accId = Convert.ToInt32(GridView2.GetRowCellValue(rowHandle, "رقم الحساب"))
        End If

        Debug.WriteLine($"Editing customer: {name}, RefNo={refNo}, Mobile={mobile}, AccId={If(accId.HasValue, accId.Value.ToString(), "NULL")}")

        Dim frm As New CashCustomerDetails
        frm.Mode = CustomerMode.Credit
        frm.Text = "تعديل بيانات الزبون"
        frm.LoadCustomerForEdit(refNo, name, mobile, accId)

        If frm.ShowDialog() = DialogResult.OK Then
            Debug.WriteLine("Edit form closed with OK, refreshing grid")
            ShowCreditCustomersAsGrid()   'Refresh correctly
        Else
            Debug.WriteLine("Edit form cancelled")
        End If
    End Sub

    'Cash Customer Payment
    Private Sub BtnCashCustomer_Click(sender As Object, e As EventArgs)
        ShowCashCustomersAsGrid()
    End Sub
    Private Sub ShowCashCustomersAsGrid()
        GetCashCustomers()
        TabbedControlGroup2.SelectedTabPageIndex = 3
    End Sub
    Private Sub GetCashCustomers()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT * FROM CashCustomer WHERE [IsActive] = 1"
            sql.SqlTrueAccountingRunQuery(sqlString)

            Dim dtCashCustomer As DataTable = sql.SQLDS.Tables(0)

            GridControl3.DataSource = dtCashCustomer

            If GridControl3.MainView IsNot GridView3 Then
                GridControl3.MainView = GridView3
            End If

            GridView3.Columns.Clear()

            GridView3.PopulateColumns()

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView3.Columns
                col.Visible = False
            Next

            If GridView3.Columns("Mobile") IsNot Nothing Then
                With GridView3.Columns("Mobile")
                    .Visible = True
                    .Caption = "رقم الهاتف"
                End With
            End If

            If GridView3.Columns("CustomerName") IsNot Nothing Then
                With GridView3.Columns("CustomerName")
                    .Visible = True
                    .Caption = "الاسم"
                End With
            End If

            Dim editColumn As New DevExpress.XtraGrid.Columns.GridColumn()
            editColumn.Caption = "تعديل"
            editColumn.FieldName = "EditRow"
            editColumn.Visible = True
            editColumn.OptionsColumn.AllowEdit = True

            Dim editButton As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            editButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            editButton.Buttons(0).Caption = "✏️"
            editButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

            GridControl3.RepositoryItems.Add(editButton)
            editColumn.ColumnEdit = editButton

            GridView3.Columns.Add(editColumn)

            RemoveHandler editButton.ButtonClick, AddressOf EditCreditCustomer
            AddHandler editButton.ButtonClick, AddressOf EditCashCustomer

            GridView3.BestFitColumns()

        Catch ex As Exception
            XtraMessageBox.Show("Error loading cash customers: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridView3_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView3.RowClick
        If e.RowHandle < 0 Then
            Debug.WriteLine("RowHandle < 0, exiting")
            Exit Sub
        End If

        Dim view As GridView = CType(sender, GridView)
        Dim hi = view.CalcHitInfo(e.Location)
        Debug.WriteLine($"HitInfo: InRow={hi.InRow}, InRowCell={hi.InRowCell}, Column={If(hi.Column IsNot Nothing, hi.Column.FieldName, "NULL")}")

        ' Ensure a cell was clicked
        If Not hi.InRowCell Then
            Debug.WriteLine("Not a cell click, exiting")
            Exit Sub
        End If

        Dim clickedColumn As GridColumn = hi.Column

        ' If Edit column was clicked → OPEN EDIT FORM
        If clickedColumn.FieldName = "EditRow" Then
            Debug.WriteLine("Edit column clicked")
            EditCashCustomer()
            Exit Sub
        End If

        ' Get customer info
        Dim customerId As Integer = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "CustomerID"))
        Dim customerName As String = view.GetRowCellValue(e.RowHandle, "CustomerName").ToString()
        Dim mobile As String = view.GetRowCellValue(e.RowHandle, "Mobile").ToString()

        Debug.WriteLine($"Row clicked: CustomerID={customerId}, Name={customerName}, Mobile={mobile}")

        ' Apply customer to payment table
        ApplyCustomerToPaymentTable(customerId)

        ' Reset paid amount and update payment options
        TxtPaid.Text = ""
        RestorePaymentOptions()
        UpdateTotals()
    End Sub

    Private Sub EditCashCustomer()
        Dim rowHandle As Integer = GridView3.FocusedRowHandle
        If rowHandle < 0 Then Exit Sub

        Dim customerId As Integer = Convert.ToInt32(GridView3.GetRowCellValue(rowHandle, "CustomerID"))

        Dim frm As New CashCustomerDetails
        frm.Mode = CustomerMode.Cash
        frm.Text = "تعديل بيانات زبون كاش"

        frm.Tag = customerId

        frm.LoadCustomerById(customerId)
        frm.isEditMode = True

        If frm.ShowDialog() = DialogResult.OK Then
            GetCashCustomers()
        End If
    End Sub

    Private Sub ApplyCustomerToPaymentTable(custNo As Integer)
        If PaymentTable Is Nothing OrElse PaymentTable.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To PaymentTable.Rows.Count - 1
            Dim row As DataRow = PaymentTable.Rows(i)

            If row.Field(Of String)("PaymentOption").Contains("ذمم") Then
                row("CustomerID") = 0
            Else
                row("CustomerID") = custNo
            End If

            If i < SelectedPayments.Count Then
                If SelectedPayments(i).PaymentOption.Contains("ذمم") Then
                    SelectedPayments(i).CustomerID = 0
                Else
                    SelectedPayments(i).CustomerID = custNo
                End If
            End If
        Next

        GridControl1.RefreshDataSource()
    End Sub

    Private Sub AddPayment(paymentType As String, Optional accountNo As String = "", Optional refNo As Integer = -1, Optional refName As String = "", Optional customerID As Integer = -1, Optional cardMethodID As Integer = -1)
        Dim amount As Decimal
        If Not Decimal.TryParse(TxtPaid.Text, amount) OrElse amount <= 0 Then
            XtraMessageBox.Show("الرجاء إدخال مبلغ صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim newRow As DataRow = PaymentTable.NewRow()
        newRow("PaymentOption") = paymentType
        newRow("Amount") = amount
        newRow("ColDelete") = "❌"

        If accountNo <> "" Then newRow("AccountNO") = accountNo
        If refNo <> -1 Then newRow("RefNo") = refNo
        If refName <> "" Then newRow("RefName") = refName
        If customerID <> -1 Then newRow("CustomerID") = customerID
        If cardMethodID <> -1 Then newRow("CardMethodID") = cardMethodID

        PaymentTable.Rows.Add(newRow)

        Dim newPayment As New Payment With {
        .PaymentOption = paymentType,
        .Amount = amount,
        .AccountNo = accountNo,
        .RefNo = refNo,
        .RefName = refName,
        .CustomerID = customerID,
        .CardMethodID = cardMethodID
        }
        SelectedPayments.Add(newPayment)
        TotalPaidAmount = TotalPaidAmount + amount
        ReturnAmount = TxtRest.EditValue
        GridControl1.RefreshDataSource()
        TxtPaid.Text = ""

        UpdateTotals()
        RestorePaymentOptions()
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.FieldName = "ColDelete" Then
            If XtraMessageBox.Show("هل تريد حذف هذا السطر؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                GridView1.DeleteRow(e.RowHandle)
                UpdateTotals()
            End If
        End If
    End Sub
    ' Utilities
    Private Sub UpdateTotals()
        Dim totalPaid As Decimal = PaymentTable.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Amount"))

        Dim rest As Decimal

        If totalPaid >= VoucherAmount Then
            ' Customer overpaid
            rest = totalPaid - VoucherAmount
        Else
            ' Customer still owes money
            rest = VoucherAmount - totalPaid
        End If

        TxtRest.EditValue = rest
        TxtTotal.EditValue = totalPaid

        If totalPaid < VoucherAmount Then
            LayoutControlItem9.Text = "المبلغ المتبقي"
        Else
            LayoutControlItem9.Text = "المبلغ المرتجع" ' Change or return amount
        End If
    End Sub
    Private Sub ShowPayments()
        If PaymentTable.Rows.Count = 0 Then
            XtraMessageBox.Show("لا توجد مدفوعات لإظهارها.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim paymentsInfo As String = "تفاصيل الدفع:" & Environment.NewLine & Environment.NewLine
        For Each row As DataRow In PaymentTable.Rows
            Dim payType As String = row("PaymentOption").ToString()
            Dim amount As Decimal = Convert.ToDecimal(row("Amount"))
            paymentsInfo &= $"طريقة الدفع: {payType} - المبلغ: {amount:C}" & Environment.NewLine
        Next

        ' XtraMessageBox.Show(paymentsInfo, "تفاصيل المدفوعات", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub BtnGoBack_Click_1(sender As Object, e As EventArgs) Handles BtnGoBack.Click
        RestorePaymentOptions()
    End Sub
    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If PaymentTable.Rows.Count = 0 Then
            XtraMessageBox.Show("يجب إضافة طريقة دفع واحدة على الأقل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim totalPaid As Decimal = PaymentTable.AsEnumerable().Sum(Function(r) r.Field(Of Decimal)("Amount"))

        If totalPaid < VoucherAmount Then
            XtraMessageBox.Show("المبلغ المدفوع أقل من الإجمالي.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        'XtraMessageBox.Show("تم تأكيد عملية الدفع بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.DialogResult = DialogResult.OK
        If TxtRest.EditValue > 0 Then
            ReturnAmount = TxtRest.EditValue
        Else
            TotalPaidAmount = 0
            ReturnAmount = 0
        End If
        ShowPayments()
        'Saving(False)
        Me.Close()
    End Sub

    Private Sub SaveToJournal(printReceipt As Boolean)
        ' Transfer payment data to main cashier form
        With My.Forms.POSRestCashier
            .TextPaidAmount.EditValue = Me.TxtPaid.EditValue
            .TextReturnAmount.EditValue = Me.TxtRest.EditValue
            .SaveWithMultiplePayments = True
            .TextReady.Text = "Yes"
            .CheckPrint.Checked = printReceipt
        End With

        Me.Dispose()
    End Sub

    Private Sub btnAddCashCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCashCustomer.Click
        ShowCashCustomersAsGrid()
    End Sub

    Private Sub ButtonAddNewCashCustomer_Click(sender As Object, e As EventArgs) Handles btnAddNewCashCSTMR.Click
        Dim newCustomerForm As New CashCustomerDetails
        newCustomerForm.Text = "اضافة زبون نقدي جديد"
        newCustomerForm.Mode = CustomerMode.Cash
        If newCustomerForm.ShowDialog() = DialogResult.OK Then
            GetCashCustomers()   'Refresh after new customer added
        End If
    End Sub
    Private Sub btnAddCreditCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCreditCustomer.Click
        Dim frm As New CashCustomerDetails
        frm.Mode = CustomerMode.Credit
        frm.Text = "اضافة زبون آجل جديد"

        ' Refresh only if customer was successfully added
        If frm.ShowDialog() = DialogResult.OK Then
            ShowCreditCustomersAsGrid()
        End If
    End Sub

    Private Sub BtnGoBack_Click(sender As Object, e As EventArgs)
        RestorePaymentOptions()
    End Sub
End Class

Public Class Payment
    Public Property PaymentOption As String
    Public Property Amount As Decimal
    Public Property AccountNo As String
    Public Property RefNo As Integer
    Public Property RefName As String
    Public Property CustomerID As Integer
    Public Property CardMethodID As Integer
End Class
