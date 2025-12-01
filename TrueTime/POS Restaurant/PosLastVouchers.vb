Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSpreadsheet.TileLayout

Public Class PosLastVouchers
    Public _PosNoInDataForPasLastVouchers
    Private Sub RepositoryPrint_Click(sender As Object, e As EventArgs) Handles RepositoryPrint.Click
        ' PrintPosVoucher(Me.GridView1.GetFocusedRowCellValue("DocCode"))
        Dim _DocCode As String
        _DocCode = Me.GridView1.GetFocusedRowCellValue("DocCode")
        PrintPosVoucherFromDataBase(_DocCode, False)
    End Sub

    Private Sub PosLastVouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPosNames()
        GetDataForPasLastVouchers()
        If POSRestCashier.useVoucherCounter = True Then
            ColVoucherCounter.VisibleIndex = 0
            ColVoucherID.VisibleIndex = -1
        Else
            ColVoucherID.VisibleIndex = 0
            ColVoucherCounter.VisibleIndex = -1
        End If
        GetSettings()
        SwitchKeyboardLayout("ar")
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim sqlstring As String = "  Select SettingValue from [Settings] where SettingName='POS_ShowTaqseetColoumn' "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            ColTaqseet.Visible = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Else
            ColTaqseet.Visible = False
        End If

    End Sub

    Public Sub GetDataForPasLastVouchers()
        Dim _Count As Integer = GetPosVoucherQueryLimit()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String

            If _Count = -1 Then
                sqlString = "SELECT "
            Else
                sqlString = "SELECT TOP (" & _Count & ") "
            End If

            sqlString += " [VoucherID], [VoucherDateTime], [VoucherAmount], [VoucherDiscount], " &
                     "[VoucherAmountAfterDiscount], [VoucherCode] AS DocCode,[VoucherPayType], " &
                     "CONCAT([VoucherReferanceName],' ', R.RefMobile) AS VoucherReferanceName, " &
                     "[PayCardName], D.Name AS DocName, V.[ID], " &
                     "VoucherCounter FROM [dbo].[PosVouchers] V " &
                     "LEFT JOIN DocNames D ON V.DocName = D.id " &
                     "LEFT JOIN [dbo].[Referencess] R ON V.VoucherReferance = R.[RefNo] " &
                     "WHERE PosNo = " & _PosNoInDataForPasLastVouchers & " ORDER BY ID DESC"

            'sqlString += " [VoucherID], [VoucherDateTime], [VoucherAmount], [VoucherDiscount], [VoucherPC], " &
            '         "[VoucherAmountAfterDiscount], [UserNo], [VoucherCode] AS DocCode, [VoucherDebit], [VoucherCredit], [VoucherPayType], " &
            '         "CONCAT([VoucherReferanceName],' ', R.RefMobile) AS VoucherReferanceName, [VoucherReferance] AS RefNo, " &
            '         "[PayCardName], [VoucherNote], [PosNo], [ShiftID], D.Name AS DocName, V.[ID], [VoucherDiscount2], " &
            '         "VoucherCounter, R.RefMobile AS Mobile FROM [dbo].[PosVouchers] V " &
            '         "LEFT JOIN DocNames D ON V.DocName = D.id " &
            '         "LEFT JOIN [dbo].[Referencess] R ON V.VoucherReferance = R.[RefNo] " &
            '         "WHERE PosNo = " & _PosNoInDataForPasLastVouchers & " ORDER BY ID DESC"

            sql.SqlTrueAccountingRunQuery(sqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)

        Catch ex As Exception
            MessageBox.Show("Error loading vouchers: " & ex.Message)
        End Try
    End Sub

    Private Sub GetDataForPasLastVouchersForPosNo(_PosNo As Integer, _Count As Integer)

        Try
            Dim sql As New SQLControl
            Dim sqlString As String

            If _Count = -1 Then
                sqlString = "SELECT "
            Else
                sqlString = "SELECT TOP (" & _Count & ") "
            End If

            sqlString += " [VoucherID], [VoucherDateTime], [VoucherAmount], [VoucherDiscount], [VoucherPC], " &
                     "[VoucherAmountAfterDiscount], [UserNo], [VoucherCode] AS DocCode, [VoucherDebit], [VoucherCredit], [VoucherPayType], " &
                     "CONCAT([VoucherReferanceName],' ', R.RefMobile) AS VoucherReferanceName, [VoucherReferance] AS RefNo, " &
                     "[PayCardName], [VoucherNote], [PosNo], [ShiftID], D.Name AS DocName, V.[ID], [VoucherDiscount2], " &
                     "VoucherCounter, R.RefMobile AS Mobile FROM [dbo].[PosVouchers] V " &
                     "LEFT JOIN DocNames D ON V.DocName = D.id " &
                     "LEFT JOIN [dbo].[Referencess] R ON V.VoucherReferance = R.[RefNo] " &
                     "WHERE PosNo = " & _PosNo & " ORDER BY ID DESC"

            sql.SqlTrueAccountingRunQuery(sqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)

        Catch ex As Exception
            MessageBox.Show("Error loading vouchers: " & ex.Message)
        End Try

    End Sub
    Private Function GetPosVoucherQueryLimit() As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select SettingValue  from  Settings where SettingName='PosVoucherQueryLimit'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub RepositoryPrintPreview_Click(sender As Object, e As EventArgs) Handles RepositoryPrintPreview.Click
        Dim _DocCode As String
        _DocCode = Me.GridView1.GetFocusedRowCellValue("DocCode")
        PrintPosVoucherFromDataBase(_DocCode, True)
    End Sub

    Private Sub RepositoryOpenTaqseet_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpenTaqseet.ButtonClick
        Dim _PaidMethod As String = CStr(GridView1.GetFocusedRowCellValue("VoucherPayType"))
        If _PaidMethod <> "CSTMR" Then
            MsgBoxShowError(" الفاتورة نقدية ولا يمكن تقسيطها ")
            Exit Sub
        End If
        Dim _Amount As Decimal = CDec(GridView1.GetFocusedRowCellValue("VoucherAmount"))
        If _Amount = 0 Then
            MsgBoxShowError(" الفاتورة صفر ولا يمكن تقسيطها ")
            Exit Sub
        End If
        Dim _DocNo As Integer = CInt(GridView1.GetFocusedRowCellValue("VoucherID"))
        Dim f As New InstallmentForm("New")
        With f
            .InstallmentReferance.EditValue = GridView1.GetFocusedRowCellValue("RefNo")
            .InstallmentsAmount.EditValue = _Amount
            .Text = " تقسيط فاتورة مبيعات "
            .InstallmentInOut.EditValue = "IN"
            .VoucherNo.Text = _DocNo
            .InstallmentsAmount.ReadOnly = True
            .InstallmentInOut.ReadOnly = True
            .VoucherNo.ReadOnly = True
            .ShowDialog()
        End With
    End Sub
    Private Sub GetPosNames()
        Dim sql As New SQLControl
        Dim sqlstring As String = " Select POSCode,POSName from AccountingPOSNames where PosType='1' "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            SearchPosNames.Properties.DataSource = sql.SQLDS.Tables(0)
        End If
    End Sub

    Private Sub SearchPosNames_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosNames.EditValueChanged
        If isFormPainted Then
            Dim _Count As Integer = GetPosVoucherQueryLimit()
            Dim _PosNo As Integer = Integer.Parse(SearchPosNames.EditValue)
            GetDataForPasLastVouchersForPosNo(_PosNo, _Count)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _PosNo As Integer = 1
        GetDataForPasLastVouchersForPosNo(_PosNo, ComboBoxEdit1.EditValue)
    End Sub

    Private Sub RepositoryDelete_Click(sender As Object, e As EventArgs) Handles RepositoryDelete.Click
        'If XtraMessageBox.Show("هل تريد حذف الفاتورة ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '    Try
        '        Dim currentRowHandle As Integer = Me.GridView1.FocusedRowHandle
        '        Dim sql As New SQLControl
        '        Dim sqlString As String
        '        Dim _DocCode As String = Me.GridView1.GetFocusedRowCellValue("DocCode")
        '        sqlString = "DELETE FROM PosVouchers WHERE VoucherCode = '" & _DocCode & "' "
        '        sqlString += " ; Update Journal Set DocStatus=0 WHERE DocCode = N'" & _DocCode & "'"
        '        sql.SqlTrueAccountingRunQuery(sqlString)
        '        XtraMessageBox.Show("تم حذف الفاتورة بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridControl1.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
        '        view.DeleteRow(view.FocusedRowHandle)
        '    Catch ex As Exception
        '        MsgBoxShowError("خطأ في حذف الفاتورة: " & ex.Message)
        '    End Try
        'End If
    End Sub
End Class