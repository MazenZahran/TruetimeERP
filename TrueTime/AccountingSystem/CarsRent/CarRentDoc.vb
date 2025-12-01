Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class CarRentDoc
    Dim _RefBithday As DateTime
    Private Sub CarRentDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   RefreshData()
        Me.ReferanceID.Properties.DataSource = GetReferences(-1, -1, -1)
        Me.LookDocStatus.Properties.DataSource = CreateRentDocumentsStatusTable()
        Me.Currency.Properties.DataSource = GetCurrency()
        TabbedControlGroup2.SelectedTabPage = LayoutControlGroupRentData
        RefreshCarData()
    End Sub
    Private Sub RefreshCarData()
        If String.IsNullOrEmpty(Me.DocID.Text) Then Exit Sub
        'If Me.DocID.Text = "-1" Then Exit Sub
        Dim SqlString As String
        Dim sql As New SQLControl
        SqlString = " SELECT  [CarID]      ,[CARNO]      ,[ChassiNoCar]      ,C.[CarType] as MarkaCar     ,C.[CarModel] as ModelCar,CONCAT(M.CarModel , '-' , T.CarType) as CarDet,
                              [YearCar]      ,[ColorCar]      ,[FuelsCar]      ,[ReferanceID]      ,[DatePurchase]      ,[CostCar],
                              [Vender]      ,[DateSale]      ,[SaleCar]      ,[Customer]      ,[CarImage] as  Picture   ,[SortCar],
                              [active]      ,[BegSpedometaer]      ,[CarDetails]      ,[Rented]      ,[MaintenanceAccountNo]      ,[AssetsAccountNo],[DailyAmount],
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsTarkhes] T    WHERE     T.CarID=C.[CarID]     ORDER BY [EndDate] desc) as TarkhesEndDate,
                              (SELECT top 1 [EndDate] FROM [dbo].[CarsInsurance] I  WHERE     I.CarID=C.[CarID]     ORDER BY [EndDate] desc) as InsuranceEndDat,
                              (SELECT top 1 [DocID] FROM [dbo].[CarRentDocuments] R WHERE   [DocStatus]=1  and R.CarID=C.[CarID]     ORDER BY [DocID] desc) as LastDocID
                    FROM [dbo].[CarsRent] C 					
                    left join CarsModel M on C.CarModel=M.CarModelID 
					left join CarsTypes T on C.CarType = T.CarTypeID  Where 1=1 "
        'If Me.DocID.Text = -1 Then
        '    SqlString = SqlString + "  where CarID > 0 and [Rented] = 0 And  [active] = 1  "
        'Else
        '    SqlString = SqlString + "  where CarID =" & Me.CarID.EditValue
        'End If
        Select Case TextDocForWhat.Text
            Case "RentCar"
                SqlString = SqlString + "  And [Rented] = 0 And [active] = 1  "
                Me.DocNote2.ReadOnly = True
                Me.OdometerTo.ReadOnly = True
                ExchangeRate.EditValue = 1
                'LayoutVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "OpenDoc"
                SqlString = SqlString + "  And CarID =" & Me.CarID.EditValue
                CarID.ReadOnly = True
              '  LayoutVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case "ReceiveCar"
                CarID.ReadOnly = True
                SqlString = SqlString + "  And [Rented] = 1 "
                Me.DocNotes.ReadOnly = True
                Me.OdometerFrom.ReadOnly = True
                LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "IssueVoucher"
                CarID.ReadOnly = True
                SqlString = SqlString + "  And CarID =" & Me.CarID.EditValue
                LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                If String.IsNullOrEmpty(VoucherNo.Text) Then
                    VoucherNotes.Text = "تاجير مركبة " & CarID.Text
                    DocDate.DateTime = Today
                    DocManualNo.Text = DocID.Text
                End If
            Case ""
                SqlString = SqlString + "  And CarID < 0 "
        End Select
        sql.SqlTrueAccountingRunQuery(SqlString)
        ' GridControl1.DataSource = sql.SQLDS.Tables(0)
        CarID.Properties.DataSource = sql.SQLDS.Tables(0)

    End Sub

    Private Sub RadioGroup2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleSave.Click
        SaveDoc()
    End Sub
    Private Sub SaveDoc()
        If Me.ReferanceID.Text = "" Then XtraMessageBox.Show("يجب اختيار زبون", "Error", MessageBoxButtons.OK) : Exit Sub
        If CarID.Text = "" Then XtraMessageBox.Show("يجب اختيار مركبة", "Error", MessageBoxButtons.OK) : Exit Sub

        Dim Sql As New SQLControl
        Dim _DocStartDate As String = Format(DocStartDate.DateTime, "yyyy-MM-dd HH:mm")
        Dim _DocEndDate As String = Format(DocEndDate.DateTime, "yyyy-MM-dd HH:mm")
        'If _DocEndDate = "0001-01-01 00:00" Then _DocEndDate = DBNull.Value.ToString()
        If _DocEndDate = "0001-01-01 00:00" Then _DocEndDate = Format(DocStartDate.DateTime, "yyyy-MM-dd HH:mm")
        Dim SQlString As String
        Select Case DocID.EditValue
            Case -1
                Dim _DocCode As String
                _DocCode = CreateRandomCode()
                Me.TextDocCode.Text = _DocCode
                '  If XtraMessageBox.Show("هل تريد حفظ سند الايجار", "ادخال سند جديد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                SQlString = " Insert Into [dbo].[CarRentDocuments] 
                              ([CarID],[ReferanceID],[DocStartDate],[DocEndDate],[OdometerFrom],[OdometerTo],
                              [Amount],[Currency],[ExchangeRate],[DocBaseAmount],[DocNotes],[DocStatus],[ReferanceName],[DocNote2],[DocCode],[DailyAmount],[FuelPercentage])
                              Values
                              ('" & CarID.EditValue & "','" & ReferanceID.EditValue & "','" & _DocStartDate & "','" & _DocEndDate & "',
                              " & OdometerFrom.EditValue & "," & OdometerTo.EditValue & "," & Amount.EditValue & "," & Currency.EditValue & ",
                              " & ExchangeRate.EditValue & "," & DocBaseAmount.EditValue & ",N'" & DocNotes.Text & "',
                              " & LookDocStatus.EditValue & ",N'" & ReferanceID.Text & "',N'" & DocNote2.Text & "','" & Me.TextDocCode.Text & "','" & Me.TextDailyAmount.EditValue & "'," & Me.TrackBarControl1.EditValue & ")
                              ;Update [dbo].[CarsRent] Set [Rented]=1,[Customer]=N'" & ReferanceID.Text & "' Where CarID=" & CarID.EditValue
                    If Sql.SqlTrueAccountingRunQuery(SQlString) Then
                        UpdateAppointments()
                    Updaterefdata()
                    SendMessage()
                    UpdateAdditionalDriverdata()
                    ' XtraMessageBox.Show("تم حفظ سند الايجار", "تأكيد الادخال", MessageBoxButtons.OK)
                End If
               ' End If

                    Case > 0
                Select Case Me.TextDocForWhat.Text
                    Case "ReceiveCar"
                        If _DocEndDate = "1900-01-01 00:00" Then XtraMessageBox.Show("يجب اختيار تاريخ الاستلام", "Error", MessageBoxButtons.OK) : Exit Sub
                        If DocEndDate.DateTime < DocStartDate.DateTime Then MsgBox("تاريخ التسليم اقل من تاريخ الايجار") : Exit Sub
                        ' If XtraMessageBox.Show("هل تريد حفظ سند الايجار", "تاكيد استلام المركبة", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub
                        SQlString = " Update [dbo].[CarRentDocuments] Set
                                     [CarID]='" & CarID.EditValue & "', ReferanceID='" & ReferanceID.EditValue & "',
                                     [DocStartDate]='" & _DocStartDate & "', DocEndDate='" & _DocEndDate & "',
                                     [OdometerFrom]='" & OdometerFrom.EditValue & "', OdometerTo='" & OdometerTo.EditValue & "',
                                     [Amount]='" & Amount.Text & "', Currency='" & Currency.EditValue & "',
                                     [ExchangeRate]='" & ExchangeRate.Text & "', DocBaseAmount='" & DocBaseAmount.EditValue & "',
                                     [DocNotes]=N'" & DocNotes.Text & "', 
                                     ReferanceName=N'" & ReferanceID.Text & "', DocNote2=N'" & DocNote2.Text & "',DocCode='" & Me.TextDocCode.Text & "',
                                     DailyAmount='" & Me.TextDailyAmount.EditValue & "',FuelPercentage=" & Me.TrackBarControl1.EditValue & ""
                        SQlString += " ,DocStatus=2"
                        SQlString += " Where DocID=" & Me.DocID.Text
                        If Me.LookDocStatus.EditValue = 1 Then
                            SQlString += " ;Update [dbo].[CarsRent] Set [Rented]=0,[Customer]=Null Where CarID=" & CarID.EditValue
                        End If
                        If Sql.SqlTrueAccountingRunQuery(SQlString) = True Then
                            UpdateAppointments()
                            UpdateAdditionalDriverdata()
                            Updaterefdata()
                            XtraMessageBox.Show("تم استلام المركبة ", "تأكيد الاستلام", MessageBoxButtons.OK)
                        End If

                    Case "OpenDoc"
                        '  If XtraMessageBox.Show("هل تريد حفظ التعديلات على سند الايجار", "تأكيد حفظ التعديل", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub
                        SQlString = " Update [dbo].[CarRentDocuments] Set
                                     [CarID]='" & CarID.EditValue & "', ReferanceID='" & ReferanceID.EditValue & "',
                                     [DocStartDate]='" & _DocStartDate & "', DocEndDate='" & _DocEndDate & "',
                                     [OdometerFrom]='" & OdometerFrom.EditValue & "', OdometerTo='" & OdometerTo.EditValue & "',
                                     [Amount]='" & Amount.Text & "', Currency='" & Currency.EditValue & "',
                                     [ExchangeRate]='" & ExchangeRate.Text & "', DocBaseAmount='" & DocBaseAmount.EditValue & "',
                                     [DocNotes]=N'" & DocNotes.Text & "', 
                                     ReferanceName=N'" & ReferanceID.Text & "', DocNote2=N'" & DocNote2.Text & "',DocCode='" & Me.TextDocCode.Text & "',
                                     DailyAmount='" & Me.TextDailyAmount.EditValue & "',FuelPercentage=" & Me.TrackBarControl1.EditValue & ""
                        SQlString += " ,DocStatus=" & LookDocStatus.EditValue & ""
                        SQlString += " Where DocID=" & Me.DocID.Text
                        If (Me.LookDocStatus.EditValue = 2 Or Me.LookDocStatus.EditValue = 3) Then
                            SQlString += " "
                        End If
                        If (Me.LookDocStatus.EditValue = 1) Then
                            SQlString += " ;Update [dbo].[CarsRent] Set [Customer]=N'" & ReferanceID.Text & "' Where CarID=" & CarID.EditValue
                        End If
                        If Sql.SqlTrueAccountingRunQuery(SQlString) = True Then
                            UpdateAppointments()
                            Updaterefdata()
                            UpdateAdditionalDriverdata()
                            XtraMessageBox.Show("تم تعديل سند الايجار", "تأكيد التعديل", MessageBoxButtons.OK)
                        End If

                    Case "IssueVoucher"
                        Me.Text = "فوترة السند"
                        ' If XtraMessageBox.Show("هل تريد حفظ التعديلات على سند الايجار واصدار فاتورة", "تأكيد حفظ التعديل واصدار فاتورة", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub
                        Dim _DocCode As String
                        _DocCode = CreateRandomCode()
                        SQlString = " Update [dbo].[CarRentDocuments] Set
                                     [CarID]='" & CarID.EditValue & "', ReferanceID='" & ReferanceID.EditValue & "',
                                     [DocStartDate]='" & _DocStartDate & "', DocEndDate='" & _DocEndDate & "',
                                    [OdometerFrom]='" & OdometerFrom.EditValue & "', OdometerTo='" & OdometerTo.EditValue & "',
                                     [Amount]='" & Amount.Text & "', Currency='" & Currency.EditValue & "',
                                     [ExchangeRate]='" & ExchangeRate.Text & "', DocBaseAmount='" & DocBaseAmount.EditValue & "',
                                     [DocNotes]=N'" & DocNotes.Text & "', 
                                     ReferanceName=N'" & ReferanceID.Text & "', DocNote2=N'" & DocNote2.Text & "',DocCode='" & Me.TextDocCode.Text & "'"
                        SQlString += " ,DocStatus=" & 3 & ""
                        SQlString += " Where DocID=" & Me.DocID.Text
                        If (Me.LookDocStatus.EditValue = 1) Then
                            SQlString += " ;Update [dbo].[CarsRent] Set [Customer]=N'" & ReferanceID.Text & "' Where CarID=" & CarID.EditValue
                        End If
                        If Sql.SqlTrueAccountingRunQuery(SQlString) = True Then
                            Updaterefdata()
                            UpdateAdditionalDriverdata()
                            UpdateAppointments()
                            '  XtraMessageBox.Show("هل تريد اصدار فاتورة", "تأكيد اصدار الفاتورة", MessageBoxButtons.OK)
                            Dim _DebitAcc As String = ""
                            Dim _CreditAcc As String = ""
                            Dim _ReferanceID As String = ""
                            Dim _ReferanceName As String = ""
                            Dim _CostCenter As Integer = 1
                            _ReferanceID = Me.ReferanceID.EditValue
                            _DebitAcc = GetRefranceData(_ReferanceID).RefAccID
                            _CreditAcc = GetCarAccounts(CarID.EditValue).AccSales
                            _CostCenter = GetCarAccounts(CarID.EditValue).CarCostCenter
                            _ReferanceName = ReferanceID.Text
                            Dim _DocID As Integer = GetDocNo(2, False)
                            Dim Sql2 As New SQLControl
                            Dim SqlInsertDetials As String
                            'Insert Debit Account
                            SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode,[LastDocCode] ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 1 & "',
                                      '" & _CostCenter & "',
                                      '" & _DebitAcc & "',
                                      '" & "0" & "',
                                      '" & GetFinancialAccountsData(_DebitAcc).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & Amount.Text & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetFinancialAccountsData(_DebitAcc).Currency, Amount.Text, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & Amount.Text * ExchangeRate.Text & "',
                                      '" & DocManualNo.Text & "',
                                       N'" & "تاجير مركبة " & CarID.Text & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & 0 & "',
                                      '" & "0" & "',
                                      '" & "0" & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceID.EditValue & "',
                                      N'" & ReferanceID.Text & "',
                                      N'" & "0" & "',
                                      '" & _DocCode & "',
                                      '" & Me.TextDocCode.Text & "'
                                            )"
                            If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                                XtraMessageBox.Show("خطا بعملية الحفظ", "Error", MessageBoxButtons.OK)
                                DeleteFromJournalTemp(2, _DocCode)
                                Exit Sub
                            End If
                            'Insert Credit Account
                            SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,StockQuantity, 
                                       [StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,DocCode,[LastDocCode] ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(DocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 2 & "', 
                                      '" & 1 & "',
                                      '" & _CostCenter & "',
                                      '" & "0" & "',
                                      '" & _CreditAcc & "',
                                      '" & GetFinancialAccountsData(_CreditAcc).Currency & "',
                                      '" & Currency.EditValue & "',
                                      '" & Amount.Text & "',
                                      '" & ExchangeRate.Text & "',
                                      '" & GetBaseAmount(GetBankAccountsData(_DebitAcc)._Currency, Amount.Text, Currency.EditValue, DocDate.DateTime, ExchangeRate.Text) & "',
                                      '" & Amount.Text * ExchangeRate.Text & "',
                                      '" & DocManualNo.Text & "',
                                       N'" & "تاجير مركبة " & CarID.Text & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now, "yyyy-MM-dd HH:mm") & "',
                                      '" & GetCarAccounts(CarID.EditValue).RelatedService & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & Amount.Text & "',
                                      '" & "0" & "',
                                      '" & GetDefaultWharehouse() & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & ReferanceID.EditValue & "',
                                      N'" & ReferanceID.Text & "',
                                      N'" & GetCarAccounts(CarID.EditValue).ItemName & "',
                                      '" & _DocCode & "',
                                      '" & Me.TextDocCode.Text & "'
                                            )"
                            If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                                XtraMessageBox.Show("خطا بعملية الحفظ", "Error", MessageBoxButtons.OK)
                                DeleteFromJournalTemp(2, _DocCode)
                                Exit Sub
                            End If
                            If InsertFromTempToJournal(2, _DocID) = True Then
                                DeleteFromJournalTemp(2, _DocCode)
                                VoucherNo.Text = _DocID
                                Sql.SqlTrueAccountingRunQuery(" Update [dbo].[CarRentDocuments] Set VoucherNo= " & _DocID & " where DocID=" & DocID.EditValue)
                                '  InsertToCalender(R("CheckDueDate"), CDate(R("CheckDueDate")).AddDays(0), "شيك وارد" & " " & FormatNumber(R("DocAmount"), 0) & " " & GetCurrencyCode(R("DocCurrency")), R("ReferanceName"), " شيك وارد مستحق ل  " & R("ReferanceName") & " (" & R("CheckNo") & ")", 3, GlobalVariables.CurrUser, Today(), GlobalVariables.CurrUser, R("Referance"), R("CheckCode"))

                                'XtraMessageBox.Show("تم الترحيل", "", MessageBoxButtons.OK)
                                ' PrintDoc(False)
                            Else
                                MsgBoxShowError(" خطأ بعملية الترحيل  ")
                            End If

                        End If
                End Select



        End Select
        If TextFromBack.Text <> "Main" Then
            Me.Dispose()
        Else
            Me.DocID.EditValue = -1
            RefreshCarData()
        End If




    End Sub

    Private Sub UpdateAppointments()
        If DocStartDate.Text <> "" Then
            InsertToCalender(DocStartDate.DateTime, DocStartDate.DateTime.AddMinutes(30), "تسليم مركبة" & " " & Me.CarID.Text, Me.ReferanceID.Text, " ", 3, GlobalVariables.CurrUser, Today(), -1, ReferanceID.EditValue, Me.TextDocCode.Text & "1")
        End If
        If DocEndDate.Text <> "" Then
            InsertToCalender(DocEndDate.DateTime, DocEndDate.DateTime.AddMinutes(30), "استلام مركبة", Me.ReferanceID.Text, " ", 3, GlobalVariables.CurrUser, Today(), -1, ReferanceID.EditValue, Me.TextDocCode.Text & "2")
        End If
    End Sub
    Private Sub GetCarsRent()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select CarID,CARNO from [dbo].[CarsRent] "
    End Sub

    Private Sub GetCarsTypes()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " SELECT [CarTypeID],[CarType]  FROM [dbo].[CarsTypes] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryType.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetCarsModel()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " SELECT [CarModelID],[CarModel]  FROM [dbo].[CarsModel] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryModel.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetDocumentDataForCar()
        Try
            If Me.CarID.Text = "" Then Exit Sub
            If Me.TextDocForWhat.Text = "ReceiveCar" Then
                Dim SQl As New SQLControl
                SQl.SqlTrueAccountingRunQuery(" SELECT top 1 [DocID],[DocStatus],[DailyAmount] 
                                            FROM [dbo].[CarRentDocuments] R 
                                            WHERE   [DocStatus]=1  and R.CarID=" & Me.CarID.EditValue & "  ORDER BY [DocID] desc  ")
                If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocID")) Then
                    Me.DocID.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocID")
                    ' Me.TextDailyAmount.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("DailyAmount")
                    Me.DocEndDate.DateTime = Now
                End If
                If SQl.SQLDS.Tables(0).Rows(0).Item("DocStatus") = 3 Then
                    'SimpleButton3.Visible = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReferanceID_EditValueChanged(sender As Object, e As EventArgs) Handles ReferanceID.EditValueChanged
        'MsgBox(ReferanceID.EditValue)
        If IsNothing(ReferanceID.EditValue) Then
            Exit Sub
        End If
        If ReferanceID.EditValue = 0 Then Exit Sub
        Dim _RefData = GetRefranceData(ReferanceID.EditValue)
        If _RefData.RefBirthDate <> "" Then TextRefAge.Text = CalcAge(_RefData.RefBirthDate)
        If _RefData._TarkhesIssueDate <> "" Then TextAgeOfTarkhes.Text = CalcAge(_RefData._TarkhesIssueDate)
        DateRefBirthDate.DateTime = CDate(_RefData.RefBirthDate)
        IdentityNo.Text = CStr(_RefData._IdentityNo)
        Nationality.Text = CStr(_RefData._Nationality)
        IdentityType.Text = CStr(_RefData._IdentityType)
        TarkhesID.Text = CStr(_RefData._TarkhesID)
        If _RefData._TarkhesIssueDate <> "" Then TarkhesIssueDate.DateTime = CDate(_RefData._TarkhesIssueDate)
        If _RefData._TarkhesEndDate <> "" Then TarkhesEndDate.DateTime = CDate(_RefData._TarkhesEndDate)

        'Me.ReferanceID.Text = _RefData.RefName
        'If _RefData.RefBirthDate <> "" Then
        '    TextRefAge.Text = CalcAge(_RefData.RefBirthDate)
        '    Dim _IdentityNo As Object = ReferanceIDView.GetFocusedRowCellValue("IdentityNo")
        '    Dim _CarTarkhes As Object = ReferanceIDView.GetFocusedRowCellValue("TarkhesEndDate")
        '    TextIdentityNo.Text = CStr(_IdentityNo)
        '    TextCarEndTarkhes.Text = CStr(_CarTarkhes)
        'End If
    End Sub

    Private Sub ReferanceID_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles ReferanceID.AddNewValue
        ReferancessAddNew.TextRefNo.Text = GetReferanceMax() + 1
        ReferancessAddNew.TextRefName.Text = ""
        ReferancessAddNew.TextRefMobile.Text = ""
        ReferancessAddNew.TextRefPhone.Text = ""
        ReferancessAddNew.PriceCategory.EditValue = 1
        ReferancessAddNew.LookRefType.EditValue = 2
        ReferancessAddNew.TextRefName.Select()
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            '  Referance.Properties.DataSource = GetReferences(-1,-1,-1)
            ' Me.Referance.EditValue = ReferancessAddNew.TextRefNo.EditValue
        End If
    End Sub
    Private Sub DocID_EditValueChanged(sender As Object, e As EventArgs) Handles DocID.EditValueChanged
        '   If Not Me.IsHandleCreated = True Then Exit Sub
        '  If String.IsNullOrEmpty(DocID.Text) Then Exit Sub
        Select Case DocID.EditValue
            Case -1
                Me.LookDocStatus.EditValue = 1
                Me.DocStartDate.DateTime = Now
                Me.DocEndDate.DateTime = Now.AddDays(1)
                Me.DocNotes.Text = ""
                OdometerFrom.EditValue = 0
                OdometerTo.EditValue = 0
                Amount.Text = 0
                Currency.EditValue = GetDefaultCurrency()
                DocBaseAmount.EditValue = 0
                Me.DocNote2.Text = ""
                Me.LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                TextDailyAmount.EditValue = 0
                TrackBarControl1.EditValue = 10
            Case >= 1
                Try
                    Dim SQl As New SQLControl
                    Dim SqlString As String
                    SqlString = " Select DocID,ReferanceID,DocStartDate,DocEndDate,OdometerFrom,OdometerTo,Amount,Currency,
                                  ExchangeRate,DocBaseAmount,DocNotes,DocStatus,CarID,ReferanceName,[DocNote2],VoucherNo,
                                  DocCode,DailyAmount,FuelPercentage,AddDriverName,AddDriverIdentityNo,AddDriverIdentityType,
                                  AddDriverBirthday,AddDriverTarkhesIssueDate,AddDriverTarkhesEndDate
                                  From [dbo].[CarRentDocuments] Where DocID=  " & DocID.Text
                    SQl.SqlTrueAccountingRunQuery(SqlString)
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("ReferanceID")) Then ReferanceID.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("ReferanceID")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocStartDate")) Then DocStartDate.DateTime = CDate(SQl.SQLDS.Tables(0).Rows(0).Item("DocStartDate"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocEndDate")) Then DocEndDate.DateTime = CDate(SQl.SQLDS.Tables(0).Rows(0).Item("DocEndDate"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("OdometerFrom")) Then OdometerFrom.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("OdometerFrom")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("OdometerTo")) Then OdometerTo.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("OdometerTo")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("Amount")) Then Amount.Text = SQl.SQLDS.Tables(0).Rows(0).Item("Amount")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("Currency")) Then Currency.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("Currency")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("ExchangeRate")) Then ExchangeRate.Text = SQl.SQLDS.Tables(0).Rows(0).Item("ExchangeRate")

                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocNotes")) Then DocNotes.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocNotes")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocStatus")) Then LookDocStatus.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("DocStatus")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("CarID")) Then CarID.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("CarID")
                    'If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("ReferanceName")) Then ReferanceID.Text = SQl.SQLDS.Tables(0).Rows(0).Item("ReferanceName")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocNote2")) Then DocNote2.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("DocNote2")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("VoucherNo")) Then
                        VoucherNo.Text = SQl.SQLDS.Tables(0).Rows(0).Item("VoucherNo")
                    Else
                        VoucherNo.Text = ""
                    End If
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DailyAmount")) Then TextDailyAmount.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("DailyAmount")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("FuelPercentage")) Then TrackBarControl1.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("FuelPercentage")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocCode")) Then
                        TextDocCode.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocCode")
                    Else
                        TextDocCode.Text = CreateRandomCode()
                    End If
                    If LookDocStatus.EditValue = 1 Or LookDocStatus.EditValue = 2 Then
                        Me.LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    Else
                        Me.LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    End If
                    If LookDocStatus.EditValue <> 2 Then
                        BarButtonItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    End If
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverName")) Then TextAddDriverName.Text = SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverName")
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverBirthday")) Then AddDriverBirthday.DateTime = CDate(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverBirthday"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityNo")) Then Me.AddDriverIdentityNo.Text = CStr(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityNo"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityType")) Then Me.TextAddDriverIdentityType.Text = CStr(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityType"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesEndDate")) Then Me.AddDriverTarkhesEndDate.DateTime = CDate(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesEndDate"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesIssueDate")) Then Me.AddDriverTarkhesIssueDate.DateTime = CDate(SQl.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesIssueDate"))
                    If Not IsDBNull(SQl.SQLDS.Tables(0).Rows(0).Item("DocBaseAmount")) Then DocBaseAmount.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocBaseAmount")
                Catch ex As Exception

                End Try
        End Select

    End Sub

    Private Sub CarID_EditValueChanged(sender As Object, e As EventArgs) Handles CarID.EditValueChanged
        '  MsgBox(CarID.EditValue)
        If IsNothing(CarID.EditValue) Then
            'Me.SimpleSave.Enabled = False
            CarTypeDetails.Text = ""
            TextCarEndTarkhes.Text = ""
            Exit Sub
            '  Me.SimpleButton3.Enabled = False
        Else
            Dim _CarData = GetCarRentDeials(CarID.EditValue)
            CarTypeDetails.Text = _CarData._CarTypeDet
            TextCarEndTarkhes.Text = CalcAgeDesc(CDate(_CarData.TarkhesEndDate))
            TextDailyAmount.Text = _CarData._DailyAmount
            GetDocumentDataForCar()
        End If


        'Try
        '    If Me.CarID.Text = "" Then Exit Sub
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select [CARNO] from [dbo].[CarsRent] where CarID=" & Me.CarID.Text)
        '    Me.CarID.Text = Sql.SQLDS.Tables(0).Rows(0).Item("CARNO")
        'Catch ex As Exception

        'End Try




    End Sub
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private Sub Currency_EditValueChanged(sender As Object, e As EventArgs) Handles Currency.EditValueChanged
        If Me.DocID.EditValue = -1 Then
            If Currency.IsHandleCreated Then
                If Currency.EditValue = _DefaultCurr Then
                    ExchangeRate.EditValue = 1
                    ExchangeRate.ReadOnly = True
                Else
                    ExchangeRate.ReadOnly = False
                    ExchangeRate.EditValue = GetExchengPrice(Currency.EditValue, Format(DocStartDate.DateTime, "yyyy-MM-dd")).PurchasePrice
                End If
            End If
        End If
    End Sub




    Private Sub CarRentDoc_Closed(sender As Object, e As EventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub TextDocForWhat_EditValueChanged(sender As Object, e As EventArgs)
        RefreshCarData()

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        If XtraMessageBox.Show("هل تريد حذف سند الايجار", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Delete From [dbo].[CarRentDocuments] Where DocID= " & Me.DocID.Text & ";
                          Delete From [Appointments] where DocCode='" & Me.TextDocCode.Text & "';
                          Update [dbo].[CarsRent] Set [Rented]=0,[Customer]='' Where CarID=" & CarID.EditValue
            sql.SqlTrueAccountingRunQuery(SqlString)
            Me.Dispose()
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Me.ReferanceID.Properties.DataSource = GetReferences(-1, -1, -1)
        Me.LookDocStatus.Properties.DataSource = CreateRentDocumentsStatusTable()
        Me.Currency.Properties.DataSource = GetCurrency()
        RefreshCarData()
    End Sub
    Private Sub CalcDocBaseAmount()
        Try
            If Amount.IsHandleCreated And ExchangeRate.IsHandleCreated Then
                DocBaseAmount.EditValue = Amount.EditValue * ExchangeRate.EditValue
            End If
        Catch ex As Exception
            DocBaseAmount.EditValue = 0
        End Try


    End Sub

    Private Sub Amount_EditValueChanged(sender As Object, e As EventArgs) Handles Amount.EditValueChanged
        CalcDocBaseAmount()
    End Sub

    Private Sub ExchangeRate_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangeRate.EditValueChanged
        CalcDocBaseAmount()
    End Sub

    Private Sub LookDocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LookDocStatus.EditValueChanged
        If LookDocStatus.EditValue = 3 Then
            '   LayoutControlGroup2.Enabled = False
            '  LayoutControlGroup3.Enabled = False
            'LayoutControlGroup4.Enabled = False
            'LayoutControlGroup5.Enabled = False
            LayoutControlGroup6.Enabled = False
            SimpleSave.Visible = False
            'SimpleButton3.Visible = False
            LayoutControlGroupVoucherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

    End Sub

    Public Function GetCarAccounts(CarID As Integer) As (RelatedService As String, CarCostCenter As Integer, AccSales As String, RelatedServiceName As String, ItemName As String)
        Dim _RelatedService As Integer = 0
        Dim _CarCostCenter As Integer = 1
        Dim _AccSales As String = ""
        Dim _RelatedServiceName As String = ""
        Dim _ItemName As String = ""
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "    Select RelatedService,CarCostCenter,I.AccSales,A.AccName ,I.ItemName
  From [dbo].[CarsRent] C
  Left Join Items I on C.RelatedService=I.ItemNo
  Left Join FinancialAccounts A on A.AccNo=I.AccSales 
  where  CarID = " & CarID
            sql.SqlTrueAccountingRunQuery(SqlString)
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RelatedService"))) Then _RelatedService = sql.SQLDS.Tables(0).Rows(0).Item("RelatedService")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CarCostCenter"))) Then _CarCostCenter = sql.SQLDS.Tables(0).Rows(0).Item("CarCostCenter")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccSales"))) Then _AccSales = sql.SQLDS.Tables(0).Rows(0).Item("AccSales")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccName"))) Then _RelatedServiceName = sql.SQLDS.Tables(0).Rows(0).Item("AccName")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ItemName"))) Then _ItemName = sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
        Catch ex As Exception

        End Try
        Return (_RelatedService, _CarCostCenter, _AccSales, _RelatedServiceName, _ItemName)
    End Function

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub PrintDoc(IsOrigional As Boolean)
        Dim _TextReferanceName, _Referance As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT [ID]      ,[DocID]      ,[DocDate]      ,[DocName]
      ,[DocStatus]      ,[DocCostCenter]      ,[DebitAcc]      ,[CredAcc]      ,[AccountCurr]
      ,[DocCurrency]      ,[DocAmount]      ,[ExchangePrice]      ,[BaseCurrAmount]      ,[BaseAmount]
      ,[DocSort]      ,[Referance]      ,[DocManualNo]      ,[DocMultiCurrency]
      ,[InputUser]      ,[InputDateTime]      ,[ModifiedUser]      ,[ModifiedDateTime]
      ,[DocAuditDate]      ,[DocAuditUser]      ,[DocNotes]      ,[StockID]
      ,[StockUnit]      ,[StockQuantity]      ,[StockQuantityByMainUnit]      ,[StockPrice]
      ,[StockDebitWhereHouse]      ,[StockCreditWhereHouse]
      ,[StockDriver]      ,[StockCarNo]      ,[SalesPerson]      ,[CheckNo]
      ,[CheckInOut]      ,[CheckStatus]      ,[CheckDueDate]      ,[CheckCustBank]
      ,[CheckCustBranch]      ,[CheckCustAccountId]      ,[AccountBank]
      ,[DeleteUser]      ,[DeleteDateTime]      ,[CurrentUserID]      ,[ReferanceName]
      ,[DocCode]      ,[CheckCode]      ,[ItemName]      ,[DocCheckTransID]
      ,[TransNoInJournal]  FROM [dbo].[Journal]
  where docid=" & VoucherNo.Text & " and DocName=2 and DebitAcc <> 0 ")
            _TextReferanceName = sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName")
            _Referance = sql.SQLDS.Tables(0).Rows(0).Item("Referance")
        Catch ex As Exception
            _TextReferanceName = "0"
            _Referance = "0"
        End Try
        Dim _MyCompanyData = GetCompanyData()

        Dim Report As New StockInvoiceReport
        StockReportViwer.DocumentViewer1.DocumentSource = Report

        With Report
            .Parameters("DocID").Value = VoucherNo.Text
            .Parameters("DocName").Value = 2
            If IsOrigional = True Then .DocOriginal.Text = "أصلية"

            .XrLabelDocName.Text = " مبيعات"
            .Parameters("Account").Value = _TextReferanceName
            .Parameters("AccountID").Value = _Referance
            .XrLabel11.Visible = False
            .XrLabel10.Visible = True

            .XrTableCell30.Value = 0
            .XrTableCell31.Value = 0
            '.Parameters("DebitWhereHouse").Value = StockDebitWhereHouse.Text
            '.Parameters("CreditWhereHouse").Value = StockCreditWhereHouse.Text
            .XrLabel6.Text = _MyCompanyData.CompanyName
            .XrLabel7.Text = _MyCompanyData.CompanyAddress
            .XrLabel22.Text = " موبايل " & " : " & _MyCompanyData.CompanyMobile
            .XrLabel23.Text = " هاتف " & " : " & _MyCompanyData.CompanyPhone

            '  .Parameters("Driver").Value = StockDriver.Text
            ' .Parameters("SalesPerson").Value = SalesPerson.EditValue
            ' .Parameters("SalesPersonName").Value = SearchSalesPerson.Text
        End With

        Report.CreateDocument()
        Report.PrintingSystem.ShowMarginsWarning = False

        'If ShowPrintPreview = False Then
        '  Report.Print()
        ' Else
        StockReportViwer.Show()
        ' Report.Print(printerName:="Brother MFC-L2710DN series Printer")
        ' End If
    End Sub


    Private Sub VoucherNo_EditValueChanged(sender As Object, e As EventArgs)
        Try
            If VoucherNo.Text <> "" And DocID.EditValue <> -1 Then
                Dim MM = GetDocData(VoucherNo.Text, 2)
                DocManualNo.Text = MM.DocManualNo
                DocDate.DateTime = CDate(MM.DocDate)
                VoucherNotes.Text = MM.DocNotes
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LabelFormName_Click(sender As Object, e As EventArgs) Handles LabelFormName.Click

    End Sub

    Private Sub ReferanceID_BeforePopup(sender As Object, e As EventArgs) Handles ReferanceID.BeforePopup
        Me.ReferanceID.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub CheckCreateAppointment_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub VoucherNo_Click(sender As Object, e As EventArgs) Handles VoucherNo.Click
        PrintDoc(False)
    End Sub

    Private Sub IdentityNo_EditValueChanged(sender As Object, e As EventArgs) Handles IdentityNo.EditValueChanged
        TextIdentityNo.Text = IdentityNo.Text
    End Sub
    Private Sub Updaterefdata()
        Dim sql As New SQLControl
        Dim _IdentityNo, _Nationality, _IdentityType, _TarkhesID, _TarkhesIssueDate, _TarkhesEndDate, _Bithday As String
        _IdentityNo = IdentityNo.Text
        _Nationality = Nationality.Text
        _IdentityType = IdentityType.Text
        _TarkhesID = TarkhesID.Text
        If TarkhesIssueDate.Text <> "" Then
            _TarkhesIssueDate = Format(TarkhesIssueDate.DateTime, "yyyy-MM-dd")
        Else
            _TarkhesIssueDate = "1900-01-01"
        End If
        If TarkhesEndDate.Text <> "" Then
            _TarkhesEndDate = Format(TarkhesEndDate.DateTime, "yyyy-MM-dd")
        Else
            _TarkhesEndDate = "1900-01-01"
        End If
        If DateRefBirthDate.Text <> "" Then
            _Bithday = Format(DateRefBirthDate.DateTime, "yyyy-MM-dd")
        Else
            _Bithday = "1900-01-01"
        End If
        Dim sqlstring As String
        sqlstring = " Update [dbo].[Referencess] Set 
                             [IdentityNo]='" & _IdentityNo & "',
                             [Nationality] =N'" & _Nationality & "',
                             [IdentityType] = N'" & _IdentityType & "',
                             [TarkhesID] = N'" & _TarkhesID & "',
                             [TarkhesIssueDate] =  '" & _TarkhesIssueDate & "',
                             [TarkhesEndDate] =  '" & _TarkhesEndDate & "',
                             [RefBirthDate]='" & _Bithday & "' 
                             where RefNo=" & ReferanceID.EditValue
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub
    Private Sub UpdateAdditionalDriverdata()
        Dim sql As New SQLControl
        Dim _AddDriverName, _AddDriverIdentityNo, _AddDriverIdentityType, _AddDriverBirthday, _AddDriverTarkhesIssueDate, _AddDriverTarkhesEndDate As String
        _AddDriverName = TextAddDriverName.Text
        _AddDriverIdentityNo = AddDriverIdentityNo.Text
        _AddDriverIdentityType = TextAddDriverIdentityType.Text

        If AddDriverBirthday.Text <> "" Then
            _AddDriverBirthday = Format(AddDriverBirthday.DateTime, "yyyy-MM-dd")
        Else
            _AddDriverBirthday = "1900-01-01"
        End If
        If AddDriverTarkhesEndDate.Text <> "" Then
            _AddDriverTarkhesEndDate = Format(AddDriverTarkhesEndDate.DateTime, "yyyy-MM-dd")
        Else
            _AddDriverTarkhesEndDate = "1900-01-01"
        End If
        If AddDriverTarkhesIssueDate.Text <> "" Then
            _AddDriverTarkhesIssueDate = Format(AddDriverTarkhesIssueDate.DateTime, "yyyy-MM-dd")
        Else
            _AddDriverTarkhesIssueDate = "1900-01-01"
        End If
        Dim sqlstring As String
        sqlstring = " Update [dbo].[CarRentDocuments] Set [AddDriverName]=N'" & _AddDriverName & "',
                             [AddDriverIdentityNo]=N'" & _AddDriverIdentityNo & "',
                             [AddDriverIdentityType] = N'" & _AddDriverIdentityType & "',
                             [AddDriverBirthday] = N'" & _AddDriverBirthday & "',
                             [AddDriverTarkhesIssueDate] =  '" & _AddDriverTarkhesIssueDate & "',
                             [AddDriverTarkhesEndDate] =  '" & _AddDriverTarkhesEndDate & "'
                             where  DocID=" & Me.DocID.Text
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub

    Private Sub DateRefBirthDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateRefBirthDate.EditValueChanged
        If Me.IsHandleCreated Then
            TextRefAge.Text = CalcAge(DateRefBirthDate.DateTime)
        End If
    End Sub

    Private Sub TarkhesIssueDate_EditValueChanged(sender As Object, e As EventArgs) Handles TarkhesIssueDate.EditValueChanged
        If Me.IsHandleCreated Then
            TextAgeOfTarkhes.Text = CalcAge(TarkhesIssueDate.DateTime)
        End If
    End Sub

    Private Sub DocStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles DocStartDate.EditValueChanged
        CalcPeriod()
    End Sub
    Private Sub CalcPeriod()
        Try
            If DocStartDate.Text <> "" And DocEndDate.Text <> "" Then
                Dim date1 As DateTime = DocStartDate.DateTime
                Dim date2 As DateTime = DocEndDate.DateTime
                TimePeriodOfRent.TimeSpan = date2 - date1
                CalcBaseAmount()
            End If
        Catch ex As Exception
            TimePeriodOfRent.TimeSpan = TimeSpan.Zero
        End Try
    End Sub

    Private Sub DocEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles DocEndDate.EditValueChanged
        CalcPeriod()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs)
        'DocBaseAmount.EditValue = (TextEdit1.TotalDays) * TextDailyAmount.EditValue
    End Sub

    Private Sub TextDailyAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextDailyAmount.EditValueChanged
        CalcBaseAmount()
    End Sub
    Private Sub CalcBaseAmount()
        If Me.TextDailyAmount.Text <> "" Then
            Me.DocBaseAmount.EditValue = CInt(CInt(TimePeriodOfRent.TimeSpan.TotalDays) * Me.TextDailyAmount.EditValue)
        End If
    End Sub


    Private Sub OdometerFrom_EditValueChanged(sender As Object, e As EventArgs) Handles OdometerFrom.EditValueChanged
        CalcDistance()
    End Sub
    Private Sub CalcDistance()
        Dim _distance As Integer
        Try
            If OdometerFrom.Text <> "" And OdometerTo.Text <> "" Then
                If OdometerFrom.EditValue < OdometerTo.EditValue Then
                    _distance = OdometerTo.EditValue - OdometerFrom.EditValue
                End If
            End If
        Catch ex As Exception
            _distance = 0
        End Try
        TextDistance.EditValue = _distance
    End Sub


    Private Sub OdometerTo_EditValueChanged(sender As Object, e As EventArgs) Handles OdometerTo.EditValueChanged
        CalcDistance()
    End Sub

    Private Sub BarButtonItemDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDelete.ItemClick
        Select Case LookDocStatus.EditValue
            Case 2
                If XtraMessageBox.Show("هل تريد حذف سند الايجار", "حذف سند ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Dim sql As New SQLControl
                    If sql.SqlTrueAccountingRunQuery(" Update  [dbo].[CarRentDocuments] Set DocStatus=0 where  [DocID]= " & DocID.EditValue) = True Then
                        Me.Dispose()
                    Else
                        XtraMessageBox.Show(" تم حذف السند ")
                    End If

                End If
        End Select
    End Sub

    Private Sub DocBaseAmount_EditValueChanged(sender As Object, e As EventArgs) Handles DocBaseAmount.EditValueChanged
        Amount.EditValue = DocBaseAmount.EditValue
    End Sub
    Private Sub SendMessage()
        If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & ReferanceID.Text & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        _SMSMessagesTempTable.Clear()
        CeateMessagesTempTable()

        Dim sql As New SQLControl
        Dim _BulkNo As Integer
        Try
            sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
            _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
        Catch ex As Exception
            _BulkNo = 0
        End Try

        Dim J As Integer
        J = 1
        Dim _ReferanceNo As String
        Dim _RefMobile, _RefName As String
        Dim _DocAmount As Decimal = 0
        Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
        Dim _OrigionalSMSMessage, _SMSMessage As String
        sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=10")
        _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")
        _ReferanceNo = ReferanceID.EditValue
        If Not String.IsNullOrEmpty(_ReferanceNo) Then
            Dim _RefData = GetRefranceData(_ReferanceNo)
            _RefMobile = _RefData.RefMobile
            _RefName = _RefData.RefName
            _SMSMessage = _OrigionalSMSMessage
            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
            _SMSMessage = _SMSMessage.Replace("#CarNo#", CarID.Text)
            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
            dr("SMSType") = 10
            dr("SMSDetails") = _SMSMessage
            dr("RefNo") = _ReferanceNo
            dr("RefMobile") = _RefMobile
            dr("RefName") = _RefName
            dr("AccrualDateTime") = Format(Today(), "yyyy-MM-dd")
            dr("Sent") = 0
            dr("Sent") = 0
            dr("SmsID") = 0
            dr("SMSStatus") = ""
            If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
            _SMSMessagesTempTable.Rows.Add(dr)
            J += 1
        End If
        Dim f As New SmsSendingForm
        With f
            .GetUnsentMessages(_BulkNo)
            .ShowDialog()
        End With

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick

        ReferancessAddNew.TextRefNo.Text = Me.ReferanceID.EditValue
        ' ReferancessAddNew.TextRefName.Select()
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        SendMessage()
    End Sub
End Class