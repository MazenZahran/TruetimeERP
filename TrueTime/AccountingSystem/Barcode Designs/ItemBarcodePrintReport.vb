Imports System.ComponentModel
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting

Public Class ItemBarcodePrintReport50_25
    Public _PageWidth As Decimal
    Public _PageHeight As Decimal
    Public _Top As Decimal
    Public _Bottom As Decimal
    Public _RightMargin As Decimal
    Public _LeftMargine As Decimal
    Public _ShowPrice As Boolean
    Public _SettingsFromDataBase As Boolean
    Public _FormID As Integer

    Private Sub ItemBarcodePrintReport_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        If _SettingsFromDataBase = True Then
            GetReportParametersFromDataBase()
        Else
            Me.PageWidth = _PageWidth
            Me.PageHeight = _PageHeight
            Me.Margins.Top = _Top
            Me.Margins.Bottom = _Bottom
            Me.Margins.Right = _RightMargin
            Me.Margins.Left = _LeftMargine
            lblPrice.Visible = _ShowPrice
            lblItemName.WidthF = (Me.PageWidth * 10) - 50
            XrBarCode1.WidthF = (Me.PageWidth * 10) - 50
            lblPrice.WidthF = (Me.PageWidth * 10) - 50
        End If
        lblPrice.Text = CDec(lblPrice.Text).ToString("N2") & " NIS "
    End Sub
    Private Sub GetReportParametersFromDataBase()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [ID]      ,[FormName]      ,[PageWidth]      ,[PageHeight]      ,[BottomMargin]      ,[TopMargin]
                            ,[ShowPrice]      ,[IsDefault]      ,[RightMargin]      ,[LeftMargin],[DefaultPrinter]
                      FROM [dbo].[BarcodePrinterSettings] Where ID=" & _FormID
        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
            With sql.SQLDS.Tables(0).Rows(0)
                Me.PageWidth = .Item("PageWidth") * 10
                Me.PageHeight = .Item("PageHeight") * 10
                'Me.Margins.Top = .Item("TopMargin") * 10
                'Me.Margins.Bottom = .Item("BottomMargin") * 10
                'Me.Margins.Right = .Item("RightMargin") * 10
                'Me.Margins.Left = .Item("LeftMargin") * 10
                lblPrice.Visible = CBool(.Item("ShowPrice"))

                'lblItemName.WidthF = .Item("PageWidth") * 10 - 50
                'XrBarCode1.WidthF = .Item("PageWidth") * 10 - 50
                'lblPrice.WidthF = .Item("PageWidth") * 10 - 50

                'lblItemName.WidthF = (.Item("PageHeight") / 20) * 10 - 50
                ' XrBarCode1.HeightF = (.Item("PageHeight") / 2) * 10 - 50
                'lblPrice.WidthF = (.Item("PageHeight") / 20) * 10 - 50

            End With
        End If


    End Sub
End Class