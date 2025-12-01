Public Class ItemsSubGroup
    Private Sub ItemsSubGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub
    'Private Sub ItemsSubGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'AccountingDataSet.ItemsGroups' table. You can move, or remove it, as needed.
    '    Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)

    'End Sub
    'Private Sub GetData()
    '    If LookUpEdit1.Text <> "" Then
    '        Dim sql As New SQLControl
    '        sql.SqlTrueAccountingRunQuery(" SELECT [ID],[SubGroupName],
    '                                           [SubGroupImage],[MainGroup],G.GroupName as MainGroup
    '                                    FROM [dbo].[ItemsSubGroup] S 
    '                                    left join [ItemsGroups] G on S.MainGroup=G.[GroupID] 
    '                                    where MainGroup=" & LookUpEdit1.EditValue)
    '        GridControl1.DataSource = sql.SQLDS.Tables(0)
    '    End If
    'End Sub

    'Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEdit1.EditValueChanged
    '    GetData()
    'End Sub

    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
    '    Dim f As New ItemMainSubGroupAddEdit
    '    With f
    '        .SearchMainGroup.EditValue = LookUpEdit1.EditValue
    '        .TextID.EditValue = -1
    '        .Text = " اضافة مجموعة فرعية جديدة "
    '        If .ShowDialog <> DialogResult.OK Then
    '            GetData()
    '        End If
    '    End With
    'End Sub

    'Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
    '    Dim f As New ItemMainSubGroupAddEdit
    '    With f
    '        .TextID.Text = GridView1.GetFocusedRowCellValue("ID")
    '        .Text = " تعديل " & .TextSubGroupName.Text
    '        If .ShowDialog <> DialogResult.OK Then
    '            GetData()
    '        End If
    '    End With
    'End Sub
End Class