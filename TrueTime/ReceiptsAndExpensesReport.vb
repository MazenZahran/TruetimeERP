Imports DevExpress.XtraPrinting

Public Class ReceiptsAndExpensesReport
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetData()
        If DateEdit1.EditValue Is Nothing Or DateEdit2.EditValue Is Nothing Then
            MsgBox("Please select a date range.")
            Return
        End If
        Dim startDate As String = Format(DateEdit1.EditValue, "yyyy-MM-dd")
        Dim endDate As String = Format(DateEdit2.EditValue, "yyyy-MM-dd")
        Try
            Dim SQL As New SQLControl
            Dim sqlString As String = "  SELECT 
    DocDate,
    ReferanceName,
    C.Code AS Currency,
    DocAmount,
    BaseCurrAmount,
    J.CheckNo,
    F.AccName,
    J.DocID,
    J.DocNotes,
    'Receipts' AS 'InOut',
    CASE 
        WHEN CheckNo = '0' THEN DocAmount 
        ELSE 0 
    END AS Cash,
    CASE 
        WHEN CheckNo <> '0' THEN DocAmount 
        ELSE 0 
    END AS [Check]
FROM 
    Journal J
    LEFT JOIN Currency C ON J.DocCurrency = C.CurrID
    LEFT JOIN FinancialAccounts F ON J.DebitAcc = F.AccNo
WHERE 
    DocName = 4 
    AND DocDate >= '" & startDate & "' AND DocDate <= '" & endDate & "'
    AND DocStatus <> 0
    AND DebitAcc <> '0'
    AND DocAmount <> 0

UNION ALL

SELECT 
    DocDate,
    ReferanceName,
    C.Code AS Currency,
    DocAmount,
    BaseCurrAmount,
    J.CheckNo,
    F.AccName,
    J.DocID,
     J.DocNotes,
    'Payments' AS 'InOut',
    CASE 
        WHEN CheckNo = '0' THEN DocAmount 
        ELSE 0 
    END AS Cash,
    CASE 
        WHEN CheckNo <> '0' THEN DocAmount 
        ELSE 0 
    END AS [Check]
FROM 
    Journal J
    LEFT JOIN Currency C ON J.DocCurrency = C.CurrID
    LEFT JOIN FinancialAccounts F ON J.CredAcc = F.AccNo
WHERE 
    DocName = 3 
    AND DocDate >= '" & startDate & "' AND DocDate <= '" & endDate & "'
    AND DocStatus <> 0
    AND CredAcc <> '0'
    AND DocAmount <> 0
ORDER BY DocDate, ReferanceName;  "
            SQL.SqlTrueAccountingRunQuery(sqlString)
            Me.GridControl1.DataSource = SQL.SQLDS.Tables(0)
            Me.PivotGridControl1.DataSource = SQL.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError("An error occurred while fetching the data: " & ex.Message)
        End Try


    End Sub

    Private Sub ReceiptsAndExpensesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEdit1.EditValue = Today
        Me.DateEdit2.EditValue = Today
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.GridControl1.ShowPrintPreview()
        Me.PivotGridControl1.ShowPrintPreview()
    End Sub
    Private Sub BandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = "  "
        Dim Tawqe3_2 As String = " "

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3_2, Tawqe3, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)

        'TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {" تقرير المقبوضات والمدفوعات ", DateEdit1.EditValue & " " & DateEdit2.EditValue, ""})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {"تقرير المقبوضات والمدفوعات من " & DateEdit1.Text & " الى " & DateEdit2.Text, ComName, " "})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)

    End Sub


End Class