Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting.Native
Imports DevExpress.XtraReports.UserDesigner

Public Class CarRentpaper2
    Private Sub CarRentpaper2_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        XrRichText1.LoadFile("roles2.docx")
    End Sub

    Private Sub CarRentpaper2_DesignerLoaded(sender As Object, e As DesignerLoadedEventArgs) Handles Me.DesignerLoaded
        XrRichText1.LoadFile("roles2.docx")
    End Sub
End Class