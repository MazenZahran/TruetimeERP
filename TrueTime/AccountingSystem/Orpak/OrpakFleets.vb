Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class OrpakFleets
    Private _OrpakCs As String
    Private _fleetcode As String = ""
    Private fleetepository As New FleetRepository()
    Private Sub OrpakFleets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Referencess' table. You can move, or remove it, as needed.

        SearchPosName.Properties.DataSource = GetOrpakPos()
        SearchPosName.EditValue = 1
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
        GetTicketsMaster()
        ' RepositoryItemFleetItems.DataSource =
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "status" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("status"))
            If category = "1" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  موقوف  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "2" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
        If e.Column.FieldName = "SendSMS" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("SendSMS"))
            If category = "0" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  لا  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "1" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  نعم  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
        If e.Column.FieldName = "MonthlyVoucher" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("MonthlyVoucher"))
            If category = "0" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  لا  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "1" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  نعم  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
        If e.Column.FieldName = "acctyp" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("acctyp"))
            If category = "0" Then
                e.DisplayText = "<backcolor=@WarningFill><b><color=255, 255, 255>  ذمم  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "1" Then
                e.DisplayText = "<backcolor=@QuestionFill><b><color=255, 255, 255>  دفع مسبق  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub
    Private Sub GridView2_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "status" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("status"))
            If category = "1" Then
                e.DisplayText = "<backcolor=@Critical><b><color=255, 255, 255>  موقوف  </b>"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "2" Then
                e.DisplayText = "<backcolor=@Success><b><color=255, 255, 255>  فعال  </b>"
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetTicketsMaster()
    End Sub

    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosName.EditValueChanged
        If String.IsNullOrEmpty(SearchPosName.Text) Then
            Exit Sub
        End If
        If Me.IsHandleCreated = True And SearchPosName.Text <> "" Then
            _OrpakCs = ""
            Dim _OrpakConnection = OrpakControl.GetOrpakConnectionString(SearchPosName.EditValue)
            If _OrpakConnection._IsConnection = True Then
                _OrpakCs = _OrpakConnection._Cstring
            End If
        End If
    End Sub

    Private Sub RepositoryItemButtonEditFleet_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEditFleet.ButtonClick
        If GridView1.GetFocusedRowCellValue("code") = "99999" Then
            MsgBoxShowError(" لا يمكن تعديل بيانات  ") : Exit Sub
        End If
        Dim _id As Integer
        _id = GridView1.GetFocusedRowCellValue("id")
        Dim F As New OrpakAddNewFleets("Edit")
        With F
            .TextPosNo.Text = Me.SearchPosName.EditValue
            .TextFleetID.Text = _id
            If .ShowDialog <> DialogResult.OK Then
                GetTicketsMaster()
            End If
        End With
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
        If e.Column.FieldName = "name" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub
    Private Sub GridView2_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView2.CustomDrawFooterCell
        If e.Column.FieldName = "plate" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub GetTicketsMaster()
        GridControl1.DataSource = ""
        If SearchPosName.Text = "" Then Exit Sub
        If _OrpakCs = "" Then Exit Sub
        'Dim focusedRow As Integer = GridControl1.MainView.SourceRowHandle
        Dim SqlString As String
        Dim SqlString2 As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable



        SqlString = "SELECT [id],[name],[status],[code],[phone],
                            Case when [acctyp] is null then '0' else [acctyp] end as [acctyp],[available_amount],
                            Case when [zip] is null then '0'  when [zip] ='' then '0'  else [Zip] end as SendSMS ,
                            Case when [state] is null then '0'  when [state] ='' then '0'  else [state] end as MonthlyVoucher  
                    FROM [dbo].[fleets] where [status] <> 0  "
        If SearchReferance.Text <> "" Then
            SqlString += " and code=" & SearchReferance.EditValue
        End If
        SqlString += " Order By id Desc "

        SqlString2 = "    select m.[name],[string],[type],m.[id],m.[status],g.[description] as GroupRule,
                                hardware_type,plate,issued_date,fleet_id
                         from [dbo].[means] m 
                         left join group_rules g on g.id=m.[rule]
                         left join fleets F on m.fleet_id=F.id
                         where m.status <> 0 and m.[type]<>0  "
        If SearchReferance.Text <> "" Then
            SqlString2 += " and F.code=" & SearchReferance.EditValue
        End If
        SqlString2 += " Order By id Desc "

        Dim Con As SqlConnection
        Dim Adapter1, Adapter2 As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(_OrpakCs)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        Adapter2 = New SqlDataAdapter(SqlString2, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "fleets")
        Adapter2.Fill(dataSet11, "means")
        Con.Close()
        dataSet11.AcceptChanges()
        Dim keyColumn As DataColumn = dataSet11.Tables("fleets").Columns("id")
        Dim foreignKeyColumn As DataColumn = dataSet11.Tables("means").Columns("fleet_id")
        dataSet11.Relations.Add("البطاقات", keyColumn, foreignKeyColumn)
        dataSet11.Tables("fleets").DefaultView.Sort = "id ASC"

        GridControl1.DataSource = dataSet11.Tables("fleets")
        GridControl1.ForceInitialize()
        GridControl1.LevelTree.Nodes.Add("البطاقات", GridView2)
        Me.ReferencessTableAdapter.Fill(Me.AccountingDataSet.Referencess)
    End Sub
    Private Sub SearchReferance_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.BeforePopup
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub

    Private Sub SearchLookUpEdit1_BeforePopup(sender As Object, e As EventArgs)

    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim F As New OrpakAddNewFleets("Add")
        With F
            .TextPosNo.Text = Me.SearchPosName.EditValue
            If .ShowDialog <> DialogResult.OK Then
                GetTicketsMaster()
            End If
        End With
    End Sub
    Private Function GetMaxRefNo() As Integer
        Dim _RefNo As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   select IsNull(Max(RefNo),0)+1 As RefNo from Referencess  "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            _RefNo = sql.SQLDS.Tables(0).Rows(0).Item("RefNo")
        Else
            _RefNo = 0
        End If
        Return _RefNo
    End Function

    Private Sub RepositorySetBalance_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositorySetBalance.ButtonClick
        Dim fleetID As Integer
        Dim fleetCode As Integer
        fleetID = GridView1.GetFocusedRowCellValue("id")
        fleetCode = GridView1.GetFocusedRowCellValue("code")
        If fleetCode = "99999" Then MsgBoxShowError(" لا يمكن تعديل بيانات  ") : Exit Sub
        Dim f As New ChargeFleet(fleetID)
        With f
            If .ShowDialog <> DialogResult.OK Then
                Dim fleet As Fleet = fleetepository.GetFleet(fleetID, 1)
                GridView1.SetFocusedRowCellValue("available_amount", fleet.Available_amount)
                GridView1.SetFocusedRowCellValue("acctyp", fleet.Prepaid)
            End If
        End With
    End Sub

    Private Sub RepositoryEditCard_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEditCard.ButtonClick
        Dim _CardID As Integer
        Dim view = TryCast(GridControl1.FocusedView, GridView)
        _CardID = view.GetFocusedRowCellValue(GridColumn13)
        '_CardID = GridView2.GetFocusedRowCellValue("id")

        Dim f As New OrpakCardAddEdit("Edit")
        With f
            f.txtCardID.Text = _CardID
            If .ShowDialog <> DialogResult.OK Then
                '  GetMeans()
            End If
        End With



    End Sub
End Class