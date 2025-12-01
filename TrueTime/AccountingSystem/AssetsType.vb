Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Localization
Imports DevExpress.XtraGrid.Views.Grid
Public Class AssetsType
    'Private Sub AssetsTypeBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles MyBaseBindingNavigatorSaveItem.Click, MyBaseBindingNavigatorSaveItem.Click, MyBaseBindingNavigatorSaveItem.Click, MyBaseBindingNavigatorSaveItem.Click
    '    Me.Validate()
    '    Me.AssetsTypeBindingSource.EndEdit()
    '    Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    'End Sub

    Private Sub AssetsType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.FinancialAccounts' table. You can move, or remove it, as needed.
        Me.FinancialAccountsTableAdapter.Fill(Me.AccountingDataSet.FinancialAccounts)
        'TODO: This line of code loads data into the 'AccountingDataSet.AssetsType' table. You can move, or remove it, as needed.
        Me.AssetsTypeTableAdapter.Fill(Me.AccountingDataSet.AssetsType)

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Validate()
        Me.AssetsTypeBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        Dim textEditType As TextEdit = TryCast(e.BindableControls("AssetType"), TextEdit)
        If textEditType IsNot Nothing Then textEditType.Properties.Appearance.BackColor = Color.LightYellow

        Dim labels As List(Of LabelControl) = New List(Of LabelControl)()
        FindChildrenByType(e.EditForm, labels)

        For Each label As LabelControl In labels
            label.Appearance.FontStyleDelta = FontStyle.Bold
        Next

        Dim buttons As List(Of SimpleButton) = New List(Of SimpleButton)()
        FindChildrenByType(e.EditForm, buttons)

        For Each btn As SimpleButton In buttons
            If btn.Text = GridLocalizer.Active.GetLocalizedString(GridStringId.EditFormCancelButton) Then
                AddHandler btn.Click, AddressOf CancelButtonClick
            End If
        Next
        e.EditForm.StartPosition = FormStartPosition.CenterScreen
    End Sub
    Private Sub CancelButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        '...
        RemoveHandler(TryCast(sender, SimpleButton)).Click, AddressOf CancelButtonClick
    End Sub

    Private Sub FindChildrenByType(Of T As Class)(ByVal parent As Control, ByVal list As List(Of T))
        For Each child As Control In parent.Controls
            If TypeOf child Is T Then list.Add(TryCast(child, T))
            If child.HasChildren Then FindChildrenByType(child, list)
        Next
    End Sub
End Class