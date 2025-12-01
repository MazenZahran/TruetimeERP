' ====================================================================================================
' Document Loader Interface
' Defines contract for loading and displaying documents
' ====================================================================================================
Public Interface IDocumentLoader
    ''' <summary>
    ''' Loads document data and displays it in the appropriate form
    ''' </summary>
    ''' <param name="docCode">Unique document code</param>
    ''' <param name="dataName">Source table name (Journal, OrdersJournal, etc.)</param>
    ''' <param name="modifiedDateTime">Optional timestamp for historical versions</param>
    ''' <returns>True if successful, False otherwise</returns>
    Function LoadDocument(docCode As String, dataName As String, modifiedDateTime As String) As Boolean

    ''' <summary>
    ''' Gets the document type this loader handles
    ''' </summary>
    Function GetDocumentType() As Integer

    ''' <summary>
    ''' Cleans up resources when document is closed
    ''' </summary>
    Sub Cleanup()
End Interface