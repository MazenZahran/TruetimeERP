Imports DevExpress.DashboardCommon

Public Class WhatsAppLogs
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select * From [WhatsAppLogs] 
                                            Where InputDateTime between '" & Format(DateEdit1.EditValue, "yyyy-MM-dd") & " 00:00:00.000 ' and '" & Format(DateEdit2.EditValue, "yyyy-MM-dd") & " 23:59:59.999'")
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WhatsAppLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEdit1.EditValue = DateTime.Today
        Me.DateEdit2.EditValue = DateTime.Today
    End Sub
End Class