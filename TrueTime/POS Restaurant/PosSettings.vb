Imports System.Drawing.Printing
Imports GMap.NET

Public Class PosSettings
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrEmpty(TextPosNo.Text) Then
            MsgBox("لا يمكن الحفظ ، يرجى تعبئة رقم نقطة البيع")
            Exit Sub
        End If

        If ComboItemsViewTemplates.Text = "" Then
            MsgBox(" يجب اختيار قالب عرض الاصناف")
            Exit Sub
        End If

        Try
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            Dim settings = My.Settings.Default
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            settings.POSNo = TextPosNo.Text
            settings.Save()
            MsgBox("تم حفظ الاعدادات")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Update [AccountingPOSNames] set 
                          PaperSize=N'" & txtPaperSize.Text & "' ,
                          DefaultStatusForPrintReceipt=N'" & CheckPrintReceipt.EditValue & "' ,
                          DefaultStatusForSendReceiptByWhatsApp=N'" & CheckSendReceiptByWhatApp.EditValue & "' ,
                          ItemsViewTemplateName=N'" & ComboItemsViewTemplates.Text & "' 
                          Where ID= " & Me.TextPosNo.Text
            sql.SqlTrueAccountingRunQuery(sqlstring)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextPosNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextPosNo.EditValueChanged
        Try
            Me.TextPosName.Text = ""
            Me.TextWahreHouse.Text = ""
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT [ID],[POSCode],[POSName],[CostCenter],[PrefixCode],
                                                   [BranchID],[Warehouse],[OnlineOnly],[Note1],
                                                   [Note2],IsNull([PaperSize],'80*80') as PaperSize,[OpenCashDrawerOnSave],[POSQr],
                                                   [ServerAddress],[DefaultPrinter],[Tickets],
                                                   IsNull(DefaultStatusForPrintReceipt,1) as DefaultStatusForPrintReceipt,  
                                                   IsNull(DefaultStatusForSendReceiptByWhatsApp,1) as DefaultStatusForSendReceiptByWhatsApp ,
                                                   IsNull(ItemsViewTemplateName,'TileViewWithImages') as ItemsViewTemplateName 
                                            FROM [dbo].[AccountingPOSNames] 
                                            Where ID= " & Me.TextPosNo.Text)
            Me.TextPosName.Text = sql.SQLDS.Tables(0).Rows(0).Item("POSName")
            Me.TextWahreHouse.Text = sql.SQLDS.Tables(0).Rows(0).Item("Warehouse")
            Me.txtPaperSize.Text = sql.SQLDS.Tables(0).Rows(0).Item("PaperSize")
            Me.CheckPrintReceipt.Checked = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DefaultStatusForPrintReceipt"))
            Me.CheckSendReceiptByWhatApp.Checked = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DefaultStatusForSendReceiptByWhatsApp"))
            Me.ComboItemsViewTemplates.Text = sql.SQLDS.Tables(0).Rows(0).Item("ItemsViewTemplateName")

        Catch ex As Exception
            MsgBox("لا يوجد بيانات")
        End Try


    End Sub

    Private Sub PosSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Warehouses' table. You can move, or remove it, as needed.
        Me.WarehousesTableAdapter.Fill(Me.AccountingDataSet.Warehouses)
        Me.TextPosNo.Text = My.Settings.POSNo
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowTaqseet.CheckedChanged

    End Sub

    Private Sub CheckSendReceiptByWhatApp_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSendReceiptByWhatApp.CheckedChanged

    End Sub

    Private Sub CheckPrintReceipt_CheckedChanged(sender As Object, e As EventArgs) Handles CheckPrintReceipt.CheckedChanged

    End Sub
End Class