
Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class CheckInOutFromExcel
    Private Sub CheckInOutFromExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl1.DataSource = GetEmployeesPositions()
    End Sub
    Public Function GetEmployeesPositions() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" SELECT  '1' as '1','1' as '2','1' as '3'  FROM [dbo].[EmployeesPositions] ")
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    'Protected Sub PasteToGridView(sender As Object, e As EventArgs)
    '    Dim dt As New DataTable()
    '    dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Id", GetType(Integer)), New DataColumn("Name", GetType(String)), New DataColumn("Country", GetType(String))})

    '    Dim copiedContent As String = Request.Form(txtCopied.UniqueID)
    '    For Each row As String In copiedContent.Split(ControlChars.Lf)
    '        If Not String.IsNullOrEmpty(row) Then
    '            dt.Rows.Add()
    '            Dim i As Integer = 0
    '            For Each cell As String In row.Split(ControlChars.Tab)
    '                dt.Rows(dt.Rows.Count - 1)(i) = cell
    '                i += 1
    '            Next
    '        End If
    '    Next
    '    GridControl1.DataSource = dt
    '    'GridView1.DataBind()
    '    'txtCopied.Text = ""
    'End Sub

    Private Sub GridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridView1.KeyPress

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Try
                For Each line As String In Clipboard.GetText.Split(vbNewLine)
                    If Not line.Trim.ToString = "" Then
                        Dim item() As String = line.Split(vbTab(0))
                        'Me.GridView1.Rows.Add(item)
                        Me.GridView1.AddNewRow()
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow

    End Sub
End Class