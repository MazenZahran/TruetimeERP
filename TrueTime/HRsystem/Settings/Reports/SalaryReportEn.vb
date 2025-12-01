Imports System.Drawing.Printing
Imports DevExpress.XtraBars
Imports System.Threading.Thread
Imports System.Globalization

Public Class SalaryReportEn
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SalaryReport_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        If GlobalVariables._SystemLanguage = "English" Then
            Me.ApplyLocalization(New CultureInfo("EN"))
        End If
    End Sub
End Class