Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class CampaignesByProductQuantity
    Dim Con As SqlConnection
    Dim CampaginAdapter, CampaginItemsAdapter As SqlDataAdapter
    Dim DS, DS2 As DataSet
    Dim _CampaginsItemsTable, _CampaginDate As New DataTable
    Dim _MaxID As Integer
    Dim _ItemNo, _ItemName As String
    Dim _UnitPrice, _Quantity As Decimal

    Private Sub CampaignesByProductQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        RepositoryItemSearch.DataSource = GetItemsFromBarcodesTable(-1)
        RepositoryUnits.DataSource = GetAllItemsUnits()
    End Sub
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.F10 Then
            ShowSearchItemsMenue()
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
                GridView1.UpdateSummary()
            End If
        End If
    End Sub
    Private Sub NewDoc()
        Dim SqlString As String
        Dim Sql As New SQLControl
        SqlString = " Select  "
    End Sub
    Private Sub GetCompainsData()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            CampaginAdapter = New SqlDataAdapter("Select [ID],CampaginName,CampaginType,FromDate,ToDate,
                              Active,CampaginNotes,CampaginCode,ItemsCount From [dbo].[Campagins] Where ID= " & Me.TextID.EditValue, Con)
            DS = New System.Data.DataSet()
            CampaginAdapter.Fill(DS, "Campagins")
            If DS.Tables(0).Rows.Count > 0 Then
                Me.CampaginName.Text = DS.Tables(0).Rows(0).Item("CampaginName")
                Me.CampaginType.Text = DS.Tables(0).Rows(0).Item("CampaginType")
                Me.FromDate.DateTime = DS.Tables(0).Rows(0).Item("FromDate")
                Me.ToDate.DateTime = DS.Tables(0).Rows(0).Item("ToDate")
                Me.CheckActive.Checked = DS.Tables(0).Rows(0).Item("Active")
                Me.CampaginNotes.Text = DS.Tables(0).Rows(0).Item("CampaginNotes")
                Me.CampaginCode.Text = DS.Tables(0).Rows(0).Item("CampaginCode")
                Me.ItemsCount.Text = DS.Tables(0).Rows(0).Item("ItemsCount")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SavingCampaginData()
        'TextID.DataBindings.Add(New Binding("Text", DS, "Campagins.ID"))
        'CampaginName.DataBindings.Add(New Binding("Text", DS, "Campagins.CampaginName"))
        'CampaginType.DataBindings.Add(New Binding("Text", DS, "Campagins.CampaginType"))
        DS.Tables(0).AcceptChanges()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(CampaginAdapter)
            CampaginAdapter.Update(DS, "Campagins")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetCampaginItemsData()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            Dim SqlString As String
            SqlString = "Select [ID],[ItemNo],[Quantity],[Amount],[CampaginID],
                                [ItemName] ,[UnitPrice],[CampignesPrice],[Barcode],[OnlyThisBarcode] , UnitID
                         From [CampaginByItemsCount]
                         Where CampaginID=" & Me.TextID.EditValue
            CampaginItemsAdapter = New SqlDataAdapter(SqlString, Con)
            DS2 = New System.Data.DataSet()
            CampaginItemsAdapter.Fill(DS2, "CampaginByItemsCount")
            GridControl1.DataSource = DS2.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        ShowSearchItemsMenue()
    End Sub
    Private Sub ShowSearchItemsMenue()
        ItemsSearchMenue.GridView1.OptionsSelection.MultiSelect = True
        ItemsSearchMenue.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        ItemsSearchMenue.Text = "اخر اسعار البيع "
        If ItemsSearchMenue.ShowDialog() <> DialogResult.OK Then
            Dim i As Integer
            For i = 0 To GlobalVariables._ItemsTable.Rows.Count - 1
                With GridView1
                    _ItemNo = GlobalVariables._ItemsTable.Rows(i).Item("ItemNo")
                    _ItemName = GlobalVariables._ItemsTable.Rows(i).Item("ItemName")
                    _UnitPrice = GlobalVariables._ItemsTable.Rows(i).Item("UnitPrice")
                    .AddNewRow()
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                    _ItemNo = String.Empty
                    _ItemName = String.Empty
                    _UnitPrice = 0
                End With
            Next
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        'Me.GridView1.SetRowCellValue(e.RowHandle, "ItemNo", _ItemNo)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "ItemName", _ItemName)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "UnitPrice", _UnitPrice)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "Quantity", 1)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "Amount", 1)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "CampignesPrice", 1)
        If Me.TextNewOld.Text = "Old" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "CampaginID", Me.TextID.Text)
        Else
            Me.GridView1.SetRowCellValue(e.RowHandle, "CampaginID", Me.TextID.Text)
        End If
        Me.GridView1.SetRowCellValue(e.RowHandle, "OnlyThisBarcode", "False")
    End Sub

    Private Sub SavingCampaginItemsTable(CampaginID As Integer)
        Dim i As Integer
        For i = 0 To GridView1.RowCount
            If Me.TextNewOld.Text = "Old" Then
                GridView1.SetRowCellValue(i, "CampaginID", TextID.EditValue)
            Else
                GridView1.SetRowCellValue(i, "CampaginID", CampaginID)
            End If
        Next
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(CampaginItemsAdapter)
            CampaginItemsAdapter.Update(DS2, "CampaginByItemsCount")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' GetCampaginItemsData()
    End Sub

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        If TextNewOld.Text = "New" Then
            Me.TextID.EditValue = GetMaxDocID()
            Me.CheckActive.Checked = True
            Me.FromDate.DateTime = Format(Now, "yyyy-MM-dd HH:mm")
            Me.ToDate.DateTime = Format(Now.AddMonths(1), "yyyy-MM-dd HH:mm")
        End If
        GetCompainsData()
        GetCampaginItemsData()
    End Sub
    Private Function GetMaxDocID() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select IsNull(max(ID),0) As MaxID from Campagins  ")
            Return CInt(sql.SQLDS.Tables(0).Rows(0).Item("MaxID")) + 1
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim SqlString As String
        Dim Sql As New SQLControl
        If GridView1.RowCount = 0 Then Exit Sub

        Select Case TextNewOld.Text
            Case "New"
                SqlString = " Insert Into [dbo].[Campagins] 
                              (CampaginName,CampaginType,FromDate,ToDate,
                              Active,CampaginNotes,CampaginCode,ItemsCount) values 
                              (" &
                              "N'" & Me.CampaginName.Text & "'," &
                              "1," &
                              "'" & Format(FromDate.DateTime, "yyyy-MM-dd HH:mm") & "'," &
                              "'" & Format(ToDate.DateTime, "yyyy-MM-dd HH:mm") & "'," &
                              "" & 1 & "," &
                              "N'" & Me.CampaginNotes.Text & "'," &
                              "N'" & Me.CampaginCode.Text & "'," &
                              " " & GridView1.RowCount & "" &
                              ");select isnull(max(id),0) as MaxID from Campagins"
                If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                    ' Sql.SqlTrueAccountingRunQuery("select isnull(max(id),0) as MaxID from Campagins")
                    _MaxID = Sql.SQLDS.Tables(0).Rows(0).Item("MaxID")
                    SavingCampaginItemsTable(_MaxID)
                    MsgBox("تم الادخال")
                    Me.Dispose()
                End If

            Case "Old"
                SqlString = " Update [dbo].[Campagins]    SET 
                           [CampaginName] = N'" & CampaginName.Text & "'" & "
                          ,[CampaginType] = " & 1 & "
                          ,[FromDate] = '" & Format(FromDate.DateTime, "yyyy-MM-dd HH:mm") & "'" & "
                          ,[ToDate] = '" & Format(ToDate.DateTime, "yyyy-MM-dd HH:mm") & "'" & "
                          ,[Active] = " & CheckActive.CheckState & "
                          ,[CampaginNotes] = N'" & CampaginNotes.Text & "'" & "
                          ,[CampaginCode]  = N'" & CampaginCode.Text & "'" & "
                          ,[ItemsCount] = " & GridView1.RowCount & "
                           WHERE [ID] =" & Me.TextID.EditValue
                If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                    SavingCampaginItemsTable(Me.TextID.EditValue)
                    MsgBox("تم التعديل")
                    Me.Dispose()
                End If
        End Select
    End Sub
    Private edit As BaseEdit = Nothing
    Dim _FieldName As String
    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor
        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
    End Sub
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        With GridView1
            Try
                .PostEditor()
                Dim _StockBarCode As String = "0"
                Try
                    _StockBarCode = .GetFocusedRowCellValue("Barcode")
                Catch ex As Exception
                    _StockBarCode = "0"
                End Try
                If _StockBarCode = "0" Then Return
                Select Case _FieldName
                    Case "Barcode"
                        If _StockBarCode <> "0" Then
                            Dim ItemData = GetItemsData(_StockBarCode, True)
                            .SetFocusedRowCellValue("ItemName", ItemData.ItemName)
                            .SetFocusedRowCellValue("ItemNo", ItemData.ItemNo)
                            .SetFocusedRowCellValue("UnitID", ItemData.DefaultUnit)
                            .SetFocusedRowCellValue("UnitPrice", ItemData._Price1)
                            .SetFocusedRowCellValue("Quantity", 1)
                            .SetRowCellValue(.FocusedRowHandle, "Amount", ItemData._Price1)
                        End If
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With

    End Sub

    Private Sub CampaignesByProductQuantity_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick

    End Sub
End Class