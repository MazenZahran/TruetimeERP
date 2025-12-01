Public Class POSSelectSerial
    Private Sub POSSelectSerial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                               S.SaleWarrantyEnd,S.SaleWarrantyStart,S.SerialStatus,IsNull(TT.TransID,0) as TransID
                        FROM [dbo].[ItemsSerials] S
                        Where S.ItemNo='" & TextItemNoInItemsSerialOut.EditValue & "' And   S.SerialStatus=1    
                        Order By SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlAllSerials.DataSource = Sql.SQLDS.Tables(0)
    End Sub
End Class