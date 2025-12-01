Imports System.Data.SqlClient
Imports System.Windows
Imports System.Windows.Threading
Imports DevExpress.XtraEditors

Public Class CostCenters
    Dim Con As SqlConnection
    Dim CostCenterAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub XtraForm4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCostCentersTables()
        'GridView1.AddNewRow()
        Me.RepositoryItemLookUpEdit1.DataSource = GetCostCentersType(False)
    End Sub

    Private Sub GetCostCentersTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            CostCenterAdapter = New SqlDataAdapter("SELECT [CostID] ,[CostName],CostCenterTypeID FROM [dbo].[CostCenter] ", Con)
            DS = New System.Data.DataSet()
            CostCenterAdapter.Fill(DS, "CostCenter")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingCostCentersTables()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(CostCenterAdapter)
            CostCenterAdapter.Update(DS, "CostCenter")
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم الحفظ بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingCostCentersTables()
        GetCostCentersTables()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim result = XtraInputBox.Show(" اكتب اسم التصنيف الجديد ", " تصنيفات مراكز التكلفة ", "")
        If String.IsNullOrEmpty(result) Then Exit Sub
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(" Insert into CostCenterTypes ([Type]) Values (N'" & result & "') ")
        GetCostCentersTables()
        Me.RepositoryItemLookUpEdit1.DataSource = GetCostCentersType(False)
    End Sub
End Class