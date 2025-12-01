Imports DevExpress.XtraEditors

Public Class CRMTaskTrans
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        RefreshData(TextTaskID.EditValue)
    End Sub
    Private Sub RefreshData(_TaskID As Integer)
        Dim Sql As New SQLControl
        Dim SqlString As String
        Try
            SqlString = "   SELECT  A.[TaskID],A.[Notes],
                              [ClosingDate],A.[ID],[UserID],
                              SS.StatusName as LastTaskStatus ,S.StatusName as CurrentTaskStatus,
	                          E.EmployeeName,P.Subject
                      FROM [dbo].[AppointmentClosing] A
                      Left join EmployeesData E on E.EmployeeID= A.UserID 
                      Left join Appointments P on P.UniqueID=A.TaskID
					  left join CRMTaskStatuses S on S.StatusID=A.CurrentTaskStatus 
					   left join CRMTaskStatuses SS on SS.StatusID=A.LastTaskStatus "
            If _TaskID <> -1 Then SqlString += " Where TaskID =" & _TaskID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Me.GridControl2.DataSource = Sql.SQLDS.Tables(0)
            '  GridView1.BestFitColumns()
        Catch ex As Exception

        End Try



        Try
            SqlString = " Select [Subject],[TaskStatus],Location from Appointments where [UniqueID]=" & _TaskID
            Sql.SqlTrueTimeRunQuery(SqlString)
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Subject")) Then
                TextSubject.Text = " الموضوع: " & Sql.SQLDS.Tables(0).Rows(0).Item("Subject")
            End If
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Location")) Then
                TextSubject.Text += " (" & Sql.SQLDS.Tables(0).Rows(0).Item("Location") & ")"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextTaskID_EditValueChanged(sender As Object, e As EventArgs) Handles TextTaskID.EditValueChanged
        RefreshData(TextTaskID.EditValue)
    End Sub

    Private Sub CRMTaskTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.CRMTaskStatuses' table. You can move, or remove it, as needed.
        Me.CRMTaskStatusesTableAdapter.Fill(Me.TrueAccountingDataSet.CRMTaskStatuses)

    End Sub
    Private Sub TileBar2_ItemClick(sender As Object, e As TileItemEventArgs) Handles LabelSubject.ItemClick
        Dim itemTag As Integer = Convert.ToInt32(e.Item.Tag)
        Select Case itemTag
            Case 1
                RefreshData(TextTaskID.EditValue)
        End Select
    End Sub


End Class