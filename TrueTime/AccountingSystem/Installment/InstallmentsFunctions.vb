Module InstallmentsFunctions
    Public Sub PayInstallmentByID(InstallmentID As Integer, RefNo As Integer, Amount As Decimal, DueDate As String, Status As Integer)
        If Status = 2 Then
            MsgBoxShowError(" القسط مسدد  ")
            Exit Sub
        End If
        Dim _RefName As String = ""
        Dim _SubNote As String = ""
        Dim _RefBalance As Decimal = 0
        If Not InstallmentID And Not String.IsNullOrEmpty(InstallmentID) Then
            Dim _RefData = GetRefranceData(RefNo)
            _RefName = _RefData.RefName
            _SubNote = " دفعة قسط   " & " ، " & " المستحق بتاريخ  " & DueDate
            Dim f As New PosDirectReceipt
            With f
                ._CostCenter = GetDefaultCostCenter(GlobalVariables.CurrUser)
                ._ShiftID = 0
                ._PosName = 0
                ._DefaultCashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
                ._InputUser = GlobalVariables.CurrUser
                .Referance.EditValue = RefNo
                .Referance.ReadOnly = True
                .MemoEdit1.Text = _SubNote
                .TextAmount.EditValue = Amount
                ._RequiredAmount = Amount
                ._InstallmentID = InstallmentID
                .ShowDialog()
            End With
        End If
    End Sub
End Module
