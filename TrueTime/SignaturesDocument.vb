Imports System.Data.SqlClient

Public Class SignaturesDocument
    Dim Con As SqlConnection
    Dim Adapter As SqlDataAdapter
    Dim Sql As New SQLControl
    Dim SqlString As String
    Private Sub SignaturesDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDocNames()
        GetData() 'hjfhh
    End Sub
    Private Sub GetDocNames()
        SqlString = " select [DocNameEN],[DocNameAR] from [DocumentsSignatures] "
        Sql.SqlTrueTimeRunQuery(SqlString)
        Me.SrchDocName.Properties.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SrchDocName.EditValueChanged
        GetData()
    End Sub
    Private Sub GetData()
        If SrchDocName.Text <> String.Empty Then
            Dim _DocSignatures = GetDocumentSignatures(SrchDocName.EditValue)
            Me.txtSignature1.Text = _DocSignatures.signature1
            Me.txtSignature2.Text = _DocSignatures.signature2
            Me.txtSignature3.Text = _DocSignatures.signature3
            Me.txtSignature4.Text = _DocSignatures.signature4
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SqlString = "  Update [DocumentsSignatures] set "
        SqlString += " [Signature1]=N'" & txtSignature1.Text & "',"
        SqlString += " [Signature2]=N'" & txtSignature2.Text & "',"
        SqlString += " [Signature3]=N'" & txtSignature3.Text & "',"
        SqlString += " [Signature4]=N'" & txtSignature4.Text & "'"
        If Sql.SqlTrueTimeRunQuery(SqlString) = True Then
            MsgBoxShowSuccess(" تم حفظ البيانات ")
        Else
            MsgBoxShowError(" خطا قي حفظ البيانات ")
        End If
    End Sub
End Class