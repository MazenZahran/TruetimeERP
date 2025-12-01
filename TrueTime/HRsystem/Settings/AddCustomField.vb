Imports System.Data.SqlClient
Public Class AddCustomField
    'Create ADO.NET objects.
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String
    Private Sub AddCustomField_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCOLUMNs()
    End Sub
    Private Sub GetCOLUMNs()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   SELECT COLUMN_NAME
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_NAME = N'AttRawatebArchive' and 
                        ( COLUMN_NAME='SalaryMonth' or COLUMN_NAME='BonusAmount' or 
                        COLUMN_NAME='Transport' or COLUMN_NAME='Additions'  or 
                        COLUMN_NAME='LeavesAmount' or COLUMN_NAME='Payment' or
                        COLUMN_NAME='GrossSalary' or COLUMN_NAME= 'NetSalary' or 
                        COLUMN_NAME= 'AbsenceAmount' )"
        Sql.SqlTrueTimeRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
    End Sub


    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_ControlRemoved(sender As Object, e As ControlEventArgs) Handles GridControl1.ControlRemoved

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim _Field As String = GridView1.GetFocusedRowCellValue("COLUMN_NAME")

        EquationString.Text += _Field
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrEmpty(FieldName.Text) Then
            MsgBox("يجب كتابة اسم الحقل الجديد")
            Exit Sub
        End If

        If String.IsNullOrEmpty(EquationString.Text) Then
            MsgBox("يجب ادخال المعادلة")
            Exit Sub
        End If


        If CheckString() = True Then
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " insert into [AddCustomField] (FieldString,FieldName,[ReportName]) values ( N'" & EquationString.Text & "', N'" & FieldName.Text & "','SalaryPosted' ) "
            Sql.SqlTrueTimeRunQuery(SqlString)
            MsgBox("done")
        End If

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        EquationString.Text += "+"
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EquationString.Text += "-"
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        EquationString.Text += "*"
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        EquationString.Text += "/"
    End Sub

    Private Function CheckString() As Boolean
        Try
            'Open the connection.

            myConn = New SqlConnection(My.Settings.TrueTimeConnectionString)
            myCmd = myConn.CreateCommand
            myCmd.CommandText = "select " & EquationString.Text & " from [AttRawatebArchive]"
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            myReader.Close()
            myConn.Close()

            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(" delete from  [AddCustomField] ")

            Return True
        Catch ex As Exception
            MsgBox("صيغة المعادلة خطا")
            Return False
        End Try




        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueTimeRunQuery(" select " & EquationString.Text & " from [AttRawatebArchive] ")
        '    Return True
        'Catch ex As Exception
        '    Return False
        'End Try



    End Function
End Class