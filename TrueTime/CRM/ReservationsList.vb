Imports System.Data.SqlClient
Imports System.Threading
Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class ReservationsList
    Dim _UserID As String = GlobalVariables.CurrUserForTasks
    Dim CurrFilter As Integer = 0
    Private Sub Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.TileBarItem1.Elements(1).Text = "100"
        'Me.TileBarItem2.Elements(1).Text = "100"
        'Me.TileBarItem3.Elements(1).Text = "100"
        'Me.GridView1.Appearance.Row.Font = New Font("Tahoma", 12.0F)
        GetEmplStatusTable()
        GetTasksCount()
        GetReservationsList(1)

    End Sub
    Private Sub GetReservationsList(_Action)
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        GetTasksCount()
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim sqlwhere As String = "  "
        SqlString = " SELECT L.[ID]
                            ,[DocDate],R.RefName,R.RefMobile,[ReservationAmount],[ReservationDate]
                            ,[ReservationNote] , ( select IsNull(sum(PaymentAmount),0) from ReservationsPayment PP where PP.ReservationID=L.ID ) as Payments
	                        ,I.ItemName,ReservationStatus
                      FROM [dbo].[ReservationsList] L
                      left join Referencess R on R.RefNo=L.ReferanceNo
                      left join Items I on I.ItemNo=L.TheService "
        SqlString += " where DocStatus <> -1 "
        Select Case _Action
            Case 1
                SqlString += " and ReservationStatus=N'مفتوح' "
            Case 2
                SqlString += " and ReservationStatus=N'مغلق' "
            Case 3
                SqlString += " and 1=1 "
        End Select
        Sql.SqlTrueTimeRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.Focus()
        GridView1.FocusedRowHandle = focusedRow

    End Sub


    Private Sub TileBar1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBar1.ItemClick
        GetReservationsList(TileBar1.SelectedItem.Tag)
    End Sub
    Private Sub GetTasksCount()
        Dim SqlString As String
        Dim Sql As New SQLControl
        SqlString = "    Select count(ID) as TasksCount1 from ReservationsList 
                            Where ReservationStatus=N'مفتوح' and  DocStatus <> -1 ;
                         Select count(ID) as TasksCount2 from ReservationsList 
                            Where ReservationStatus=N'مغلق' and  DocStatus <> -1 ; 
                         Select count(ID) As TasksCount3 from ReservationsList 
                            Where 1=1 and  DocStatus <> -1 ; "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Me.TileBarItem1.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("TasksCount1")
        Me.TileBarItem2.Elements(1).Text = Sql.SQLDS.Tables(1).Rows(0).Item("TasksCount2")
        Me.TileBarItem3.Elements(1).Text = Sql.SQLDS.Tables(2).Rows(0).Item("TasksCount3")
    End Sub

    Private Function GetTaskTrans(_TaskID As Integer) As Integer
        Dim _Count As Integer
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select count(ID) as Count  from AppointmentClosing where TaskID=" & _TaskID
            Sql.SqlTrueTimeRunQuery(SqlString)
            _Count = Sql.SQLDS.Tables(0).Rows(0).Item("Count")

        Catch ex As Exception
            _Count = 0
        End Try
        Return _Count
    End Function



    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        'Dim _TaskID = GridView1.GetFocusedRowCellValue("UniqueID")
        'Me.TileBarItem6.Elements(1).Text = GetTaskTrans(_TaskID)
        'Me.TileBarItem6.Elements(2).Text = "TaskID:" & _TaskID
    End Sub

    Private Sub TileBar2_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBar2.ItemClick
        Dim itemTag As Integer = Convert.ToInt32(e.Item.Tag)
        Select Case itemTag
            Case 1
                GetReservationsList(TileBar1.SelectedItem.Tag)
                GetTasksCount()
            Case 2
                Dim f As New ReservationAddEdit
                With f
                    .TextNewOld.Text = "New"
                    If .ShowDialog <> DialogResult.OK Then
                        GetReservationsList(1)
                    End If
                End With
            Case 3
                Dim _report As New ReservationXtraReport
                With _report
                    .Parameter1.Value = Me.GridView1.GetFocusedRowCellValue("ID")
                    .XrLabelRemainAmount.Text = " المبلغ المتبقي: " & Me.GridView1.GetFocusedRowCellValue("GridColumn3") & " شيكل "
                    .ShowPreview()
                End With
        End Select
    End Sub
    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim _ID = GridView1.GetFocusedRowCellValue("ID")
        Dim F As New ReservationAddEdit
        With F
            .TextNewOld.Text = "old"
            .DocIdquery.Text = _ID
            If .ShowDialog <> DialogResult.OK Then
                GetReservationsList(TileBar1.SelectedItem.Tag)
            End If
        End With
    End Sub
    Private Sub GetEmplStatusTable()
        Dim table As New DataTable
        table.Columns.Add("EmplStatus", GetType(String))
        table.Columns.Add("ArStatus", GetType(String))
        table.Columns.Add("EnStatus", GetType(String))
        table.Rows.Add("مفتوح", "مفتوح", "مفتوح")
        table.Rows.Add("مغلق", "مغلق", "مغلق")

        RepositoryItemLookUpEdit1.DataSource = table
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Const _Active As String = "<backcolor=@Success><b><color=255, 255, 255>  مفتوح  </b>"
        Const _UnActive As String = "<backcolor=@Danger><b><color=255, 255, 255>  مغلق  </b>"
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "ReservationStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ReservationStatus"))
            If category = "مفتوح" Then
                e.DisplayText = String.Format(_Active)
            ElseIf category = "مغلق" Then
                e.DisplayText = String.Format(_UnActive)
            End If
        End If
    End Sub
End Class