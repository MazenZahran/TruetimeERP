Imports DevExpress.XtraEditors

Public Class AttLeavesProcessMonthlyLogs
    Private _docID As Integer
    Public _deleteLastTrans As Boolean
    Public Sub New(docID As Integer)
        InitializeComponent()
        _docID = docID
    End Sub
    Private Sub AttLeavesProcessMonthlyLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetLogs()
    End Sub
    Private Sub GetLogs()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Select * from AttRawatebArchiveAdjustmentLogs where [DocID]=" & _docID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub DeleteLog()
        Dim Msg As DialogResult = XtraMessageBox.Show(" هل تريد الغاء التسوية ", "تأكيد", MessageBoxButtons.YesNo)
        If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Declare @lastPeriod varchar(10)
                      Declare @lastAmount float
                      Declare @VocID int
                      Set @lastPeriod=( Select top(1) IsNull(LastLeavesTimeSpan,'00:00') as LastLeavesTimeSpan  from AttRawatebArchiveAdjustmentLogs where DocID=" & _docID & ")
                      Set @lastAmount=( Select top(1) IsNull(LastLeavesAmount,0) as LastLeavesAmount  from AttRawatebArchiveAdjustmentLogs where DocID=" & _docID & " )
                      Set @VocID = ( Select top(1) VocID from AttRawatebArchiveAdjustmentLogs where DocID=" & _docID & "   )
                      Update [AttRawatebArchive] set NetSalary=NetSalary- @lastAmount,LeavesAmount=@lastAmount,HouresNetLeaves=@lastPeriod,[leavesIsAdjusted]=0 where ID=" & _docID & ";
                      Delete from AttRawatebArchiveAdjustmentLogs where [DocID]=" & _docID & "; 
                      Delete from [Vocations] where [VocID]=@VocID "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            MsgBoxShowSuccess(" تم حذف المعالجة ")
            _deleteLastTrans = True
            Me.Close()
        End If

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        DeleteLog()
    End Sub
End Class