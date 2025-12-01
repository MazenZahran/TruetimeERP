Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class ItemSerialsSelect
    Public ItemNoInItemsSerialOut As String
    Public DocCodeInItemsSerialOut As String
    Public DocNameInItemsSerialOut As String
    Public DocDateInItemsSerialOut As Date
    Public SerialDebitWhereHouseInItemsSerialOut As Integer
    Public SerialCreditWhereHouseInItemsSerialOut As Integer
    Public DocNoInItemsSerialOut As Integer
    Public DocStatusInItemsSerialOut As Integer
    Public SerialVendor As Integer
    Public SerialCustomer As Integer
    Private Sub ItemSerialsSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Warehouses' table. You can move, or remove it, as needed.
        Me.WarehousesTableAdapter.Fill(Me.AccountingDataSet.Warehouses)
        SerialStatus()
    End Sub
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
    Public Sub GetItemSerialsForOut()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Select 0 As TransType, S.[SerialNumber] as SerialNumber,
                               S.ItemNo,S.PurchaseWarrantyEnd,S.PurchaseWarrantyStart,
                               S.SaleWarrantyEnd,S.SaleWarrantyStart,S.SerialStatus,IsNull(TT.TransID,0) as TransID,S.CurrentWahreHouse
   FROM [dbo].[ItemsSerials] S
   left join [dbo].[ItemsSerialTransTemp] TT on S.SerialNumber=TT.SerialNumber and S.ItemNo=TT.ItemNo
   Where S.CurrentWahreHouse=" & SerialCreditWhereHouseInItemsSerialOut & " And S.ItemNo ='" & ItemNoInItemsSerialOut & "' And  (( TempTransType='Delete' ) or (TT.TransID Is Null And S.SerialStatus=1 ))   Order By SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlAllSerials.DataSource = Sql.SQLDS.Tables(0)

        SqlString = "   Select 0 As TransType,T.TransID as TransID, T.[SerialNumber] as SerialNumber,
                               T.[DocCode],T.ItemNo,T.PurchaseWarrantyEnd,T.PurchaseWarrantyStart,
                               T.SaleWarrantyEnd,T.SaleWarrantyStart,T.SerialStatus,T.IDInSerials as SerialID,
                               T.SerialDebitWhereHouse,T.SerialCreditWhereHouse,T.DocName,T.DocDate,T.AddedDate,
                               T.AddedUser,T.Notes,T.DocNo,IsNull(T.TransID,0) as TransID
   FROM [dbo].[ItemsSerialTransTemp] T
   Where T.ItemNo='" & ItemNoInItemsSerialOut & "' And T.DocCode='" & DocCodeInItemsSerialOut & "' And TempTransType<>'Delete'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlSelectedSerials.DataSource = Sql.SQLDS.Tables(0)
    End Sub
    Public Sub GetItemSerialsForPurchaseReturn()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Select 0 As TransType, S.[SerialNumber] as SerialNumber,
                               S.ItemNo,S.PurchaseWarrantyEnd,S.PurchaseWarrantyStart,
                               S.SaleWarrantyEnd,S.SaleWarrantyStart,S.SerialStatus,IsNull(TT.TransID,0) as TransID,S.CurrentWahreHouse
                        FROM [dbo].[ItemsSerials] S
                        left join [dbo].[ItemsSerialTransTemp] TT on S.SerialNumber=TT.SerialNumber and S.ItemNo=TT.ItemNo
                        Where S.CurrentWahreHouse=" & SerialCreditWhereHouseInItemsSerialOut & "  
                              And S.ItemNo ='" & ItemNoInItemsSerialOut & "' 
                              And  (( TempTransType='Delete' ) or (TT.TransID Is Null And S.SerialStatus=1 ))   
                              And S.Vendor='" & SerialVendor & "'
                              Order By SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlAllSerials.DataSource = Sql.SQLDS.Tables(0)

        SqlString = "   Select 0 As TransType,T.TransID as TransID, T.[SerialNumber] as SerialNumber,
                               T.[DocCode],T.ItemNo,T.PurchaseWarrantyEnd,T.PurchaseWarrantyStart,
                               T.SaleWarrantyEnd,T.SaleWarrantyStart,T.SerialStatus,T.IDInSerials as SerialID,
                               T.SerialDebitWhereHouse,T.SerialCreditWhereHouse,T.DocName,T.DocDate,T.AddedDate,
                               T.AddedUser,T.Notes,T.DocNo,IsNull(T.TransID,0) as TransID
   FROM [dbo].[ItemsSerialTransTemp] T
   Where T.ItemNo='" & ItemNoInItemsSerialOut & "' And T.DocCode='" & DocCodeInItemsSerialOut & "' And TempTransType<>'Delete'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlSelectedSerials.DataSource = Sql.SQLDS.Tables(0)
    End Sub
    Public Sub GetItemSerialsForSalesReturn(_Customer As Integer)
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Select 0 As TransType, S.[SerialNumber] as SerialNumber,
                               S.ItemNo,S.PurchaseWarrantyEnd,S.PurchaseWarrantyStart,
                               S.SaleWarrantyEnd,S.SaleWarrantyStart,S.SerialStatus,IsNull(TT.TransID,0) as TransID,S.CurrentWahreHouse
                        FROM [dbo].[ItemsSerials] S
                        left join [dbo].[ItemsSerialTransTemp] TT on S.SerialNumber=TT.SerialNumber and S.ItemNo=TT.ItemNo
                        Where S.CurrentWahreHouse=" & SerialDebitWhereHouseInItemsSerialOut & "  
                              And S.ItemNo ='" & ItemNoInItemsSerialOut & "' 
                              And  (( TempTransType='Delete' ) or (TT.TransID Is Null And S.SerialStatus=2 ))   
                               And Customer =" & _Customer & "
                              Order By SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlAllSerials.DataSource = Sql.SQLDS.Tables(0)

        SqlString = "   Select 0 As TransType,T.TransID as TransID, T.[SerialNumber] as SerialNumber,
                               T.[DocCode],T.ItemNo,T.PurchaseWarrantyEnd,T.PurchaseWarrantyStart,
                               T.SaleWarrantyEnd,T.SaleWarrantyStart,T.SerialStatus,T.IDInSerials as SerialID,
                               T.SerialDebitWhereHouse,T.SerialCreditWhereHouse,T.DocName,T.DocDate,T.AddedDate,
                               T.AddedUser,T.Notes,T.DocNo,IsNull(T.TransID,0) as TransID
   FROM [dbo].[ItemsSerialTransTemp] T
   Where T.ItemNo='" & ItemNoInItemsSerialOut & "' And T.DocCode='" & DocCodeInItemsSerialOut & "' And TempTransType<>'Delete'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlSelectedSerials.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Public Sub GetItemSerialsForWahreHouseMoves()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Select 0 As TransType, S.[SerialNumber] as SerialNumber,
                               S.ItemNo,S.PurchaseWarrantyEnd,S.PurchaseWarrantyStart,
                               S.SaleWarrantyEnd,S.SaleWarrantyStart,S.SerialStatus,IsNull(TT.TransID,0) as TransID,case when TT.TransID is null then S.[CurrentWahreHouse] else TT.SerialDebitWhereHouse end as CurrentWahreHouse 
   FROM [dbo].[ItemsSerials] S
   left join [dbo].[ItemsSerialTransTemp] TT on S.SerialNumber=TT.SerialNumber and S.ItemNo=TT.ItemNo
   Where   S.ItemNo='" & ItemNoInItemsSerialOut & "' And ((S.CurrentWahreHouse=" & SerialCreditWhereHouseInItemsSerialOut & ") or ( TempTransType='Delete' ) ) And (( TempTransType='Delete' ) or (TT.TransID Is Null And S.SerialStatus=1 ))   Order By SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlAllSerials.DataSource = Sql.SQLDS.Tables(0)

        SqlString = "   Select 0 As TransType,T.TransID as TransID, T.[SerialNumber] as SerialNumber,
                               T.[DocCode],T.ItemNo,T.PurchaseWarrantyEnd,T.PurchaseWarrantyStart,
                               T.SaleWarrantyEnd,T.SaleWarrantyStart,T.SerialStatus,T.IDInSerials as SerialID,
                               T.SerialDebitWhereHouse,T.SerialCreditWhereHouse,T.DocName,T.DocDate,T.AddedDate,
                               T.AddedUser,T.Notes,T.DocNo,IsNull(T.TransID,0) as TransID
   FROM [dbo].[ItemsSerialTransTemp] T
   Where T.ItemNo='" & ItemNoInItemsSerialOut & "' And T.DocCode='" & DocCodeInItemsSerialOut & "' And TempTransType<>'Delete'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlSelectedSerials.DataSource = Sql.SQLDS.Tables(0)



    End Sub



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            MsgBox(GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber"))
        Next
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Select Case DocNameInItemsSerialOut
            Case 2, 18, 12
                OutSerial()
            Case 16
                MoveSerial()
        End Select

    End Sub
    Private Sub OutSerial()
        Dim SqlString1 As String
        Dim Sql As New SQLControl
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            If GridView1.GetRowCellValue(selectedRowHandles(i), "TransID") = 0 Then

                Dim _PurchaseWarrantyStart, _PurchaseWarrantyEnd As String
                If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyStart")) Then
                    _PurchaseWarrantyStart = Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyStart"), "yyyy-MM-dd")
                Else
                    _PurchaseWarrantyStart = String.Empty
                End If
                If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyEnd")) Then
                    _PurchaseWarrantyEnd = Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyEnd"), "yyyy-MM-dd")
                Else
                    _PurchaseWarrantyEnd = String.Empty
                End If

                SqlString1 = "  Insert Into [dbo].[ItemsSerialTransTemp] 
                         ([SerialNumber],[SerialStatus]
                          ,[ItemNo],DocCode,UserNo,DocName,DocDate,PurchaseWarrantyStart,PurchaseWarrantyEnd,
                          SaleWarrantyStart,SaleWarrantyEnd,TempTransType,SerialCreditWhereHouse) Values (" &
                          "'" & GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber") & "'" &
                          ",'" & 2 & "'" &
                           ",'" & GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo") & "'" &
                           ",'" & DocCodeInItemsSerialOut & "'" &
                           ",'" & GlobalVariables.CurrUser & "'" &
                           ",'" & DocNameInItemsSerialOut & "'" &
                           ",'" & Format(DocDateInItemsSerialOut, "yyyy-MM-dd") & "'" &
                           ",'" & _PurchaseWarrantyStart & "'" &
                           ",'" & _PurchaseWarrantyEnd & "'" &
                           ",'" & Format(DocDateInItemsSerialOut, "yyyy-MM-dd") & "'" &
                           ",'" & Format(CDate(DocDateInItemsSerialOut).AddYears(1).AddDays(-1), "yyyy-MM-dd") & "'" &
                           ",'New'" &
                           ",'" & GridView1.GetRowCellValue(selectedRowHandles(i), "CurrentWahreHouse") & "'" &
                           ") "
                Sql.SqlTrueAccountingRunQuery(SqlString1)
            Else
                SqlString1 = "  Update [dbo].[ItemsSerialTransTemp] Set 
                                TempTransType='Update' ,
                                SaleWarrantyStart= Case When DocName =16 then Null else '" & Format(DocDateInItemsSerialOut, "yyyy-MM-dd") & "' end ,
                                SaleWarrantyEnd= Case When DocName =16 then Null else '" & Format(CDate(DocDateInItemsSerialOut).AddYears(1).AddDays(-1), "yyyy-MM-dd") & "' end
                                where TransID=" & GridView1.GetRowCellValue(selectedRowHandles(i), "TransID")
                Sql.SqlTrueAccountingRunQuery(SqlString1)
            End If
        Next
        GetItemSerialsForOut()
    End Sub
    Private Sub MoveSerial()
        Dim SqlString1 As String
        Dim Sql As New SQLControl
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            If GridView1.GetRowCellValue(selectedRowHandles(i), "TransID") = 0 Then

                Dim _PurchaseWarrantyStart, _PurchaseWarrantyEnd, _SaleWarrantyStart, _SaleWarrantyEnd As String
                If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyStart")) Then
                    _PurchaseWarrantyStart = Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyStart"), "yyyy-MM-dd")
                Else
                    _PurchaseWarrantyStart = String.Empty
                End If
                If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyEnd")) Then
                    _PurchaseWarrantyEnd = Format(GridView1.GetRowCellValue(selectedRowHandles(i), "PurchaseWarrantyEnd"), "yyyy-MM-dd")
                Else
                    _PurchaseWarrantyEnd = String.Empty
                End If

                If DocNameInItemsSerialOut <> 16 Then
                    _SaleWarrantyStart = Format(DocDateInItemsSerialOut, "yyyy-MM-dd")
                    _SaleWarrantyEnd = Format(CDate(DocDateInItemsSerialOut).AddYears(1).AddDays(-1), "yyyy-MM-dd")
                Else
                    _SaleWarrantyStart = String.Empty
                    _SaleWarrantyEnd = String.Empty
                End If

                SqlString1 = "  Insert Into [dbo].[ItemsSerialTransTemp] 
                         ([SerialNumber],[SerialStatus]
                          ,[ItemNo],DocCode,UserNo,DocName,DocDate,PurchaseWarrantyStart,PurchaseWarrantyEnd,
                          SaleWarrantyStart,SaleWarrantyEnd,TempTransType,[SerialDebitWhereHouse],[SerialCreditWhereHouse]) Values (" &
                          "'" & GridView1.GetRowCellValue(selectedRowHandles(i), "SerialNumber") & "'" &
                          ",'" & 1 & "'" &
                           ",'" & GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo") & "'" &
                           ",'" & DocCodeInItemsSerialOut & "'" &
                           ",'" & GlobalVariables.CurrUser & "'" &
                           ",'" & DocNameInItemsSerialOut & "'" &
                           ",'" & Format(DocDateInItemsSerialOut, "yyyy-MM-dd") & "'" &
                           ",'" & _PurchaseWarrantyStart & "'" &
                           ",'" & _PurchaseWarrantyEnd & "'" &
                           ",'" & _SaleWarrantyStart & "'" &
                           ",'" & _SaleWarrantyEnd & "'" &
                           ",'New'" &
                           ",'" & SerialDebitWhereHouseInItemsSerialOut & "'" &
                           ",'" & SerialCreditWhereHouseInItemsSerialOut & "'" &
                           ") "
                Sql.SqlTrueAccountingRunQuery(SqlString1)
            Else
                SqlString1 = "  Update [dbo].[ItemsSerialTransTemp] Set 
                                TempTransType='Update' ,
                                SaleWarrantyStart= Case When DocName =16 then Null else '" & Format(DocDateInItemsSerialOut, "yyyy-MM-dd") & "' end ,
                                SaleWarrantyEnd=Case When DocName =16 then Null else  '" & Format(CDate(DocDateInItemsSerialOut).AddYears(1).AddDays(-1), "yyyy-MM-dd") & "' end,
                                SerialDebitWhereHouse='" & SerialDebitWhereHouseInItemsSerialOut & "',
                                SerialCreditWhereHouse='" & SerialCreditWhereHouseInItemsSerialOut & "'
                                where TransID=" & GridView1.GetRowCellValue(selectedRowHandles(i), "TransID")
                Sql.SqlTrueAccountingRunQuery(SqlString1)
            End If
        Next
        GetItemSerialsForWahreHouseMoves()
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click




        Dim SqlString1 As String
        Dim Sql As New SQLControl
        Dim selectedRowHandles As Integer() = GridView2.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            If DocStatusInItemsSerialOut = -1 Then
                Try
                    SqlString1 = " Delete from ItemsSerialTransTemp where 
                                   TransID= " & GridView2.GetRowCellValue(selectedRowHandles(i), "TransID")
                    Sql.SqlTrueAccountingRunQuery(SqlString1)
                Catch ex As Exception

                End Try

            Else
                Try
                    Dim _TransID As String
                    _TransID = GridView2.GetRowCellValue(selectedRowHandles(i), "TransID")
                    If Not IsDBNull(GridView2.GetRowCellValue(selectedRowHandles(i), "TransID")) Then
                        Sql.SqlTrueAccountingRunQuery(" Update  [dbo].[ItemsSerialTransTemp] Set 
                                                                TempTransType='Delete' ,
                                                                SerialStatus=1,SaleWarrantyStart=Null,
                                                                SaleWarrantyEnd=Null,
                                                                SerialDebitWhereHouse='" & SerialCreditWhereHouseInItemsSerialOut & "',
                                                                SerialCreditWhereHouse='" & SerialDebitWhereHouseInItemsSerialOut & "'
                                                                where TransID='" & _TransID & "'")
                    End If
                Catch ex As Exception
                    MsgBox("لم يتم حذف الصنف")
                End Try
            End If
        Next

        Select Case DocNameInItemsSerialOut
            Case 2, 18
                GetItemSerialsForOut()
            Case 16
                GetItemSerialsForWahreHouseMoves()
        End Select

    End Sub

    Private Sub GridControlSelectedSerials_Click(sender As Object, e As EventArgs) Handles GridControlSelectedSerials.Click

    End Sub
    Private Sub GridView2_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView2.ValidateRow
        Dim sql As New SQLControl
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim _TransID As String = Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "TransID")
        Dim _SaleWarrantyStart As String = Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "SaleWarrantyStart")
        Dim _SaleWarrantyEnd As String = Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "SaleWarrantyEnd")
        Dim SaleWarrantyStartCol As GridColumn = view.Columns("SaleWarrantyStart")
        Try
            Dim SaleWarrantyStart As String = Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "SaleWarrantyStart")
            If String.IsNullOrEmpty(SaleWarrantyStart) Or String.IsNullOrWhiteSpace(SaleWarrantyStart) Then
                e.Valid = False
                e.ErrorText = "السيريال فارغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = SaleWarrantyStartCol
                view.ShowEditor()
            End If
        Catch ex As Exception

        End Try

        Try
            Dim SaleWarrantyStart As String = Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "SaleWarrantyEnd")
            If String.IsNullOrEmpty(SaleWarrantyStart) Or String.IsNullOrWhiteSpace(SaleWarrantyStart) Then
                e.Valid = False
                e.ErrorText = "السيريال فارغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = SaleWarrantyStartCol
                view.ShowEditor()
            End If
        Catch ex As Exception

        End Try


        Try
            If e.Valid = True Then
                sql.SqlTrueAccountingRunQuery("Update [ItemsSerialTransTemp] set 
                                                      SaleWarrantyStart='" & Format(CDate(_SaleWarrantyStart), "yyyy-MM-dd") & "' ,
                                                      SaleWarrantyEnd='" & Format(CDate(_SaleWarrantyEnd), "yyyy-MM-dd") & "' 
                                               Where TransID=" & _TransID & "")
            End If
        Catch ex As Exception

        End Try


    End Sub
End Class