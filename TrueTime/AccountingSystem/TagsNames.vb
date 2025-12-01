Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class TagsNames
    Public TableName As String
    Public DocID As Integer
    Public DocName As String

    Private Sub TagsNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTags()
        LookUpEditTags.Select()
        Me.LookUpEditTags.Text = _PublicDocumentTags
    End Sub
    Private Sub LoadTags()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Select *,'Selected' as Selected  From [Tags]  "
        sql.SqlTrueAccountingRunQuery(sqlString)
        LookUpEditTags.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TableName <> "" Then
            UpdateTags()
        End If
        _PublicDocumentTags = LookUpEditTags.Text
        Me.Close()
    End Sub
    Private Sub UpdateTags()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update " & TableName & " set DocTags=N'" & LookUpEditTags.Text & "' where DocID=" & DocID & " and DocName=N'" & DocName & "'"
        sql.SqlTrueAccountingRunQuery(sqlString)
    End Sub
    Private Sub LookUpEditTags_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditTags.EditValueChanged

    End Sub

    'Private Sub LookUpEditTags_ProcessNewValue(sender As Object, e As ProcessNewValueEventArgs) Handles LookUpEditTags.ProcessNewValue

    '    If CStr(e.DisplayValue) = String.Empty Then Exit Sub
    '    Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد جديد  [     : " & e.DisplayValue.ToString(), "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
    '    Try
    '        Dim sql As New SQLControl
    '        Dim SQLString As String
    '        SQLString = "insert into [Tags] ([TagName]) values (N'" & e.DisplayValue.ToString() & "')"
    '        sql.SqlTrueTimeRunQuery(SQLString)
    '        LoadTags()
    '        e.Handled = True
    '    Catch ex As Exception
    '        XtraMessageBox.Show(" خطا: لم يتم  اضافة ")
    '        Exit Sub
    '    End Try

    'End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ' My.Forms.TagsNamesList.ShowDialog()
        Dim F As New TagsNamesList
        With F
            If .ShowDialog <> DialogResult.OK Then
                LoadTags()
                LookUpEditTags.Select()
            End If
        End With
    End Sub

    Private Sub LookUpEditTags_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles LookUpEditTags.Properties.ButtonClick

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        LookUpEditTags.Text = ""
    End Sub
End Class