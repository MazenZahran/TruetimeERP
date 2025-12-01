Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class ResetData
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DeleteItems()
    End Sub
    Private Sub DeleteItems()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim n As Integer = 0
        Try
            con.ConnectionString = My.Settings.TrueTimeConnectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Delete From Items;Delete From Items_units;Delete from ItemsSerials;Delete from units where id <> 1;DBCC CHECKIDENT ('Items', RESEED, 0);DBCC CHECKIDENT ('Items_units', RESEED, 0);"
            If MessageBox.Show("هل تريد حذف الأصناف؟?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                MsgBox("Operation Cancelled")
                Exit Sub
            End If
            n = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")
        Finally
            con.Close()
        End Try
        LabelResult.Text = "Done," & n & " records Deleted successfully"
    End Sub
    Private Sub DeleteReferances()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim n As Integer = 0
        Try
            con.ConnectionString = My.Settings.TrueTimeConnectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Delete From Referencess"
            If MessageBox.Show("هل تريد حذف الذمم؟?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                MsgBox("Operation Cancelled")
                Exit Sub
            End If
            n = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")
        Finally
            con.Close()
        End Try
        LabelResult.Text = "Done," & n & " records Deleted successfully"
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        DeleteReferances()
    End Sub
    Private Sub DeleteRecoreds()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim n As Integer = 0
        Try
            con.ConnectionString = My.Settings.TrueTimeConnectionString
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "  delete from Journal where [DocDate] <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from JournalBeforeUpdate where [DocDate] <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from JournalTemp;
  delete from OrdersAppJournal where [DocDate] <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from OrdersJournal where [DocDate] <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from POSDeletedJournal where [DocDate] <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from POSHoldJournal ;
  delete from POSJournal;
  delete from PosVouchers where VoucherDateTime <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from PosShifts where EndDateTime <= '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
  delete from PosShiftsByUsers;
  delete from ItemsSerialTrans;
  delete from Appointments ;
  delete from UsersLogs ;
  delete from [dbo].[Checks] ;"
            If MessageBox.Show("هل تريد حذف الحركات؟?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                MsgBox("Operation Cancelled")
                Exit Sub
            End If
            n = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")
        Finally
            con.Close()
        End Try
        LabelResult.Text = "Done," & n & " records Deleted successfully"
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        DeleteRecoreds()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        ' DeleteRecoreds()
    End Sub

    Private Sub ResetData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEdit1.DateTime = Today
    End Sub
End Class