Imports System.Data.SqlClient
Imports System.Data

Public Class SequenceManager
    Private Shared sequenceTable As DataTable
    Dim connectionString As String = My.Settings.TrueTimeConnectionString

    ' Initialize the DataTable when the class is first used
    Public Sub New()
        If sequenceTable Is Nothing Then
            sequenceTable = LoadSequenceTable()
        End If
    End Sub

    ' Load the mapping into a DataTable
    Private Function LoadSequenceTable() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("SequenceName", GetType(String))

        ' Add document sequences (No need for a SQL table)
        dt.Rows.Add(1, "PurchaseInvoiceSeq")
        dt.Rows.Add(2, "SalesInvoiceSeq")
        dt.Rows.Add(3, "PaymentVoucherSeq")
        dt.Rows.Add(4, "ReceiptVoucherSeq")
        dt.Rows.Add(5, "JournalVoucherSeq")
        dt.Rows.Add(6, "DebitNoteSeq")
        dt.Rows.Add(7, "CreditNoteSeq")
        dt.Rows.Add(8, "PurchaseDispatchSeq")
        dt.Rows.Add(9, "SalesDispatchSeq")
        dt.Rows.Add(10, "PurchaseOrderSeq")
        dt.Rows.Add(11, "SalesOrderSeq")
        dt.Rows.Add(12, "SalesReturnsSeq")
        dt.Rows.Add(13, "PurchaseReturnsSeq")
        dt.Rows.Add(16, "InternalDispatchSeq")
        dt.Rows.Add(17, "StockEntryVoucherSeq")
        dt.Rows.Add(18, "StockExitVoucherSeq")
        dt.Rows.Add(19, "ProductionVoucherSeq")
        dt.Rows.Add(20, "PosReceiptVoucherSeq")

        Return dt
    End Function

    ' Get Next Sequence using DataTable instead of querying SQL
    Public Function GetNextSequence(docName As Integer) As Integer
        Dim nextValue As Integer = 0
        Try
            ' Find sequence name in DataTable
            Dim sequenceName As String = (From row In sequenceTable.AsEnumerable()
                                          Where row.Field(Of Integer)("ID") = docName
                                          Select row.Field(Of String)("SequenceName")).FirstOrDefault()

            If String.IsNullOrEmpty(sequenceName) Then
                Throw New Exception("Sequence not found for the given DocID.")
            End If

            ' Get next sequence value from SQL
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT NEXT VALUE FOR " & sequenceName & " AS NextNumber;"

                Using cmd As New SqlCommand(query, conn)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        nextValue = Convert.ToInt32(result)
                    End If
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return nextValue
    End Function

    Public Function GetCurrentSequenceValue(docName As Integer) As Integer
        Dim sequenceName As String = (From row In sequenceTable.AsEnumerable()
                                      Where row.Field(Of Integer)("ID") = docName
                                      Select row.Field(Of String)("SequenceName")).FirstOrDefault()
        If String.IsNullOrEmpty(sequenceName) Then
            Throw New ArgumentException("Invalid DocName or sequence not found.")
        End If

        Dim query As String = "SELECT current_value FROM sys.sequences WHERE name = @SequenceName"
        Dim currentValue As Integer = 0

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SequenceName", sequenceName)
                conn.Open()
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    currentValue = Convert.ToInt32(result)
                End If
            End Using
        End Using


        Return currentValue + 1


    End Function
    Public Sub ResetAllSequences()
        Dim dtSequences As DataTable = LoadSequenceTable()

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            For Each row As DataRow In dtSequences.Rows
                Dim docTypeID As Integer = Convert.ToInt32(row("ID"))
                Dim sequenceName As String = row("SequenceName").ToString()
                Dim maxDocID As Integer = 0

                ' Get the max DocID from the Journal table for this document type
                Using getMaxCmd As New SqlCommand("SELECT ISNULL(MAX(DocID), 0) FROM Journal WHERE DocName = @DocTypeID", conn)
                    getMaxCmd.Parameters.AddWithValue("@DocTypeID", docTypeID)
                    Dim result = getMaxCmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        maxDocID = Convert.ToInt32(result)
                    End If
                End Using

                ' Check if sequence exists
                Dim sequenceExists As Boolean = False
                Using checkCmd As New SqlCommand("SELECT COUNT(*) FROM sys.sequences WHERE name = @SeqName", conn)
                    checkCmd.Parameters.AddWithValue("@SeqName", sequenceName)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    sequenceExists = (count > 0)
                End Using

                ' If sequence exists, reset it
                If sequenceExists Then
                    Dim resetSql As String = $"ALTER SEQUENCE dbo.[{sequenceName}] RESTART WITH {maxDocID + 1};"
                    Using resetCmd As New SqlCommand(resetSql, conn)
                        resetCmd.ExecuteNonQuery()
                    End Using
                    Console.WriteLine($"Sequence '{sequenceName}' reset to start from {maxDocID + 1}")
                Else
                    Console.WriteLine($"Sequence not found: {sequenceName}")
                End If
            Next

            conn.Close()
        End Using
    End Sub
    Public Sub ResetSingleSequence(docTypeID As Integer)
        Dim dtSequences As DataTable = LoadSequenceTable()

        ' Find the matching sequence name
        Dim sequenceRow = dtSequences.Select("ID = " & docTypeID).FirstOrDefault()

        If sequenceRow Is Nothing Then
            Console.WriteLine("Document type ID not found in sequence table.")
            Return
        End If

        Dim sequenceName As String = sequenceRow("SequenceName").ToString()

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Get max DocID from Journal table
            Dim maxDocID As Integer = 0
            Using getMaxCmd As New SqlCommand("SELECT ISNULL(MAX(DocID), 0) FROM Journal WHERE DocName = @DocTypeID", conn)
                getMaxCmd.Parameters.AddWithValue("@DocTypeID", docTypeID)
                Dim result = getMaxCmd.ExecuteScalar()
                If result IsNot Nothing Then
                    maxDocID = Convert.ToInt32(result)
                End If
            End Using

            ' Check if sequence exists
            Dim sequenceExists As Boolean = False
            Using checkCmd As New SqlCommand("SELECT COUNT(*) FROM sys.sequences WHERE name = @SeqName", conn)
                checkCmd.Parameters.AddWithValue("@SeqName", sequenceName)
                sequenceExists = (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
            End Using

            If sequenceExists Then
                Dim resetSql As String = $"ALTER SEQUENCE dbo.[{sequenceName}] RESTART WITH {maxDocID + 1};"
                Using resetCmd As New SqlCommand(resetSql, conn)
                    resetCmd.ExecuteNonQuery()
                End Using
                Console.WriteLine($"Sequence '{sequenceName}' reset to start from {maxDocID + 1}")
            Else
                Console.WriteLine($"Sequence not found: {sequenceName}")
            End If

            conn.Close()
        End Using
    End Sub
End Class
