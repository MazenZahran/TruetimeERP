Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class Accounts
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetAll()
    End Sub
    Private Sub GetAll()
        RepositoryCurrency.DataSource = GetCurrency()
        GetFinancialStatementNames()
        GetFinancialSectors()
        GetAccounts()
    End Sub
    Private Sub GetAccounts()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select AccID,AccNo,AccName,[Currency],[FinancialStatment],[FinancialSector] 
from [FinancialAccounts] A
Left Join FinancialStatementNames N on A.FinancialStatment=N.ID 
Left Join FinancialParts S on S.SectorID=A.FinancialSector
order by AccNo "
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub Accounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAll()
    End Sub

    Private Sub GetFinancialStatementNames()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select [ID],[FinancialStatementName] From [FinancialStatementNames]  "
        sql.SqlTrueAccountingRunQuery(SqlString)
        RepositoryFinancialStatment.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub GetFinancialSectors()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [SectorID],[SectorName]
  FROM [FinancialParts] S
  left join [FinancialStatementNames] N on S.[FinancialStatmentID]=N.ID
order by SectorID"

        sql.SqlTrueAccountingRunQuery(SqlString)
        RepositoryFinancialSectors.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim _AccName As String
        Dim _FinancialStatment As Integer
        Dim _FinancialSector, _AccID, _Currency As Integer
        _AccName = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccName")
        _FinancialStatment = CInt(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "FinancialStatment"))
        _FinancialSector = CInt(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "FinancialSector"))
        _AccID = CInt(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccID"))
        _Currency = CInt(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Currency"))

        SqlString = " Update FinancialAccounts
                      Set AccName= N'" & _AccName & "',FinancialStatment= " & _FinancialStatment & ",
                      FinancialSector= " & _FinancialSector & " , Currency=" & _Currency & " where AccID=" & _AccID
        Sql.SqlTrueAccountingRunQuery(SqlString)
        XtraMessageBox.Show("تم التعديل", "تعديل", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AccountAddNew.ShowDialog()
    End Sub
End Class