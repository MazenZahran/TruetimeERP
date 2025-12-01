Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class AttAdjustmentTransLast

    Private Sub AttAdjustmentTransLast_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
    End Sub
    Public Sub GetLastAdjustmentTrans(_EmplID As Integer, _Date As Date, _Type As Integer)
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT A. [ID],T.adjustment,[PeriodFactor],T.ID as adjustmentID
                                ,A.[Notes],[InputUser],[InputdateTime]
                                ,[TransDate],[VocID]  FROM [dbo].[AttAdjustmentTrans] A
                          left join AttAdjustmentTypes T on T.ID=A.AdjustName  
                          where EmpNo=" & _EmplID & " And A.TransDate='" & Format(_Date, "yyyy-MM-dd") & "' and T.type=" & _Type
            sql.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim _id As Integer
        Dim sql As New SQLControl

        Dim _adjustmentID As Integer
        _adjustmentID = GridView1.GetFocusedRowCellValue("adjustmentID")
        _id = GridView1.GetFocusedRowCellValue("ID")
        If _adjustmentID = 2 Or _adjustmentID = 4 Or _adjustmentID = 6 Or _adjustmentID = 8 Then
            sql.SqlTrueTimeRunQuery(" delete from Vocations where TransAdjustID=" & _id)
        End If

        If sql.SqlTrueTimeRunQuery(" delete from [AttAdjustmentTrans] where ID=" & _id) = True Then
            GridView1.DeleteSelectedRows()
        End If

    End Sub
End Class