Imports System.Data.SqlClient

Public Class SambaUnMatchAccounts

    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles txtReferance.Properties.BeforePopup

    End Sub

    Private Sub SambaUnMatchAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
        txtReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            Dim _SambaName, _ttsName, _ttsAccountNo, _ttsAccountType, _Referance As String
            _SambaName = txtSambaName.Text
            _ttsName = txtAccount.Text
            _ttsAccountNo = txtAccount.EditValue
            _Referance = txtReferance.EditValue
            _ttsAccountType = txtttsAccountType.Text
            Dim connString As String = txtConnectionString.Text
            Dim conn As New SqlConnection(connString)
            conn.Open()
            Dim Sqlstring As String = " Insert Into AccountsMapWithTTS 
                                        (SambaName,ttsName,ttsAccountNo,ttsAccountType,ttsRefNo) 
                                        Values 
                                        (N'" & _SambaName & "',N'" & _ttsName & "','" & _ttsAccountNo & "','" & _ttsAccountType & "','" & _Referance & "') "
            Dim comm As New SqlCommand(Sqlstring, conn)
            comm.ExecuteNonQuery()
            MsgBoxShowSuccess(" تم تعريف الحساب بنجاح ")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub txtReferance_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles txtReferance.Properties.AddNewValue
        ReferancessAddNew.TextRefNo.Text = GetReferanceMax() + 1
        ReferancessAddNew.TextRefName.Text = ""
        ReferancessAddNew.TextRefMobile.Text = ""
        ReferancessAddNew.TextRefPhone.Text = ""
        ReferancessAddNew.PriceCategory.EditValue = 1
        ReferancessAddNew.LookRefType.EditValue = 2
        ReferancessAddNew.TextRefName.Select()
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            txtReferance.Properties.DataSource = GetReferences(-1, -1, -1)
        End If
    End Sub

    Private Sub txtttsAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtttsAccountType.SelectedIndexChanged
        If txtttsAccountType.Text = "Customer" Then txtAccount.EditValue = "1104010000"
        If txtttsAccountType.Text = "Employee" Then txtAccount.EditValue = "2102000000"
    End Sub
End Class