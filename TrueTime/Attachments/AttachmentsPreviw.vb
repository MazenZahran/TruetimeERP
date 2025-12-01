Imports DevExpress.XtraGrid.Views.Base
Imports System.Data.SqlClient
Imports System.IO

Public Class AttachmentsPreviw
    Private Sub AttachmentsPreviw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadingAttachments()
    End Sub

    Private Sub LoadingAttachments()

        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " Select  [DocID]  ,[DocName] ,[DocAccountCode] ,[DocInputDate],[DocInputUser],
                                                [DocSort1] ,[DocCostCenter],[DocDetails] ,[DocLocation],EmployeeName
                                        FROM [ArchiveDocs] 
                                        Left join [EmployeesData] on ArchiveDocs.DocAccountCode= [EmployeesData].EmployeeID  "
            SQl.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = SQl.SQLDS.Tables(0)
            GridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub


    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            Dim File As String = CType(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"), String)
            LoadPdfFile(File)
            '  Me.PdfViewer1.LoadDocument(File)
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LoadPdfFile(File As String)
        Try
            '    If OrderIDTextBox.Text = "" Then Exit Try
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim con As SqlConnection
            Dim cmd As SqlCommand
            Dim row As Integer
            'Dim str As String
            con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            con.Open()
            cmd = New SqlCommand(" select DocFile   FROM [ArchiveDocs] where DocID= " & File, con)
            row = cmd.ExecuteNonQuery()
            Using sqlQueryResult = cmd.ExecuteReader()
                If sqlQueryResult IsNot Nothing Then
                    sqlQueryResult.Read()
#Disable Warning BC42016 ' Implicit conversion
                    Dim blob = New Byte((sqlQueryResult.GetBytes(0, 0, Nothing, 0, Integer.MaxValue)) - 1) {}
#Enable Warning BC42016 ' Implicit conversion
                    sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length)
                    memoryStream.Write(blob, 0, blob.Length)
                    PdfViewer1.LoadDocument(memoryStream)
                    My.Forms.AttachmentDispaly.PdfViewer1.LoadDocument(memoryStream)
                End If
            End Using
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            PdfViewer1.CloseDocument()
        End Try


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadingAttachments()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub PdfViewer1_Load(sender As Object, e As EventArgs) Handles PdfViewer1.Load

    End Sub
End Class