Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.Serialization

Public Class ReservationAddEdit
    Dim dataSet11 As DataSet
    Dim Con As SqlConnection
    Dim AdapterPayments As SqlDataAdapter
    Dim askbeforeclose As Boolean
    Private Sub ReservationAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TheServiceSearchLookUpEdit.Properties.DataSource = GetItems("All")
        Me.ReferanceNoSearchLookUpEdit.Properties.DataSource = GetReferences(1, -1, -1)
        Me.ReservationDateDateEdit.Select()
        askbeforeclose = True
    End Sub
    Public Sub GetDocData()
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " SELECT [ID]
                            ,[DocDate]      ,[ReferanceNo]
                            ,[ReservationAmount]      ,[ReservationDate]
                            ,[ReservationNote] ,[TheService]  ,ReservationStatus
                    FROM [dbo].[ReservationsList] 
                    Where ID=" & Me.DocIdquery.Text
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            XtraMessageBox.Show(" لا يوجد بيانات ")
            EmptyDocData()
            Exit Sub
        End If
        With sql.SQLDS.Tables(0).Rows(0)
            DocID.Text = .Item("ID")
            ReservationDateDateEdit.DateTime = .Item("ReservationDate")
            ReferanceNoSearchLookUpEdit.EditValue = .Item("ReferanceNo")
            ReservationNoteTextEdit.Text = .Item("ReservationNote")
            TheServiceSearchLookUpEdit.EditValue = .Item("TheService")
            ReservationAmountTextEdit.Text = .Item("ReservationAmount")
            ReservationStatus.Text = .Item("ReservationStatus")
            Me.TextDocDate.Text = .Item("DocDate")
        End With


        sqlstring = " SELECT  [PaymentID]
                         ,[PaymentAmount]      ,[PaymentNotes]
                         ,[PaymentDate],ReservationID  FROM [dbo].[ReservationsPayment] where [ReservationID]=" & Me.DocIdquery.Text
        Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
        Con.Open()
        AdapterPayments = New SqlDataAdapter(sqlstring, Con)
        dataSet11 = New System.Data.DataSet()
        AdapterPayments.Fill(dataSet11, "ReservationsPayment")
        Me.ReservationsPaymentGridControl.DataSource = dataSet11.Tables("ReservationsPayment")
        Con.Close()

        PaymentsSum.EditValue = colPaymentAmount.SummaryItem.SummaryValue
        Me.TextRemainAmount.EditValue = ReservationAmountTextEdit.EditValue - colPaymentAmount.SummaryItem.SummaryValue
    End Sub
    Private Sub EmptyDocData()
        ReservationDateDateEdit.DateTime = DateTime.Now
        ReferanceNoSearchLookUpEdit.Text = ""
        TheServiceSearchLookUpEdit.Text = ""
        ReservationAmountTextEdit.EditValue = 0
        ReservationNoteTextEdit.Text = ""
        ReservationStatus.Text = "مفتوح"
        ReservationsPaymentGridControl.DataSource = CreateTempTable()
        Me.DocID.Text = ""
    End Sub
    Private Function GetMaxDocumentNo() As Integer
        Dim _ID As Integer
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select IsNull(Max(ID),0)+1 as MaxID from ReservationsList ")
        _ID = sql.SQLDS.Tables(0).Rows(0).Item("MaxID")
        Return _ID
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'u
        Me.Validate()
        SaveData()
    End Sub
    Private Sub SaveData()

        If String.IsNullOrEmpty(ReservationDateDateEdit.Text) Then
            XtraMessageBox.Show("يجب تعبئة تاريخ الحجز")
            Exit Sub
        End If
        If String.IsNullOrEmpty(ReferanceNoSearchLookUpEdit.Text) Then
            XtraMessageBox.Show("يجب تعبئة الزبون")
            Exit Sub
        End If
        If String.IsNullOrEmpty(TheServiceSearchLookUpEdit.Text) Then
            XtraMessageBox.Show("يجب تعبئة الخدمة")
            Exit Sub
        End If
        If String.IsNullOrEmpty(ReservationAmountTextEdit.Text) Then
            XtraMessageBox.Show("يجب تعبئة المبلغ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(ReservationStatus.Text) Then
            XtraMessageBox.Show("يجب تعبئة حالة الحجز")
            Exit Sub
        End If



        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim DocDate As String = Format(Today(), "yyyy-MM-dd")
        Dim ReservationDate As String = Format(ReservationDateDateEdit.EditValue, "yyyy-MM-dd")
        If String.IsNullOrEmpty(DocID.Text) Then
            MsgBox(" رقم السند فارغ... ")
            Exit Sub
        End If
        askbeforeclose = False
        Select Case TextNewOld.Text
            Case "New"
                sqlstring = " INSERT INTO [dbo].[ReservationsList]
                               ([ID]
                               ,[DocDate]
                               ,[ReferanceNo]
                               ,[ReservationAmount]
                               ,[ReservationDate]
                               ,[ReservationNote]
                               ,ReservationStatus,[TheService])
                         VALUES
                               (" & DocID.EditValue & "
                               ,'" & DocDate & "'
                               , " & ReferanceNoSearchLookUpEdit.EditValue & "
                               , " & ReservationAmountTextEdit.EditValue & "
                               , '" & ReservationDate & "'
                               , N'" & ReservationNoteTextEdit.Text & "' 
                               , N'" & ReservationStatus.Text & "' 
                               , " & TheServiceSearchLookUpEdit.EditValue & ")"
                sql.SqlTrueAccountingRunQuery(sqlstring)
                ' InsertToCalender(ReservationDate, ReservationDate, "حجز",)
                Dim i As Integer
                Dim sqlstring2 As String
                For i = 0 To GridView1.RowCount - 1
                    sqlstring2 = " INSERT INTO [dbo].[ReservationsPayment]
                                   ([PaymentAmount]
                                   ,[PaymentNotes]
                                   ,[PaymentDate]
                                   ,[ReservationID])
                             VALUES
                                   (" & GridView1.GetRowCellValue(i, "PaymentAmount") & "
                                   ,N'" & GridView1.GetRowCellValue(i, "PaymentNotes") & "'
                                   ,'" & Format(CDate(GridView1.GetRowCellValue(i, "PaymentDate")), "yyyy-MM-dd") & "'
                                   ," & DocID.Text & ")"
                    sql.SqlTrueAccountingRunQuery(sqlstring2)
                Next
            Case "old"
                sqlstring = " UPDATE [dbo].[ReservationsList]
                                  SET 
                                       [DocDate] = '" & DocDate & "'
                                      ,[ReferanceNo] = " & ReferanceNoSearchLookUpEdit.EditValue & "
                                      ,[ReservationAmount] = " & ReservationAmountTextEdit.EditValue & "
                                      ,[ReservationDate] = '" & ReservationDate & "'
                                      ,[ReservationNote] = N'" & ReservationNoteTextEdit.Text & "'
                                      ,[TheService] = " & TheServiceSearchLookUpEdit.EditValue & "
                                      ,ReservationStatus= N'" & ReservationStatus.Text & "'
                                 WHERE [ID]=" & DocID.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)

                Try
                    Dim SqlCommBuil As SqlCommandBuilder
                    SqlCommBuil = New SqlCommandBuilder(AdapterPayments)
                    AdapterPayments.Update(dataSet11, "ReservationsPayment")
                Catch ex As Exception
                    MsgBox("لا يمكن حفظ الوحدات")
                End Try

        End Select

        Me.Close()
    End Sub

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        Select Case TextNewOld.Text
            Case "New"
                Me.ReservationsPaymentGridControl.DataSource = CreateTempTable()
                DocIdquery.Visible = False
                DocID.Visible = True
                ReservationStatus.Text = "مفتوح"
                BtnDelete.Visible = False
                DocID.Text = GetMaxDocumentNo()
                'ReferanceNoSearchLookUpEdit.Enabled = False
                'TheServiceSearchLookUpEdit.Enabled = False
                'ReservationAmountTextEdit.Enabled = False
                'ReservationNoteTextEdit.Enabled = False
                'ReservationsPaymentGridControl.Enabled = False
                'ReservationStatus.Enabled = False
                'BtnSave.Enabled = False
            Case "old"
                DocIdquery.Visible = True
                DocID.Visible = False
        End Select
    End Sub
    Public Function CreateTempTable() As DataTable
        Dim PlaneTable As New DataTable
        Dim JournalTable As New DataTable
        With JournalTable
            .Columns.Add("PaymentID", GetType(Integer))
            .Columns.Add("PaymentAmount", GetType(Decimal))
            .Columns.Add("PaymentNotes", GetType(String))
            .Columns.Add("PaymentDate", GetType(Date))
            .Columns.Add("ReservationID", GetType(Integer))
        End With
        Return JournalTable
    End Function

    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        GridView1.SetRowCellValue(e.RowHandle, "ReservationID", DocIdquery.EditValue)
    End Sub
    Private Sub DocIdquery_EditValueChanged(sender As Object, e As EventArgs) Handles DocIdquery.EditValueChanged
        GetDocData()
    End Sub

    Private Sub ReservationDateDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ReservationDateDateEdit.EditValueChanged
        If Me.TextNewOld.Text = "old" Or Me.TextNewOld.Text = "" Then Exit Sub
        Dim _DocDate As String
        _DocDate = Format(ReservationDateDateEdit.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT Top(1) L.ID,R.RefName as RefName
                      FROM [dbo].[ReservationsList] L
                      left join Referencess R on L.ReferanceNo=R.RefNo 
                      WHERE EXISTS
                            (SELECT ID FROM [dbo].[ReservationsList] WHERE DocStatus=0 and ReservationDate ='" & _DocDate & "')  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show(" يوجد حجز بهذا التاريخ ")
            Dim f As New ReservationShortList
            With f
                ._ReservationDate = Me.ReservationDateDateEdit.DateTime
                .ShowDialog()
            End With
            'ReferanceNoSearchLookUpEdit.Enabled = False
            'TheServiceSearchLookUpEdit.Enabled = False
            'ReservationAmountTextEdit.Enabled = False
            'ReservationNoteTextEdit.Enabled = False
            'ReservationsPaymentGridControl.Enabled = False
            'ReservationStatus.Enabled = False
            'BtnSave.Enabled = False
            ' Me.DocID.Text = ""
        Else
            'ReferanceNoSearchLookUpEdit.Enabled = True
            'TheServiceSearchLookUpEdit.Enabled = True
            'ReservationAmountTextEdit.Enabled = True
            'ReservationNoteTextEdit.Enabled = True
            'ReservationsPaymentGridControl.Enabled = True
            'ReservationStatus.Enabled = True
            'BtnSave.Enabled = True
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.None Then
            GridView1.UpdateSummary()
        End If
        Me.PaymentsSum.EditValue = colPaymentAmount.SummaryItem.SummaryValue
    End Sub
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles ReservationsPaymentGridControl.ProcessGridKey
        Dim sql As New SQLControl
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
                GridView1.UpdateTotalSummary()
                Me.PaymentsSum.EditValue = colPaymentAmount.SummaryItem.SummaryValue
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub GridView1_RowCountChanged(sender As Object, e As EventArgs) Handles GridView1.RowCountChanged
        Me.PaymentsSum.EditValue = colPaymentAmount.SummaryItem.SummaryValue
    End Sub

    Private Sub PaymentsSum_EditValueChanged(sender As Object, e As EventArgs) Handles PaymentsSum.EditValueChanged
        Me.TextRemainAmount.EditValue = ReservationAmountTextEdit.EditValue - PaymentsSum.EditValue
    End Sub

    Private Sub frmExample_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.Closing
        If askbeforeclose = True Then

            If XtraMessageBox.Show("هل تريد الخروج؟?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub
    Private Sub ButtonEdit1_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ReferanceNoSearchLookUpEdit.ButtonClick
        Dim Editor As ButtonEdit = CType(sender, ButtonEdit)
        Dim Button As EditorButton = e.Button
        If Button.Tag = "AddNew" Then
            Dim F As New ReferancessAddNew
            With F
                .TextRefNo.Text = GetReferanceMax() + 1
                .TextRefName.Text = ""
                .TextRefMobile.Text = ""
                .TextRefPhone.Text = ""
                .CheckActive.Checked = True
                .PriceCategory.EditValue = 1
                ._AddNewOrSave = "AddNew"
                .LookRefType.EditValue = 2
                .TextRefName.Select()
                If .ShowDialog() <> DialogResult.OK Then
                    ReferanceNoSearchLookUpEdit.Properties.DataSource = GetReferences(-1, -1, -1)
                End If
            End With
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If Me.TextNewOld.Text <> "old" Then Exit Sub
        If XtraMessageBox.Show("هل تريد حذف السند؟", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " update  [ReservationsList] Set ReservationStatus =N'محذوف' , [DocStatus]=-1 where [ID]=" & Me.DocIdquery.EditValue & ";"
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                XtraMessageBox.Show(" تم حذف السند ")
                askbeforeclose = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ReservationStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReservationStatus.SelectedIndexChanged
        If ReservationStatus.EditValue = "مغلق" Then
            If TextRemainAmount.EditValue > 0 Then
                If XtraMessageBox.Show(" الحجز غير مسدد ، هل تريد اغلاق السند؟  ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    ReservationStatus.EditValue = "مفتوح"
                End If
            End If
        End If
        If ReservationStatus.EditValue = "محذوف" Then
            BtnDelete.Visible = False
            BtnSave.Visible = False
        Else
            BtnDelete.Visible = True
            BtnSave.Visible = True
        End If
    End Sub
End Class