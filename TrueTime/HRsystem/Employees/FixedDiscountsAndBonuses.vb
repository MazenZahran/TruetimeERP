Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraEditors

Public Class FixedDiscountsAndBonuses
    Private Sql As New SQLControl
    Private SqlString As String

    Private Sub BtnAddBonus_Click(sender As Object, e As EventArgs) Handles BtnAddBonus.Click
        If Srech_EmployeeID.EditValue = Nothing Then
            MsgBoxShowError(" يرجى اختيار الموظف ")
            Exit Sub
        End If

        Dim F As New AddFixedDiscountsAndBonuses(Srech_EmployeeID.EditValue, "Addition", -1)
        With F
            If .ShowDialog <> DialogResult.OK Then
                Getdata()
            End If
        End With
    End Sub

    Private Sub BtnAddDiscount_Click(sender As Object, e As EventArgs) Handles BtnAddDiscount.Click
        If Srech_EmployeeID.EditValue = Nothing Then
            MsgBoxShowError(" يرجى اختيار الموظف ")
            Exit Sub
        End If

        Dim F As New AddFixedDiscountsAndBonuses(Srech_EmployeeID.EditValue, "Discount", -1)
        With F
            If .ShowDialog <> DialogResult.OK Then
                Getdata()
            End If
        End With
    End Sub
    Private Sub GetDiscountsByEmployeeID()
        SqlString = " Select A.[ID] From [AttFixedDiscountsAndBonuses] A "
    End Sub

    Private Sub FixedDiscountsAndBonuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Srech_EmployeeID.Properties.DataSource = GetEmployeesTable(1, -1)
    End Sub

    Private Sub Srech_EmployeeID_EditValueChanged(sender As Object, e As EventArgs) Handles Srech_EmployeeID.EditValueChanged
        Getdata()
    End Sub
    Private Sub Getdata()
        If Srech_EmployeeID.EditValue = Nothing Then
            Me.GridControlAdditions.DataSource = Nothing
            Exit Sub
        End If

        SqlString = "      Select A.ID,A.EmployeeID,A.Amount,A.Notes,A.FromDate,A.ToDate,A.TermType,A.TermID,T.AdditionsType as TermName,TermStatus, Case when A.TermType='Addition' then N'الاضافات' else N'الخصميات' end as TermTypeAr
                           From [AttFixedDiscountsAndBonuses] A
                           Left Join AttAdditionsTypes T on T.ID=A.TermID
                           Where A.TermType='Addition' And A.EmployeeID=" & Srech_EmployeeID.EditValue & "
                                Union All
                           Select A.ID,A.EmployeeID,A.Amount,A.Notes,A.FromDate,A.ToDate,A.TermType,A.TermID,T.PaymentType as TermName,TermStatus, Case when A.TermType='Addition' then N'الاضافات' else N'الخصميات' end as TermTypeAr
                           From [AttFixedDiscountsAndBonuses] A
                           Left Join AttPaymentsTypes T on T.ID=A.TermID
                           Where A.TermType='Discount' And  A.EmployeeID=" & Srech_EmployeeID.EditValue
        Sql.SqlTrueTimeRunQuery(SqlString)
        GridControlAdditions.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryDelete_Click(sender As Object, e As EventArgs) Handles RepositoryDelete.Click
        If XtraMessageBox.Show(" هل تريد حذف السجل ؟ ", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim _Id As Integer = GridView1.GetFocusedRowCellValue("ID")
            SqlString = " Delete from [AttFixedDiscountsAndBonuses] where [ID]=" & _Id
            If Sql.SqlTrueTimeRunQuery(SqlString) = True Then
                Getdata()
            End If
        End If
    End Sub

    Private Sub RepositoryOpen_Click(sender As Object, e As EventArgs) Handles RepositoryOpen.Click
        Dim Termtype As String = GridView1.GetFocusedRowCellValue("TermType")
        Dim ID As String = GridView1.GetFocusedRowCellValue("ID")
        If Srech_EmployeeID.EditValue = Nothing Then
            MsgBoxShowError(" يرجى اختيار الموظف ")
            Exit Sub
        End If

        Dim F As New AddFixedDiscountsAndBonuses(Srech_EmployeeID.EditValue, Termtype, ID)
        With F
            If .ShowDialog <> DialogResult.OK Then
                Getdata()
            End If
        End With
    End Sub

    Private Sub RepositoryStatus_Toggled(sender As Object, e As EventArgs) Handles RepositoryStatus.Toggled
        ' MsgBox(GridView1.GetFocusedRowCellValue("TermStatus"))

        Dim _ID As Integer = CInt(GridView1.GetFocusedRowCellValue("ID"))

        Select Case CStr(GridView1.GetFocusedRowCellValue("TermStatus"))
            Case True
                Sql.SqlTrueTimeRunQuery(" Update AttFixedDiscountsAndBonuses set TermStatus=0 where ID=" & _ID)
            Case False
                Sql.SqlTrueTimeRunQuery(" Update AttFixedDiscountsAndBonuses set TermStatus=1 where ID=" & _ID)
        End Select
        Getdata()
    End Sub
End Class