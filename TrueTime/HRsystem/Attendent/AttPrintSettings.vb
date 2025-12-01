Imports System.Data.SqlTypes

Public Class AttPrintSettings
    Private Sub AttPrintAttendantReportLandscape_CheckedChanged(sender As Object, e As EventArgs) Handles AttPrintAttendantReportLandscape.CheckedChanged
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Settings Set SettingValue='" & AttPrintAttendantReportLandscape.EditValue & "' where SettingName='AttPrintAttendantReportLandscape'"
        sql.SqlTrueTimeRunQuery(sqlstring)
    End Sub

    Private Sub AttPrintAttendantReportNarrowLine_CheckedChanged(sender As Object, e As EventArgs) Handles AttPrintAttendantReportNarrowLine.CheckedChanged
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Settings Set SettingValue='" & AttPrintAttendantReportNarrowLine.EditValue & "' where SettingName='AttPrintAttendantReportNarrowLine'"
        sql.SqlTrueTimeRunQuery(sqlstring)
    End Sub

    Private Sub VocationTableInMonthSalaryVisible_CheckedChanged(sender As Object, e As EventArgs) Handles VocationTableInMonthSalaryVisible.CheckedChanged
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Settings Set SettingValue='" & VocationTableInMonthSalaryVisible.EditValue & "' where SettingName='VocationTableInMonthSalaryVisible'"
        sql.SqlTrueTimeRunQuery(sqlstring)
    End Sub

    Private Sub AttPrintSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportLandscape' "
        Sql.SqlTrueTimeRunQuery(SqlString)
        AttPrintAttendantReportLandscape.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))

        sqlstring = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportNarrowLine' "
        Sql.SqlTrueTimeRunQuery(SqlString)
        AttPrintAttendantReportNarrowLine.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))

        sqlstring = " select SettingValue from Settings where SettingName ='VocationTableInMonthSalaryVisible' "
        sql.SqlTrueTimeRunQuery(sqlstring)
        VocationTableInMonthSalaryVisible.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))

        sqlstring = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportShowEmpID' "
        sql.SqlTrueTimeRunQuery(sqlstring)
        AttPrintAttendantReportShowEmpID.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))

        sqlstring = " select SettingValue from Settings where SettingName ='AttScaleAttendantReport' "
        sql.SqlTrueTimeRunQuery(sqlstring)
        Me.Scale.EditValue = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))


    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles AttPrintAttendantReportShowEmpID.CheckedChanged
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Settings Set SettingValue='" & AttPrintAttendantReportShowEmpID.EditValue & "' where SettingName='AttPrintAttendantReportShowEmpID'"
        sql.SqlTrueTimeRunQuery(sqlstring)
    End Sub

    Private Sub Scale_EditValueChanged(sender As Object, e As EventArgs) Handles Scale.EditValueChanged
        ' Validate Scale before updating
        If Scale.EditValue IsNot Nothing AndAlso
           Not String.IsNullOrWhiteSpace(Scale.EditValue.ToString()) AndAlso
           Scale.EditValue.ToString() <> "0" Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Update Settings Set SettingValue='" & Scale.EditValue & "' where SettingName='AttScaleAttendantReport'"
            sql.SqlTrueTimeRunQuery(sqlstring)
            AttRawatebByShift.PrintScale = Scale.EditValue
        End If
    End Sub
End Class