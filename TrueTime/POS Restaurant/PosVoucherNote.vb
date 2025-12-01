Public Class PosVoucherNote
    Private _PosNo As Integer
    Private _DocCode As String
    Public Sub New(PosNo As Integer, DocCode As String)
        _PosNo = PosNo
        _DocCode = DocCode
        InitializeComponent()
    End Sub
    Private Sub PosVoucherNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetLastNote()
        SwitchKeyboardLayout("ar")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("Update PosJournal set DocNotes=N'" & Me.MemoEdit1.Text & "' Where DocCode='" & _DocCode & "' And PosNo=" & _PosNo)
        My.Forms.POSRestCashier._PosVoucherNote = Me.MemoEdit1.Text
        My.Forms.POSRestCashier._PosVoucherNoteCancelled = False
        Me.Close()
    End Sub
    Private Function GetLastNote() As String
        Dim _Note As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select top(1) IsNull(DocNotes,'') as DocNotes from PosJournal where DocCode='" & _DocCode & "' And PosNo=" & _PosNo)
            _Note = sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")
        Catch ex As Exception
            _Note = ""
        End Try
        Return _Note
    End Function
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnShowKeyboard.Click
        Me.MemoEdit1.Select()

        Try
            Dim old As Long
            If Environment.Is64BitOperatingSystem Then
                If Wow64DisableWow64FsRedirection(old) Then
                    Process.Start(osk)
                    Wow64EnableWow64FsRedirection(old)
                End If
            Else
                Process.Start(osk)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MemoEdit1_KeyUp(sender As Object, e As KeyEventArgs) Handles MemoEdit1.KeyUp
        If e.KeyCode = Keys.Enter Then
            My.Forms.POSRestCashier._PosVoucherNote = Me.MemoEdit1.Text
            My.Forms.POSRestCashier._PosVoucherNoteCancelled = False
            Me.Close()
        End If
    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        My.Forms.POSRestCashier._PosVoucherNoteCancelled = True
        Me.Close()
    End Sub
    Private Sub GetTables()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Select  TableID,TableName,Location from [dbo].[PosTables] Where PosNo=" & My.Settings.POSNo & " Order By TableID"
        sql.SqlTrueAccountingRunQuery(sqlString)
        'GridControlTables.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class