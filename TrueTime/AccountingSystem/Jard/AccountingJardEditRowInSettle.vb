Imports DevExpress.XtraEditors

Public Class AccountingJardEditRowInSettle
    Private _ID As Integer
    Public Sub New(ID As Integer)
        InitializeComponent()
        _ID = ID
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update JardSavedSessions Set 
                             balance=" & txtBalance.EditValue & ",
                             LastPurchasePrice=" & txtLastPrice.EditValue & ",
                             ItemCostAmount=" & txtBalance.EditValue * txtLastPrice.EditValue & ",
                             QuantityByMainUnitInJard=" & txtJardQuantity.EditValue & ",
                             AdjustingQuantity=" & txtAdjustingQuantity.EditValue & ",
                             AdjustingAmount=" & txtAdjustingAmount.EditValue & ",Edited=1
                             Where ID=" & _ID
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            Me.Close()
        End If
    End Sub

    Private Sub AccountingJardEditRowInSettle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataFromJardSavedSessions()
    End Sub
    Private Sub GetDataFromJardSavedSessions()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select * from JardSavedSessions where ID=" & _ID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            With sql.SQLDS.Tables(0).Rows(0)
                txtID.EditValue = .Item("ID")
                txtItemNo.EditValue = .Item("StockID")
                txtItemName.EditValue = .Item("ItemName")
                txtBalance.EditValue = .Item("balance")
                txtLastPrice.EditValue = .Item("LastPurchasePrice")
                txtJardQuantity.EditValue = .Item("QuantityByMainUnitInJard")
            End With
        End If
    End Sub
    Private Sub Calc()
        Try
            txtAdjustingQuantity.EditValue = txtJardQuantity.EditValue - txtBalance.EditValue
            txtAdjustingAmount.EditValue = (txtJardQuantity.EditValue - txtBalance.EditValue) * txtLastPrice.EditValue
        Catch ex As Exception
            txtAdjustingQuantity.EditValue = 0
            txtAdjustingAmount.EditValue = 0
        End Try

    End Sub

    Private Sub txtLastPrice_EditValueChanged(sender As Object, e As EventArgs) Handles txtLastPrice.EditValueChanged
        Calc()
    End Sub

    Private Sub txtBalance_EditValueChanged(sender As Object, e As EventArgs) Handles txtBalance.EditValueChanged
        Calc()
    End Sub

    Private Sub txtJardQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles txtJardQuantity.EditValueChanged
        Calc()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If XtraMessageBox.Show(" سيتم حذف السجل، هل تريد الاستمرار ؟ ", " تاكيد ", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Delete from JardSavedSessions where ID=" & _ID
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                Me.Close()
            End If
        End If
    End Sub
End Class