Public Class SequenceTable
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SubGetTable()
    End Sub
    Private Sub SubGetTable()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = " SELECT name AS SequenceName, current_value AS CurrentValue FROM sys.sequences; "
            sql.SqlTrueAccountingRunQuery(sqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " DECLARE @SQL NVARCHAR(MAX) = '';
DECLARE @DocName NVARCHAR(100);
DECLARE @DocID INT;
DECLARE doc_cursor CURSOR FOR 
SELECT id, 
       CASE id 
            WHEN 1 THEN 'PurchaseInvoiceSeq'
            WHEN 2 THEN 'SalesInvoiceSeq'
            WHEN 3 THEN 'PaymentVoucherSeq'
            WHEN 4 THEN 'ReceiptVoucherSeq'
            WHEN 5 THEN 'JournalVoucherSeq'
            WHEN 6 THEN 'DebitNoteSeq'
            WHEN 7 THEN 'CreditNoteSeq'
            WHEN 8 THEN 'PurchaseDispatchSeq'
            WHEN 9 THEN 'SalesDispatchSeq'
            WHEN 10 THEN 'PurchaseOrderSeq'
            WHEN 11 THEN 'SalesOrderSeq'
            WHEN 12 THEN 'SalesReturnsSeq'
            WHEN 13 THEN 'PurchaseReturnsSeq'
            WHEN 16 THEN 'InternalDispatchSeq'
            WHEN 17 THEN 'StockEntryVoucherSeq'
            WHEN 18 THEN 'StockExitVoucherSeq'
            WHEN 19 THEN 'ProductionVoucherSeq'
       END AS SequenceName
FROM (VALUES 
    (1), (2), (3), (4), (5), (6), (7), (8), (9), 
    (10), (11), (12), (13), (16), (17), (18), (19)
) AS Docs(id)
WHERE id IS NOT NULL; -- Ensure ID is not NULL

OPEN doc_cursor;
FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @MaxDocID INT;
    
    -- Get the highest existing DocID for this document type
    SELECT @MaxDocID = COALESCE(MAX(DocID), 0) FROM Journal WHERE DocName = @DocID; 

    -- Check if sequence exists before updating
    IF EXISTS (SELECT 1 FROM sys.sequences WHERE name = @DocName)
    BEGIN
        SET @SQL = 'ALTER SEQUENCE dbo.' + QUOTENAME(@DocName) + ' 
                    RESTART WITH ' + CAST(@MaxDocID +1  AS NVARCHAR(20)) + ';';

        EXEC sp_executesql @SQL;

        PRINT 'Sequence ' + @DocName + ' updated successfully to START from: ' + CAST(@MaxDocID AS NVARCHAR(20));
    END
    ELSE
    BEGIN
        PRINT 'Sequence ' + @DocName + ' does not exist. Skipping update.';
    END

    FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;
END;

CLOSE doc_cursor;
DEALLOCATE doc_cursor; "
        If sql.SqlTrueAccountingRunQuery(sqlString) = True Then
            SubGetTable()
        Else
            MsgBox("Error")
        End If
        SubGetTable()
    End Sub

End Class