Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class OrpakCards
    Private _OrpakCs As String
    Private Sub OrpakCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchPosName.Properties.DataSource = GetOrpakPos()
        SearchPosName.EditValue = 1
        GetMeans()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetMeans()
    End Sub
    Private Sub GetMeans()
        If SearchPosName.Text = "" Then Exit Sub
        If _OrpakCs = "" Then Exit Sub
        GridControl1.DataSource = ""
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable


        SqlString = "    select m.[name],[string],[type],m.[id],m.[status],g.[description] as GroupRule,
                                hardware_type,plate,issued_date,f.code as fleetcode,f.[name] as fleetname
                         from [dbo].[means] m 
                         left join fleets F on m.fleet_id=F.id 
                         left join group_rules g on g.id=m.[rule]
                         where m.status <> 0 and m.[type]<>0 and F.code<>'99999' "
        If SearchReferance.Text <> "" Then
            SqlString += " and F.code=" & SearchReferance.EditValue
        End If
        If SearchLookCards.Text <> "" Then
            SqlString += " and m.id=" & SearchLookCards.EditValue
        End If
        If CheckActiveCardsOnly.Checked Then
            SqlString += " and m.[status]=2"
        End If
        Dim Con As SqlConnection
        Dim Adapter1 As SqlDataAdapter
        Dim dataSet11 As DataSet
        Con = New SqlConnection(_OrpakCs)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "means")
        Con.Close()
        dataSet11.AcceptChanges()
        GridControl1.DataSource = dataSet11.Tables("means")
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

    Private Sub SearchReferance_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.BeforePopup
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub

    Private Sub SearchReferance_EditValueChanged(sender As Object, e As EventArgs) Handles SearchReferance.EditValueChanged

    End Sub

    Private Sub SearchLookCards_BeforePopup(sender As Object, e As EventArgs) Handles SearchLookCards.BeforePopup
        If SearchPosName.Text = "" Then Exit Sub
        If _OrpakCs = "" Then Exit Sub
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable

        SqlString = "    select m.[name],[string],m.[id],m.[status],g.[description] as GroupRule,
                                plate,issued_date,f.[name] as fleetname,f.code as fleetcode
                         from [dbo].[means] m 
                         left join fleets F on m.fleet_id=F.id 
                         left join group_rules g on g.id=m.[rule]
                         where m.status <> 0 and m.[type]<>0  "
        If SearchReferance.Text <> "" Then
            SqlString += " and F.code=" & SearchReferance.EditValue
        End If
        Dim Con As SqlConnection
        Dim Adapter1 As SqlDataAdapter
        Dim dataSet11 As DataSet
        Con = New SqlConnection(_OrpakCs)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "means")
        Con.Close()
        dataSet11.AcceptChanges()
        SearchLookCards.Properties.DataSource = dataSet11.Tables("means")
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
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim f As New OrpakCardAddEdit("Add")
        With f
            If .ShowDialog <> DialogResult.OK Then
                GetMeans()
            End If
        End With
    End Sub

    Private Sub RepositoryItemButtonEditCard_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEditCard.ButtonClick

    End Sub

    Private Sub RepositoryItemButtonEditCard_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEditCard.Click
        Dim _CardID As Integer
        _CardID = GridView1.GetFocusedRowCellValue("id")
        Dim f As New OrpakCardAddEdit("Edit")
        With f
            f.txtCardID.Text = _CardID
            If .ShowDialog <> DialogResult.OK Then
                GetMeans()
            End If
        End With
    End Sub
End Class