Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports TrueTime.DynamicallyConnectionString

Public Class SambaItemsMatching
    Private Sub SambaItemsMatching_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RepositoryTTSItems.DataSource = GetItemsFromBarcodesTable(-1)
        GetSambaBranches()
        'Me.Close()
    End Sub
    Private Sub GetSambaItems()
        If Me.IsHandleCreated Then
            Dim Con As SqlConnection
            Dim Adapter1 As SqlDataAdapter
            Dim dataSet11 As DataSet
            Dim SqlString As String
            SqlString = " SELECT  [Id] As SambaId     ,[GroupCode]
                          ,[Barcode]  As SambaBarcode    ,[Tag]
                          ,[CustomTags]      ,[ItemType]
                          ,[Name]  As SambaName,'' As item_unit_bar_code, '' as Edited, '' as ItemNo
                      FROM [dbo].[MenuItems] "
            Con = New SqlConnection(TextConnectionString.Text)
            Con.Open()
            Adapter1 = New SqlDataAdapter(SqlString, Con)
            dataSet11 = New System.Data.DataSet()
            Adapter1.Fill(dataSet11, "MenuItems")
            Con.Close()
            GridControl1.DataSource = dataSet11.Tables("MenuItems")

            Dim _SambaBarcode As String
            Dim _TTSBarcode As String
            For i = 0 To BandedGridView1.RowCount - 1
                If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "SambaBarcode")) Then
                    _SambaBarcode = BandedGridView1.GetRowCellValue(i, "SambaBarcode")
                    _TTSBarcode = GetItemNo(_SambaBarcode)
                    If _TTSBarcode <> "0" Then BandedGridView1.SetRowCellValue(i, "item_unit_bar_code", _TTSBarcode)
                End If
            Next
        End If

    End Sub
    Private Function GetItemNo(SambaBarcode As String) As String
        Dim sql As New SQLControl
        Try
            sql.SqlTrueAccountingRunQuery(" select item_unit_bar_code from Items_units where item_unit_bar_code ='" & SambaBarcode & "'")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")) Then
                    Return sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")
                Else
                    Return "0"
                End If
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return "0"
        End Try

    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetSambaItems()
        Me.RepositoryTTSItems.DataSource = GetItemsFromBarcodesTable(-1)
    End Sub
    Private Sub GetSambaBranches()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  ID, POSCode, POSName, CostCenter, BranchID, 
                                  Warehouse, ServerAddress, UseDirectProduction, SamabaPos
                                  FROM AccountingPOSNames 
                                  Where SamabaPos=1"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            SearchPosName.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosName.EditValueChanged
        GetConnectionString()

    End Sub
    Private Sub GetConnectionString()
        If Me.IsHandleCreated = True Then
            TextConnectionString.Text = ""
            If String.IsNullOrEmpty(SearchPosName.Text) Then
                Exit Sub
            End If
            Try
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " SELECT  ServerAddress
                                  FROM AccountingPOSNames 
                                  Where ID=" & SearchPosName.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
                TextConnectionString.Text = sql.SQLDS.Tables(0).Rows(0).Item("ServerAddress")
                If Not String.IsNullOrEmpty(TextConnectionString.Text) Then
                    Try
                        Dim helper As SqlHelper = New SqlHelper(TextConnectionString.Text)
                        If helper.IsConnection Then
                            GetSambaItems()
                        Else
                            XtraMessageBox.Show("لا يوجد اتصال مع نقطة البيع")
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _ID As Integer
        Dim _Name, _Barcode As String
        With BandedGridView1
            For i = 0 To BandedGridView1.RowCount - 1
                If .GetRowCellValue(i, "Edited") = "True" Then
                    If Not IsDBNull(.GetRowCellValue(i, "SambaId")) And
    Not IsDBNull(.GetRowCellValue(i, "SambaName")) And
    Not IsDBNull(.GetRowCellValue(i, "item_unit_bar_code")) Then
                        _ID = .GetRowCellValue(i, "SambaId")
                        _Name = .GetRowCellValue(i, "SambaName")
                        _Barcode = .GetRowCellValue(i, "item_unit_bar_code")
                        If Not String.IsNullOrEmpty(_ID) And
                            Not String.IsNullOrEmpty(_Name) And
                            Not String.IsNullOrEmpty(_Barcode) Then
                            .SetRowCellValue(i, "Edited", UpdateSambaBarcode(_ID, _Name, _Barcode))
                            .SetRowCellValue(i, "SambaBarcode", _Barcode)
                        End If
                    End If
                End If
            Next
        End With
        'GetSambaItems()
    End Sub
    Private Function UpdateSambaBarcode(Id As Integer, ItemName As String, barcode As String) As Integer
        Dim rowsAffected As Integer
        Try
            Using con As New SqlConnection(TextConnectionString.Text)
                Using cmd As New SqlCommand("UPDATE  [dbo].[MenuItems] 
                                                Set  [Barcode] =@Barcode , [Name]=@ItemName  WHERE id =@Id", con)
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id
                    cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = barcode
                    cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = ItemName
                    con.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            rowsAffected = 0
        End Try
        ' MsgBox(rowsAffected)
        Return rowsAffected

    End Function
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
        If e.Column.FieldName = "SambaName" Or e.Column.FieldName = "item_unit_bar_code" Then
            BandedGridView1.SetRowCellValue(BandedGridView1.FocusedRowHandle, BandedGridView1.Columns("Edited"), "True")
        End If
    End Sub
    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles BandedGridView1.ValidateRow
        With BandedGridView1
            Try
                Dim view As ColumnView = TryCast(sender, ColumnView)
                Dim _StockQuantity As GridColumn = view.Columns("SambaName")
                If IsDBNull(.GetRowCellValue(.FocusedRowHandle, "SambaName")) = True Then
                    e.Valid = False
                    e.ErrorText = "يجب ادخال اسم للصنف"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = _StockQuantity
                    view.ShowEditor()
                End If

                If String.IsNullOrEmpty(.GetRowCellValue(.FocusedRowHandle, "SambaName")) Then
                    e.Valid = False
                    e.ErrorText = "يجب ادخال اسم للصنف"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = _StockQuantity
                    view.ShowEditor()
                End If

            Catch ex As Exception

            End Try
        End With
    End Sub

    Private Sub RepositoryTTSItems_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryTTSItems.BeforePopup
        'Me.RepositoryTTSItems.DataSource = GetItems(-1)
    End Sub

    Private Sub RepositoryTTSItems_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles RepositoryTTSItems.AddNewValue
        Dim Max As Integer
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " select max(item_id) as Max from Items_units "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Max = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("Max"))
        Catch ex As Exception
            Max = 0
        End Try

        Dim NewNo As Integer, NewBarcode As String
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " select item_id,item_unit_bar_code from Items_units where item_id = (select max(item_id) from Items_units )"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            NewNo = Sql.SQLDS.Tables(0).Rows(0).Item("item_id")
            NewBarcode = Sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")
        Catch ex As Exception
            NewNo = 0
            NewBarcode = 0
        End Try


        My.Forms.Items.ItemName.Select()
        My.Forms.Items.ItemNo.EditValue = Max + 1
        My.Forms.Items.ItemName.Text = BandedGridView1.GetFocusedRowCellValue("SambaName")
        If Items.ShowDialog() <> DialogResult.OK Then
            Me.RepositoryTTSItems.DataSource = GetItemsFromBarcodesTable(-1)
            Me.BandedGridView1.SetFocusedRowCellValue("item_unit_bar_code", NewBarcode)
        End If
    End Sub
End Class