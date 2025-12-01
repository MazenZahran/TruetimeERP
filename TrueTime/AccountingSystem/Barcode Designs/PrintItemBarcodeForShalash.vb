Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI

Public Class PrintItemBarcodeForShalash
    Private Sub TxtQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles txtQuantity.EditValueChanged
        Try
            Dim quantity As Integer = Convert.ToInt32(txtQuantity.Text)
            If quantity < 1 Then
                txtQuantity.Text = "1"
            End If
        Catch ex As Exception
            txtQuantity.Text = "1"
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

        Try
            If IsBarcodeLinked(Me.TxtItemNo.Text, Me.TxtBarcode.Text) Then
                MsgBoxShowSuccess(" لا يمكن طباعة الباكود ")
                Exit Sub
            End If
            If String.IsNullOrEmpty(Me.TxtBarcode.Text) Then
                MsgBoxShowSuccess(" لا يمكن طباعة الباكود ")
                Exit Sub
            End If
            If Me.TxtBarcode.Text = "0" Then
                MsgBoxShowSuccess(" لا يمكن طباعة الباكود ")
                Exit Sub
            End If

            ' Get quantity from the textbox
            Dim quantity As Integer = 1 ' Default value
            If Not String.IsNullOrEmpty(txtQuantity.Text) Then
                Integer.TryParse(txtQuantity.Text, quantity)
            End If

            ' Make sure quantity is at least 1
            If quantity < 1 Then quantity = 1

            Dim itemData = GetItemsData(TxtItemNo.Text, False)
            Dim report As New ShalashItemDataLabel
            With report
                .XrLabelItemName.Text = TruncateTo70(itemData.ItemName)
                Dim _len As Integer = 0
                _len = itemData.ItemName.Length
                Select Case _len
                    Case < 14
                        .XrLabelItemName.Font = New Font("Arial", 24, FontStyle.Bold)
                    Case < 50
                        .XrLabelItemName.Font = New Font("Arial", 20, FontStyle.Bold)
                    Case Else
                        .XrLabelItemName.Font = New Font("Arial", 14, FontStyle.Bold)
                End Select
                .XrLabelItemNo2.Text = itemData._ItemNo2 & " / " & "OE. " & itemData._ItemNo4
                .XrBarCode.Text = TxtBarcode.Text
                If GlobalVariables._Shalash Then
                    .XrLabelDetails.Text = "P. " & ShalashNumbersToLetters(CInt(2 * itemData.LastPurchasePrice)) & " XS " & GetLastShelfNameByWahreHouse(TxtItemNo.Text, 1) & " / " & GetLastShelfNameByWahreHouse(TxtItemNo.Text, 3)
                Else
                    .XrLabelDetails.Text = GetLastShelfNameByWahreHouse(TxtItemNo.Text, 1) & " / " & GetLastShelfNameByWahreHouse(TxtItemNo.Text, 3)
                End If

                .XrLabelDateTime.Text = "Date: " & itemData._LastPurchaseDate & " ItemNo: " & TxtItemNo.Text

                ' Set printer to a specific printer
                report.PrinterName = "itemsprinter2"

                ' IMPORTANT: Generate the document first
                report.CreateDocument()

                ' --- CORRECTED APPROACH TO PRINT ONLY THE FIRST PAGE ---
                ' Get the PrintingSystem from the report
                Dim printingSystem As DevExpress.XtraPrinting.PrintingSystemBase = report.PrintingSystem

                ' Create a PrintTool using the report's PrintingSystem
                Dim printTool As New DevExpress.XtraPrinting.PrintTool(printingSystem)

                For i = 1 To CInt(txtQuantity.EditValue)
                    ' Set the page range to print only the first page (page 1 to 1)
                    printTool.PrinterSettings.FromPage = 1
                    printTool.PrinterSettings.ToPage = 1
                    printTool.Print() ' This will now print only pages 1 to 1 based on PrinterSettings
                Next
            End With

            Me.Close()

            'MessageBox.Show($"{quantity} label(s) sent to printer.", "Print Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error printing barcode: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function IsBarcodeLinked(itemNo As Integer, barCode As String) As Boolean
        Return barCode.Contains(itemNo)
    End Function

    Public Function TruncateTo70(itemName As String) As String
        If String.IsNullOrEmpty(itemName) Then
            Return String.Empty
        End If

        If itemName.Length <= 70 Then
            Return itemName
        Else
            Return itemName.Substring(0, 70)
        End If
    End Function

    Private Sub PrintItemBarcodeForShalash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQuantity.Focus()
    End Sub

    Private Sub txtQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles txtQuantity.MouseUp
        TextEditSelectText(txtQuantity)
    End Sub
End Class