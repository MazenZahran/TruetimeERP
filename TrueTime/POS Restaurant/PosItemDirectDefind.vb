Imports DevExpress.XtraPrinting

Public Class PosItemDirectDefind
    Public stayOpen As Boolean = False
    Private Sub PosItemDirectDefind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Units' table. You can move, or remove it, as needed.
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
        Me.UnitsTableAdapter.Fill(Me.AccountingDataSet.Units)
        TextItemName.Focus()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DefinNewItem()
    End Sub
    Private Sub DefinNewItem()
        If String.IsNullOrEmpty(Me.TextItemName.Text) Then
            MsgBoxShowError(" الاسم فارغ ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.TextItemBarcode.Text) Then
            TextItemBarcode.Text = "0"
        End If

        If String.IsNullOrEmpty(Me.TextPrice.Text) Then
            MsgBoxShowError(" السعر فارغ ")
            Exit Sub
        End If

        If TextPrice.EditValue <0 Then
            MsgBoxShowError(" خطا في السعر  ")
            Exit Sub
        End If



        If TextItemBarcode.Text <> "0" And CheckIfBarcodeFound(Me.TextItemBarcode.Text) Then
            MsgBoxShowError(" الباركود موجود مسبقا ")
            Exit Sub
        End If

        Dim _item As New FinancialItems
        With _item
            .ItemName = Me.TextItemName.Text
            .ItemBarcode = Me.TextItemBarcode.Text
            .ItemUnit = Me.LookUpUnit.EditValue
            .ItemPrice = Me.TextPrice.EditValue
            .ItemGroup = Me.SearchItemsGroups.EditValue
            Dim itemNo As Integer = .InsertItemFromPos()
            If itemNo > 0 Then
                If TextQuantity.EditValue > 0 Then
                    AddQuantityToJardJournal(TextItemBarcode.Text, itemNo, Me.TextItemName.Text, Me.LookUpUnit.EditValue, TextQuantity.EditValue)
                End If
                CreateDocLog("File", "", "0", "0", "Insert", "Add New Item" & ":" & Me.TextItemName.Text & " Barcode:" & Me.TextItemBarcode.Text & " From Pos", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                If stayOpen = False Then
                    Me.Close()
                Else
                    ClearData()
                End If
            End If
        End With



    End Sub

    Private Sub TextPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles TextPrice.MouseUp
        TextEditSelectText(TextPrice)
    End Sub
    Private Sub InsertIntoLogs()

    End Sub
    Private Sub TextItemName_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemName.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SearchItemsGroups_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles SearchItemsGroups.Properties.AddNewValue

    End Sub

    Private Sub SearchItemsGroups_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchItemsGroups.Properties.BeforePopup

    End Sub
    Private Sub AddQuantityToJardJournal(barcode As String, itemNo As Integer, itemName As String, itemUnit As Integer, itemQuantity As Decimal)
        Dim sessionID As Integer = 0
        Dim docID As Integer = 0
        Dim sqlString As String

        sqlString = " INSERT INTO [dbo].[JardJournal]
           (
            [ItemBarcode]
           ,[ItemNo]
           ,[ItemName]
           ,[ItemUnit]
           ,[ItemQuantity]
           ,[ItemPrice]
           ,[UserID]
           ,[DocStatus]
           ,[DocNoteByItem]
           ,[DeviceName]
           ,[SessionID],DocID)
     VALUES (
           N'" & barcode & "' 
           ," & itemNo & "
           ,N'" & itemName & "'
           ," & itemUnit & "
           ," & itemQuantity & "
           ," & 0 & "
           ," & GlobalVariables.CurrUser & "
           ,1
           ,N'" & "" & "'
           ,N'" & GlobalVariables.CurrDevice & "'
           ,(Select IsNull(Max(ID),0)+1  from [JardSessions])
           ,(Select IsNull(Max(ID),0)+1  from [JardJournalList]))"
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(sqlString)
    End Sub

    Private Sub TextQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles TextQuantity.MouseUp
        TextEditSelectText(TextQuantity)
    End Sub
    Private Sub ClearData()
        TextItemName.Text = ""
        TextItemBarcode.Text = "0"
        TextPrice.Text = "0"
        TextQuantity.Text = "0"
        LookUpUnit.EditValue = 1
        SearchItemsGroups.EditValue = 0
    End Sub

    Private Sub TextItemName_Enter(sender As Object, e As EventArgs) Handles TextItemName.Enter
        SwitchKeyboardLayout("ar")
    End Sub

    Private Sub TextItemBarcode_Enter(sender As Object, e As EventArgs) Handles TextItemBarcode.Enter
        SwitchKeyboardLayout("en")
    End Sub
End Class