Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class PlansForRequiredHours
    Dim Con As SqlConnection
    Dim PlansAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub PlansForRequiredHours_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPlansTables()
    End Sub
    Private Sub GetPlansTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            PlansAdapter = New SqlDataAdapter("SELECT id,PlaneCode,PlaneName from AttRequiredHoursPlanesNames order by ID ", Con)
            DS = New System.Data.DataSet()
            PlansAdapter.Fill(DS, "Plans")
            GridControlPlans.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingPlans()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(PlansAdapter)
            PlansAdapter.Update(DS, "Plans")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SavingPlans()
    End Sub

    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _ColPlaneCode As GridColumn = view.Columns("PlaneCode")
            Dim _ColPlaneName As GridColumn = view.Columns("PlaneName")
            Dim PlaneCode As String = ""
            Dim PlaneName As String = ""

            Try
                PlaneCode = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlaneCode")
            Catch ex As Exception
                PlaneCode = ""
            End Try

            Try
                PlaneName = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlaneName")
            Catch ex As Exception
                PlaneName = ""
            End Try


            If IsDBNull(PlaneCode) Or String.IsNullOrEmpty(PlaneCode) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال رقم الخطة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColPlaneCode
                view.ShowEditor()
            End If

            If IsDBNull(PlaneName) = True Or String.IsNullOrEmpty(PlaneName) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال اسم الخطة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColPlaneName
                view.ShowEditor()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class