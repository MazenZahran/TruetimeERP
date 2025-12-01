Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports TrueTime.UserAccessManager

Public Class UsersAccess
    Private Sub UsersAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.SearchUser.Properties.DataSource = GetEmployeesTable(-1, -1)
    End Sub
    Private userAccessDict As New Dictionary(Of Integer, Boolean) ' Stores AccessNo and its Boolean value
    Private manager As New UserAccessManager()
    Private connectionString As String = My.Settings.TrueTimeConnectionString


    Private Sub LoadUserAccess(accessUser As String)
        Dim userAccessList = manager.GetUserAccess(accessUser)
        For Each access As UserAccessDetail In userAccessList
            Select Case access.AccessNo
                Case "1"
                    CheckIfHasAccessToEditPrice.Checked = CBool(access.AccessValue)
                Case "2"
                    CheckIfHasAccessToShowBonus.Checked = CBool(access.AccessValue)
                Case "3"
                    CheckIfHasAccessToShowSalesInvoice.Checked = CBool(access.AccessValue)
                Case "4"
                    CheckIfHasAccessToShowReceiptVoucher.Checked = CBool(access.AccessValue)
            End Select
        Next
    End Sub

    Private Sub SearchUser_EditValueChanged(sender As Object, e As EventArgs) Handles SearchUser.EditValueChanged
        LoadUserAccess(SearchUser.EditValue) ' Load user access from DB
    End Sub
    Private Sub SaveUserAccess(accessUser As String, accessNo As Integer, accessValue As String)
        Dim query As String = "IF EXISTS (SELECT 1 FROM UsersAccess WHERE AccessUser = @AccessUser AND AccessNo = @AccessNo)
                            UPDATE UsersAccess 
                            SET AccessValue = @AccessValue
                            WHERE AccessUser = @AccessUser AND AccessNo = @AccessNo
                          ELSE
                            INSERT INTO UsersAccess (AccessUser, AccessNo, AccessValue)
                            VALUES (@AccessUser, @AccessNo, @AccessValue)"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AccessUser", accessUser)
                cmd.Parameters.AddWithValue("@AccessNo", accessNo)
                cmd.Parameters.AddWithValue("@AccessValue", accessValue)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Private Sub CheckIfHasAccessToEditPrice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckIfHasAccessToEditPrice.CheckedChanged
    '    SaveUserAccess(SearchUser.EditValue, 1, CBool(CheckIfHasAccessToEditPrice.Checked))
    'End Sub

    'Private Sub CheckIfHasAccessToShowBonus_CheckedChanged(sender As Object, e As EventArgs) Handles CheckIfHasAccessToShowBonus.CheckedChanged
    '    SaveUserAccess(SearchUser.EditValue, 2, CBool(CheckIfHasAccessToShowBonus.Checked))
    'End Sub

    'Private Sub CheckIfHasAccessToShowSalesInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckIfHasAccessToShowSalesInvoice.CheckedChanged
    '    SaveUserAccess(SearchUser.EditValue, 3, CBool(CheckIfHasAccessToShowSalesInvoice.Checked))
    'End Sub

    'Private Sub CheckIfHasAccessToShowReceiptVoucher_CheckedChanged(sender As Object, e As EventArgs) Handles CheckIfHasAccessToShowReceiptVoucher.CheckedChanged
    '    SaveUserAccess(SearchUser.EditValue, 4, CBool(CheckIfHasAccessToShowReceiptVoucher.Checked))
    'End Sub
End Class