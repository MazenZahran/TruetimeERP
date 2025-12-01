Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Public Class AccountStatementReport80mm
    Inherits XtraReport

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub SetDataSource(dataSet As DataSet, ReferanceName As String, EndingBalance As Decimal, Period As String)
        Try
            If dataSet IsNot Nothing Then
                ' Debug: Check if we have data
                System.Diagnostics.Debug.WriteLine($"Tables count: {dataSet.Tables.Count}")
                If dataSet.Tables.Count > 0 Then
                    System.Diagnostics.Debug.WriteLine($"Journal rows: {dataSet.Tables("Journal").Rows.Count}")
                End If
                If dataSet.Tables.Count > 1 Then
                    System.Diagnostics.Debug.WriteLine($"JournalDetails rows: {dataSet.Tables("JournalDetails").Rows.Count}")
                End If

                ' Set the main data source to the entire DataSet
                Me.DataSource = dataSet
                Me.DataMember = "Journal"

                ' Find and configure the DetailReport band for JournalDetails
                For Each band As Band In Me.Bands
                    If TypeOf band Is DetailReportBand Then
                        Dim detailReport As DetailReportBand = CType(band, DetailReportBand)
                        detailReport.DataSource = dataSet
                        ' Use the relation name we created in the main form
                        detailReport.DataMember = "Journal.CategoriesProducts"
                        System.Diagnostics.Debug.WriteLine("DetailReport configured")
                        Exit For
                    End If
                Next
                Me.XrLabelReferancesName.Text = ReferanceName
                Me.XrLabelEndingBalance.Text = " المبلغ المطلوب " & EndingBalance.ToString("N1") & " NIS "
                Me.XrLabelPeriod.Text = " عن الفترة " & Period
                ' Force the report to refresh its data
                Me.CreateDocument()

            Else
                System.Diagnostics.Debug.WriteLine("DataSet is null")
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error setting data source: {ex.Message}")
            Throw ex
        End Try
    End Sub

    ' Alternative method to set data source with separate tables
    Public Sub SetDataSourceFromTables(journalTable As DataTable, journalDetailsTable As DataTable)
        Try
            ' Create a new DataSet
            Dim dataSet As New DataSet()

            ' Add tables to the DataSet
            dataSet.Tables.Add(journalTable.Copy())
            dataSet.Tables.Add(journalDetailsTable.Copy())

            ' Rename tables to match expected names
            dataSet.Tables(0).TableName = "Journal"
            dataSet.Tables(1).TableName = "JournalDetails"

            ' Create relationship if both tables have DocCode column
            If dataSet.Tables("Journal").Columns.Contains("DocCode") AndAlso
               dataSet.Tables("JournalDetails").Columns.Contains("DocCode") Then

                Dim relation As New DataRelation("CategoriesProducts",
                    dataSet.Tables("Journal").Columns("DocCode"),
                    dataSet.Tables("JournalDetails").Columns("DocCode"))
                dataSet.Relations.Add(relation)
            End If

            ' Set the data source
            SetDataSource(dataSet, "", 0, "")

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error in SetDataSourceFromTables: {ex.Message}")
            Throw ex
        End Try
    End Sub

    Private Sub AccountStatementReport80mm_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        Try
            Dim _CompanyData = GetCompanyData()
            lblCompanyName.Text = _CompanyData.CompanyName
            lblAddress.Text = _CompanyData.CompanyAddress
            lblPhone.Text = "Tel: " & _CompanyData.CompanyMobile
            XrLabelDateTimePrinted.Text = "Printed@ " & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Try
                Dim cn As SqlConnection
                cn = New SqlConnection
                cn.ConnectionString = My.Settings.TrueTimeConnectionString
                Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class