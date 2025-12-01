Public Class ChangeCheqStatus
    Private _CheqID As Integer
    Private _StatusNo As Integer
    Private _InOrOut As String

    Public Sub New(CheqID As Integer)
        _CheqID = CheqID
        InitializeComponent()
    End Sub
    Private Sub GetSettings()
        Dim Sql As New SQLControl
        Sql.SqlTrueTimeRunQuery(" Select SettingValue FROM [dbo].[Settings] WHERE SettingName='Accounting_AllowChangeChequeStatus' ")
        NewStatus.Enabled = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    End Sub
    Private Sub ChangeCheqStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RelatedReferance.Properties.DataSource = GetReferences(1, -1, -1)
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
        Dim _CheqData = GetChequeData(_CheqID)
        Me.CheqNo.Text = _CheqData.ChequeNo
        Me.DueDate.Text = CDate(_CheqData.ChequeDueDate)
        Me.NewDate.DateTime = CDate(_CheqData.ChequeDueDate)
        Me.Amount.Text = _CheqData.ChequeAmount
        Me.OldStatus.Text = _CheqData.ChequeStatusName
        Me.InOut.Text = _CheqData.CheckInOut
        _StatusNo = _CheqData.CheckStatusNo
        Me.NewStatus.Properties.DataSource = GetChecksStatus(_CheqData.CheckInOut)
        Me.NewStatus.EditValue = _StatusNo
        Me.NewCheqNo.Text = _CheqData.ChequeNo
        Me.RelatedReferance.EditValue = _CheqData.RelatedReferance
        Me.Referance.EditValue = _CheqData.Referance
        GetSettings()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If NewDate.Text = "" Then Exit Sub
        If CheqNo.Text = "" Then Exit Sub
        Dim sql As New SQLControl
        If sql.SqlTrueAccountingRunQuery(" UPDATE [dbo].[Checks] 
                                           SET [CheckDueDate]='" & Format(Me.NewDate.DateTime, "yyyy-MM-dd") & "' , 
                                           [CheckNo]= N'" & NewCheqNo.Text & "',
                                           [CheckStatus]= " & NewStatus.EditValue & ",
                                           [Referance]= " & Referance.EditValue & ",
                                           [RelatedReferance]= " & RelatedReferance.EditValue & "
                                           WHERE [CheckID]=" & _CheqID) = True Then
            MsgBoxShowSuccess(" تم تعديل التاريخ بنجاح ")
            Me.Close()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If NewDate.Text = "" Then Exit Sub
        If CheqNo.Text = "" Then Exit Sub
        Dim sql As New SQLControl
        If Me.InOut.Text = "In" Then
            If sql.SqlTrueAccountingRunQuery(" UPDATE [dbo].[Checks] 
                                           SET [CheckStatus]= 12
                                           WHERE [CheckID]=" & _CheqID) = True Then
                MsgBoxShowSuccess(" تم الغاء الشيك بنجاح ")
                Me.Close()
            End If
        Else
            If sql.SqlTrueAccountingRunQuery(" UPDATE [dbo].[Checks] 
                                           SET [CheckStatus]= 13
                                           WHERE [CheckID]=" & _CheqID) = True Then
                MsgBoxShowSuccess(" تم الغاء الشيك بنجاح ")
                Me.Close()
            End If
        End If

    End Sub

    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles RelatedReferance.Properties.BeforePopup, Referance.Properties.BeforePopup

    End Sub
End Class