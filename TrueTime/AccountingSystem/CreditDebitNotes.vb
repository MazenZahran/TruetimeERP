Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class CreditDebitNotes
    Dim DefaultCurrency As Integer
    Public _DocTagsToOpen As String
    Private Sub CreditDebitNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup2
        LoadData()
        If Me.TextDocStatus.EditValue = -1 Then
            TextDocID.EditValue = GetDocNo(TextDocName.EditValue, True)
            DocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
            DocCurrency.EditValue = DefaultCurrency
            ExchangePrice.EditValue = 1
            LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
            LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            GetDocData()
        End If
        'hg
        If Me.TextDocStatus.EditValue = 2 Or Me.TextDocStatus.EditValue = 3 Or Me.TextDocStatus.EditValue = 4 Then
            TextDocManualNo.ReadOnly = True
            DocDate.ReadOnly = True
            DocCurrency.ReadOnly = True
            ExchangePrice.ReadOnly = True
            Referance.ReadOnly = True
            TextReferanceName.ReadOnly = True
            TotalDocAmount.ReadOnly = True
            TextDocNotes.ReadOnly = True
            Account.ReadOnly = True
            LookCostCenter.ReadOnly = True
            TextDocID.ReadOnly = True
            LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If




        Me.KeyPreview = True
        Me.Referance.Select()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveDocument()
        ElseIf e.KeyCode = Keys.F4 Then
            ' ShowPrint()
        ElseIf e.KeyCode = Keys.Escape Then
            If XtraMessageBox.Show("هل تريد الخروج من السند؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub GetDocData()
        Dim Sql As New SQLControl
        Dim SqlString As String

        SqlString = " Select  [DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc], 
                                  [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[DocManualNo],[DocNotes],InputUser,
                                  CurrentUserID,Referance,ReferanceName,[DocCostCenter],DocCode,DocTags from Journal where "
        If Me.TextDocName.EditValue = 7 Then
            SqlString += " [DebitAcc]='0' and DocName=7 and DocID=" & Me.TextDocID.EditValue
        ElseIf Me.TextDocName.EditValue = 6 Then
            SqlString += " [CredAcc]='0' and DocName=6 and DocID=" & Me.TextDocID.EditValue
        End If
        Sql.SqlTrueAccountingRunQuery(SqlString)
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocID")) Then
            Me.TextDocID.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocDate")) Then
            Me.DocDate.DateTime = CDate(Sql.SQLDS.Tables(0).Rows(0).Item("DocDate"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocStatus")) Then
            Me.TextDocStatus.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocStatus"))
        End If
        If Me.TextDocName.EditValue = 7 Then
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("CredAcc")) Then
                Me.Account.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("CredAcc"))
            End If
        ElseIf Me.TextDocName.EditValue = 6 Then
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc")) Then
                Me.Account.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DebitAcc"))
            End If
        End If

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency")) Then
            Me.DocCurrency.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocCurrency"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")) Then
            Me.TotalDocAmount.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocAmount"))
        End If

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Referance")) Then
            Me.Referance.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("Referance"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName")) Then
            Me.TextReferanceName.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("ReferanceName"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")) Then
            Me.TextDocNotes.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocNotes"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")) Then
            Me.ExchangePrice.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter")) Then
            Me.LookCostCenter.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocCostCenter"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo")) Then
            Me.TextDocManualNo.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocManualNo"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")) Then
            Me.TextDocCode.EditValue = (Sql.SQLDS.Tables(0).Rows(0).Item("DocCode"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocTags")) Then
            _DocTagsToOpen = (Sql.SQLDS.Tables(0).Rows(0).Item("DocTags"))
        Else
            _DocTagsToOpen = ""
        End If

        Me.Account.EditValue = GetOtherAccount()

        If Not IsNothing(_DocTagsToOpen) Then
            Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = LayoutControlGroup1.CustomHeaderButtons(0)
            If customHeaderButton IsNot Nothing Then
                Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
                customHeaderButtonTyped.Caption = _DocTagsToOpen
            End If
        Else
            _DocTagsToOpen = ""
        End If

    End Sub
    Private Function GetOtherAccount() As String
        Dim _OtherAccount As String = "0"
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = ""
            If Me.TextDocName.EditValue = 6 Then
                SqlString += " select top(1) CredAcc as Account
                               From Journal
                               where DocID=" & Me.TextDocID.EditValue & " and DocName=6 And DebitAcc='0' "
            ElseIf Me.TextDocName.EditValue = 7 Then
                SqlString += "  Select top(1)  DebitAcc as Account
                                From Journal
                                where DocID=" & Me.TextDocID.EditValue & " and DocName=7 And CredAcc='0' "
            End If
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _OtherAccount = Sql.SQLDS.Tables(0).Rows(0).Item("Account")
        Catch ex As Exception

        End Try
        Return _OtherAccount
    End Function
    Private Sub LoadData()
        Dim SqlString1, SqlString2, SqlString3, SqlString4, SqlString5, SqlString6 As String
        Dim Con As SqlConnection
        Dim Adapter1, Adapter2, Adapter3, Adapter4, Adapter5, Adapter6 As SqlDataAdapter
        Dim dataSet11 As DataSet
        SqlString1 = " Select  CAST([AccNo] AS float) as AccNo, [AccID],[AccName],
                              [Currency],[FinancialStatment],[FinancialSector],
                              [AccType],[FatherAccount] ,[IsMain]
                         From [FinancialAccounts] where  IsMain = 0"
        SqlString2 = " Select RefName,RefNo as RefNo ,RefTypeName,RefMobile,T.TypeID, RefAccID ,F.Currency as Currency 
                                 From Referencess R 
                                 left join ReferencesTypes T on T.TypeID=R.RefType
                                 Left Join FinancialAccounts F on F.AccNo=R.RefAccID "
        SqlString3 = " Select Code,CurrID from Currency"
        SqlString4 = " Select [SettingValue] as ShowCotCenter From [dbo].[Settings] Where [SettingName]='CostCenters'"
        SqlString5 = " SELECT CostID, CostName FROM   CostCenter  "
        SqlString6 = " Select CurrID from Currency where IsDefault =1  "

        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString1, Con)
        Adapter2 = New SqlDataAdapter(SqlString2, Con)
        Adapter3 = New SqlDataAdapter(SqlString3, Con)
        Adapter4 = New SqlDataAdapter(SqlString4, Con)
        Adapter5 = New SqlDataAdapter(SqlString5, Con)
        Adapter6 = New SqlDataAdapter(SqlString6, Con)

        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "FinancialAccounts")
        Adapter2.Fill(dataSet11, "Referencess")
        Adapter3.Fill(dataSet11, "Currency")
        Adapter4.Fill(dataSet11, "Settings")
        Adapter5.Fill(dataSet11, "CostCenter")
        Adapter6.Fill(dataSet11, "DefaultCurrency")
        Me.Referance.Properties.DataSource = dataSet11.Tables("Referencess")
        Me.Account.Properties.DataSource = dataSet11.Tables("FinancialAccounts")
        Me.DocCurrency.Properties.DataSource = dataSet11.Tables("Currency")
        Me.LookCostCenter.Properties.DataSource = dataSet11.Tables("CostCenter")

        If CBool(dataSet11.Tables("Settings").Rows(0).Item("ShowCotCenter")) = True Then
            Me.LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
        Else
            Me.LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        TextDocStatus.Properties.DataSource = GetDocStatus(False)
        DefaultCurrency = dataSet11.Tables("DefaultCurrency").Rows(0).Item("CurrID")


        If Me.TextDocName.EditValue = 7 Then
            Account.EditValue = "3020000000"
            LayoutReferance.Text = "الزبون"
            Me.Text = " اشعار دائن "
        ElseIf Me.TextDocName.EditValue = 6 Then
            Account.EditValue = "4040000000"
            LayoutReferance.Text = "المورد"
            Me.Text = " اشعار مدين "
        End If

        Con.Close()
    End Sub

    Private Sub GetDocData(_DocID As Integer)
        Dim Sql As New SQLControl
        Dim SqlString As String = "  "
    End Sub

    Private Sub SaveDocument()

        Dim _Referance As Integer = 0
        Try
            If Referance.Text = "" Then
                _Referance = 0
            Else
                _Referance = Referance.Text
            End If
        Catch ex As Exception
            _Referance = 0
        End Try

        If String.IsNullOrEmpty(_Referance) Or _Referance = 0 Then
            XtraMessageBox.Show("يجب تعبئة اسم الذمة")
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextReferanceName.Text) Then
            XtraMessageBox.Show("يجب تعبئة اسم الذمة")
            Exit Sub
        End If
        If String.IsNullOrEmpty(TotalDocAmount.Text) Or TotalDocAmount.EditValue = 0 Then
            XtraMessageBox.Show("يجب تعبئة المبلغ")
            Exit Sub
        End If

        If String.IsNullOrEmpty(TotalDocAmount.Text) Or TotalDocAmount.EditValue = 0 Then
            XtraMessageBox.Show("يجب تعبئة المبلغ")
            Exit Sub
        End If


        If String.IsNullOrEmpty(Account.Text) Or Account.EditValue = 0 Then
            XtraMessageBox.Show("يجب اختيار الحساب")
            Exit Sub
        End If

        If DocDate.DateTime > Today Then
            If XtraMessageBox.Show("تاريخ السند اكبر من تاريخ اليوم، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        'Check Cost Center for ref account
        If GlobalVariables._CostCenterRequired = True Then
            If LookCostCenter.Text = "" Then
                Dim _Account As New FinancialAccount
                If _Account.GetAccountData(GetRefranceData(Referance.EditValue).RefAccID) = True Then
                    If _Account.NeedCostCenter = True Then
                        XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        Exit Sub
                    End If
                End If
                If _Account.GetAccountData(Account.EditValue) = True Then
                    If _Account.NeedCostCenter = True Then
                        XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        Exit Sub
                    End If
                End If
            End If
        End If


        Dim _CheckIfDocInJournal As Boolean
        Dim _DocStatus As Integer
        If Me.TextDocStatus.EditValue = "-1" Then
            _CheckIfDocInJournal = False
            _DocStatus = 1
            TextDocCode.Text = CreateRandomCode()
        Else
            ' _CheckIfDocInJournal = CheckIfDocInJournalByDocCode(TextDocCode.Text, "Journal")
            _CheckIfDocInJournal = True
            _DocStatus = Me.TextDocStatus.EditValue
        End If



        Dim sql As New SQLControl
        Dim SqlString As String



        Dim _AccountCurrency As Integer = GetFinancialAccountsData(Account.EditValue).Currency



        Dim _RefData = GetRefranceData(Referance.EditValue)
        Dim _RefAccCurrency As String = _RefData.currency_id
        Dim _RefAccID As String = _RefData.RefAccID
        Dim _DocLogName, _LogDetails As String
        Dim _CurrDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim _DocDate As String = Format(DocDate.DateTime, "yyyy-MM-dd")
        Dim _BaseAmount As Decimal = GetBaseAmount(_AccountCurrency, TotalDocAmount.EditValue, DocCurrency.EditValue, DocDate.DateTime, ExchangePrice.EditValue)
        Dim _BaseAmount2 As Decimal = GetBaseAmount(_RefAccCurrency, TotalDocAmount.EditValue, DocCurrency.EditValue, DocDate.DateTime, ExchangePrice.EditValue)

        Dim _DocIDString As String
        If _CheckIfDocInJournal = False Then
            _DocIDString = "( Select isnull(max([DocID])+1,1)  from Journal where DocName=" & TextDocName.EditValue & ") "
            _DocLogName = "Insert"
            _LogDetails = "Insert Voucher "
        Else
            _DocIDString = Me.TextDocID.Text
            _DocLogName = "Update"
            _LogDetails = "Update Voucher "
        End If

        Select Case TextDocName.EditValue
            Case 7
                ' Debit Side
                SqlString = " Insert Into JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                                [DocCostCenter],DocCode,CurrentUserID,DocTags) 
                                    Values (" & _DocIDString & ",'" & _DocDate & "'," & TextDocName.EditValue & "," & _DocStatus &
                                            ",'" & Account.EditValue & "','0'," & _AccountCurrency & "," & DocCurrency.EditValue &
                                            "," & TotalDocAmount.EditValue & "," & ExchangePrice.EditValue &
                                            "," & TotalDocAmount.EditValue * ExchangePrice.EditValue & "," & _BaseAmount &
                                            ",N'" & TextDocManualNo.Text & "',N'" & Me.TextDocNotes.Text &
                                            "','" & GlobalVariables.CurrUser & "','" & _CurrDateTime &
                                            "','" & Me.Referance.EditValue & "',N'" & TextReferanceName.Text &
                                            "','" & LookCostCenter.EditValue & "','" & TextDocCode.Text & "','" & GlobalVariables.CurrUser & "',N'" & _DocTagsToOpen & "') "
                'Credit Side
                SqlString += "; Insert Into JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                                [DocCostCenter],DocCode,CurrentUserID,DocTags) 
                                    Values (" & _DocIDString & ",'" & _DocDate & "'," & TextDocName.EditValue & "," & _DocStatus &
                                            ",'0','" & _RefAccID & "'," & _RefAccCurrency & "," & DocCurrency.EditValue &
                                            "," & TotalDocAmount.EditValue & "," & ExchangePrice.EditValue &
                                            "," & TotalDocAmount.EditValue * ExchangePrice.EditValue & "," & _BaseAmount2 &
                                            ",N'" & TextDocManualNo.Text & "',N'" & Me.TextDocNotes.Text &
                                            "','" & GlobalVariables.CurrUser & "','" & _CurrDateTime &
                                            "','" & Me.Referance.EditValue & "',N'" & TextReferanceName.Text &
                                            "','" & LookCostCenter.EditValue & "','" & TextDocCode.Text & "','" & GlobalVariables.CurrUser & "',N'" & _DocTagsToOpen & "') "
                sql.SqlTrueAccountingRunQuery(SqlString)

            Case 6
                ' Debit Side
                SqlString = " Insert Into JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[CredAcc],[DebitAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                                [DocCostCenter],DocCode,CurrentUserID,DocTags) 
                                    Values (" & _DocIDString & ",'" & _DocDate & "'," & TextDocName.EditValue & "," & _DocStatus &
                                            ",'" & Account.EditValue & "','0'," & _AccountCurrency & "," & DocCurrency.EditValue &
                                            "," & TotalDocAmount.EditValue & "," & ExchangePrice.EditValue &
                                            "," & TotalDocAmount.EditValue * ExchangePrice.EditValue & "," & _BaseAmount &
                                            ",N'" & TextDocManualNo.Text & "',N'" & Me.TextDocNotes.Text &
                                            "','" & GlobalVariables.CurrUser & "','" & _CurrDateTime &
                                            "','" & Me.Referance.EditValue & "',N'" & TextReferanceName.Text &
                                            "','" & LookCostCenter.EditValue & "','" & TextDocCode.Text & "','" & GlobalVariables.CurrUser & "',N'" & _DocTagsToOpen & "') "
                'Credit Side
                SqlString += "; Insert Into JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[CredAcc],[DebitAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                                [DocCostCenter],DocCode,CurrentUserID,DocTags) 
                                    Values (" & _DocIDString & ",'" & _DocDate & "'," & TextDocName.EditValue & "," & _DocStatus &
                                            ",'0','" & _RefAccID & "'," & _RefAccCurrency & "," & DocCurrency.EditValue &
                                            "," & TotalDocAmount.EditValue & "," & ExchangePrice.EditValue &
                                            "," & TotalDocAmount.EditValue * ExchangePrice.EditValue & "," & _BaseAmount2 &
                                            ",N'" & TextDocManualNo.Text & "',N'" & Me.TextDocNotes.Text &
                                            "','" & GlobalVariables.CurrUser & "','" & _CurrDateTime &
                                            "','" & Me.Referance.EditValue & "',N'" & TextReferanceName.Text &
                                            "','" & LookCostCenter.EditValue & "','" & TextDocCode.Text & "','" & GlobalVariables.CurrUser & "',N'" & _DocTagsToOpen & "') "
                sql.SqlTrueAccountingRunQuery(SqlString)
        End Select


        Dim SqlString3 As String
        SqlString3 = "   Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,DeliverDate,DocTags )"
        SqlString3 += " Select "
        If _CheckIfDocInJournal = False Then
            SqlString3 += "( Select isnull(max([DocID])+1,1)  from journal where DocName=" & TextDocName.EditValue & ") "
        Else
            SqlString3 += "'" & Me.TextDocID.Text & "' "
        End If
        SqlString3 += " , [DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,DeliverDate,DocTags
                                                from JournalTemp  where   DocCode= '" & TextDocCode.Text & "'"

        Dim _AskBeforeSave As String = "0"
        Select Case _CheckIfDocInJournal
            Case True
                _AskBeforeSave = "هل تريد تعديل السند"
            Case False
                _AskBeforeSave = "هل تريد حفظ السند"
        End Select

        If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            If _CheckIfDocInJournal = True Then
                DeleteFromJournal(TextDocName.Text, Me.TextDocID.Text)
                _DocTagsToOpen = ""
            End If
            Dim Sql3 As New SQLControl
            Sql3.SqlTrueAccountingRunQuery(SqlString3)
            DeleteFromJournalTemp(TextDocName.Text, Me.TextDocCode.Text)
            CreateDocLog("Document", Me.TextDocCode.Text, TextDocName.Text, Me.TextDocID.Text, _DocLogName, _LogDetails, _CurrDateTime)
            Dim F As New SavePrintPostDocument
            With F
                .TextDocCode.Text = Me.TextDocCode.Text
                .TextDocData.Text = "Journal"
                If .ShowDialog() = DialogResult.OK Then

                Else

                    Me.Dispose()
                End If
            End With
        Else
            DeleteFromJournalTemp(TextDocName.Text, TextDocCode.Text)
        End If


    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        SaveDocument()
    End Sub

    Private Sub TextDocStatus_EditValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub TextDocName_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocName.EditValueChanged

    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        Dim view2 As GridView = Referance.Properties.View
        Dim rowHandle2 As Integer = view2.FocusedRowHandle
        Dim fieldName2 As String = "RefName"
        Dim _RefName As Object = view2.GetRowCellValue(rowHandle2, fieldName2)
        TextReferanceName.Text = _RefName

        TextRefBalance.Text = GetReferanceBalance(Referance.EditValue)

    End Sub


    Private Sub DocCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles DocCurrency.EditValueChanged
        If Me.IsHandleCreated Then
            Try
                Select Case DocCurrency.EditValue
                    Case CInt(DefaultCurrency), 0
                        ExchangePrice.EditValue = 1
                        ExchangePrice.ReadOnly = True
                    Case Else
                        ExchangePrice.ReadOnly = False
                        ExchangePrice.EditValue = GetExchengPrice(DocCurrency.EditValue, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
                End Select
            Catch ex As Exception
                ExchangePrice.EditValue = 1
                ExchangePrice.ReadOnly = False
            End Try
        End If
    End Sub
    Private Sub Referance_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles Referance.AddNewValue
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            '.LoaddefaultDataSourceforReferences()
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 2
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                Referance.Properties.DataSource = GetReferences(-1, -1, -1)
            End If
            _DocTagsToOpen = ""
        End With
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If DeleteDoc(TextDocName.EditValue, TextDocID.EditValue, Me.TextDocCode.Text, True) = True Then
            Me.Dispose()
        End If
    End Sub

    Private Sub TextDocStatus_EditValueChanged_1(sender As Object, e As EventArgs) Handles TextDocStatus.EditValueChanged
        If Me.TextDocStatus.EditValue = 3 Then
            Me.TextDocStatus.BackColor = Color.Red
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        PrintDoc(False, TextDocCode.Text, "Journal", True, False)
    End Sub

    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub TextDocID_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocID.EditValueChanged
        'GetDocData()
    End Sub

    Private Sub TotalDocAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TotalDocAmount.EditValueChanged

    End Sub

    Private Sub TotalDocAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles TotalDocAmount.MouseUp
        TextEditSelectText(TotalDocAmount)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim F As New DocumentLogs
        With F
            ._DocCode = Me.TextDocCode.Text
            .GridControl1.DataSource = GetDocumentsLogs(Me.TextDocCode.Text, -1)
            .ColDeviceName.Visible = False
            .ColDocName.Visible = False
            '.ColDocID.Visible = False
            .ColUserID.Visible = False
            .ShowDialog()
        End With
    End Sub

    Private Sub LayoutControlGroup1_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles LayoutControlGroup1.CustomButtonClick
        Try
            Dim F As New TagsNames
            With F
                If .ShowDialog() <> DialogResult.OK Then
                    If GlobalVariables._PublicDocumentTags <> "" Then
                        e.Button.Properties.Caption = GlobalVariables._PublicDocumentTags
                        _DocTagsToOpen = GlobalVariables._PublicDocumentTags
                    Else
                        e.Button.Properties.Caption = e.Button.Properties.Caption
                        _DocTagsToOpen = e.Button.Properties.Caption
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class