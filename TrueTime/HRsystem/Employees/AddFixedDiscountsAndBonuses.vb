Public Class AddFixedDiscountsAndBonuses
    Private _EmpID As Integer
    Private _TermType As String
    Private _RecordID As Integer 
    Private Sql As New SQLControl
    Private Sqlstring As String
    Public Sub New(EmpID As Integer, TermType As String, RecordID As Integer)
        _EmpID = EmpID
        _TermType = TermType
        _RecordID = RecordID
        InitializeComponent()
    End Sub
    Private Sub AddFixedDiscountsAndBonuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case _TermType
            Case "Discount"
                Sqlstring = "  select ID as TermID, [PaymentType] as TermType ,DefaultAmount  from [AttPaymentsTypes]  "
                Me.Text = " اضافة خمصيات ثابته "
            Case "Addition"
                Sqlstring = "  select ID as TermID, [AdditionsType]   as TermType ,DefaultAmount  from [AttAdditionsTypes] "
                Me.Text = " اضافة علاوات ثابته "
        End Select
        Sql.SqlTrueTimeRunQuery(Sqlstring)
        txtTermID.Properties.DataSource = Sql.SQLDS.Tables(0)

        Select Case _RecordID
            Case -1
                Me.txtTermID.Text = ""
                Me.DateEditFrom.DateTime = Today
                Me.DateEditTo.DateTime = Today
                Me.TXT_Amount.EditValue = 0.0
                MemoEdit1.Text = ""
                RadioGroup1.EditValue = "FixedAmount"
                TextPercentage.EditValue = 0
                TextFields.Text = ""
            Case Else
                Sqlstring = " SELECT [ID],[TermID],[TermType],[Amount],[FromDate],[ToDate],[Notes],[EmployeeID],IsNull([Percentage],0.0) As Percentage ,IsNull([Fields],'') As Fields ,IsNull([FixOrPercentage],'FixedAmount') As FixOrPercentage  FROM [dbo].[AttFixedDiscountsAndBonuses] Where ID=" & _RecordID
                Sql.SqlTrueTimeRunQuery(Sqlstring)
                If Sql.SQLDS.Tables(0).Rows.Count = 1 Then
                    With Sql.SQLDS.Tables(0).Rows(0)
                        txtTermID.EditValue = CInt(.Item("TermID"))
                        DateEditFrom.DateTime = CDate(.Item("FromDate"))
                        DateEditTo.DateTime = CDate(.Item("ToDate"))
                        TXT_Amount.EditValue = CDec(.Item("Amount"))
                        MemoEdit1.Text = CStr(.Item("Notes"))
                        TextPercentage.EditValue = CDec(.Item("Percentage"))
                        TextFields.Text = CStr(.Item("Fields"))
                        RadioGroup1.EditValue = CStr(.Item("FixOrPercentage"))
                    End With
                End If


        End Select
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtTermID.Text = "" Then
            MsgBoxShowError(" يجب تعبئة البند ")
            txtTermID.Select()
            Exit Sub
        End If

        If TXT_Amount.EditValue < 1 And RadioGroup1.EditValue = "FixedAmount" Then
            MsgBoxShowError(" المبلغ خطأ ")
            TXT_Amount.Select()
            Exit Sub
        End If

        If TextPercentage.EditValue = 0 And RadioGroup1.EditValue = "Perecentage" Then
            MsgBoxShowError(" النسبة خطأ ")
            TextPercentage.Select()
            Exit Sub
        End If

        If DateEditFrom.DateTime > DateEditTo.DateTime Then
            MsgBoxShowError(" الفترة خطأ ")
            DateEditFrom.Select()
            Exit Sub
        End If

        Select Case _RecordID
            Case -1
                If InsertNew() = True Then
                    Me.Close()
                End If
            Case > 0
                If UpdateRecord() = True Then
                    Me.Close()
                End If
        End Select


    End Sub
    Private Function InsertNew() As Boolean
        Dim _FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Sqlstring = " Insert Into AttFixedDiscountsAndBonuses (TermID,TermType,Amount,FromDate,ToDate,Notes,EmployeeID,TermStatus,Percentage,Fields,FixOrPercentage) 
                      Values
                      (" & txtTermID.EditValue & ",'" & _TermType & "'," & TXT_Amount.EditValue & ",'" & _FromDate & "','" & _ToDate & "',N'" & MemoEdit1.Text & "'," & _EmpID & ",1," & TextPercentage.EditValue & ",N'" & TextFields.Text & "','" & RadioGroup1.EditValue & "')"
        Return Sql.SqlTrueAccountingRunQuery(Sqlstring)
    End Function
    Private Function UpdateRecord() As Boolean
        Dim _FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Sqlstring = " UPDATE [dbo].[AttFixedDiscountsAndBonuses]
                      SET [TermID] = " & txtTermID.EditValue & "
                          ,[Amount] = " & TXT_Amount.EditValue & "
                          ,[FromDate] = '" & _FromDate & "'
                          ,[ToDate] = '" & _ToDate & "'
                          ,[Notes] = N'" & MemoEdit1.Text & "'
                          ,[Percentage] = N'" & TextPercentage.EditValue & "'
                          ,[Fields] = N'" & TextFields.Text & "'
                          ,[FixOrPercentage] = N'" & RadioGroup1.EditValue & "'
                      WHERE ID=" & _RecordID
        Return Sql.SqlTrueTimeRunQuery(Sqlstring)
    End Function

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue

            Case "Percentage"
                LayoutAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutFields.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutPercntage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case "FixedAmount"
                LayoutAmount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutFields.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutPercntage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
    End Sub
End Class