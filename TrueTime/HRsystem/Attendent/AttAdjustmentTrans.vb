Public Class AttAdjustmentTrans
    Private Sub AttAdjustmentTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAttAdjustmentTypes()
    End Sub
    Private Sub GetAttAdjustmentTypes()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [ID],[adjustment],[type]  FROM [dbo].[AttAdjustmentTypes] where  [type]=" & Me.TextAdjustType.Text
        sql.SqlTrueTimeRunQuery(sqlstring)
        Me.LookAdjustmentsName.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub CurrentPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CurrentPeriod.EditValueChanged
        Me.FactorPeriod.EditValue = Me.CurrentPeriod.EditValue
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _factor As String

        If Me.LookAdjustmentsName.Text = "" Then
            MsgBoxShowError(" يجب اختيار نوع الحركة ")
            Exit Sub
        End If
        Select Case Me.LookAdjustmentsName.EditValue
            Case 1, 3, 5, 7, 9, 11
                _factor = "" & Me.FactorPeriod.EditValue.ToString
            Case 2, 4, 6, 8, 10, 12
                _factor = "-" & Me.FactorPeriod.EditValue.ToString
            Case Else
                _factor = Me.FactorPeriod.EditValue.ToString
        End Select

        Dim _VocID As Integer = 0
        Dim _adjustTransID As Integer
        Dim _docdate As String = Format(DateTransDate.DateTime, "yyyy-MM-dd")

        If LookAdjustmentsName.EditValue = 2 Or LookAdjustmentsName.EditValue = 4 _
            Or LookAdjustmentsName.EditValue = 6 Or LookAdjustmentsName.EditValue = 8 _
            Or LookAdjustmentsName.EditValue = 10 Or LookAdjustmentsName.EditValue = 12 Then
            If LookUpEditVocations.Text = "" Then
                MsgBoxShowError(" يجب تعبئة نوع الاجازة ")
                Exit Sub
            End If
            Dim _dayNo As Decimal
            Dim _requiretimespan As TimeSpan = Me.TimeSpanRequriedHoursInDay.EditValue
            Dim _factortimespan As TimeSpan = Me.FactorPeriod.EditValue
            If _requiretimespan.TotalHours > 0 Then
                _dayNo = (_factortimespan.TotalHours / _requiretimespan.TotalHours)
            Else
                _dayNo = _factortimespan.TotalHours
            End If
            If LookAdjustmentsName.EditValue = 4 Or LookAdjustmentsName.EditValue = 6 Or LookAdjustmentsName.EditValue = 8 Then
                _dayNo = -_dayNo
            End If
            _VocID = VocationInsert(LookUpEditVocations.EditValue, Me.TextEmpNo.Text, _docdate, _docdate, _dayNo, Me.MemoEdit1.Text, _docdate, "adjust", FactorPeriod.Text)
        End If

        sqlstring = " INSERT INTO [dbo].[AttAdjustmentTrans]
           ([EmpNo]
           ,[AdjustName]
           ,[PeriodFactor]
           ,[TransDate]
           ,[Notes]
           ,[InputUser]
           ,[InputdateTime],[VocID] ) Output Inserted.ID 
     VALUES
           ('" & Me.TextEmpNo.Text & "'
           ,'" & Me.LookAdjustmentsName.EditValue & "'
           ,'" & _factor & "'
           ,'" & Format(Me.DateTransDate.DateTime, "yyyy-MM-dd") & "'
           ,N'" & Me.MemoEdit1.Text & "'
           ,'" & GlobalVariables.CurrUser & "'
           ,GetDate()," & _VocID & ") "
        If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
            _adjustTransID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Select Case Me.LookAdjustmentsName.EditValue
                Case 2, 4, 6, 8, 10, 12
                    sql.SqlTrueTimeRunQuery(" update Vocations set TransAdjustID=" & _adjustTransID & " where VocID=" & _VocID)
            End Select

            Me.Close()
        End If
    End Sub

    Private Sub LookAdjustmentsType_EditValueChanged(sender As Object, e As EventArgs) Handles LookAdjustmentsName.EditValueChanged
        If LookAdjustmentsName.Text = "" Then Exit Sub
        If LookAdjustmentsName.EditValue = 2 And CurrentPeriod.EditValue = TimeSpan.Zero Then
            LookAdjustmentsName.EditValue = 0
            MsgBoxShowError(" رصيد المغادرات صفر لا يمكن عمل اجازة  ")
            Exit Sub
        End If
        Select Case LookAdjustmentsName.EditValue
            Case 1, 3, 5, 7, 9, 11
                LayoutModifyTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutPeriodFactor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                LayoutVocationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                FactorPeriod.EditValue = -Me.CurrentPeriod.EditValue
            Case 2, 4, 6, 8, 10, 12
                LayoutModifyTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                LayoutPeriodFactor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutVocationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                FactorPeriod.EditValue = Me.CurrentPeriod.EditValue
            Case Else
                LayoutModifyTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                LayoutPeriodFactor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                LayoutVocationType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
                FactorPeriod.EditValue = Me.CurrentPeriod.EditValue
        End Select
    End Sub

    Private Sub LookUpEditVocations_Properties_BeforePopup(sender As Object, e As EventArgs) Handles LookUpEditVocations.Properties.BeforePopup
        LookUpEditVocations.Properties.DataSource = GetVocationsTypes()
    End Sub
    Private Function GetCountForLastTrans(_EmplID As Integer, _Date As Date, _Type As Integer) As Integer
        Dim _count = 0
        ' MsgBox(Format(_Date, "yyyy-MM-dd"))
        If Format(_Date, "yyyy-MM-dd") <> "0001-01-01" Then
            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                _count = 0
                SqlString = " select count(A.ID) As Count 
                          from AttAdjustmentTrans A left join AttAdjustmentTypes T on A.AdjustName=T.ID  
                          where EmpNo=" & _EmplID & " And A.TransDate='" & Format(_Date, "yyyy-MM-dd") & "' and T.type=" & _Type
                sql.SqlTrueTimeRunQuery(SqlString)
                _count = sql.SQLDS.Tables(0).Rows(0).Item("Count")
            Catch ex As Exception
                _count = 0
            End Try
        End If

        Return _count
    End Function

    Private Sub TextEmpNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextEmpNo.EditValueChanged
        If TextEmpNo.Text = "" Then Exit Sub
        If TextAdjustType.Text = "" Then Exit Sub
        HyperlinkLabelLastTransCount.Text = GetCountForLastTrans(TextEmpNo.Text, Me.DateTransDate.DateTime, TextAdjustType.Text)
    End Sub

    Private Sub DateTransDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateTransDate.EditValueChanged
        If TextEmpNo.Text = "" Then Exit Sub
        If TextAdjustType.Text = "" Then Exit Sub
        HyperlinkLabelLastTransCount.Text = String.Format(" عدد الحركات {0} ", GetCountForLastTrans(TextEmpNo.Text, Me.DateTransDate.DateTime, TextAdjustType.Text))
    End Sub

    Private Sub TimeSpanEdit1_EditValueChanged_1(sender As Object, e As EventArgs) Handles TimeSpanNew.EditValueChanged
        Try
            FactorPeriod.EditValue = TimeSpanNew.EditValue - CurrentPeriod.EditValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HyperlinkLabelLastTransCount_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelLastTransCount.Click
        Dim f As New AttAdjustmentTransLast
        With f
            .GetLastAdjustmentTrans(TextEmpNo.Text, Me.DateTransDate.DateTime, TextAdjustType.Text)
            .ShowDialog()
        End With
    End Sub
End Class