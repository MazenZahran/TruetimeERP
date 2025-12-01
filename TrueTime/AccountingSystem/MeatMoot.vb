Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class MeatMoot
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ReadExcelFile()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub ReadExcelFile()
        Me.TextTotalImportedVouchers.Text = 0
        Me.TextTotalVouchers.Text = 0

        Try
            Dim strConnection As String = "ConnectionString"
            Dim connectionString As String = ""
            XtraOpenFileDialog1.Filter = "Excel Files|*.xls"
            Dim res As DialogResult = XtraOpenFileDialog1.ShowDialog()
            Dim fileName As String = Path.GetFileName(XtraOpenFileDialog1.FileName)
            Dim fileExtension As String = Path.GetExtension(XtraOpenFileDialog1.FileName)
            If String.IsNullOrEmpty(fileExtension) Then
                Return
            End If
            Dim fileLocation As String = XtraOpenFileDialog1.FileName
            TextFilePath.Text = XtraOpenFileDialog1.FileName
            If fileExtension = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
            ElseIf fileExtension = ".xlsx" Or fileExtension = ".xlsm" Then
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0 Xml;HDR=Yes;IMEX=2"""
            End If
            Dim con As OleDbConnection = New OleDbConnection(connectionString)
            Dim cmd As OleDbCommand = New OleDbCommand()
            cmd.CommandType = System.Data.CommandType.Text
            cmd.Connection = con
            Dim dAdapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim dtExcelRecords As DataTable = New DataTable()
            con.Open()

            Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
            cmd.CommandText = " SELECT  [Time] as DocDateTime,[Invoice No] as DocNo,[Item No] as StockBarcode ,
                                        [Item Name] as ItemName,[Quantity],[Total2] as DocAmount,Total/Quantity As Price, 0 As IsExist,'' as ImportResult
                                FROM [Sheet1$] where [Item No] <> '' and Total > 0 "
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dtExcelRecords)
            ' GridControl1.DataSource = dtExcelRecords

            '  CheckData()
            con.Close()

            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  Delete from [dbo].[MeatMootImportInvoices];
                                             DBCC CHECKIDENT('MeatMootImportInvoices', RESEED, 0)")
            Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
                For Each col As DataColumn In dtExcelRecords.Columns
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
                Next
                bulkCopy.BulkCopyTimeout = 600
                bulkCopy.DestinationTableName = "MeatMootImportInvoices"
                bulkCopy.WriteToServer(dtExcelRecords)
            End Using

            sql.SqlTrueAccountingRunQuery("SELECT  i.[ID]
      ,i.[DocDateTime]
      ,i.[DocNo]
      ,i.[StockBarcode]
      ,i.[ItemName]
      ,i.[Quantity]
      ,i.[Price]
      ,CAST(i.[DocAmount] AS DECIMAL(7,2) ) as DocAmount
      ,i.[DocCode] as DocCode
	  ,j.DocCode as DocCodeInJournal
	  ,isnull(j.DocID,0) as Journal
	  ,case when isnull(j.DocID,0)=0 then 'New' else 'Imported' end as Exist
,ImportResult
  FROM [dbo].[MeatMootImportInvoices] i
  left join Journal j on i.[DocCode]=j.DocCode and j.StockID is not null and j.StockID <> 0 order by i.[ID] ")
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select sum(DocAmount) as total from [dbo].[MeatMootImportInvoices] where IsExist=0 ")
            Me.TextTotalVouchers.Text = sql.SQLDS.Tables(0).Rows(0).Item("total")
        Catch ex As Exception

        End Try

        If GridView1.RowCount > 0 Then
            SimpleImportData.Enabled = True
        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleImportData.Click
        Dim _DocID2 As Decimal = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select Count(ID) from MeatMootImportInvoices ")
            If sql.SQLDS.Tables(0).Rows(0).Item("total") = 0 Then
                XtraMessageBox.Show(" لا يوجد بيانات لسحبها ")
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try



            Dim sqlCon As SqlConnection
            sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand
                sqlComm.Connection = sqlCon
                sqlComm.CommandText = "InsertPosVouchersFromMeatMootSystem"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000
                sqlComm.Parameters.AddWithValue("USERID", GlobalVariables.CurrUser)
                sqlComm.Parameters.AddWithValue("PosNo", 1)
                sqlCon.Open()
                Dim returarameter = sqlComm.Parameters.Add("@VouchersInJournalAmount", SqlDbType.Decimal)
                returarameter.Direction = ParameterDirection.ReturnValue
                sqlComm.ExecuteNonQuery()
                sqlCon.Close()
                _DocID2 = returarameter.Value

            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT  i.[ID]
      ,i.[DocDateTime]
      ,i.[DocNo]
      ,i.[StockBarcode]
      ,i.[ItemName]
      ,i.[Quantity]
      ,i.[Price]
      ,CAST(i.[DocAmount] AS DECIMAL(7,2) ) as DocAmount
      ,i.[DocCode] as DocCode
	  ,j.DocCode as DocCodeInJournal
	  ,isnull(j.DocID,0) as Journal
	  ,case when isnull(j.DocID,0)=0 then 'New' else 'Imported' end as Exist
,ImportResult
  FROM [dbo].[MeatMootImportInvoices] i
  left join Journal j on i.[DocCode]=j.DocCode and j.StockID is not null and j.StockID <> 0 order by i.[ID] ")
            GridControl1.DataSource = sql.SQLDS.Tables(0)


            sql.SqlTrueAccountingRunQuery("  Delete from [dbo].[MeatMootImportInvoices];
                                             DBCC CHECKIDENT('MeatMootImportInvoices', RESEED, 0)")

            SimpleImportData.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
            CloseProgressPanel(handle)
        Finally
            CloseProgressPanel(handle)
        End Try

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select sum(DocAmount)/2 as DocAmount from  journal where docname=2 and  DocID2=" & _DocID2)
            Me.TextTotalImportedVouchers.Text = sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")
        Catch ex As Exception
            Me.TextTotalImportedVouchers.Text = 0
        End Try

    End Sub

    Private Sub MeatMoot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleImportData.Enabled = False
    End Sub
End Class