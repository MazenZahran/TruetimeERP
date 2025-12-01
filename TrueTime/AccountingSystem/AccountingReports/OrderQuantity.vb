Imports DevExpress.XtraEditors

Public Class OrderQuantity
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click, SimpleButton4.Click
        If String.IsNullOrEmpty(TextEditItemNo.EditValue) Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(LabelControlItem.Text) Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextEditOrderQuantity.EditValue) Or TextEditOrderQuantity.EditValue <= 0 Then
            XtraMessageBox.Show("خطأ: الكمية يجب أن تكون أكبر من صفر")
            Exit Sub
        End If



        'Dim sql As New SQLControl
        'Dim sqlstring As String
        'sqlstring = " INSERT INTO [dbo].[OrderProcessing]
        '      ([ItemNo]
        '      ,[ItemName]
        '      ,[Quantity]
        '      ,[OrderDate]
        '      ,[OrderByUser]
        '      ,[Orderstatus],[OrderType])
        'VALUES
        '      (" & ItemNo & "
        '      ,N'" & ItemName & "'
        '      ," & OrderedQuantity & "
        '      ,'" & Format(Now, "yyyy-MM-dd HH:mm") & "'
        '      ," & GlobalVariables.CurrUser & "
        '      ,0," & e.Button.Tag & ") "
        'If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
        '    XtraMessageBox.Show("تمت عملية الطلب بنجاح")
        '    BandedGridView1.SetFocusedRowCellValue("OrderedQuantity", OrderedQuantity)
        'End If




    End Sub

    Private Sub OrderQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub
End Class