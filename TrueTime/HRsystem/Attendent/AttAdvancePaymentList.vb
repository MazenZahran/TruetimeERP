
Imports DevExpress.XtraPrinting

Public Class AttAdvancePaymentList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshingAttAdvancePaymentList()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshingAttAdvancePaymentList()
        ElseIf e.KeyCode = Keys.Insert Then
            AddNewPayment()
        End If
    End Sub
    Public Sub RefreshingAttAdvancePaymentList()
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()
        Dim _DateFrom As String = Format(DateFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateTo.DateTime, "yyyy-MM-dd")
        Try
            GridControl1.DataSource = String.Empty
            Dim EmpID As String = SearchLookUpEdit1.EditValue
            Dim RefreshString As String = ""
            Dim sql As New SQLControl
            If CheckShowAllEmployees.Checked = True Then
                RefreshString = "   Select PaymentID,A.EmployeeID,A.EmployeeName,A.Department,A.JobName,A.Branch,IsNull(A.Salary,0) As Salary,IsNull(B.PaymentAmount,0) As PaymentAmount ,B.PaymentDate,B.PaymentType,b.PaymentNote,B.PaymentBranch from 
  ( Select EmployeeID,EmployeeName,Department,JobName,Branch,Salary  from EmployeesData   ) A
  left join 
  ( SELECT [PaymentID] ,[PaymentDate]  ,[AttEmployeePayments].[EmployeeID],[PaymentAmount],[PaymentNote],[PaymentType],PaymentBranch 
           FROM [AttEmployeePayments] where [Status]=1 And PaymentDate between '" & _DateFrom & "' and '" & _DateTo & "'
  ) B
  On A.EmployeeID=B.EmployeeID  "
                If Not String.IsNullOrEmpty(EmpID) Then RefreshString = RefreshString + " where A.[EmployeeID]='" & EmpID & "'"
            Else
                RefreshString = " SELECT [PaymentID]
                                          ,[PaymentDate]
                                          ,EmployeesData.EmployeeName 
                                          ,[AttEmployeePayments].[EmployeeID]
                                          ,[PaymentAmount]
                                          ,[PaymentNote]
                                          ,AttPaymentsTypes.[PaymentType] as PaymentType,Department,JobName,Branch,Salary,PaymentBranch
                                  FROM [AttEmployeePayments]
                                  Left join EmployeesData on EmployeesData.EmployeeID=[AttEmployeePayments].[EmployeeID] 
                                  Left Join AttPaymentsTypes on AttPaymentsTypes.ID=[AttEmployeePayments].PaymentType
                                  where [AttEmployeePayments].[Status]=1 And PaymentDate  between '" & _DateFrom & "' and '" & _DateTo & "'"
                If Not String.IsNullOrEmpty(EmpID) Then RefreshString = RefreshString + " And [AttEmployeePayments].[EmployeeID]='" & EmpID & "'"
            End If
            RefreshString += " Order By PaymentID Desc"

            sql.SqlTrueTimeRunQuery(RefreshString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

        ' GridView1.BestFitColumns()


    End Sub

    Private Sub RepositoryItemButtonOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonOpen.ButtonClick
        If GridView1.GetFocusedRowCellValue("PaymentID").ToString <> String.Empty Then
            AttAdvancePayment.TextPaymentID.Text = GridView1.GetFocusedRowCellValue("PaymentID").ToString
            My.Forms.AttAdvancePayment.Show()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AddNewPayment()
    End Sub
    Private Sub AddNewPayment()
        Dim F As New AttAdvancePayment
        With F
            .TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            If .ShowDialog <> DialogResult.OK Then
                RefreshingAttAdvancePaymentList()
            End If
        End With
    End Sub

    Private Sub AttAdvancePaymentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateTo.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateFrom.DateTime = startDt
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        'Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        RefreshingAttAdvancePaymentList()
        Me.KeyPreview = True
        SearchLookUpEdit1.Properties.DataSource = GetEmployeesTable(-1, -1)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        'Dim Tawqe3 As String = " .................:توقيع الادارة"
        'Dim Tawqe3_2 As String = " .................:توقيع الموظف"

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {"", "", "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add("")



        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" تقرير السلف والخصميات ")


        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



    End Sub

    Private Sub CheckShowAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowAllEmployees.CheckedChanged
        RefreshingAttAdvancePaymentList()
    End Sub
End Class