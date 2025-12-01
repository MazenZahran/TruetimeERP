
Public Class ChargeFleet
    Private fleetepository As New FleetRepository()
    Private fleetID As Integer
    Public Sub New(ByVal _fleetID As String)
        InitializeComponent()
        fleetID = _fleetID
    End Sub
    Private Sub ChargeFleet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFleetData()
        txtAmount.EditValue = 0
        RadioGroup1.EditValue = "Set"
        txtAmount.Select()
        TextEditSelectText(txtAmount)
    End Sub
    Private Sub GetFleetData()
        Dim fleet As Fleet = fleetepository.GetFleet(fleetID, 1)
        txtCurrentAmount.Text = fleet.Available_amount
        txtFleetName.Text = fleet.FleetName
        txtRefName.Text = GetRefranceData(fleet.fleetCode).RefName
        txtFleetCode.Text = fleet.fleetCode
        GridControl1.DataSource = fleetepository.GetFleetChargesLog(fleetID, 1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtAmount.Text = "" Then
            MsgBoxShowError(" المبلغ فارغ ")
            Exit Sub
        End If
        Dim _Amount As Decimal
        _Amount = Me.txtNewBalanceAmount.EditValue
        If _Amount < 0 Then
            MsgBoxShowError(" المبلغ خطا ")
            Exit Sub
        End If
        Dim sqlstring As String
        Dim sql As New SQLControl
        If fleetepository.ChargeFleet(fleetID, 1, _Amount) = True Then
            sqlstring = " INSERT INTO [dbo].[OrpakFleetsChargeLog]
           ([RefNo]
           ,[RefName]
           ,[ProcessName]
           ,[Amount]
           ,[LastBalance]
           ,[NewBalance]
           ,[Notes]
           ,[InputDatetime]
           ,[FleetID]
           ,[UserID])
     VALUES
           ('" & txtFleetCode.Text & "'
           ,N'" & txtRefName.Text & "'
           ,'" & RadioGroup1.EditValue & "'
           ," & _Amount & "
           ," & txtCurrentAmount.EditValue & "
           ," & txtNewBalanceAmount.EditValue & "
           ,N'" & txtNote.Text & "'
           ,GetDate()
           ,'" & fleetID & "'
           ,'" & GlobalVariables.CurrUser & "')"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.Close()
        End If



    End Sub


    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged, txtAmount.EditValueChanged
        Select Case RadioGroup1.EditValue
            Case "Set"
                txtNewBalanceAmount.EditValue = txtAmount.EditValue
                txtNote.Text = "ترصيد مبلغ " & txtAmount.Text & " الرصيد الجديد " & txtNewBalanceAmount.Text
            Case "+"
                txtNewBalanceAmount.EditValue = txtCurrentAmount.EditValue + txtAmount.EditValue
                txtNote.Text = "اضافة مبلغ " & txtAmount.Text & " الرصيد الجديد " & txtNewBalanceAmount.Text
            Case "-"
                txtNewBalanceAmount.EditValue = txtCurrentAmount.EditValue - txtAmount.EditValue
                txtNote.Text = "طرح مبلغ   " & txtAmount.Text & " الرصيد الجديد " & txtNewBalanceAmount.Text
        End Select
    End Sub
    Private Sub ItemName_MouseUp(sender As Object, e As MouseEventArgs) Handles txtAmount.MouseUp
        TextEditSelectText(txtAmount)
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GridControl1.ShowPrintPreview()
    End Sub
End Class