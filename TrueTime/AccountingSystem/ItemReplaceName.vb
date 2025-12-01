Imports System.Data.SqlTypes

Public Class ItemReplaceName
    Private ItemCount As Integer
    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click, LabelControl2.Click

    End Sub

    Private Sub ItemReplaceName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LabelCount.Text = ""
        Me.BarResult.Caption = ""
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextOldText.EditValueChanged
        LabelCount.Text = ""
        BarResult.Caption = ""
        ItemCount = 0
        If Me.TextOldText.Text <> "" Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select count(ID) as count from Items WHERE ItemName LIKE N'%" & TextOldText.Text & "%'"
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                LabelCount.Text = " عدد الأصناف التي تحتوي على كلمة " & TextOldText.Text & " : " & " " & sql.SQLDS.Tables(0).Rows(0).Item("count")
                ItemCount = sql.SQLDS.Tables(0).Rows(0).Item("count")
            End If
            'LabelCount.Text = (sql.SqlTrueAccountingRunQueryWithResultCount(sqlstring))
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        BarResult.Caption = ""
        If ItemCount = 0 Then
            MsgBoxShowError(" لا يوجد اصناف ")
        End If
        If Me.TextNewText.Text <> "" And Me.TextOldText.Text <> "" Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Update [dbo].[Items] 
                            Set [ItemName] = ( SELECT REPLACE([ItemName], N'" & TextOldText.Text & "', N'" & TextNewText.Text & "')  ) WHERE ItemName LIKE N'%" & TextOldText.Text & "%'"
            Me.BarResult.Caption = " تم استبدال  " & sql.SqlTrueAccountingRunQueryWithResultCount(sqlstring) & " كلمة  "
        Else
            MsgBoxShowError(" خطا الاسم فارغ ")
        End If

    End Sub
End Class