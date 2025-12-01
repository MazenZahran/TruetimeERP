Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class PosPaidOptions
    Dim _DefaultCurr As Integer = GetDefaultCurrency()

    Private Sub PosPaidOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RepositoryItemLookUpEdit1.DataSource = GetCurrency()
        GetAllMethods()
        GetMethodPaids()
        Me.KeyPreview = True

        If GridViewVisa.GetRowCellValue(0, "ExchangePrice") = 1 Then
            GridViewVisa.SetRowCellValue(0, "Amount", Me.TextVoucherAmount.EditValue)
            GridViewVisa.SetRowCellValue(0, "AmountInMainCurrency", Me.TextVoucherAmount.EditValue)
            Me.TextTotalPaid.EditValue = Me.TextVoucherAmount.EditValue
            Me.TextDifference.EditValue = 0
        Else
            GridViewVisa.SetRowCellValue(0, "Amount", Me.TextVoucherAmount.EditValue)
            GridViewVisa.SetRowCellValue(0, GridViewVisa.Columns("Amount"), Me.GridViewVisa.GetRowCellValue(GridViewVisa.FocusedRowHandle, "AmountInMainCurrency") / Me.GridViewVisa.GetRowCellValue(GridViewVisa.FocusedRowHandle, "ExchangePrice"))
            Me.TextTotalPaid.EditValue = Me.TextVoucherAmount.EditValue
            ' Me.TextDifference.EditValue = 0
        End If
        'If GridView1.GetFocusedRowCellValue("SaleOnScale") Then
        '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Amount"), TextVoucherAmount.EditValue)
        'End If

        ColAmountInMainCurrency.DisplayFormat.FormatString = "{0:0.00} NIS"
        ColExchangePrice.DisplayFormat.FormatString = "{0:0.00} NIS"
        ColAmount.DisplayFormat.FormatString = "{0:0.00}"

    End Sub
    Private Sub GetMethodPaids()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select top 1 MethodNo,PaidMethodName,AccountNO,
CAST(0 AS DECIMAL(19,2)) as Amount,F.Currency ,CAST(1 AS DECIMAL(19,2)) as ExchangePrice,CAST(0 AS DECIMAL(19,2)) as AmountInMainCurrency
  From [dbo].[PosPaidMethods] M
  left join FinancialAccounts F on F.AccNo=M.AccountNO  order by MethodNo  ")
            GridControlVisa.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetAllMethods()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select  MethodNo,PaidMethodName,AccountNO,
