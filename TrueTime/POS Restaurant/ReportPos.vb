Imports System.ComponentModel

Public Class ReportPos
    Private Sub ReportPos_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='POS_PrintVoucherNo';
                                    Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='POS_HidePosVoucherImageInHeader'")
            XrLabelVoucherNo.Visible = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Me.ReportHeader.Visible = CBool(Sql.SQLDS.Tables(1).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBoxShowError(" خطا في تحميل اعدادات الطباعة " & ex.Message)
        End Try
    End Sub
End Class