Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class ItemsSerialsAdd
    Dim Con As SqlConnection
    Dim ItemsSerialsAdapter As SqlDataAdapter
    Dim ItemsSerialsTransAdapter As SqlDataAdapter
    Dim DS As DataSet
    Dim DSTrans As DataSet
    Public ItemNoInItemsSerialAdd As String
    Public DocCodeInItemsSerialAdd As String
    Public DocNameInItemsSerialAdd As String
    Public DocDateInItemsSerialAdd As Date
    Public SerialDebitWhereHouse As Integer
    Public SerialCreditWhereHouse As Integer
    Public DocNoInItemsSerialAdd As Integer
    Public DocStatusInItemsSerialAdd As Integer
    Private DisabledRowHandles As Integer

    Private Sub ItemsSerialsAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColSelectedSerial.Visible = False
        SerialStatus()
        If DocNameInItemsSerialAdd = 1 Or DocNameInItemsSerialAdd = 17 Then
            ColSaleWarrantyStart.VisibleIndex = -1
            ColSaleWarrantyEnd.VisibleIndex = -1
            ColSaleWarrantyStart.VisibleIndex = -1
            ColPurchaseWarrantySrart.VisibleIndex = -1
            ColPurchaseWarrantyEnd.VisibleIndex = -1
            ColSerialStatus.VisibleIndex = -1
            CheckEdit1.Checked = False
            ColSerialNumber.OptionsColumn.AllowEdit = True
        ElseIf DocNameInItemsSerialAdd = 2 Then
            CheckEdit1.Checked = True
            ColPurchaseWarrantySrart.VisibleIndex = -1
            ColPurchaseWarrantyEnd.VisibleIndex = -1
            ColSerialNumber.VisibleIndex = 0
            ColSaleWarrantyStart.VisibleIndex = 1
            ColSaleWarrantyEnd.VisibleIndex = 2
            ColSerialNumber.OptionsColumn.AllowEdit = False
            For i = 0 To GridView1.RowCount - 1
                With GridView1
                    If IsDBNull(.GetRowCellValue(i, "SaleWarrantyStart")) Then
                        .SetRowCellValue(i, "SaleWarrantyStart", DocDateInItemsSerialAdd)
                        .SetRowCellValue(i, "SaleWarrantyEnd", CDate(DocDateInItemsSerialAdd).AddYears(1).AddDays(-1))
                    End If
                End With
            Next
        End If
        GridControl1.Select()
    End Sub
    Public Sub GetItemSerials()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Select 0 As TransType,T.TransID as TransID, T.[SerialNumber] as SerialNumber,
                               T.[DocCode],T.ItemNo,T.PurchaseWarrantyEnd,T.PurchaseWarrantyStart,
                               T.SaleWarrantyEnd,T.SaleWarrantyStart,T.SerialStatus,T.IDInSerials as SerialID,
                               T.SerialDebitWhereHouse,T.SerialCreditWhereHouse,T.DocName,T.DocDate,T.AddedDate,
                               T.AddedUser,T.Notes,T.DocNo,TT.[TransCount]
   FROM [dbo].[ItemsSerialTransTemp] T
   Left join ( Select Count(TransID) As TransCount ,ItemNo,SerialNumber From  [dbo].[ItemsSerialTrans] Group By ItemNo,SerialNumber) TT on T.SerialNumber=TT.SerialNumber and T.ItemNo=TT.ItemNo
   Where T.TempTransType<>'Delete' And T.ItemNo='" & ItemNoInItemsSerialAdd & "' And T.DocCode='" & DocCodeInItemsSerialAdd & "'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)

    End Sub

    Public Sub GetItemSerialsForOut()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "     SELECT S.[ID]      ,S.[SerialNumber]
      ,S.[SerialStatus]      ,S.[PurchaseWarrantyStart]
      ,S.[PurchaseWarrantyEnd]      ,ST.[SaleWarrantyStart]
      ,ST.[SaleWarrantyEnd]      ,S.[ItemNo]
      ,S.[DocCode] ,Case when TT.SerialNumber Is Null then 0 else 1 end as SelectedSerial
	  FROM [dbo].[ItemsSerials] S
	  left join [dbo].[ItemsSerialTransTemp] TT on S.SerialNumber=TT.SerialNumber and S.ItemNo=TT.ItemNo
	  left join [dbo].[ItemsSerialsTemp] ST on S.SerialNumber=ST.SerialNumber and S.ItemNo=ST.ItemNo
	  where  S.ItemNo='" & ItemNoInItemsSerialAdd & "' And ((S.SerialStatus=2 and TT.SerialNumber Is Not Null) or (S.SerialStatus=1))"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)

        'For i = 0 To GridView1.RowCount - 1
        '    If IsDBNull(GridView1.GetRowCellValue(i, "SelectedSerial")) Then

        '    End If
        'Next

        Dim view As ColumnView = CType(GridControl1.MainView, ColumnView)
        Dim ColSelectedSerial As GridColumn = view.Columns("SelectedSerial")
        If ColSelectedSerial Is Nothing Then Return
        'Enable multiple row selection mode.
        view.OptionsSelection.MultiSelect = True
        view.ClearSelection()
        Dim rowHandle As Integer = -1
        'Select rows that contain 'Mexico' in the Country column.
        While rowHandle <> GridControl.InvalidRowHandle
            rowHandle = view.LocateByDisplayText(rowHandle + 1, ColSelectedSerial, "1")
            'rowHandle = view.LocateByValue(rowHandle + 1, ColSelectedSerial, Nothing)
            view.SelectRow(rowHandle)
        End While

        '        RepositorySerialStatus.editv = "<size=14>Size = 14 <br/> <b>Bold</b> <i>Italic</i> <u>Underline</u> " +
        '"<br/><size=11>Size = 11<br/> <color=255, 0, 0>Sample Text"

    End Sub


    'Public Sub GetItemsSerialsTables()
    '    Try
    '        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
    '        Con.Open()
    '        ItemsSerialsAdapter = New SqlDataAdapter("SELECT [ID] ,[SerialNumber]
    '                         ,[SerialStatus] ,[PurchaseWarrantyStart]
    '                         ,[PurchaseWarrantyEnd] ,[SaleWarrantyStart]
    '                         ,[SaleWarrantyEnd] ,[ItemNo],[DocCode]
    '                  FROM [dbo].[ItemsSerials] Where ItemNo='" & ItemNoInItemsSerialAdd & "' And DocCode='" & DocCodeInItemsSerialAdd & "'", Con)
    '        DS = New System.Data.DataSet()
    '        ItemsSerialsAdapter.Fill(DS, "ItemsSerials")
    '        GridControl1.DataSource = DS.Tables(0)
    '    Catch __unusedException1__ As Exception
    '        Throw
    '    End Try
    'End Sub
    'Public Sub GetItemsSerialsTransTables()
    '    Try
    '        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
    '        Con.Open()
    '        ItemsSerialsTransAdapter = New SqlDataAdapter(" SELECT  [TransID] ,[SerialID] ,[DocCode]
    '                                                   FROM [dbo].[ItemsSerialTrans] Where ItemNo='" & ItemNoInItemsSerialAdd & "' And DocCode='" & DocCodeInItemsSerialAdd & "'", Con)
    '        DSTrans = New System.Data.DataSet()
    '        ItemsSerialsTransAdapter.Fill(DSTrans, "ItemsSerialTrans")
    '        GridControl1.DataSource = DSTrans.Tables(0)
    '    Catch __unusedException1__ As Exception
    '        Throw
    '    End Try
    'End Sub
    'Private Sub SavingItemsSerialsTransTables()
    '    Try
    '        Dim SqlCommBuil As SqlCommandBuilder
    '        SqlCommBuil = New SqlCommandBuilder(ItemsSerialsTransAdapter)
    '        ItemsSerialsTransAdapter.Update(DSTrans, "ItemsSerialTrans")
    '    Catch ex As Exception

    '    End Try
    '    GetItemsSerialsTables()
    'End Sub
    'Private Sub SavingItemsSerialsTables()
    '    Try
    '        Dim SqlCommBuil As SqlCommandBuilder
    '        SqlCommBuil = New SqlCommandBuilder(ItemsSerialsAdapter)
    '        ItemsSerialsAdapter.Update(DS, "ItemsSerials")
    '    Catch ex As Exception

    '    End Try
    '    GetItemsSerialsTables()
    'End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'SavingItemsSerialsTables()
        'GetItemsSerialsTables()
        'SavingItemsSerialsTransTables()
        'GetItemsSerialsTransTables()
        'InsertUpdateSerials()
        'Me.Close()
        'InsertUpdateSerialsByRow()
        InsertUpdateSerials()
    End Sub


    Private Sub InsertUpdateSerials()
        Dim _InserDateTime As String
        _InserDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim SqlString2, SqlString1Update As String
        Dim Sql As New SQLControl
        Dim _InputSerialTransProcess As Boolean = True
        Select Case DocNameInItemsSerialAdd
            Case 1, 17
                For i = 0 To GridView1.RowCount - 1
                    If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, "SerialNumber")) Then

                        Dim _PurchaseWarrantyStart, _PurchaseWarrantyEnd As String
                        If Not IsDBNull(GridView1.GetRowCellValue(i, "PurchaseWarrantyStart")) Then
                            _PurchaseWarrantyStart = Format(GridView1.GetRowCellValue(i, "PurchaseWarrantyStart"), "yyyy-MM-dd")
                        Else
                            _PurchaseWarrantyStart = String.Empty
                        End If
                        If Not IsDBNull(GridView1.GetRowCellValue(i, "PurchaseWarrantyEnd")) Then
                            _PurchaseWarrantyEnd = Format(GridView1.GetRowCellValue(i, "PurchaseWarrantyEnd"), "yyyy-MM-dd")
                        Else
                            _PurchaseWarrantyEnd = String.Empty
                        End If

                        If IsDBNull(GridView1.GetRowCellValue(i, "TransID")) Then
                            Dim _SerialStatus As Integer
                            If GridView1.GetRowCellValue(i, "SerialStatus") = 0 Then _SerialStatus = 1
                            SqlString2 = " Insert Into [dbo].[ItemsSerialTransTemp] 
                                                     ([SerialNumber],[DocCode],[ItemNo],UserNo,
                                                      SerialDebitWhereHouse,DocDate,DocNo,DocName,AddedUser,AddedDate,
                                                      TempTransType,[PurchaseWarrantyStart],[PurchaseWarrantyEnd],SerialStatus)
                                                      Values (" &
                                                   "'" & GridView1.GetRowCellValue(i, "SerialNumber") & "'" &
                                                   ",'" & GridView1.GetRowCellValue(i, "DocCode") & "'" &
                                                   ",'" & GridView1.GetRowCellValue(i, "ItemNo") & "'" &
                                                   ",'" & GlobalVariables.CurrUser & "'" &
                                                   ",'" & SerialDebitWhereHouse & "'" &
                                                   ",'" & Format(DocDateInItemsSerialAdd, "yyyy-MM-dd") & "'" &
                                                   ",'" & DocNoInItemsSerialAdd & "'" &
                                                   ",'" & DocNameInItemsSerialAdd & "'" &
                                                   ",'" & GlobalVariables.CurrUser & "'" &
                                                   ",'" & _InserDateTime & "'" &
                                                   ",'New'" &
                                                  ",'" & _PurchaseWarrantyStart & "'" &
                                                  ",'" & _PurchaseWarrantyEnd & "'" &
                                                  ",'" & _SerialStatus & "'" &
                                                  ") "
                            _InputSerialTransProcess = Sql.SqlTrueAccountingRunQuery(SqlString2)
                            If _InputSerialTransProcess = True Then
                                GridView1.SetRowCellValue(i, "TransType", 1)
                            Else
                                MsgBox("Insert To Trans Error:  Serial" & GridView1.GetRowCellValue(i, "SerialNumber"))
                                Exit Sub
                            End If
                        Else
                            Dim _UpdateStatment As Boolean
                            SqlString1Update = "UPDATE [dbo].[ItemsSerialTransTemp]
                                                SET [SerialNumber] = '" & GridView1.GetRowCellValue(i, "SerialNumber") & "',
                                                    [PurchaseWarrantyStart] = '" & _PurchaseWarrantyStart & "', 
                                                    [PurchaseWarrantyEnd] = '" & _PurchaseWarrantyEnd & "'
                                                Where TransID='" & GridView1.GetRowCellValue(i, "TransID") & "' 
                                                And ItemNo='" & ItemNoInItemsSerialAdd & "'"
                            _UpdateStatment = Sql.SqlTrueAccountingRunQuery(SqlString1Update)
                            If _UpdateStatment = False Then
                                MsgBox("Error on Update Serial" & GridView1.GetRowCellValue(i, "SerialNumber"))
                                Exit Sub
                            End If
                        End If

                        'If _InputSerialTransProcess = True Then
                        '    Me.Close()
                        'Else
                        '    MsgBox("Error")
                        'End If

                    End If
                Next
                Me.Close()
                'Case 2
                '    Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
                '    For i As Integer = 0 To selectedRowHandles.Length - 1
                '        'MsgBox(GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber"))
                '        If GridView1.GetRowCellValue(selectedRowHandles(i), "SelectedSerial") = 0 Then

                '            SqlString1 = " Insert Into [dbo].[ItemsSerialsTemp] 
                '                 ([SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],[SaleWarrantyStart],[SaleWarrantyEnd]
                '                  ,[ItemNo],DocCode,UserNo) Values (" &
                '                      "'" & GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber") & "'" &
                '                      ",'" & 2 & "'" &
                '                       ",'" & Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyStart"), "yyyy-MM-dd") & "'" &
                '                       ",'" & Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyEnd"), "yyyy-MM-dd") & "'" &
                '                       ",'" & Format(GridView1.GetRowCellValue(selectedRowHandles(i), "SaleWarrantyStart"), "yyyy-MM-dd") & "'" &
                '                       ",'" & Format(GridView1.GetRowCellValue(selectedRowHandles(i), "SaleWarrantyEnd"), "yyyy-MM-dd") & "'" &
                '                       ",'" & GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo") & "'" &
                '                       ",'" & DocCodeInItemsSerialAdd & "'" &
                '                       ",'" & GlobalVariables.CurrUser & "'" &
                '                       ") "
                '            _InputSerialProcess = Sql.SqlTrueAccountingRunQuery(SqlString1)

                '            If _InputSerialProcess = True Then
                '                SqlString2 = " Insert Into [dbo].[ItemsSerialTransTemp] 
                '                                         ([SerialNumber],[DocCode],[ItemNo],UserNo,SerialCreditWhereHouse,DocDate,[DocNo],DocName,AddedUser,AddedDate) Values (" &
                '       "'" & GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber") & "'" &
                '       ",'" & DocCodeInItemsSerialAdd & "'" &
                '       ",'" & GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo") & "'" &
                '       ",'" & GlobalVariables.CurrUser & "'" &
                '       ",'" & SerialCreditWhereHouse & "'" &
                '       ",'" & Format(DocDateInItemsSerialAdd, "yyyy-MM-dd") & "'" &
                '       ",'" & DocNoInItemsSerialAdd & "'" &
                '       ",'" & DocNameInItemsSerialAdd & "'" &
                '       ",'" & GlobalVariables.CurrUser & "'" &
                '       ",'" & _InserDateTime & "'" &
                '      ") "
                '                _InputSerialTransProcess = Sql.SqlTrueAccountingRunQuery(SqlString2)
                '                If _InputSerialTransProcess = True Then
                '                    'GridView1.SetRowCellValue(i, "TransType", 1)
                '                Else
                '                    Exit Sub
                '                    'Sql.SqlTrueAccountingRunQuery("Delete from ItemsSerialTransTemp
                '                    '                      where [UserNo]='" & GlobalVariables.CurrUser & "' And ItemNo='" & GridView1.GetRowCellValue(i, "ItemNo") & "'")
                '                End If
                '            End If

                '        Else

                '            Dim _Date1, _Date2 As String
                '            If Not IsDBNull(GridView1.GetRowCellValue(i, "SaleWarrantyStart")) Then
                '                _Date1 = Format(GridView1.GetRowCellValue(i, "SaleWarrantyStart"), "yyyy-MM-dd")
                '            Else
                '                _Date1 = String.Empty
                '            End If
                '            If Not IsDBNull(GridView1.GetRowCellValue(i, "SaleWarrantyEnd")) Then
                '                _Date2 = Format(GridView1.GetRowCellValue(i, "SaleWarrantyEnd"), "yyyy-MM-dd")
                '            Else
                '                _Date2 = String.Empty
                '            End If

                '            SqlString1Update = "UPDATE [dbo].[ItemsSerialsTemp]
                '                                    SET [SaleWarrantyStart] = '" & _Date1 & "', 
                '                                        [SaleWarrantyEnd] = '" & _Date2 & "' 
                '                                    Where SerialNumber='" & GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber") & "' And ItemNo='" & ItemNoInItemsSerialAdd & "'"
                '            Sql.SqlTrueAccountingRunQuery(SqlString1Update)
                '        End If
                '    Next

                '    Dim _UnSelectedSerila As String
                '    For i = 0 To GridView1.RowCount - 1
                '        If GridView1.IsRowSelected(i) = False Then
                '            _UnSelectedSerila = CStr(GridView1.GetRowCellValue(i, "SerialNumber"))
                '            Sql.SqlTrueAccountingRunQuery("Update ItemsSerialsTemp Set [SerialStatus]=1,SaleWarrantyStart =Null,SaleWarrantyEnd=Null  where 
                '                                           SerialNumber='" & _UnSelectedSerila & "' And ItemNo='" & ItemNoInItemsSerialAdd & "';
                '                                           Delete from ItemsSerialTransTemp where
                '                                           SerialNumber='" & _UnSelectedSerila & "' And ItemNo='" & ItemNoInItemsSerialAdd & "'")
                '        End If
                '    Next

                '    If _InputSerialProcess = True And _InputSerialTransProcess = True Then
                '        Me.Close()
                '    Else
                '        MsgBox("Error")
                '    End If
        End Select

    End Sub

    Private Sub InsertUpdateSerialsFromNewVoucher()

    End Sub

    Private Sub InsertUpdateSerialsFromOldVoucher()

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Me.GridView1.SetRowCellValue(e.RowHandle, "DocCode", DocCodeInItemsSerialAdd)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemNo", ItemNoInItemsSerialAdd)
        Me.GridView1.SetRowCellValue(e.RowHandle, "SerialStatus", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "PurchaseWarrantyStart", DocDateInItemsSerialAdd)
        Me.GridView1.SetRowCellValue(e.RowHandle, "PurchaseWarrantyEnd", DocDateInItemsSerialAdd.AddYears(1).AddDays(-1))

    End Sub
    'Private Sub InsertUpdateSerialsByRow()
    '    Dim Sql As New SQLControl
    '    Dim SqlString1, SqlString2 As String
    '    Dim _InputSerialProcess, _InputSerialTransProcess As Boolean
    '    Select Case DocNameInItemsSerialAdd
    '        Case 1
    '            For i = 0 To GridView1.RowCount - 1
    '                If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, "SerialNumber")) Then
    '                    SqlString1 = " Insert Into [dbo].[ItemsSerialsTemp] 
    '                         ([SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],
    '                          [SaleWarrantyStart],[SaleWarrantyEnd],SaleWarrantyStart,SaleWarrantyEnd,[ItemNo],UserNo) Values (" &
    '                          "'" & GridView1.GetRowCellValue(i, "SerialNumber") & "'" &
    '                          ",'" & GridView1.GetRowCellValue(i, "SerialStatus") & "'" &
    '                          ",'" & Format(GridView1.GetRowCellValue(i, "PurchaseWarrantyStart"), "dd-MM-yyyy") & "'" &
    '                          ",'" & Format(GridView1.GetRowCellValue(i, "PurchaseWarrantyEnd"), "dd-MM-yyyy") & "'" &
    '                          ",'" & Format(GridView1.GetRowCellValue(i, "SaleWarrantyStart"), "dd-MM-yyyy") & "'" &
    '                          ",'" & Format(GridView1.GetRowCellValue(i, "SaleWarrantyEnd"), "dd-MM-yyyy") & "'" &
    '                          ",'" & GridView1.GetRowCellValue(i, "ItemNo") & "'" &
    '                          ",'" & GlobalVariables.CurrUser & "'" &
    '                         ") "
    '                    SqlString2 = " Insert Into [dbo].[ItemsSerialTransTemp] 
    '                         ([SerialNumber],[DocCode],[ItemNo],UserNo) Values (" &
    '                                       "'" & GridView1.GetRowCellValue(i, "SerialNumber") & "'" &
    '                                       ",'" & GridView1.GetRowCellValue(i, "DocCode") & "'" &
    '                                       ",'" & GridView1.GetRowCellValue(i, "ItemNo") & "'" &
    '                                       ",'" & GlobalVariables.CurrUser & "'" &
    '                                      ") "
    '                    If String.IsNullOrEmpty(GridView1.GetRowCellValue(i, "TransID")) Then
    '                        _InputSerialProcess = Sql.SqlTrueAccountingRunQuery(SqlString1)
    '                        If _InputSerialProcess = True Then
    '                            _InputSerialTransProcess = Sql.SqlTrueAccountingRunQuery(SqlString2)
    '                        End If
    '                    Else
    '                        'Update
    '                    End If
    '                End If
    '            Next
    '    End Select
    'End Sub

    Private Sub SerialStatus()
        Dim Sr As New DataTable
        Sr.Columns.Add("ID", GetType(Integer))
        Sr.Columns.Add("SerialStatus", GetType(String))
        Sr.Rows.Add(-1, "الكل")
        Sr.Rows.Add(0, "جديد")
        Sr.Rows.Add(1, "متوفر")
        Sr.Rows.Add(2, "مباع")
        Sr.Rows.Add(3, "ملغي")
        RepositorySerialStatus.DataSource = Sr
    End Sub
    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim SerialNumberCol As GridColumn = view.Columns("SerialNumber")

        If DocNameInItemsSerialAdd = 1 Or DocNameInItemsSerialAdd = 17 Then
            Try
                Dim _SerialNumber As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SerialNumber")
                If String.IsNullOrEmpty(_SerialNumber) Or String.IsNullOrWhiteSpace(_SerialNumber) Then
                    e.Valid = False
                    e.ErrorText = "السيريال فارغ"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = SerialNumberCol
                    view.ShowEditor()
                End If
            Catch ex As Exception

            End Try

            Try
                Dim _SerialNumber As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SerialNumber")
                Dim _idOnData As String = SearchSerialNumberIfFound(_SerialNumber)
                If _idOnData <> 0 Then
                    ' XtraMessageBox.Show("الباركود موجود مسبقا")
                    e.Valid = False
                    e.ErrorText = "السيريال مكرر"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = SerialNumberCol
                    view.ShowEditor()
                End If

            Catch ex As Exception

            End Try

            Try
                Dim i As Integer
                For i = 0 To GridView1.RowCount - 1
                    Dim _SerialNumber = Me.GridView1.GetRowCellValue(i, "SerialNumber")
                    Dim FocusSerialNumber = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SerialNumber")
                    Dim _RowHandel As Integer = GridView1.GetDataSourceRowIndex(i)
                    Dim _RowHandelFocus As Integer = GridView1.GetFocusedDataSourceRowIndex()
                    If _RowHandel <> _RowHandelFocus And Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SerialNumber") = _SerialNumber Then
                        e.Valid = False
                        e.ErrorText = "السيريال مكرر بنفس السند"
                        view.FocusedRowHandle = e.RowHandle
                        view.FocusedColumn = SerialNumberCol
                        view.ShowEditor()
                    End If
                Next
            Catch ex As Exception

            End Try
        End If




    End Sub
    Private Function SearchSerialNumberIfFound(_SerialNumber As String) As Integer
        Dim _Result As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select top 1 SerialNumber,ID  from [dbo].[ItemsSerials] 
                                            where SerialNumber ='" & _SerialNumber & "' 
                                            and [ItemNo] ='" & ItemNoInItemsSerialAdd & "'")
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Result = Sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Else
                _Result = 0
            End If
        Catch ex As Exception
            _Result = 0
        End Try
        Return _Result
    End Function
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey

        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        Dim sql As New SQLControl

        If e.KeyCode = Keys.Delete AndAlso DocNameInItemsSerialAdd = 1 AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If DocStatusInItemsSerialAdd = -1 Then
                    Try
                        Dim _TransID As String
                        _TransID = GridView1.GetFocusedRowCellValue("TransID")
                        If Not IsDBNull(GridView1.GetFocusedRowCellValue("TransID")) Then
                            sql.SqlTrueAccountingRunQuery(" Delete from [dbo].[ItemsSerialTransTemp] where TransID='" & _TransID & "'")
                        End If
                    Catch ex As Exception
                        MsgBox("لم يتم حذف الصنف")
                    End Try
                Else
                    Try
                        Dim _TransCount As Integer = 0
                        Dim _TransID As String
                        If Not IsDBNull(GridView1.GetFocusedRowCellValue("TransCount")) Then _TransCount = GridView1.GetFocusedRowCellValue("TransCount")
                        If _TransCount > 1 Then
                            XtraMessageBox.Show("لا يمكن حذف السطر، السيريال له حركات")
                            Exit Sub
                        End If
                        _TransID = GridView1.GetFocusedRowCellValue("TransID")
                        If Not IsDBNull(GridView1.GetFocusedRowCellValue("TransID")) Then
                            sql.SqlTrueAccountingRunQuery(" Update  [dbo].[ItemsSerialTransTemp] Set TempTransType='Delete' where TransID='" & _TransID & "'")
                        End If
                    Catch ex As Exception
                        MsgBox("لم يتم حذف الصنف")
                    End Try
                End If
                view.DeleteSelectedRows()
                GridView1.UpdateSummary()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
                'GridView1.AddNewRow()
            End If
        End If

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        Select Case CheckEdit1.CheckState
            Case 1, 17
                If DocNameInItemsSerialAdd = 1 Then
                    ColSerialNumber.VisibleIndex = 0
                    ColPurchaseWarrantySrart.VisibleIndex = 1
                    ColPurchaseWarrantyEnd.VisibleIndex = 2
                ElseIf DocNameInItemsSerialAdd = 2 Then
                    ColSerialNumber.VisibleIndex = 1
                    ColSaleWarrantyStart.VisibleIndex = 2
                    ColSaleWarrantyEnd.VisibleIndex = 3
                End If
            Case False
                If DocNameInItemsSerialAdd = 1 Then
                    ColPurchaseWarrantySrart.VisibleIndex = -1
                    ColPurchaseWarrantyEnd.VisibleIndex = -1
                    ColSerialNumber.VisibleIndex = 0
                ElseIf DocNameInItemsSerialAdd = 2 Then
                    ColSerialNumber.VisibleIndex = 0
                    ColSaleWarrantyStart.VisibleIndex = -1
                    ColSaleWarrantyEnd.VisibleIndex = -1
                End If
        End Select

    End Sub
    'Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
    '    If e.FocusedColumn.FieldName = "PurchaseWarrantyEnd" And String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("SerialNumber")) Then
    '        'GridView1.FocusedColumn = e.FocusedColumn
    '        SimpleButton1.Select()
    '        SimpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True
    '        If XtraMessageBox.Show("هل تريد اعتماد سيريال عدد؟" & ColSerialNumber.SummaryItem.SummaryValue, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
    '            InsertUpdateSerials()
    '            Me.Close()
    '        End If
    '    End If
    'End Sub
    Private Sub DisabledCellEvents1_ProcessingCell(ByVal sender As Object, ByVal e As DevExpress.Utils.Behaviors.Common.ProcessCellEventArgs)
        If DisabledRowHandles > 1 Then
            e.Disabled = True
        End If
    End Sub
End Class