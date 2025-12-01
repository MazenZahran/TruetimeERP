Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class MeatMootReadLog
    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim _DocID2, _ID, _WorkPeriodNo, _PeriodID, _PosNo As Integer
        _DocID2 = GridView1.GetFocusedRowCellValue("DocID2")
        _ID = GridView1.GetFocusedRowCellValue("ID")
        _WorkPeriodNo = GridView1.GetFocusedRowCellValue("PeriodID")
        _PeriodID = GridView1.GetFocusedRowCellValue("PeriodID")
        _PosNo = GridView1.GetFocusedRowCellValue("PosNo")
        If XtraMessageBox.Show("سيتم حذف المعالجة، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If



        Dim rowsAffected As Integer
        Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand("Delete from Journal where DocID2=" & _DocID2, con)
                con.Open()
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        End Using

        Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand("Delete from MeatMootReadingLog where ID=" & _ID, con)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

        Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand("Delete from PosVouchers where ShiftID=" & _PeriodID & " And PosNo=" & _PosNo, con)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using


        XtraMessageBox.Show(" تم حذف حركات عدد " & rowsAffected)

    End Sub

    Private Sub MeatMootReadLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Private Sub GetData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT [ID]
      ,[PeriodID]
      ,[PosNo]
      ,[FromDate]
      ,[ToDate]
      ,[Amount]
      ,[UserName]
      ,[VouchersCount]
      ,[ReadDateTime]
      ,[ReadBy]
      ,[DocID2]
  FROM [dbo].[MeatMootReadingLog] "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class