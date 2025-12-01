Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports Microsoft.Graph

Public Class PosSerachReferance
    Public docCode As String
    Public posNo As Integer
    Private Sub PosSerachReferance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookRefType.Properties.DataSource = GetReferancessTypes(False)
        If GlobalVariables._SystemLanguage = "Arabic" Then
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusName"
            GridColumn3.Visible = True
            GridColumn4.Visible = False
        Else
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusNameE"
            GridColumn3.Visible = False
            GridColumn4.Visible = True
        End If
        LookUpActiveNotActive.Properties.DataSource = ActiveNotActive()
        LookUpActiveNotActive.EditValue = "2"
        GetSettings()
        RefreshList()
        If GlobalVariables._Shalash = True Then
            Me.GridColumnPrint.Visible = True
        End If
        SwitchKeyboardLayout("ar")
        'GetCurrentKeyboardLayout()
        SearchControl1.Select()
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                        From [dbo].[Settings]
                                    where  [SettingName]='PosShowColOpenInReferanceList' ")
            GridColumnOpen.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GridColumnOpen.Visible = False
        End Try
    End Sub
    Private Sub AddNew()
        ReferancessAddNew.TextRefNo.Text = GetReferanceMax() + 1
        ReferancessAddNew.TextRefName.Text = ""
        ReferancessAddNew.TextRefMobile.Text = ""
        ReferancessAddNew.TextRefPhone.Text = ""
        ReferancessAddNew.PriceCategory.EditValue = 1
        ReferancessAddNew.TextRefName.Select()
        ReferancessAddNew.LookRefType.EditValue = 2
        ReferancessAddNew._AddNewOrSave = "AddNew"
        ReferancessAddNew.CheckActive.Checked = True
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub
    Private Sub RefreshList()
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()
        Dim SqlString As String
        Dim Sql As New SQLControl
        SqlString = " Select RefID,RefName,RefNo,RefType,RefMobile,RefPhone,RefAccID,PriceCategory,IsNull(RefMemo,'') as RefMemo  from Referencess where [Active]=1 and RefType in (2,99)   "
        If Not String.IsNullOrEmpty(Me.LookRefType.Text) Then
            SqlString += "  and [RefType]=  " & LookRefType.EditValue
        End If
        If Not String.IsNullOrEmpty(Me.LookUpActiveNotActive.Text) And Me.LookUpActiveNotActive.EditValue <> "2" Then
            SqlString += "  and [Active]=  " & LookUpActiveNotActive.EditValue
        End If
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        stopwatch.Stop()
        BarStaticItemTimeSpan.Caption = $"Query time: {stopwatch.ElapsedMilliseconds} ms"
    End Sub

    'Private Sub RefreshList()

    '    Dim SqlString As String
    '    Dim Sql As New SQLControl
    '    SqlString = " Select RefID,RefName,RefNo,RefType,RefMobile,RefPhone,RefAccID,PriceCategory,IsNull(RefMemo,'') as RefMemo  from Referencess where [Active]=1 and RefType in (2,99)   "
    '    'If Not String.IsNullOrEmpty(Me.SearchSort.Text) Then
    '    '    SqlString += "  and [RefSort]=  " & SearchSort.EditValue
    '    'End If
    '    If Not String.IsNullOrEmpty(Me.LookRefType.Text) Then
    '        SqlString += "  and [RefType]=  " & LookRefType.EditValue
    '    End If
    '    If Not String.IsNullOrEmpty(Me.LookUpActiveNotActive.Text) And Me.LookUpActiveNotActive.EditValue <> "2" Then
    '        SqlString += "  and [Active]=  " & LookUpActiveNotActive.EditValue
    '    End If

    '    Sql.SqlTrueAccountingRunQuery(SqlString)
    '    GridControl1.DataSource = Sql.SQLDS.Tables(0)
    '    GridView1.BestFitColumns()
    'End Sub

    Private Sub RepositorySelect_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositorySelect.ButtonClick
        My.Forms.POSRestCashier.TextReferanceNo.Text = GridView1.GetFocusedRowCellValue("RefNo")
        My.Forms.POSRestCashier.TextReferanceName.Text = GridView1.GetFocusedRowCellValue("RefName")
        My.Forms.POSRestCashier.DocNotes.Text = GridView1.GetFocusedRowCellValue("RefMemo")
        My.Forms.POSRestCashier.Text = "فاتورة مبيعات"
        My.Forms.POSRestCashier.TextOtherAccountNo.Caption = GridView1.GetFocusedRowCellValue("RefAccID")
        My.Forms.POSRestCashier.TextOtherAccountName.Caption = GetFinancialAccountsData(GridView1.GetFocusedRowCellValue("RefAccID")).AccName
        'My.Forms.POSRestCashier.ReferanceNameItem.Caption = GridView1.GetFocusedRowCellValue("RefName")
        My.Forms.POSRestCashier.TextReferanceName.Text = GridView1.GetFocusedRowCellValue("RefName")
        SelectCustomer(GridView1.GetFocusedRowCellValue("RefNo"), GridView1.GetFocusedRowCellValue("RefName"))
        Me.Close()
    End Sub
    Private Sub SelectCustomer(refNo As Integer, refName As String)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update POSJournal Set Referance=" & refNo & ",ReferanceName=N'" & refName & "' where DocCode='" & docCode & "' and PosNo=" & posNo
        sql.SqlTrueAccountingRunQuery(sqlString)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshList()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        My.Forms.POSRestCashier.TextReferanceNo.Text = ""
        My.Forms.POSRestCashier.TextReferanceName.Text = ""
        My.Forms.POSRestCashier.Text = "فاتورة مبيعات"
        My.Forms.POSRestCashier.TextOtherAccountNo.Caption = GlobalVariables._DefaultBaseCashAccount
        My.Forms.POSRestCashier.TextOtherAccountName.Caption = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
        'My.Forms.POSRestCashier.ReferanceNameItem.Caption = ""
        My.Forms.POSRestCashier.TextReferanceName.Text = "زبون نقدي"
        My.Forms.POSRestCashier.DocNotes.Text = ""
        Me.Close()
    End Sub
    Private _Mobilechanges As Boolean = True
    Private _Refchanges As Boolean = True
    Sub gridView1_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim sql As New SQLControl
        view.CloseEditor()
        If e.Column.FieldName = "RefMobile" And _Mobilechanges = True Then
            If XtraMessageBox.Show("هل تريد تعديل رقم الموبايل؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _RefNo As Integer
                Dim _RefMobile As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("RefNo")) Then
                    _RefNo = GridView1.GetFocusedRowCellValue("RefNo")
                    _RefMobile = GridView1.GetFocusedRowCellValue("RefMobile")
                    If sql.SqlTrueAccountingRunQuery(" update [dbo].[Referencess] set RefMobile='" & _RefMobile & "' where  RefNo=" & _RefNo) = True Then
                        ' MsgBoxShowSuccess(" تم تعديل الرقم  ")
                        _Mobilechanges = False
                        GridView1.SetFocusedRowCellValue("RefMobile", _RefMobile)
                        _Mobilechanges = True
                    End If
                End If
            End If
        End If
        If e.Column.FieldName = "RefName" And _Refchanges = True Then
            If XtraMessageBox.Show("هل تريد تعديل اسم الزبون؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _RefNo As Integer
                Dim _RefName As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("RefNo")) Then
                    _RefNo = GridView1.GetFocusedRowCellValue("RefNo")
                    _RefName = GridView1.GetFocusedRowCellValue("RefName")
                    If sql.SqlTrueAccountingRunQuery(" update [dbo].[Referencess] set RefName=N'" & _RefName & "' where  RefNo=" & _RefNo) = True Then
                        _Refchanges = False
                        GridView1.SetFocusedRowCellValue("RefName", _RefName)
                        _Refchanges = True
                    End If
                End If
            End If
        End If
        If e.Column.FieldName = "RefMemo" And _Refchanges = True Then
            If XtraMessageBox.Show("هل تريد تعديل الملاحظة؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _RefNo As Integer
                Dim _RefMemo As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("RefNo")) Then
                    _RefNo = GridView1.GetFocusedRowCellValue("RefNo")
                    _RefMemo = GridView1.GetFocusedRowCellValue("RefMemo")
                    If sql.SqlTrueAccountingRunQuery(" update [dbo].[Referencess] set RefMemo=N'" & _RefMemo & "' where  RefNo=" & _RefNo) = True Then
                        _Refchanges = False
                        GridView1.SetFocusedRowCellValue("RefMemo", _RefMemo)
                        _Refchanges = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        AddNew()
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefNo")
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub

    Private Sub RepositoryPrint_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryPrint.ButtonClick
        Dim _RefData = GetRefranceData(GridView1.GetFocusedRowCellValue("RefNo"))
        Dim _Report As New ReferanceDataLabel
        With _Report
            .XrLabelName.Text = _RefData.RefName
            .XrLabelAddress.Text = _RefData._Address
            .XrLabelMobile.Text = _RefData.RefMobile
            .ShowPreview()
        End With
    End Sub
End Class