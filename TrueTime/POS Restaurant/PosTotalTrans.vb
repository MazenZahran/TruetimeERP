Public Class PosTotalTrans
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm:ss")
        Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm:ss")
        Dim _PosNoFrom As Integer = PosNoFrom.EditValue
        Dim _PosNoTo As Integer = PosNoTo.EditValue
        Dim _ShiftIdFrom As Integer = ShiftIdFrom.EditValue
        Dim _ShiftIdTo As Integer = ShiftIdTo.EditValue
        sqlstring = "   
                      Declare @FromDate datetime;
                      Declare @ToDdate  datetime;
                      Declare @PosNoFrom int;
                      Declare @PosNoTo int;
                      Declare @ShiftIdFrom int;
                      Declare @ShiftIdTo int;
                      Set @FromDate = '" & _DateFrom & "';
                      Set @ToDdate = '" & _DateTo & "';
                      Set @PosNoFrom = '" & _PosNoFrom & "';
                      Set @PosNoTo = '" & _PosNoTo & "';                      
                      Set @ShiftIdFrom = '" & _ShiftIdFrom & "';
                      Set @ShiftIdTo = '" & _ShiftIdTo & "';

                      Select IsNull(sum(VoucherAmount),0) As VoucherAmount,
		                     IsNull(Sum(VoucherDiscount),0)+IsNull(Sum(VoucherDiscount2),0) As Discount,
                             IsNull(Sum(VoucherAmountAfterDiscount),0) As VoucherAmountAfterDiscount
                      From PosVouchers 
                      Where VoucherPayType='Cash' 
                      And VoucherDateTime between @FromDate And @ToDdate 
                      And PosNo between @PosNoFrom and @PosNoTo And ShiftID between @ShiftIdFrom And @ShiftIdTo;

                      Select IsNull(sum(VoucherAmount),0) As VoucherAmount,
		                     IsNull(Sum(VoucherDiscount),0)+IsNull(Sum(VoucherDiscount2),0) As Discount,
                             IsNull(Sum(VoucherAmountAfterDiscount),0) As VoucherAmountAfterDiscount
                      From PosVouchers 
                      Where VoucherPayType='Card' 
                      And VoucherDateTime between @FromDate And @ToDdate 
                      And PosNo between @PosNoFrom and @PosNoTo And ShiftID between @ShiftIdFrom And @ShiftIdTo;

                      Select IsNull(sum(VoucherAmount),0) As VoucherAmount,
		                     IsNull(Sum(VoucherDiscount),0)+IsNull(Sum(VoucherDiscount2),0) As Discount,
                             IsNull(Sum(VoucherAmountAfterDiscount),0) As VoucherAmountAfterDiscount
                      From PosVouchers 
                      Where VoucherPayType='CSTMR' 
                      And VoucherDateTime between @FromDate And @ToDdate 
                      And PosNo between @PosNoFrom and @PosNoTo And ShiftID between @ShiftIdFrom And @ShiftIdTo;

                      Select IsNull(sum(VoucherAmount),0) As VoucherAmount,
		                     IsNull(Sum(VoucherDiscount),0)+IsNull(Sum(VoucherDiscount2),0) As Discount,
                             IsNull(Sum(VoucherAmountAfterDiscount),0) As VoucherAmountAfterDiscount
                      From PosVouchers 
                      Where 
                      VoucherDateTime between @FromDate And @ToDdate And
                      PosNo between @PosNoFrom and @PosNoTo And ShiftID between @ShiftIdFrom And @ShiftIdTo;


                      Select  IsNull(Count(ID), 0) As DeletedCount ,IsNull(Sum(DocAmount),0) As DeletedAmount 
                      From POSDeletedJournal 
                      Where DeleteDateTime between @FromDate And @ToDdate 
                      And PosNo between @PosNoFrom And @PosNoTo 
                      And ShiftID between @ShiftIdFrom And @ShiftIdTo"


        sql.SqlTrueAccountingRunQuery(sqlstring)
        TextEditCashAmount.Text = sql.SQLDS.Tables(0).Rows(0).Item("VoucherAmount")
        TextEditCashDiscount.Text = sql.SQLDS.Tables(0).Rows(0).Item("Discount")
        TextEditCashNet.Text = sql.SQLDS.Tables(0).Rows(0).Item("VoucherAmountAfterDiscount")

        TextEditCardsAmount.Text = sql.SQLDS.Tables(1).Rows(0).Item("VoucherAmount")
        TextEditCardsDiscount.Text = sql.SQLDS.Tables(1).Rows(0).Item("Discount")
        TextEditCardsNet.Text = sql.SQLDS.Tables(1).Rows(0).Item("VoucherAmountAfterDiscount")

        TextEditDebitAmount.Text = sql.SQLDS.Tables(2).Rows(0).Item("VoucherAmount")
        TextEditDebitDiscount.Text = sql.SQLDS.Tables(2).Rows(0).Item("Discount")
        TextEditDebitNet.Text = sql.SQLDS.Tables(2).Rows(0).Item("VoucherAmountAfterDiscount")

        TextEditTotalAmount.Text = sql.SQLDS.Tables(3).Rows(0).Item("VoucherAmount")
        TextEdittotalDiscount.Text = sql.SQLDS.Tables(3).Rows(0).Item("Discount")
        TextEditTotalNet.Text = sql.SQLDS.Tables(3).Rows(0).Item("VoucherAmountAfterDiscount")

        TextEditDeletedTrans.Text = sql.SQLDS.Tables(4).Rows(0).Item("DeletedCount")
        TextEditDeletedAmount.Text = sql.SQLDS.Tables(4).Rows(0).Item("DeletedAmount")

        'Select  IsNull(Count(ID), 0) As DeletedCount ,IsNull(Sum(DocAmount),0) As DeletedAmount 
        '  From POSDeletedJournal Where DeleteDateTime between @FromDate And @ToDdate And PosNo between @PosNoFrom And @PosNoTo And ShiftID between @ShiftIdFrom And @ShiftIdTo 

    End Sub

    Private Sub PosTotalTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt
        PosNoFrom.EditValue = 0
        PosNoTo.EditValue = 99999
        ShiftIdFrom.EditValue = 0
        ShiftIdTo.EditValue = 99999
        Me.KeyPreview = True
    End Sub
End Class