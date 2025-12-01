Public Class ItemSerialTrans
    Private Sub ItemSerialTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub GetSerialTrans(SerialNumber As String)
        Dim Sqlstring As String
        Dim sql As New SQLControl
        Sqlstring = " SELECT [TransID]
      ,[SerialNumber]
      ,[DocCode]
      ,[ItemNo]
      ,[SerialID]
      ,[SerialDebitWhereHouse]
      ,[SerialCreditWhereHouse]
      ,D.[Name] as DocName
      ,[DocDate]
      ,[AddedDate]
      ,[AddedUser]
      ,[Notes]
      ,[DocNo]
  FROM [dbo].[ItemsSerialTrans] S
  left join DocNames D on S.DocName=D.id where SerialNumber='" & SerialNumber & "'"
        sql.SqlTrueAccountingRunQuery(Sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim _DocCode As String
        _DocCode = GridView1.GetFocusedRowCellValue("DocCode")
        OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name)
    End Sub
End Class