CAST(0 AS DECIMAL(19,2)) as Amount,F.Currency ,CAST(1 AS DECIMAL(19,2)) as ExchangePrice,CAST(0 AS DECIMAL(19,2)) as AmountInMainCurrency
  From [dbo].[PosPaidMethods] M
  left join FinancialAccounts F on F.AccNo=M.AccountNO  order by MethodNo   ")
            RepositoryItemSearchLookUpEdit1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewVisa.CellValueChanged



        With GridViewVisa
            'Dim _ExchangePrice As Decimal = 0
            'Dim _Amount As Decimal = 0
            Dim _AmountInMainCurrency As String = "0"


            ''If Not IsDBNull(.GetRowCellValue(.FocusedRowHandle, "AccountNO")) Then _Account = .GetRowCellValue(.FocusedRowHandle, "AccountNO")
            If Not IsDBNull(.GetRowCellValue(.FocusedRowHandle, "AmountInMainCurrency")) Then _AmountInMainCurrency = .GetRowCellValue(.FocusedRowHandle, "AmountInMainCurrency")

            Try
                If e.Column.FieldName = "MethodNo" Then
                    Try
                        Dim _Method As Integer = 0
                        If Not IsDBNull(.GetRowCellValue(.FocusedRowHandle, "MethodNo")) Then _Method = .GetRowCellValue(.FocusedRowHandle, "MethodNo")
                        Dim sql As New SQLControl
                        sql.SqlTrueAccountingRunQuery("Select top 1 MethodNo,PaidMethodName,AccountNO,
CAST(0 AS DECIMAL(19,2)) as Amount,F.Currency ,CAST(1 AS DECIMAL(19,2)) as ExchangePrice," & _AmountInMainCurrency & " as AmountInMainCurrency
  From [dbo].[PosPaidMethods] M
  left join FinancialAccounts F on F.AccNo=M.AccountNO  where MethodNo=" & _Method & " order by MethodNo  ")
                        GridControlVisa.DataSource = sql.SQLDS.Tables(0)
                    Catch ex As Exception

                    End Try

                    Try
                        Dim _ExchangePrice As Decimal = 1
                        Dim _CurrencyID As Integer = GridViewVisa.GetRowCellValue(GridViewVisa.FocusedRowHandle, "Currency")
                        _ExchangePrice = GetExchengPrice(_CurrencyID, Format(Today, "yyyy-MM-dd")).PurchasePrice
                        GridViewVisa.SetRowCellValue(GridViewVisa.FocusedRowHandle, GridViewVisa.Columns("ExchangePrice"), _ExchangePrice)
                    Catch ex As Exception

                    End Try

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With
    End Sub

    Private edit As BaseEdit = Nothing
    Private Sub gridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewVisa.ShownEditor
        Dim view As GridView = TryCast(sender, GridView)
        edit = view.ActiveEditor
        AddHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
    End Sub

    Private Sub edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)


        Try
            GridViewVisa.PostEditor()
            Dim _Amount, _ExchangePrice, _AmountInMainCurrency As Decimal
            _AmountInMainCurrency = Me.GridViewVisa.GetRowCellValue(GridViewVisa.FocusedRowHandle, "AmountInMainCurrency")
            _ExchangePrice = Me.GridViewVisa.GetRowCellValue(GridViewVisa.FocusedRowHandle, "ExchangePrice")
            _Amount = _AmountInMainCurrency / _ExchangePrice
            GridViewVisa.SetRowCellValue(GridViewVisa.FocusedRowHandle, "Amount", (_AmountInMainCurrency / _ExchangePrice))
        Catch ex As Exception

        End Try


        Try
            TextTotalPaid.EditValue = GridControlVisa.DataSource.Compute("SUM(AmountInMainCurrency)", "")
        Catch ex As Exception
            TextTotalPaid.EditValue = 0
        End Try

    End Sub

    Private Sub gridView1_HiddenEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewVisa.HiddenEditor
        RemoveHandler edit.EditValueChanged, AddressOf edit_EditValueChanged
        edit = Nothing
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        TextDifference.EditValue = -1
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        My.Forms.POSRestCashier.TextOtherAccountNo.Caption = GridViewVisa.GetRowCellValue(0, "AccountNO")
        My.Forms.POSRestCashier.TextOtherAccountName.Caption = GetFinancialAccountsData(GridViewVisa.GetRowCellValue(0, "AccountNO")).AccName
        Me.Close()
    End Sub

    Private Sub GridControlVisa_Click(sender As Object, e As EventArgs) Handles GridControlVisa.Click

    End Sub

    'Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
    '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Currency"), Me.RepositoryItemSearchLookUpEdit1View.GetRowCellValue(RepositoryItemSearchLookUpEdit1View.FocusedRowHandle, "Currency"))


    'End Sub
    '    Private Sub GetDetailsForMethod()
    '        Try
    '            Dim sql As New SQLControl
    '            Dim _MethodNo As Integer

    '            sql.SqlTrueAccountingRunQuery("Select top 1 MethodNo,PaidMethodName,AccountNO,
    'CAST(0 AS DECIMAL(19,2)) as Amount,F.Currency ,CAST(1 AS DECIMAL(19,2)) as ExchangePrice,CAST(0 AS DECIMAL(19,2)) as AmountInMainCurrency
    '  From [dbo].[PosPaidMethods] M
    '  left join FinancialAccounts F on F.AccNo=M.AccountNO  where MethodNo=" & _MethodNo & " order by MethodNo  ")
    '            GridControl1.DataSource = sql.SQLDS.Tables(0)
    '        Catch ex As Exception

    '        End Try
    '    End Sub
End Class