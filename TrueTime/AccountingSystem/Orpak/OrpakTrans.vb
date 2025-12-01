Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports TrueTime.DynamicallyConnectionString

Public Class OrpakTrans
    Private Sub OrpakTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SearchPosName.Properties.DataSource = GetOrpakPos()
        SearchPosName.EditValue = 1
        RadioGroup1.EditValue = "current"
    End Sub


    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosName.EditValueChanged
        If String.IsNullOrEmpty(SearchPosName.Text) Then
            Exit Sub
        End If
        If Me.IsHandleCreated = True And SearchPosName.Text <> "" Then
            TextConnectionString.Text = ""
            Dim _OrpakConnection = OrpakControl.GetOrpakConnectionString(SearchPosName.EditValue)
            If _OrpakConnection._IsConnection = True Then
                TextConnectionString.Text = _OrpakConnection._Cstring
            End If
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SearchPosName.Text = "" Then Exit Sub
        If TextConnectionString.Text = "" Then Exit Sub
        GridControl1.DataSource = ""
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable
        Dim _dateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd") & " " & Format(TimeEdit1.Time, "HH:mm:ss")
        Dim _date__To As String = Format(DateEdit2.DateTime, "yyyy-MM-dd") & " " & Format(TimeEdit2.Time, "HH:mm:ss")

        SqlString = "SELECT  [shift_id],T.[id],[date]
                              ,[time],[type],[pump],[sale]
                              ,[ppv],[quantity],[tag],[plate]
                              ,[mean_name],[product_name],F.code as FleetCode,driver_name
	                          ,F.name as FleetName,timestamp,[nozzle],proxy_id
                    FROM [dbo].[transactions] T 
                    Left join fleets F on F.id=T.fleet_id where timestamp between '" & _dateFrom & "' and '" & _date__To & "'"
        If SearchReferance.Text <> "" Then SqlString += " and F.code='" & SearchReferance.EditValue & "'"
        SqlString += " order by id desc  "

        Dim Con As SqlConnection
        Dim Adapter1 As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(TextConnectionString.Text)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "Tickets")
        Con.Close()
        dataSet11.AcceptChanges()
        GridControl1.DataSource = dataSet11.Tables("Tickets")

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "last"
                Dim _fromdate, _todate As DateTime
                Dim _lastmonth, _year As Integer
                If Today.Month = 1 Then
                    _lastmonth = 12
                    _year = Today.Year - 1
                Else
                    _lastmonth = Today.Month - 1
                    _year = Today.Year
                End If
                Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
                _fromdate = New DateTime(_year, _lastmonth, 1)
                _todate = New DateTime(_year, _lastmonth, _daysCount)
                Me.DateEdit2.DateTime = _todate
                Me.DateEdit1.DateTime = _fromdate
            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt
        End Select
    End Sub

    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.Properties.BeforePopup
        SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub
End Class