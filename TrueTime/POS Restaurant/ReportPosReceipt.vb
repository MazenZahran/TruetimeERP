Imports System.ComponentModel


Public Class ReportPosReceipt
    Public _DocID As Integer
    Public _AmountType As String
    Private Sub ReportPosReceipt_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        Dim _DocData = GetDocumentHeaderData(_DocID, 4)
        Me.XrLabelCustomer.Text = _DocData._ReferanceName
        Me.XrLabelAmount.Text = _DocData._DocAmount & " شيكل  "
        Me.XrLabelNote.Text = _AmountType & ": " & _DocData._DocNote
        Me.XrLabelUserName.Text = _DocData._InputUserID & "  @" & _DocData._InputDateTime
        XrLabelDocDate.Text = _DocData._DocDate
        Me.XrLabelVoucherNo.Text = " رقم السند: " & " " & _DocID


        If GlobalVariables._PosPrintReferanceBalance = True Then
            XrLabelBalance.Text = "( الرصيد المتبقي   " & GetReferanceBalance(_DocData._RefNo) & " شيكل )"
        Else
            XrLabelBalance.Text = ""
        End If

        Dim _CompanyData = GetCompanyData()
        XrLabelCompanyName.Text = _CompanyData.CompanyName
        XrLabelAddress.Text = _CompanyData.CompanyAddress
        Me.XrPictureBox1.Image = GetCompanyImage()
    End Sub
End Class