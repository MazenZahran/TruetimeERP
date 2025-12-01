Public Class ItemsColorAddForm

    Private Sub ColorPickEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles ColorPickEdit1.EditValueChanged
        ' View.SetRowCellValue(e.RowHandle, "ColorHex", ColorTranslator.ToHtml(Val))
        '  ColorPickEdit1.Properties.ColorText = DevExpress.XtraEditors.Controls.ColorText.Integer
        Me.TextColorHEX.EditValue = ColorTranslator.ToHtml(ColorPickEdit1.EditValue)
        Me.TextEdit1.Text = ColorPickEdit1.Text
        '  ColorPickEdit1.Properties.ColorText =
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.TextColorName.Text = "" And Me.TextColorHEX.Text = "" Then
            MsgBoxShowError(" يجب تعبئة كل البيانات")
            Exit Sub
        End If


        Dim sql As New SQLControl
        If Me.TextID.EditValue = -1 Then
            If checkifColorNameFound(Me.TextColorName.Text) = True Then
                MsgBoxShowError(" الاسم معرف مسبق ")
                Exit Sub
            End If
            sql.SqlTrueAccountingRunQuery(" Insert into [ItemsColors] ([ColorName],[ColorNo],[ColorHex]) 
                                            Values ( N'" & Me.TextColorName.Text & "','" & Me.ColorPickEdit1.Text & "','" & Me.TextColorHEX.Text & "' ) ")
        End If
        If Me.TextID.EditValue > 1 Then
            sql.SqlTrueAccountingRunQuery("update ItemsColors set ColorName=N'" & Me.TextColorName.Text & "',
                                            ColorNo='" & Me.ColorPickEdit1.Text & "',
                                            ColorHex='" & Me.TextColorHEX.Text & "' 
                                            where ID=" & Me.TextID.EditValue)
        End If
        Me.Close()
    End Sub
    Private Function checkifColorNameFound(name As String) As Boolean
        Dim result As Boolean
        result = False
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select [ID] from [ItemsColors] where [ColorName]=N'" & name & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            result = True
        End If
        Return result
    End Function
    Private Sub GetData()
        If TextID.Text = "" Then Exit Sub
        If TextID.Text <> "-1" Then
            BtnDelete.Visible = True
            Try
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " SELECT [ID],[ColorName],[ColorNo] 
                      FROM [dbo].[ItemsColors] 
                      Where ID=" & TextID.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
                Me.TextColorName.Text = sql.SQLDS.Tables(0).Rows(0).Item("ColorName")
                Me.ColorPickEdit1.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ColorNo")
            Catch ex As Exception

            End Try
        End If
        If TextID.Text = "-1" Then
            Me.TextColorHEX.Text = ""
            Me.TextColorName.Text = ""
            Me.ColorPickEdit1.Text = "-1"
            BtnDelete.Visible = False
        End If

        Me.TextColorName.Select()

    End Sub

    Private Sub ItemsColorAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextID_EditValueChanged(sender As Object, e As EventArgs) Handles TextID.EditValueChanged
        GetData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " delete from [ItemsColors] where ID=" & Me.TextID.Text
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.Close()
    End Sub
End Class