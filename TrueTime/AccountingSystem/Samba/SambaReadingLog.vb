Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports TrueTime.DynamicallyConnectionString

Public Class SambaReadingLog
    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick


        Dim _DocID2 As Integer
        Dim _PosNo As Integer
        Dim _ID As Integer
        Dim _WorkPeriodNo As Integer
        Dim _ConnectionString As String
        _DocID2 = GridView1.GetFocusedRowCellValue("DocID2")
        _PosNo = GridView1.GetFocusedRowCellValue("PosNo")
        _ID = GridView1.GetFocusedRowCellValue("ID")
        _WorkPeriodNo = GridView1.GetFocusedRowCellValue("PeriodID")
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  ServerAddress,TempAccounting,CostCenter
                                  FROM AccountingPOSNames 
                                  Where ID=" & _PosNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _ConnectionString = sql.SQLDS.Tables(0).Rows(0).Item("ServerAddress")
            If Not String.IsNullOrEmpty(_ConnectionString) Then
                Try
                    Dim helper As SqlHelper = New SqlHelper(_ConnectionString)
                    If helper.IsConnection Then
                        If XtraMessageBox.Show("سيتم حذف المعالجة، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                            Exit Sub
                        End If
                    Else
                        XtraMessageBox.Show(" لا يوجد اتصال مع سيرفر سامبا ، الرجاء اعادة المحاولة ")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    Exit Sub
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End Try





        Dim rowsAffected As Integer
        Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand("Delete from Journal where DocID2=" & _DocID2 & " And PosNo=" & _PosNo, con)
                con.Open()
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        End Using

        Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand("Delete from SambaReadingLog where ID=" & _ID, con)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Using con As New SqlConnection(_ConnectionString)
            Using cmd As New SqlCommand("update WorkPeriods set StartDescription='' where WorkPeriodNumber=" & _WorkPeriodNo, con)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MsgBox(" تم حذف حركات عدد " & rowsAffected)

    End Sub

    Private Sub SambaReadingLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select * from SambaReadingLog ")
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class