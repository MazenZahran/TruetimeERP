Imports System.Data.SqlClient

Public Class InstallmentEdit
    Public _NewOld As String
    Public _ID As Integer
    Private Sql As New SQLControl
    Public Property InstallmentID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            ' Check if the value is different from the current ID
            If _ID <> value Then
                _ID = value
                ' Call GetInstallment when ID changes
                GetInstallment(_ID)
            End If
        End Set
    End Property
    Private Sub InstallmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetInstallment(_ID)
    End Sub
    Public Sub GetInstallment(ID As Integer)
        Dim query As String = "SELECT * FROM InstallmentsPayments WHERE ID = " & ID
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(query)
        TxtAmount.Text = sql.SQLDS.Tables(0).Rows(0).Item("Amount")
        TxtDueDate.Text = CDate(sql.SQLDS.Tables(0).Rows(0).Item("DueDate"))
        'Me.TxtReferance.Text = sql.SQLDS.Tables(0).Rows(0).Item("RefName")
        Me.TxtNote.Text = sql.SQLDS.Tables(0).Rows(0).Item("Note")
    End Sub


    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Select Case _NewOld
            Case "Old"
                Dim sqlString = " Update InstallmentsPayments Set Note=N'" & TxtNote.Text & "' WHERE  ID=" & _ID
                Sql.SqlTrueAccountingRunQuery(sqlString)
                Me.Close()
        End Select
    End Sub
End Class