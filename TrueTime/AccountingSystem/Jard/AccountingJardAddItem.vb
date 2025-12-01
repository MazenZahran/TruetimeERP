Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Public Class AccountingJardAddItem
    Public ItemNo As Integer
    Private _SessionID As Integer
    Private _DocNo As Integer
    Public Sub New(SessionID As Integer, DocNo As Integer)
        InitializeComponent()
        _SessionID = SessionID
        _DocNo = DocNo
    End Sub
    Private Sub AccountingJardAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookUnit.Properties.DataSource = GetAllItemsUnits()
        If GlobalVariables._WareHouseUseShelf = True Then
            Me.SearchShelfNo.Properties.DataSource = GetShelves(GetDefaltWahreHouseForUser(GlobalVariables.CurrUser))
            LayoutShelf.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            InsertToJardTable()
        ElseIf e.KeyCode = Keys.Escape Then
            JardGlobalVariables._OpenJardFormAgain = False
            Me.Close()
        End If
    End Sub
    Private Function GetDocNo() As Integer
        Dim _No As Integer = 0
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select top(1) DocNo from JardJournal "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                _No = 1
            Else
                _No = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocNo")) + 1
            End If
        Catch ex As Exception
            _No = 0
        End Try
        Return _No
    End Function
    Public Sub GetItemData(By_Barcode As Boolean)
        If Me.txtBarcode.Text = "0" Then Exit Sub
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   Select top(1) I.ItemNo,I.ItemName,IU.item_unit_bar_code,IU.Price1,IU.unit_id,IsNull(I.LastPurchasePrice,0) as LastPurchasePrice
                        From [Items] I
                        Left Join Items_units IU on I.ItemNo=IU.item_id "
        If By_Barcode = True Then
            sqlstring += " Where IU.item_unit_bar_code='" & txtBarcode.Text & "' "
        Else
            If GlobalVariables._ItemBarcodeGlobal <> "0" Then
                sqlstring += " Where IU.item_unit_bar_code='" & GlobalVariables._ItemBarcodeGlobal & "'"
            Else
                sqlstring += " Where I.ItemNo='" & GlobalVariables._ItemNoGlobal & "' And IU.unit_id=" & GlobalVariables._ItemUnitIDGlobal
            End If
        End If

        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count <> 0 Then
            With sql.SQLDS.Tables(0).Rows(0)
                txtItemNo.Text = .Item("ItemNo")
                txtItemName.Text = .Item("ItemName")
                LookUnit.Properties.DataSource = GetUnitsTable(.Item("ItemNo"))
                LookUnit.EditValue = .Item("unit_id")
                txtPrice.EditValue = .Item("Price1")
                txtBarcode.Text = .Item("item_unit_bar_code")
                txtCost.Text = .Item("LastPurchasePrice")
                txtQuantity.Select()
            End With
        Else
            System.Media.SystemSounds.Beep.Play()
            OpenSearchForm()
        End If
    End Sub

    Private Sub BtnSearchItem_Click(sender As Object, e As EventArgs) Handles BtnSearchItem.Click
        OpenSearchForm()
    End Sub
    Private Sub OpenSearchForm()
        Dim F As New AccountingJardSearchItems(Me.Name)
        If F.ShowDialog <> DialogResult.OK Then
            If GlobalVariables._ItemNoGlobal <> 0 Then
                GetItemData(False)
            End If
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetItemData(True)
        End If
    End Sub


    Private Sub LookUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles LookUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtQuantity.Select()
        End If
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnOK.Select()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        InsertToJardTable()
    End Sub

    Private Sub InsertToJardTable()
        If String.IsNullOrEmpty(txtBarcode.Text) Then
            MsgBoxShowError(" يجب اختيار باركود للصنف ")
            txtBarcode.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtItemNo.Text) Then
            MsgBoxShowError(" رقم الصنف فارغ ")
            txtItemNo.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtItemName.Text) Then
            MsgBoxShowError(" اسم الصنف فارغ ")
            txtItemName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(LookUnit.Text) Then
            MsgBoxShowError(" يجب اختيار وحدة ")
            LookUnit.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtQuantity.Text) Or txtQuantity.EditValue = 0 Then
            MsgBoxShowError(" الكمية صفر  ")
            txtQuantity.Select()
            Exit Sub
        End If

        If GlobalVariables._WareHouseUseShelf = True Then
            If String.IsNullOrEmpty(SearchShelfNo.Text) Or SearchShelfNo.EditValue = 0 Then
                MsgBoxShowError(" يجب اختيار رف  ")
                SearchShelfNo.Select()
                Exit Sub
            End If
        Else
            SearchShelfNo.EditValue = 0
        End If


        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " INSERT INTO [dbo].[JardJournal]
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
           ,[SessionID],DocID,ItemCost,ShelfID)
     VALUES (
           '" & txtBarcode.Text & "' 
           ," & txtItemNo.Text & "
           ,N'" & txtItemName.Text & "'
           ," & LookUnit.EditValue & "
           ," & txtQuantity.EditValue & "
           ," & txtPrice.EditValue & "
           ," & GlobalVariables.CurrUser & "
           ,1
           ,N'" & txtDocNoteByItem.Text & "'
           ,N'" & GlobalVariables.CurrDevice & "'
           ,N'" & _SessionID & "'
           ," & _DocNo & "," & txtCost.EditValue & "," & SearchShelfNo.EditValue & ")"
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            JardGlobalVariables._OpenJardFormAgain = True
            Me.Close()
        End If
    End Sub

    Private Sub AccountingJardAddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            OpenSearchForm()
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        JardGlobalVariables._OpenJardFormAgain = False
        Me.Close()
    End Sub
    Private Sub txtQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles txtQuantity.MouseUp
        TextEditSelectText(txtQuantity)
    End Sub

    Private Sub txtBarcode_EditValueChanged(sender As Object, e As EventArgs) Handles txtBarcode.EditValueChanged

    End Sub
End Class