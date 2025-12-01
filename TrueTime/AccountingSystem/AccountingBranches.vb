Public Class AccountingBranches
    Public _AddOrEdit As String
    Public _BranchNo As Integer
    Private Sub AccountingBranches_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.TextBranchName.Text = "" Then
            MsgBoxShowError(" يجب تعبئة اسم الفرع ")
        Else
            Dim sql As New SQLControl
            If _AddOrEdit = "Add" Then
                If sql.SqlTrueAccountingRunQuery(" Insert Into [dbo].[AccountingBranches] 
                                                       ([ID],[BranchName],BranchCode) 
                                                        Values 
                                                       ((Select IsNull(Max(ID),0)+1 From AccountingBranches ),
                                                       N'" & TextBranchName.Text & "',(Select IsNull(Max(ID),0)+1 From AccountingBranches )) ") = True Then
                    MsgBoxShowSuccess(" تم تعريف الفرع بنجاح ")
                    Me.Dispose()
                Else
                    MsgBoxShowError(" لم يتم تعريف الفرع ")
                End If

            Else
                If sql.SqlTrueAccountingRunQuery(" Update  [dbo].[AccountingBranches]  
                                                Set  [BranchName]=N'" & TextBranchName.Text & "' 
                                                Where [ID]=" & _BranchNo) = True Then
                    MsgBoxShowSuccess(" تم تعديل  بيانات الفرع بنجاح ")
                    Me.Dispose()
                Else
                    MsgBoxShowError(" لم يتم تعديل بيانات الفرع ")
                End If


            End If
        End If
    End Sub
End Class