Imports System.Data.SqlClient
Imports DevExpress.XtraTreeList.Data
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Microsoft.Office.Interop.Outlook

Public Class OrpakEditTrans
    Public _OrpakCs As String

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextTransID.EditValueChanged
        GetTransDetails()
    End Sub
    Private Sub GetTransDetails()
        If SearchPosID.Text = "" Then Exit Sub
        If _OrpakCs = "" Then Exit Sub
        ' GridControl1.DataSource = ""
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable


        SqlString = "SELECT TOP (1) [shift_id]
      ,T.[id]
      ,[date]
      ,[time]
      ,[type]
      ,[pump]
      ,[sale]
      ,[ppv]
      ,[quantity]
      ,[tag]
      ,[plate]
      ,[mean_name]
      ,[product_name]
	  ,F.code as FleetCode
	  ,F.name as FleetName
      ,[timestamp]
  FROM [dbo].[transactions] T 
left join fleets F on F.id=T.fleet_id where T.id=" & TextTransID.EditValue



        Dim _TransData As New DataTable
        Using cnn As New SqlConnection(_OrpakCs)
            cnn.Open()
            Using dad As New SqlDataAdapter(SqlString, cnn)
                dad.Fill(_TransData)
            End Using
            cnn.Close()
        End Using
        DateEdit1.DateTime = _TransData.Rows(0).Item("timestamp")
        Textquantity.EditValue = _TransData.Rows(0).Item("quantity")
        Textsale.EditValue = _TransData.Rows(0).Item("sale")
        Textppv.EditValue = _TransData.Rows(0).Item("ppv")

    End Sub

    Private Sub SearchPosID_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosID.EditValueChanged
        If String.IsNullOrEmpty(SearchPosID.Text) Then
            Exit Sub
        End If
        If Me.IsHandleCreated = True And SearchPosID.Text <> "" Then
            _OrpakCs = ""
            Dim _OrpakConnection = OrpakControl.GetOrpakConnectionString(SearchPosID.EditValue)
            If _OrpakConnection._IsConnection = True Then
                _OrpakCs = _OrpakConnection._Cstring
            End If
        End If
    End Sub



    Private Sub SearchFleets_BeforePopup(sender As Object, e As EventArgs) Handles SearchFleets.BeforePopup
        If SearchPosName.Text = "" Then Exit Sub
        If _OrpakCs = "" Then Exit Sub
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable

        SqlString = "    SELECT [id],[name],[status],[code],[phone],
                            Case when [acctyp] is null then '0' else [acctyp] end as [acctyp],[available_amount],
                            Case when [zip] is null then '0'  when [zip] ='' then '0'  else [Zip] end as SendSMS  
                         FROM [dbo].[fleets] where [status] <> 0 and id<>200000000   "
        Dim _fleets As New DataTable
        Using cnn As New SqlConnection(_OrpakCs)
            cnn.Open()
            Using dad As New SqlDataAdapter(SqlString, cnn)
                dad.Fill(_fleets)
            End Using
            cnn.Close()
        End Using
        SearchFleets.Properties.DataSource = _fleets
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
        If SearchFleets.Text <> "" Then
            SqlString += " and F.code=" & SearchFleets.EditValue
            SearchLookCards.ReadOnly = False
        Else
            Exit Sub
        End If
        Dim _Means As New DataTable
        Using cnn As New SqlConnection(_OrpakCs)
            cnn.Open()
            Using dad As New SqlDataAdapter(SqlString, cnn)
                dad.Fill(_Means)
            End Using
            cnn.Close()
        End Using
        SearchLookCards.Properties.DataSource = _Means
    End Sub

    Private Sub SearchFleets_EditValueChanged(sender As Object, e As EventArgs) Handles SearchFleets.EditValueChanged
        If SearchFleets.Text <> "" Then
            SearchLookCards.Text = ""
            SearchLookCards.ReadOnly = False
        Else
            SearchLookCards.ReadOnly = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OrpakEditTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.SearchFleets.Text = "" Then
            MsgBoxShowError(" يجب اختيار زبون ")
            Exit Sub
        End If
        If SearchLookCards.Text = "" Then
            MsgBoxShowError("يجب اختيار بطاقة")
            Exit Sub
        End If

        Dim _CardData = GetCardData(SearchLookCards.EditValue)
        Dim Lastdata As String = _CardData._CardCode & " " & _CardData._Plate & "" & _CardData._CardNo & " " & _CardData._FleetName
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " update transactions 
                      set [type]='CSTMR',tag='" & _CardData._CardCode & "',plate='" & _CardData._Plate & "',
                      fleet_id='" & _CardData._FleetID & "', mean_id='" & SearchLookCards.EditValue & "',
                      mean_name='" & _CardData._CardNo & "',fleet_name='" & _CardData._FleetName & "',
                      fleet_code='" & _CardData._FleetCode & "' where id=" & TextTransID.EditValue
        sqlstring += " ;Update fleets set available_amount=available_amount-" & CDec(Textsale.EditValue) & " where id='" & _CardData._FleetID & "'"
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            CreateDocLog("Orpak", "", "0", _CardData._FleetID, "Update", "Edit Orpak Trans" & ": " & Lastdata, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            MsgBoxShowSuccess(" تم تعديل البيانات بنجاح ")
            Me.Close()
        End If
    End Sub
End Class