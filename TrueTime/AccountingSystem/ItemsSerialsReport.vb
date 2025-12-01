Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class ItemsSerialsReport
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetSerials(-1)
    End Sub
    Public Sub GetSerials(VoucherCode)
        Dim Sql As New SQLControl
        Dim SqlString As String
        'SqlString = "SELECT S.[ID], [SerialNumber],
        '                [SerialStatus], [PurchaseWarrantyStart],
        '                [PurchaseWarrantyEnd], [SaleWarrantyStart],
        '                [SaleWarrantyEnd], S.[ItemNo],
        '                [DocCode], I.ItemName,H.WarehouseNameAR as CurrentWahreHouse,
        '                R.RefName as vendor,RR.RefName as customer
        '             FROM [dbo].[ItemsSerials] S
        '                left join Items I on I.ItemNo=S.ItemNo
        '                left join Warehouses H on H.WarehouseID=S.CurrentWahreHouse
        '                left join Referencess R on R.RefNo=S.vendor
        '                left join Referencess RR on RR.RefNo=S.customer"
        'If VoucherCode <> "-1" Then SqlString += " Where DocCode='" & VoucherCode & "'"
        'SqlString += " Order by S.ItemNo,S.SerialNumber "



        SqlString = "SELECT S.[ID], S.[SerialNumber],
                        [SerialStatus], [PurchaseWarrantyStart],
                        [PurchaseWarrantyEnd], [SaleWarrantyStart],
                        [SaleWarrantyEnd], S.[ItemNo],
                        T.[DocCode], I.ItemName,H.WarehouseNameAR as CurrentWahreHouse,
                        R.RefName as vendor,RR.RefName as customer
                     FROM [dbo].[ItemsSerials] S
                        left join Items I on I.ItemNo=S.ItemNo
                        left join Warehouses H on H.WarehouseID=S.CurrentWahreHouse
                        left join Referencess R on R.RefNo=S.vendor
                        left join Referencess RR on RR.RefNo=S.customer
						left join ItemsSerialTrans T on T.SerialNumber=S.SerialNumber  and S.ItemNo=T.ItemNo  "
        SqlString += " where T.DocName in (1,8,17) "
        If VoucherCode <> "-1" Then SqlString += " and T.DocCode='" & VoucherCode & "'"
        SqlString += " Order by S.ItemNo,S.SerialNumber "



        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub
    Public Sub GetSerialForDocument(VoucherCode)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " 						  SELECT S.[ID], S.[SerialNumber],
                        [SerialStatus], [PurchaseWarrantyStart],
                        [PurchaseWarrantyEnd], [SaleWarrantyStart],
                        [SaleWarrantyEnd], S.[ItemNo],
                        T.[DocCode], I.ItemName,
                        R.RefName as vendor,RR.RefName as customer
                     FROM [dbo].ItemsSerialTrans T
                        left join Items I on I.ItemNo=T.ItemNo 
						left join ItemsSerials S on T.SerialNumber=S.SerialNumber   and S.ItemNo=T.ItemNo  
		                left join Referencess R on R.RefNo=S.vendor
                        left join Referencess RR on RR.RefNo=S.customer
						where  T.DocCode='" & VoucherCode & "' Order by S.ItemNo,S.SerialNumber  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub
    Public Sub GetSerialsTrans(VoucherCode)
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "SELECT S.[ID], [SerialNumber],
                        [SerialStatus], [PurchaseWarrantyStart],
                        [PurchaseWarrantyEnd], [SaleWarrantyStart],
                        [SaleWarrantyEnd], S.[ItemNo],
                        [DocCode], I.ItemName
                     FROM [dbo].[ItemsSerials] S
                        left join Items I on I.ItemNo=S.ItemNo"
        If VoucherCode <> "-1" Then SqlString += " Where DocCode='" & VoucherCode & "'"
        SqlString += " Order by S.ItemNo,S.SerialNumber "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub

    Private Sub ItemsSerialsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RepositorySerialStatus.DataSource = GetSerialStatusTable()
        'ColPurchaseWarrantyStart.Visible = False
        'ColPurchaseWarrantyEnd.Visible = False
        'ColSaleWarrantyStart.Visible = False
        'ColSaleWarrantyEnd.Visible = False
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowDates.CheckedChanged
        If CheckShowDates.Checked = True Then
            ColPurchaseWarrantyStart.Visible = True
            ColPurchaseWarrantyEnd.Visible = True
            ColSaleWarrantyStart.Visible = True
            ColSaleWarrantyEnd.Visible = True
        Else
            ColPurchaseWarrantyStart.Visible = False
            ColPurchaseWarrantyEnd.Visible = False
            ColSaleWarrantyStart.Visible = False
            ColSaleWarrantyEnd.Visible = False
        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell


        '        Const LargeHTMLPattern As String = "
        '<size=+10>Invoice: <href={0}>R{0}</href> <image={1}></size>
        '<size=+5><i><color=@DisabledText>{3}</color></i></size>

        '<size=+6>{5} - {2}</size>
        '<size=+4><href={4}>{4}</href></size>
        '<size=+3><i><color=@DisabledText>{6}
        '{7}</color></i></size>
        ' "
        '        Const _HtmlAvailable As String = "<backcolor=@Success><b><color=255, 255, 255>  متوفر  </b>"
        '        Const _HtmlSold As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  مباع  </b>"

        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "SerialStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("SerialStatus"))
            If category = "متوفر" Then
                'e.DrawHtmlText(e.DisplayText)
                'e.Graphics.DrawImage(AddImage, e.Bounds.Location)
                'e.DisplayText = String.Empty
                e.DisplayText = String.Format(SerialStatus.Available)
                e.Appearance.Options.CancelUpdate()
                'e.Appearance.HAlignment = DevExpress.Utils.HorzAlignment.Near
            ElseIf category = "مباع" Then
                e.DisplayText = String.Format(SerialStatus.Sold)
                e.Appearance.Options.CancelUpdate()
            End If
            'If category <> "" Then
            '    'e.Graphics.DrawImage(ApplyImage, e.Bounds.Location)
            '    e.DisplayText = String.Format(_HtmlPattern)
            'End If
        End If
    End Sub
    Private Sub gridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Const LargeHTMLPattern As String = "
