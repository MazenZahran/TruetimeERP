Imports DevExpress.XtraDiagram.Bars

Public Class SambaEditItem
    Private branchID As Integer
    Private ItemID As Integer
    Private ItemName As String
    Private BranchName As String
    Private ItemPrice As Decimal
    Private PortionID As Integer
    Sub New(_BranchID As Integer, _ItemID As Integer, _ItemName As String, _ItemPrice As Decimal, _PortionID As Integer)
        InitializeComponent()
        branchID = _BranchID
        ItemID = _ItemID
        ItemName = _ItemName
        PortionID = _PortionID
        ItemPrice = _ItemPrice
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateItem()
    End Sub
    Private Sub UpdateItem()

        Try
            If ItemName <> txtItemName.Text Then
                If CheckSambaItemNameExists(txtItemName.Text, branchID) = True Then
                    MsgBoxShowError(" اسم الصنف مكرر ")
                    Exit Sub
                End If
            End If
            Dim sql As New SQLControl
            Dim sqlstring As String = " UPDATE [dbo].[MenuItems] SET [Name] = N'" & txtItemName.Text & "' WHERE [Id] =" & ItemID & " ;
                                        UPDATE [dbo].[MenuItemPrices] SET [Price]=" & txtItemPrice.Text & " WHERE [MenuItemPortionId] = " & PortionID & " ; 
                                        UPDATE [dbo].[ScreenMenuItems] SET [Name]=N'" & txtItemName.Text & "' WHERE [MenuItemId] = " & ItemID & " ; "
            If sql.SqlPosRunQuery(sqlstring, branchID) = True Then
                MsgBoxShowSuccess(" تم تعديل الصنف بنجاح ")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBoxShowError(" لم يتم تعديل البيانات ")
        End Try

    End Sub

    Private Sub SambaEditItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtItemID.Text = ItemID
        Me.txtItemName.Text = ItemName
        Me.txtItemPrice.Text = ItemPrice
        txtItemPrice.Select()
    End Sub

    Private Sub txtItemPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles txtItemPrice.MouseUp
        TextEditSelectText(txtItemPrice)
    End Sub

    Private Sub txtItemName_MouseUp(sender As Object, e As MouseEventArgs) Handles txtItemName.MouseUp
        TextEditSelectText(txtItemName)
    End Sub
End Class