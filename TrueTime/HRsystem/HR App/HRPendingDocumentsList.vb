Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class HRPendingDocumentsList

    Dim WithImages As Boolean
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub TileBar1_Click(sender As Object, e As EventArgs) Handles TileBar1.Click

    End Sub

    Private Sub SubScriptionsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        GetDocStatusTable()
        GetDocNamesTable()
        GetSubscritions("TileBarPending")
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetSubscritions(TileBar1.SelectedItem.Name)
        End If
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Dim _EmpID, _DocName, _DocID As Integer
        _EmpID = GridView1.GetFocusedRowCellValue("EmployeeID")
        _DocName = GridView1.GetFocusedRowCellValue("DocName")
        _DocID = GridView1.GetFocusedRowCellValue("DocID")
        Select Case tag
            Case "OpenDoc"
                OpenDoc(_DocName, _EmpID, _DocID)
            Case "Close"
                Me.Close()
            Case "OpenSubscriber"
                My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
                My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
                If EmployeesEdit.ShowDialog() = DialogResult.OK Then
                    MsgBox("ok")
                Else
                    GetSubscritions(TileBar1.SelectedItem.Name)
                End If
            Case "Refresh"
                GetSubscritions(TileBar1.SelectedItem.Name)
            Case "out"
                Dim _SubID As Integer
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("EmployeeID")) And Not String.IsNullOrEmpty(GridView1.GetFocusedRowCellValue("EmployeeID")) Then
                    Dim F As New EmployeeOut
                    With F
                        _SubID = GridView1.GetFocusedRowCellValue("EmployeeID")
                        .EmployeeIDTextEdit.EditValue = _SubID
                        If .ShowDialog() <> DialogResult.OK Then
                            GetSubscritions(TileBar1.SelectedItem.Name)
                        End If
                    End With
                End If
            Case "Print"
                GridControl1.ShowPrintPreview()
            Case "Copy"
                GridView1.OptionsSelection.MultiSelect = True
                GridView1.SelectAll()
                GridView1.CopyToClipboard()
                GridView1.OptionsSelection.MultiSelect = False
        End Select
    End Sub
    Private Sub OpenDoc(DocName As Integer, EmpID As Integer, DocID As Integer)
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Select Case DocName
            Case 1
                Dim _VocDetials = GetVocationDetails(DocID)
                Dim F As New VocationFromApp
                With F
                    .Text = "تفاصيل طلب الاجازة للموظف:" & "  (" & GridView1.GetFocusedRowCellValue("EmployeeName") & ")"
                    .EmployeeID.EditValue = EmpID
                    .DateEditFrom.Text = _VocDetials.FromDate
                    .DateEditTo.Text = _VocDetials.ToDate
                    .VocationType.Text = _VocDetials.VocationName
                    .MemoEdit1.Text = _VocDetials.NoteDetails
                    .DateEditFrom.Text = _VocDetials.FromDate
                    .DateEditFrom.Text = _VocDetials.ToDate
                    .VocationID.EditValue = _VocDetials.VocationType
                    .MemoEdit3.EditValue = _VocDetials.NoteFromManager
                    .TextEmployee.Text = GridView1.GetFocusedRowCellValue("EmployeeName")
                    .DocID.Text = GridView1.GetFocusedRowCellValue("DocID")
                    If GridView1.GetFocusedRowCellValue("DocStatus") <> 0 Then
                        .LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        .LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    End If
                    If .ShowDialog() <> DialogResult.OK Then
                        GetSubscritions(TileBar1.SelectedItem.Name)
                    End If
                End With
            Case 2
                Dim _AttDetials = GetAttDetails(DocID)
                Dim F As New AttFromApp
                With F
                    .Text = "تفاصيل طلب اعتماد حركة دوام للموظف:" & "  (" & GridView1.GetFocusedRowCellValue("EmployeeName") & ")"
                    .TextEmployee.Text = GridView1.GetFocusedRowCellValue("EmployeeName")
                    .EmployeeID.EditValue = EmpID
                    .TransType.Text = _AttDetials.CHECKTYPE
                    .AttDateTime.Text = _AttDetials.CHECKTIME
                    .LongitudeAndLatitude.Text = _AttDetials.Latitude & ":" & _AttDetials.Longitude
                    .Longitude.Text = _AttDetials.Longitude
                    .Latitude.Text = _AttDetials.Latitude
                    .MemoEdit3.Text = _AttDetials.NoteFromManager
                    .DocID.Text = GridView1.GetFocusedRowCellValue("DocID")
                    If GridView1.GetFocusedRowCellValue("DocStatus") <> 0 Then
                        .LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        .LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    End If
                    If .ShowDialog() <> DialogResult.OK Then
                        GetSubscritions(TileBar1.SelectedItem.Name)
                    End If
                End With
        End Select
        GridView1.FocusedRowHandle = focusedRow
    End Sub
    Private Function GetVocationDetails(DocID As Integer) As (VocationType As Integer, FromDate As String,
                                                              ToDate As String, NoDays As Integer,
                                                              NoteDetails As String, VocDate As String,
                                                              NoteFromManager As String, VocationName As String)
        Dim _VocationType As Integer = 0
        Dim _VocationName As String = ""
        Dim _FromDate As String = "1900-01-01"
        Dim _ToDate As String = "1900-01-01"
        Dim _NoDays As Decimal = 0
        Dim _NoteDetails As String = " "
        Dim _VocDate As String = "1900-01-01"
        Dim _NoteFromManager As String = " "
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  SELECT  P.[VocID] ,[VocDate],[EmployeeID],
                               V.Vocation As VocationName,[FromDate],[ToDate],[NoDays],[NoteFromManager],
                               [NoteDetails],[VocationType]
                       FROM [dbo].[VocationsPending] P 
                       Left join VocationsTypes V on P.VocationType=V.VocID 
                       Where P.VocID= " & DocID
        sql.SqlTrueAccountingRunQuery(SqlString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Return (_VocationType, _FromDate, _ToDate, _NoDays, _NoteDetails, _VocDate, _NoteFromManager, _VocationName)
            Exit Function
        End If
        With sql.SQLDS.Tables(0).Rows(0)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not (IsDBNull(.Item("VocationName"))) Then _VocationName = (.Item("VocationName").ToString)
                If Not (IsDBNull(.Item("FromDate"))) Then _FromDate = .Item("FromDate")
                If Not (IsDBNull(.Item("ToDate"))) Then _ToDate = .Item("ToDate")
                If Not (IsDBNull(.Item("NoDays"))) Then _NoDays = .Item("NoDays")
                If Not (IsDBNull(.Item("NoteDetails"))) Then _NoteDetails = .Item("NoteDetails")
                If Not (IsDBNull(.Item("VocDate"))) Then _VocDate = .Item("VocDate")
                If Not (IsDBNull(.Item("NoteFromManager"))) Then _NoteFromManager = CStr(.Item("NoteFromManager"))
                If Not (IsDBNull(.Item("VocationType"))) Then _VocationType = .Item("VocationType")
            End If
        End With
        Return (_VocationType, _FromDate, _ToDate, _NoDays, _NoteDetails, _VocDate, _NoteFromManager, _VocationName)
    End Function
    Private Function GetAttDetails(DocID As Integer) As (CHECKTIME As DateTime, CHECKTYPE As String,
                                                         Latitude As String, Longitude As String, NoteFromManager As String)
        Dim _CHECKTIME As DateTime = Now
        Dim _CHECKTYPE As String = " "
        Dim _Latitude As String = "0"
        Dim _Longitude As String = "0"
        Dim _NoteFromManager As String = " "

        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "  SELECT  [USERID],[CHECKTIME],T.InArabic,
                               [SENSORID],[ID],[Location],[Latitude],
                               [Longitude],[TransStatus],[DocInputDateTime],[NoteFromManager]
                       FROM [AttCHECKINOUTPending] A
                       LEFT JOIN [CheckTypes] T ON A.CHECKTYPE COLLATE Latin1_General_CS_AS =T.CheckType COLLATE Latin1_General_CS_AS
                       Where ID= " & DocID
        sql.SqlTrueAccountingRunQuery(SqlString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Return (_CHECKTIME, _CHECKTYPE, _Latitude, _Longitude, _NoteFromManager)
            Exit Function
        End If
        With sql.SQLDS.Tables(0).Rows(0)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not (IsDBNull(.Item("CHECKTIME"))) Then _CHECKTIME = (.Item("CHECKTIME").ToString)
                If Not (IsDBNull(.Item("InArabic"))) Then _CHECKTYPE = .Item("InArabic")
                If Not (IsDBNull(.Item("Latitude"))) Then _Latitude = .Item("Latitude")
                If Not (IsDBNull(.Item("Longitude"))) Then _Longitude = .Item("Longitude")
                If Not (IsDBNull(.Item("NoteFromManager"))) Then _NoteFromManager = .Item("NoteFromManager")
            End If
        End With
        Return (_CHECKTIME, _CHECKTYPE, _Latitude, _Longitude, _NoteFromManager)
    End Function

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarApproved.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        WithImages = True
        GetSubscritions(TileBar1.SelectedItem.Name)
        GridControl1.MainView = TileView1

    End Sub
    Private Sub GetSubscritions(_Action As String)
        Dim _VocationTable As New DataTable
        Dim _AttTransTable As New DataTable
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _DocStatus As Integer = 99
        Select Case _Action
            Case "TileBarAll"
                _DocStatus = 99
                TileBarAll.Checked = True
                TileBarPending.Checked = False
                TileBarApproved.Checked = False
                TileBarDeclined.Checked = False
            Case "TileBarPending"
                _DocStatus = 0
                TileBarAll.Checked = False
                TileBarPending.Checked = True
                TileBarApproved.Checked = False
                TileBarDeclined.Checked = False
            Case "TileBarApproved"
                _DocStatus = 1
                TileBarAll.Checked = False
                TileBarPending.Checked = False
                TileBarApproved.Checked = True
                TileBarDeclined.Checked = False
            Case "TileBarDeclined"
                _DocStatus = -1
                TileBarAll.Checked = False
                TileBarPending.Checked = False
                TileBarApproved.Checked = False
                TileBarDeclined.Checked = True
        End Select
        SqlString = "   DECLARE @DocStatus int;
                        SET @DocStatus=" & _DocStatus & ";
                        SELECT V.[VocID] AS DocID,
                               [VocDate] AS DocDate,
                               E.EmployeeName,
                               '1' AS DocName,
                               N'طلب اجازة' AS DocNameText,
                               E.Mobile1 AS Mobile,
                               T.Vocation AS DocType,
                               DocStatus,
                               DocInputDateTime,
                               E.JobName,
                               E.[Department],
                               E.[Branch],
                               V.[EmployeeID]
                        FROM [dbo].[VocationsPending] V
                        LEFT JOIN EmployeesData E ON V.EmployeeID=E.[EmployeeID]
                        LEFT JOIN VocationsTypes T ON V.VocationType=T.VocID "
        If _DocStatus <> 99 Then SqlString += "  WHERE [DocStatus]=@DocStatus "
        SqlString += " UNION
                        SELECT V.ID AS DocID ,
                               [CHECKTIME] AS DocDate,
                               E.EmployeeName,
                               '2' AS DocName,
                               N'حركة دوام' AS DocNameText,
                               E.Mobile1 AS Mobile,
                               T.InArabic AS DocType,
                               [TransStatus] AS DocStatus,
                               DocInputDateTime,
                               E.JobName,
                               E.[Department],
                               E.[Branch],
                               V.[USERID]
                        FROM [dbo].AttCHECKINOUTPending V
                        LEFT JOIN EmployeesData E ON V.[USERID]=E.[EmployeeID]
                        LEFT JOIN [CheckTypes] T ON V.CHECKTYPE COLLATE Latin1_General_CS_AS =T.CheckType COLLATE Latin1_General_CS_AS"
        If _DocStatus <> 99 Then SqlString += "  WHERE [TransStatus]=@DocStatus order by DocInputDateTime desc"
        Sql.SqlTrueTimeRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)

        SqlString = "  Select Sum(Pendings) As AllPendings from (
                              SELECT Count([ID]) As Pendings From [dbo].[AttCHECKINOUTPending]
                              Union All
                              SELECT Count([VocID]) As Pendings From [dbo].[VocationsPending]) A ;
                       Select Sum(Pendings) As Pendings from (
                              SELECT Count([ID]) As Pendings From [dbo].[AttCHECKINOUTPending] Where TransStatus=0
                              Union All
                              SELECT Count([VocID]) As Pendings From [dbo].[VocationsPending] Where DocStatus=0 ) A ;
                       Select Sum(Pendings) As Approved from (
                              SELECT Count([ID]) As Pendings From [dbo].[AttCHECKINOUTPending] Where TransStatus=1
                              Union All
                              SELECT Count([VocID]) As Pendings From [dbo].[VocationsPending] Where DocStatus=1 ) A ;
                       Select Sum(Pendings) As Declined from (
                              SELECT Count([ID]) As Pendings From [dbo].[AttCHECKINOUTPending] Where TransStatus=-1
                              Union All
                              SELECT Count([VocID]) As Pendings From [dbo].[VocationsPending] Where DocStatus=-1 ) A "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Me.TileBarAll.Elements(1).Text = Sql.SQLDS.Tables(0).Rows(0).Item("AllPendings")
        Me.TileBarPending.Elements(1).Text = Sql.SQLDS.Tables(1).Rows(0).Item("Pendings")
        Me.TileBarApproved.Elements(1).Text = Sql.SQLDS.Tables(2).Rows(0).Item("Approved")
        Me.TileBarDeclined.Elements(1).Text = Sql.SQLDS.Tables(3).Rows(0).Item("Declined")

    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarAll.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub

    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarDeclined.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub
    Private Sub GetDocNamesTable()
        Dim table As New DataTable
        table.Columns.Add("NameID", GetType(Integer))
        table.Columns.Add("DocName", GetType(String))
        table.Rows.Add("1", "طلب اجازة")
        table.Rows.Add("2", "حركة دوام")
        RepositoryDocNames.DataSource = table
    End Sub
    Private Sub GetDocStatusTable()
        Dim ProcessType As New DataTable
        ProcessType.Columns.Add("TypeID", GetType(Integer))
        ProcessType.Columns.Add("TypeString", GetType(String))
        ProcessType.Rows.Add(-3, "الكل")
        ProcessType.Rows.Add(-2, "محذوفة")
        ProcessType.Rows.Add(-1, "مرفوضة")
        ProcessType.Rows.Add(0, "بانتظار الموافقة")
        ProcessType.Rows.Add(1, "معتمدة")
        RepositoryDocStatus.DataSource = ProcessType
    End Sub

    Private Sub TileBarItem1_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        WithImages = False
        GridControl1.MainView = GridView1
    End Sub

    Private Sub TileBarPending_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarPending.ItemClick
        GetSubscritions(TileBar1.SelectedItem.Name)
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim Pending As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  بانتظار الموافقة  </b>"
        Dim Approved As String = "<backcolor=@Success><b><color=255, 255, 255>  معتمدة  </b>"
        Dim Cancelled As String = "<backcolor=@Critical><b><color=255, 255, 255>  مرفوضة  </b>"
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "DocStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocStatus"))
            If category = "بانتظار الموافقة" Then
                e.DisplayText = String.Format(Pending)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "معتمدة" Then
                e.DisplayText = String.Format(Approved)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مرفوضة" Then
                e.DisplayText = String.Format(Cancelled)
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub

    Private Sub RepositoryItemDocID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemDocID.OpenLink
        Dim _EmpID, _DocName, _DocID As Integer
        _EmpID = GridView1.GetFocusedRowCellValue("EmployeeID")
        _DocName = GridView1.GetFocusedRowCellValue("DocName")
        _DocID = GridView1.GetFocusedRowCellValue("DocID")
        OpenDoc(_DocName, _EmpID, _DocID)
    End Sub

    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        GridControl1.MainView = GridView1
    End Sub

    Private Sub TileBarItem2_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        GridControl1.MainView = TileView1
    End Sub


    'Public Sub HandleBehaviorDragDropEvents()
    '    Dim gridControlBehavior As DragDropBehavior = BehaviorManager1.GetBehavior(Of DragDropBehavior)(Me.GridView1)
    '    AddHandler gridControlBehavior.DragDrop, AddressOf Behavior_DragDrop
    '    AddHandler gridControlBehavior.DragOver, AddressOf Behavior_DragOver
    'End Sub
    'Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)
    '    Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
    '    e.InsertType = args.InsertType
    '    e.InsertIndicatorLocation = args.InsertIndicatorLocation
    '    e.Action = args.Action
    '    Cursor.Current = args.Cursor
    '    args.Handled = True
    'End Sub
    Private Sub Behavior_DragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
        'Dim targetGrid As GridView = TryCast(e.Target, GridView)
        'Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        'If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
        '    Return
        'End If
        'Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        'Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        'Dim hitInfo As GridHitInfo = targetGrid.CalcHitInfo(hitPoint)

        'Dim sourceHandles() As Integer = e.GetData(Of Integer())()

        'Dim targetRowHandle As Integer = hitInfo.RowHandle
        'Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        'Dim draggedRows As New List(Of DataRow)()
        'For Each sourceHandle As Integer In sourceHandles
        '    Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
        '    Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
        '    draggedRows.Add(oldRow)
        'Next sourceHandle

        'Dim newRowIndex As Integer

        'Select Case e.InsertType
        '    Case InsertType.Before
        '        newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
        '        For i As Integer = draggedRows.Count - 1 To 0 Step -1
        '            Dim oldRow As DataRow = draggedRows(i)
        '            Dim newRow As DataRow = sourceTable.NewRow()
        '            newRow.ItemArray = oldRow.ItemArray
        '            sourceTable.Rows.Remove(oldRow)
        '            sourceTable.Rows.InsertAt(newRow, newRowIndex)
        '        Next i
        '    Case InsertType.After
        '        newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
        '        For i As Integer = 0 To draggedRows.Count - 1
        '            Dim oldRow As DataRow = draggedRows(i)
        '            Dim newRow As DataRow = sourceTable.NewRow()
        '            newRow.ItemArray = oldRow.ItemArray
        '            sourceTable.Rows.Remove(oldRow)
        '            sourceTable.Rows.InsertAt(newRow, newRowIndex)
        '        Next i
        '    Case Else
        '        newRowIndex = -1
        'End Select
        'Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        'targetGrid.FocusedRowHandle = insertedIndex
        'targetGrid.SelectRow(targetGrid.FocusedRowHandle)
        'MsgBox(targetGrid.FocusedRowHandle)
    End Sub

    Private Sub DragDropEvents1_EndDragDrop(sender As Object, e As EndDragDropEventArgs) Handles DragDropEvents1.EndDragDrop

    End Sub

    Private Sub DragDropEvents1_DragOver(sender As Object, e As DragOverEventArgs) Handles DragDropEvents1.DragOver
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
    End Sub

    Private Sub DragDropEvents1_DragDrop(sender As Object, e As DragDropEventArgs) Handles DragDropEvents1.DragDrop
        Dim targetGrid As GridView = TryCast(e.Target, GridView)
        Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If
        Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        Dim hitInfo As GridHitInfo = targetGrid.CalcHitInfo(hitPoint)

        Dim sourceHandles() As Integer = e.GetData(Of Integer())()

        Dim targetRowHandle As Integer = hitInfo.RowHandle
        Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        Dim draggedRows As New List(Of DataRow)()
        For Each sourceHandle As Integer In sourceHandles
            Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
            Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
            draggedRows.Add(oldRow)
        Next sourceHandle

        Dim newRowIndex As Integer

        Select Case e.InsertType
            Case InsertType.Before
                newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
                For i As Integer = draggedRows.Count - 1 To 0 Step -1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case InsertType.After
                newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
                For i As Integer = 0 To draggedRows.Count - 1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case Else
                newRowIndex = -1
        End Select
        Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        targetGrid.FocusedRowHandle = insertedIndex
        targetGrid.SelectRow(targetGrid.FocusedRowHandle)
        'MsgBox(targetGrid.FocusedRowHandle)
    End Sub
End Class