<size=+10>Invoice: <href={0}>R{0}</href> <image={1}></size>
<size=+5><i><color=@DisabledText>{3}</color></i></size>

<size=+6>{5} - {2}</size>
<size=+4><href={4}>{4}</href></size>
<size=+3><i><color=@DisabledText>{6}
{7}</color></i></size>
 "
        'If e.Column Is colHtmlText AndAlso e.IsGetData Then
        'Dim invoice As Invoice = TryCast(e.Row, Invoice)
        'If invoice Is Nothing Then Return
        e.Value = String.Format(LargeHTMLPattern, "mazen", "zahran")
        'End If
    End Sub

    Private Sub كشفحركةالسيريالToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحركةالسيريالToolStripMenuItem.Click
        Dim _Serial As String
        _Serial = GridView1.GetFocusedRowCellValue("SerialNumber")
        Dim F As New ItemSerialTrans
        With F
            .GetSerialTrans(_Serial)
            .ShowDialog()
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub
    'Public Enum InvoiceInfoStatus
    '    <Display(Name:="<backcolor=@DisabledText><b><color=255, 255, 255>  Unpaid  </b>")>
    '    Unpaid
    '    <Display(Name:="<backcolor=@Success><b><color=255, 255, 255>  Paid In Full  </b>")>
    '    PaidInFull
    '    <Display(Name:="<backcolor=@Danger><b><color=255, 255, 255>  Refund In Full  </b>")>
    '    RefundInFull
    'End Enum

End Class