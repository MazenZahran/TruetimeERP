Public Class ItemBarcodePrinterSettings
    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchFormName.EditValueChanged
        GetFormData()
    End Sub
    Private Sub GetFormData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select * from [BarcodePrinterSettings] where ID=" & SearchFormName.EditValue
            sql.SqlTrueTimeRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                txtPageWidth.EditValue = .Item("PageWidth")
                txtPageHeight.EditValue = .Item("PageHeight")
                txtTopMargin.EditValue = .Item("TopMargin")
                txtBottomMargin.EditValue = .Item("BottomMargin")
                txtRightMargin.EditValue = .Item("RightMargin")
                txtLeftMargin.EditValue = .Item("LeftMargin")
                CheckShowPrice.Checked = CBool(.Item("ShowPrice"))
                SearchDefaultPrinter.EditValue = .Item("DefaultPrinter")
                CheckIsDefault.EditValue = CBool(.Item("IsDefault"))
                If IsDBNull(.Item("PrintUnit")) Then CheckPrintUnit.Checked = False Else CheckPrintUnit.EditValue = CBool(.Item("PrintUnit"))
            End With
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try

    End Sub
    Private Sub GetDefaultForm()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select top(1) ID from BarcodePrinterSettings where IsDefault=1"
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            SearchFormName.Text = sql.SQLDS.Tables(0).Rows(0).Item("ID")
        Else
            SearchFormName.Text = 1
        End If

    End Sub

    Private Sub ItemBarcodePrinterSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchDefaultPrinter.Properties.DataSource = GetPrintersDataTable()
        GetDefaultForm()
        GetFormsTable()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub
    Private Sub UpdateData()
        Dim _CheckShowPrice As Integer
        If CheckShowPrice.Checked = True Then
            _CheckShowPrice = 1
        Else
            _CheckShowPrice = 0
        End If
        Dim _CheckIsDefault As Integer
        If CheckIsDefault.Checked = True Then
            _CheckIsDefault = 1
        Else
            _CheckIsDefault = 0
        End If
        Dim _CheckPrintUnit As Integer
        If CheckPrintUnit.Checked = True Then
            _CheckPrintUnit = 1
        Else
            _CheckPrintUnit = 0
        End If
        Try
            Dim sql As New SQLControl
            If CheckIsDefault.EditValue = True Then
                sql.SqlTrueAccountingRunQuery(" UPDATE [dbo].[BarcodePrinterSettings] SET [IsDefault] = 0")
            End If
            Dim SqlString As String
            SqlString = " UPDATE [dbo].[BarcodePrinterSettings]
                      SET 
                           [PageWidth] = " & txtPageWidth.EditValue & "
                          ,[PageHeight] = " & txtPageHeight.EditValue & "
                          ,[BottomMargin] = " & txtBottomMargin.EditValue & "
                          ,[TopMargin] = " & txtTopMargin.EditValue & "
                          ,[RightMargin] = " & txtRightMargin.EditValue & "
                          ,[LeftMargin] = " & txtLeftMargin.EditValue & "
                          ,[ShowPrice] = " & _CheckShowPrice & "
                          ,[IsDefault] = " & _CheckIsDefault & "
                          ,[DefaultPrinter] = N'" & SearchDefaultPrinter.EditValue & "'
                          ,PrintUnit=" & _CheckPrintUnit & "
                       WHERE ID=" & SearchFormName.EditValue
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                MsgBoxShowSuccess("تم حفظ البيانات")

            Else
                MsgBoxShowError(" خطا في حفظ البيانات ")
            End If
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try
    End Sub
    Private Sub GetFormsTable()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select ID,FormName from BarcodePrinterSettings  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        SearchFormName.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class