Imports DevExpress.XtraPrinting

Public Class SalariesRCCI
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        GetSalaries()
    End Sub
    Private Sub GetSalaries()
        Dim Sql As New SQLControl
        Dim sqlString As String
        '        sqlString = "   Select   EmployeeID,EmployeeName,SalaryMonth,CostOfLiving,AbsenceAmount,LeavesAmount,
        '  (SalaryMonth+CostOfLiving-AbsenceAmount-LeavesAmount) As GrossSalary ,
        '  PersonalContribution,CompanyContribution,(PersonalContribution+CompanyContribution) As TotalOFSavingsFund
        '  ,(SalaryMonth+CostOfLiving-AbsenceAmount-LeavesAmount-PersonalContribution) As GrossSalaryAfterSavingsFund,
        '  LoansFromSavingFund,CashPayments,Loans,(SalaryMonth+CostOfLiving-AbsenceAmount-LeavesAmount-PersonalContribution-LoansFromSavingFund-CashPayments-Loans) As NetSalary
        '  From (
        '  Select S.EmployeeID,E.EmployeeName,S.SalaryMonth,
        ' (Select IsNull(Sum(AdditionAmount),0) From AttEmployeeAdditions A Where A.AdditionID=3 AND A.EmployeeID=S.EmployeeID) As CostOfLiving,
        ' (Select IsNull(Sum(SF.PersonalContribution),0) From SavingsFund SF Where S.EmployeeID=SF.EmployeeID And S.ID=SF.SalaryDocumentID) As PersonalContribution,
        ' (Select IsNull(Sum(SF.CompanyContribution),0) From SavingsFund SF Where S.EmployeeID=SF.EmployeeID And S.ID=SF.SalaryDocumentID) As CompanyContribution,
        ' (Select IsNull(Sum(P.PaymentAmount),0) From AttEmployeePayments P Where P.PaymentType=3 AND P.EmployeeID=S.EmployeeID) As LoansFromSavingFund,
        ' (Select IsNull(Sum(P.PaymentAmount),0) From AttEmployeePayments P Where P.PaymentType=1 AND P.EmployeeID=S.EmployeeID) As CashPayments,
        ' (Select IsNull(Sum(P.PaymentAmount),0) From AttEmployeePayments P Where P.PaymentType=4 AND P.EmployeeID=S.EmployeeID) As Loans,
        ' S.AbsenceAmount,S.LeavesAmount
        '  From [dbo].[AttRawatebArchive] S 
        '  Left Join EmployeesData E on S.EmployeeID=E.EmployeeID
        'Where DATEPART(MONTH, S.DateFrom)='" & Me.SpinMonth.EditValue & "' AND DATEPART(YEAR, S.DateFrom)='" & Me.SpinYear.EditValue & "'
        ' ) Z "
        sqlString = " Declare @Month int='" & Me.SpinMonth.EditValue & "'
Declare @Year int='" & Me.SpinYear.EditValue & "'
SELECT 
    S.EmployeeID,
    E.EmployeeName,
    S.SalaryMonth,
    ISNULL(COL.CostOfLiving, 0) AS CostOfLiving,
    S.AbsenceAmount,
    S.LeavesAmount,
    ISNULL(PMT.LeavesPayments,0) AS LeavesPayments,
    SalaryMonth + ISNULL(COL.CostOfLiving, 0) - S.AbsenceAmount - S.LeavesAmount-ISNULL(PMT.LeavesPayments,0) AS GrossSalary,
    ISNULL(SF.PersonalContribution, 0) AS PersonalContribution,
    ISNULL(SF.CompanyContribution, 0) AS CompanyContribution,
    ISNULL(SF.PersonalContribution, 0) + ISNULL(SF.CompanyContribution, 0) AS TotalOFSavingsFund,
    SalaryMonth + ISNULL(COL.CostOfLiving, 0) - S.AbsenceAmount - S.LeavesAmount-ISNULL(PMT.LeavesPayments,0) - ISNULL(SF.PersonalContribution, 0) AS GrossSalaryAfterSavingsFund,
    ISNULL(PMT.LoansFromSavingFund, 0) AS LoansFromSavingFund,
    ISNULL(PMT.CashPayments, 0) AS CashPayments,
    ISNULL(PMT.Loans, 0) AS Loans,
    SalaryMonth + ISNULL(COL.CostOfLiving, 0) - S.AbsenceAmount - S.LeavesAmount-ISNULL(PMT.LeavesPayments,0) - ISNULL(SF.PersonalContribution, 0) 
        - ISNULL(PMT.LoansFromSavingFund, 0) - ISNULL(PMT.CashPayments, 0) - ISNULL(PMT.Loans, 0) AS NetSalary
