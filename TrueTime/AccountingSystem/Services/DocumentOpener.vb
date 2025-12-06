Imports System.Data.SqlClient
Imports DevExpress
Imports DevExpress.XtraEditors

' ====================================================================================================
' Document Opener Service
' مسؤول عن فتح جميع أنواع المستندات
' ====================================================================================================
Public Class DocumentOpener
    Private ReadOnly postService As DocumentsPostService
    Private ReadOnly stopwatch As System.Diagnostics.Stopwatch

    Public Sub New()
        Me.postService = New DocumentsPostService()
        Me.stopwatch = New System.Diagnostics.Stopwatch()
    End Sub

    ''' <summary>
    ''' فتح مستند بناءً على DocCode
    ''' </summary>
    Public Function OpenDocument(docCode As String, dataName As String, openFrom As String,
                                 Optional modifiedDateTime As String = "") As String
        ' ✅ نقل startTime خارج Try
        Dim startTime As DateTime = Now

        Try
            ' التحقق من صلاحيات المستخدم
            If GlobalVariables._UserAccessType = 98 Then
                Return "Error: Access Denied"
            End If

            My.Forms.Main.ItemElapseTime.Caption = "0"

            ' الحصول على نوع المستند
            Dim docName As Integer = GetDocNameByDocCode(docCode, dataName)
            If docName = 0 Then
                Return "Error: Document Not Found"
            End If

            ' معالجة الحالات الخاصة
            Select Case dataName
                Case "InsuranceDoc"
                    Return HandleInsuranceDocument(docCode)

                Case "OrdersAppJournal"
                    Return HandleAppJournalDocument(docCode, dataName, docName, openFrom)
            End Select

            ' معالجة مستندات المخزون
            If IsStockDocument(docName) Then
                Return HandleStockDocument(docCode, dataName, docName, modifiedDateTime, startTime)
            End If

            ' معالجة المعاملات المالية
            Select Case docName
                Case 3, 4
                    Return HandleMoneyTransaction(docCode, dataName, docName, modifiedDateTime)
                Case 5
                    Return HandleJournalEntry(docCode, dataName, docName, modifiedDateTime)
                Case 6, 7
                    Return HandleDebitCreditNote(docCode, dataName, docName, modifiedDateTime)
                Case 19
                    Return HandleProductionDocument(docCode, dataName, docName, modifiedDateTime)
            End Select

            Return "Error: Unsupported Document Type"

        Catch ex As Exception
            MsgBoxShowError("خطأ في فتح المستند: " & ex.Message)
            Return "Error: " & ex.Message
        Finally
            ' ✅ الآن يمكن الوصول إلى startTime
            Dim elapsedTime As TimeSpan = Now.Subtract(startTime)
            My.Forms.Main.ItemElapseTime.Caption = elapsedTime.TotalSeconds.ToString("0.00")
        End Try
    End Function

    ''' <summary>
    ''' التحقق من نوع المستند
    ''' </summary>
    Private Function IsStockDocument(docName As Integer) As Boolean
        Return docName = 1 OrElse docName = 2 OrElse docName = 8 OrElse docName = 9 OrElse
               docName = 12 OrElse docName = 13 OrElse docName = 16 OrElse docName = 17 OrElse
               docName = 18 OrElse docName = 10 OrElse docName = 11
    End Function

    ''' <summary>
    ''' معالجة مستندات المخزون
    ''' </summary>
    Private Function HandleStockDocument(docCode As String, dataName As String, docName As Integer,
                                        modifiedDateTime As String, startTime As DateTime) As String
        Try
            Dim form As New AccStockMove()
            form.DocName.EditValue = docName

            ' استخدام الـ Unified Loader
            Dim loader As New UnifiedDocumentLoader(form)
            Dim success As Boolean = loader.LoadDocument(docCode, dataName, modifiedDateTime)

            Return If(success, "Success", "Error")

        Catch ex As Exception
            MsgBoxShowError("خطأ في تحميل المستند: " & ex.Message)
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة مستندات التأمين
    ''' </summary>
    Private Function HandleInsuranceDocument(docCode As String) As String
        Try
            Dim form As New InsuranceDoc()
            With form
                .DocCode.Text = docCode
                .TextDocNewOld.Text = "Old"
                .Show()
            End With
            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة المعاملات المالية
    ''' </summary>
    Private Function HandleMoneyTransaction(docCode As String, dataName As String,
                                           docName As Integer, modifiedDateTime As String) As String
        Try
            Dim docData = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)
            My.Forms.MoneyTrans.Show()
            My.Forms.MoneyTrans.DocName.EditValue = docData.DocName
            My.Forms.MoneyTrans.TextDocIDQuery.EditValue = docData.DocID
            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة القيود اليومية
    ''' </summary>
    Private Function HandleJournalEntry(docCode As String, dataName As String,
                                       docName As Integer, modifiedDateTime As String) As String
        Try
            Dim form As New Journal()
            Dim docData = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)
            With form
                .TextDocID.EditValue = docData.DocID
                .DocName.EditValue = docData.DocName
                .TextDocIDQuery.EditValue = docData.DocID
                .TextOpenFrom.Text = MoneyTrans.Name
                .DocCode.Text = docCode
                .GridJournal.Select()
                .Show()
            End With
            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة الإشعارات المدينة/الدائنة
    ''' </summary>
    Private Function HandleDebitCreditNote(docCode As String, dataName As String,
                                          docName As Integer, modifiedDateTime As String) As String
        Try
            Dim docData = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)
            My.Forms.CreditDebitNotes.TextDocName.EditValue = docData.DocName
            My.Forms.CreditDebitNotes.TextDocID.EditValue = docData.DocID
            My.Forms.CreditDebitNotes.Show()
            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة مستندات الإنتاج
    ''' </summary>
    Private Function HandleProductionDocument(docCode As String, dataName As String,
                                             docName As Integer, modifiedDateTime As String) As String
        Try
            Dim docData = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)
            Dim form As New ProductionDocument()
            With form
                .TextNewOld.Text = "old"
                .Show()
                .TextQueryID.EditValue = docData.DocID
            End With
            Return "Success"
        Catch ex As Exception
            MsgBoxShowError("لا يمكن فتح السند")
            Return "Error: " & ex.Message
        End Try
    End Function

    ''' <summary>
    ''' معالجة مستندات تطبيق الموبايل
    ''' </summary>
    Private Function HandleAppJournalDocument(docCode As String, dataName As String,
                                             docName As Integer, openFrom As String) As String
        Try
            Dim form As New AccStockMove()
            Dim docData = GetDocDataByDocCode(docCode, dataName)

            With form
                ' حالة المستند والألوان
                .DocStatus.EditValue = docData.DocStatus
                If .DocStatus.EditValue = 2 OrElse .DocStatus.EditValue = 3 Then
                    .DocStatus.BackColor = Color.Red
                End If

                ' البيانات الأساسية
                .DocID.EditValue = docData.DocID
                .DocName.EditValue = docData.DocName
                .DocDate.DateTime = CDate(docData.DocDate)
                .DocManualNo.Text = docData.DocManualNo
                .DocSort.EditValue = docData.DocSort
                .Referance.EditValue = docData.Referance
                .TextReferanceName.EditValue = docData.ReferanceName
                .DocNotes.Text = docData.DocNotes
                .BarInputUser.Caption = docData.InputUser

                ' تحميل جدول التفاصيل
                Dim firstTable As DataTable = GetDocDataTableFromAppSystem(docData.DocName, docCode).FirstTable
                If firstTable IsNot Nothing Then
                    .JournalGridControl.DataSource = firstTable
                    .TextVoucherDiscount.EditValue = Convert.ToDecimal(firstTable.Compute("SUM(VoucherDiscount)", String.Empty))
                End If

                ' البيانات الإضافية
                .RepositoryUnit.DataSource = GetAllItemsUnits()
                .StockCreditWhereHouse.EditValue = GetWhareHouseByDocCode(docData.DocName, docCode).WahreHouse
                .AccountForRefranace.EditValue = GetOtherAccountByDocCode(docData.DocName, docCode)

                ' إعدادات النموذج
                .Text = "طلبية مبيعات موبايل"
                .BarBarConvertToSalesVoucher.Visibility = XtraBars.BarItemVisibility.Always
                .BarSubItemSetItemPrices.Visibility = XtraBars.BarItemVisibility.Never
                .DocCurrency.EditValue = 1
                .ExchangePrice.Text = "1"
                .TextOpenFrom.Text = openFrom
                .DocCode.Text = docData.DocCode
                .TextEditDocSource.Text = "OrdersAppJournal"

                ' إعدادات الرؤية
                .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                .BarButtonItemDelete.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never

                If docData.DocStatus = 0 Then
                    .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Else
                    .LayoutCancellAppDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                End If

                If docData.OrderStatus = 1 Then
                    .LayoutControlItemApprove.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                End If

                ' إعدادات القراءة فقط
                .GridView1.OptionsBehavior.Editable = False
                .DocManualNo.ReadOnly = True
                .DocDate.ReadOnly = True
                .DocCurrency.ReadOnly = True
                .Referance.ReadOnly = True
                .LookCostCenter.ReadOnly = True
                .TextReferanceName.ReadOnly = True
                .StockDebitWhereHouse.ReadOnly = True
                .StockCreditWhereHouse.ReadOnly = True
                .DocNotes.ReadOnly = True
                .AccountForRefranace.ReadOnly = True
                .DateDeliverDate.ReadOnly = True
                .SalesPerson.ReadOnly = True
                .TextVoucherDiscount.ReadOnly = True

                ' بيانات الموبايل
                .BarDeviceName.Caption = docData.DeviceName
                .TextOrderStatus.Text = docData.OrderStatus
                .DateDeliverDate.DateTime = CDate(docData.DeliverDate)
                .BarDocCode.Caption = docData.DocCode
                .HyperLinkEdit1.Text = "Mobile Application, from Device :" & docData.DeviceName
                .SalesPerson.EditValue = docData.SalesPerson
                ._DocTagsToOpen = docData.DocTags

                ' معالجة DocCode
                If .DocCode.Text = "0" Then
                    .DocCode.Text = CreateRandomCode()
                End If

                .Show()
            End With

            Return "Success"

        Catch ex As Exception
            MsgBoxShowError("خطأ في فتح مستند الموبايل: " & ex.Message)
            Return "Error: " & ex.Message
        End Try
    End Function
End Class