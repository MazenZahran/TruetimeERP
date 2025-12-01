
Imports DevExpress.XtraPrinting

Public Class AttAdditionsList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshingAttBonusList()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshingAttBonusList()
        ElseIf e.KeyCode = Keys.Insert Then
            AddNewAddition()
        End If
    End Sub
    Public Sub RefreshingAttBonusList()
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()
        Dim _DateFrom As String = Format(DateFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateTo.DateTime, "yyyy-MM-dd")
        Try
            GridControl1.DataSource = String.Empty
            Dim EmpID As String = SearchLookUpEdit1.EditValue
            Dim RefreshString As String = ""
            Dim sql As New SQLControl
            'Dim RefreshString As String = " SELECT [AdditionID]
            '                              ,[AdditionDate]
            '                              ,EmployeesData.EmployeeName 
            '                              ,[AttEmployeeAdditions].[EmployeeID]
            '                              ,[AdditionAmount]
            '                              ,[AdditionNote]
            '                              ,[AdditionType]
            '                      FROM [AttEmployeeAdditions]
            '                      Left join EmployeesData on EmployeesData.EmployeeID=[AttEmployeeAdditions].[EmployeeID] "
            'If Not String.IsNullOrEmpty(EmpID) Then RefreshString = RefreshString + " where [AttEmployeeAdditions].[EmployeeID]='" & EmpID & "'"

            If CheckShowAllEmployees.Checked = True Then
                RefreshString = "   Select AdditionID,A.EmployeeID,A.EmployeeName,A.Department,A.JobName,A.Branch,IsNull(A.Salary,0) As Salary,IsNull(B.AdditionAmount,0) As AdditionAmount ,B.AdditionDate,B.AdditionType,b.AdditionNote from 
  ( Select EmployeeID,EmployeeName,Department,JobName,Branch,Salary  from EmployeesData  ) A
  left join 
  ( SELECT [AdditionID],[AdditionDate],[AttEmployeeAdditions].[EmployeeID]
           ,[AdditionAmount],[AdditionNote],AttAdditionsTypes.AdditionsType as AdditionType
           FROM [AttEmployeeAdditions]  Left Join AttAdditionsTypes on AttAdditionsTypes.ID=AttEmployeeAdditions.AdditionType  where AdditionDate between '" & _DateFrom & "' and '" & _DateTo & "'
  ) B
  On A.EmployeeID=B.EmployeeID  "
                If Not String.IsNullOrEmpty(EmpID) Then RefreshString = RefreshString + " where A.[EmployeeID]='" & EmpID & "'"
            Else
                RefreshString = " SELECT [AdditionID]
                                              ,[AdditionDate]
                                              ,EmployeesData.EmployeeName 
                                              ,[AttEmployeeAdditions].[EmployeeID]
                                              ,[AdditionAmount]
                                              ,[AdditionNote]
                                              ,AttAdditionsTypes.AdditionsType as AdditionType,Department,JobName,Branch,Salary
                                      FROM [AttEmployeeAdditions] 
                                      Left join EmployeesData on EmployeesData.EmployeeID=[AttEmployeeAdditions].[EmployeeID] 
                                      Left Join AttAdditionsTypes on AttAdditionsTypes.ID=AttEmployeeAdditions.AdditionType
                                      Where AdditionDate between '" & _DateFrom & "' and '" & _DateTo & "'"
                If Not String.IsNullOrEmpty(EmpID) Then RefreshString = RefreshString + " And [AttEmployeeAdditions].[EmployeeID]='" & EmpID & "'"
            End If

            sql.SqlTrueTimeRunQuery(RefreshString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

            MsgBox(ex.ToString)
        End Try

        GridView1.BestFitColumns()


    End Sub

    Private Sub RepositoryItemButtonOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonOpen.ButtonClick
        If GridView1.GetFocusedRowCellValue("AdditionID").ToString <> String.Empty Then
            My.Forms.AttBonus.TextAdditionsID.Text = GridView1.GetFocusedRowCellValue("AdditionID").ToString
            My.Forms.AttBonus.Show()
        End If
    End Sub
    Private Sub AddNewAddition()
        Dim F As New AttBonus
        With F
            .TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            If .ShowDialog <> DialogResult.OK Then
                RefreshingAttBonusList()
            End If
        End With
    End Sub

    Private Sub AttAdvancePaymentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateTo.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateFrom.DateTime = startDt
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        'Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        RefreshingAttBonusList()
        Me.KeyPreview = True
        SearchLookUpEdit1.Properties.DataSource = GetEmployeesTable(-1, -1)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            If GlobalVariables._SystemLanguage = "Arabic" Then
                MsgBox("لا يوجد صلاحية")
            Else
                MsgBox("Database Connection Error")
            End If
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        '
    End Sub

    Private Sub CheckShowAllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowAllEmployees.CheckedChanged
        RefreshingAttBonusList()
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim _DateFrom As String = DateFrom.DateTime
        Dim _Date__To As String = DateTo.DateTime
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 50
        pb.PageSettings.RightMargin = 50
        pb.PageSettings.TopMargin = 100
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select IsNull(CompanyName,'') as CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim _signatures = GetDocumentSignatures("AttSalariesReport")
        Dim Tawqe1 As String = "" & vbCrLf & " ............................:" & _signatures.signature1 & vbCrLf & vbCrLf & " ............................:" & _signatures.signature3
        Dim Tawqe2 As String = "" & vbCrLf & " ............................:" & _signatures.signature2 & vbCrLf & vbCrLf & " ............................:" & _signatures.signature4
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe1, "Pages: [Page # of Pages #]", Tawqe2})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {"تقرير الاضافات للفترة من " & _DateFrom & " الى " & _Date__To, ComName, " "})
    End Sub
End Class