FROM dbo.AttRawatebArchive S
LEFT JOIN EmployeesData E ON S.EmployeeID = E.EmployeeID
LEFT JOIN (
    SELECT EmployeeID, SUM(AdditionAmount) AS CostOfLiving
    FROM AttEmployeeAdditions
    WHERE AdditionID = 3 
      AND MONTH(AdditionDate) = @Month 
      AND YEAR(AdditionDate) = @Year
    GROUP BY EmployeeID
) COL ON S.EmployeeID = COL.EmployeeID
LEFT JOIN (
    SELECT EmployeeID, SalaryDocumentID, 
           SUM(PersonalContribution) AS PersonalContribution,
           SUM(CompanyContribution) AS CompanyContribution
    FROM SavingsFund
    GROUP BY EmployeeID, SalaryDocumentID
) SF ON S.EmployeeID = SF.EmployeeID AND S.ID = SF.SalaryDocumentID
LEFT JOIN (
    SELECT EmployeeID,
        SUM(CASE WHEN PaymentType = 3 THEN PaymentAmount ELSE 0 END) AS LoansFromSavingFund,
        SUM(CASE WHEN PaymentType = 5 THEN PaymentAmount ELSE 0 END) AS CashPayments,
        SUM(CASE WHEN PaymentType = 4 THEN PaymentAmount ELSE 0 END) AS Loans,
        SUM(CASE WHEN PaymentType = 1 THEN PaymentAmount ELSE 0 END) AS LeavesPayments
    FROM AttEmployeePayments
    WHERE [Status]=1 AND MONTH(PaymentDate) = @Month AND YEAR(PaymentDate) = @Year
    GROUP BY EmployeeID
) PMT ON S.EmployeeID = PMT.EmployeeID
WHERE MONTH(S.DateFrom) = @Month AND YEAR(S.DateFrom) = @Year Order by S.EmployeeID;
 "
        Sql.SqlTrueTimeRunQuery(sqlString)
        Me.GridControl1.DataSource = Sql.SQLDS.Tables(0)
        If Sql.SQLDS.Tables(0).Rows.Count = 0 Then
            MsgBox("لا توجد بيانات لهذا الشهر", MsgBoxStyle.Information, "لا توجد بيانات")
            Me.GridControl1.DataSource = Nothing
        End If

        BandedGridView1.OptionsView.ColumnAutoWidth = True
        BandedGridView1.BestFitColumns()
        BandedGridView1.ViewCaption = "تقرير رواتب الموظفين لشهر: " & Me.SpinMonth.EditValue & " السنة: " & Me.SpinYear.EditValue
    End Sub

    Private Sub SalariesRCCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SpinMonth.EditValue = Format(Now, "MM")
        Me.SpinYear.EditValue = Format(Now, "yyyy")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        PrintReport()
    End Sub
    Private Sub PrintReport()
        Me.GridControl1.ShowPrintPreview()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.F5 Then
            GetSalaries()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub BandedGridView1_PrintInitialize(sender As Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize
        'Dim ps As DevExpress.XtraPrinting.PrintingSystemBase = CType(e.PrintingSystem, DevExpress.XtraPrinting.PrintingSystemBase)
        'Dim phf As DevExpress.XtraPrinting.PageHeaderFooter = TryCast(ps.PageSettings.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter)
        'If phf IsNot Nothing Then
        '    ' Set header: [Left, Center, Right]
        '    phf.Header.Content.Clear()
        '    phf.Header.Content.AddRange(New String() {"", "تقرير رواتب الموظفين", ""})

        '    ' Set footer: [Left, Center, Right]
        '    phf.Footer.Content.Clear()
        '    phf.Footer.Content.AddRange(New String() {Now.ToString("yyyy-MM-dd"), "", "Page [Page # of Pages #]"})

        'End If

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        pb.PageSettings.TopMargin = 120
        pb.PageSettings.BottomMargin = 20
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
{"  ", Now(), "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
(" " & Me.BandedGridView1.ViewCaption)
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = "شهر: " & Me.SpinMonth.EditValue & "السنة: " & " " & Me.SpinYear.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)



    End Sub
End Class