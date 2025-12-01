Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports TrueTime.DynamicallyConnectionString

Public Class ZenHrSyncData
    Private _ConnectionName As String
    Dim _ttsUnreadAttTransCount As Integer
    Dim _ZenAttTransCount As Integer
    Public Sub New()
        InitializeComponent()
        BackgroundWorker1.WorkerReportsProgress = True
    End Sub
    Sub ZenHrSyncData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select SettingValue from Settings where SettingName='AlqudsCigConnection'"
            sql.SqlTrueTimeRunQuery(sqlstring)
            _ConnectionName = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ConnectionName = ""
        End Try
        LabelConnectionResult.Visible = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.BarStaticItemSync.Caption = "Sync..."
        'Me.BarStaticItemSync.Caption = (e.ProgressPercentage.ToString() & "%")
        ' Me.BarEditItemSync.EditValue = (e.ProgressPercentage)
        Select Case e.ProgressPercentage
            Case 0
                LabelConnectionResult.Text = "   "
                LabelUnreadTransResult.Text = "   "
                LabelreadTransResult.Text = "   "
                LayoutControlItemTestConnection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 1
                LabelConnectionResult.Text = "Error: Connection Error"
                LayoutControlItemResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LabelResult.Text = "Sync faild "
            Case 10
                LayoutControlItemProgress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LabelConnectionResult.Text = "Success"
                LayoutControlItemUnreadTransontts.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 21
                LabelUnreadTransResult.Text = "There is no new transactions"
                LayoutControlItemResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LabelResult.Text = "Sync finished"
            Case 20
                LabelUnreadTransResult.Text = _ttsUnreadAttTransCount
                LayoutControlItemreadTransontts.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case 30
                LabelreadTransResult.Text = TransToZen()
            Case 100
                LayoutControlItemResult.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LabelResult.Text = "Sync finished"
        End Select
        Me.ProgressBarControl1.EditValue = e.ProgressPercentage
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)

        worker.ReportProgress(0)
        System.Threading.Thread.Sleep(500)


        System.Threading.Thread.Sleep(500)
        If TestConnection() = False Then
            worker.ReportProgress(1)
            Exit Sub
        Else
            worker.ReportProgress(10)
            System.Threading.Thread.Sleep(500)
        End If


        System.Threading.Thread.Sleep(500)
        _ttsUnreadAttTransCount = GetUnreadTransCount()
        If _ttsUnreadAttTransCount > 0 Then
            worker.ReportProgress(20)
        Else
            worker.ReportProgress(21)
            Exit Sub
        End If

        System.Threading.Thread.Sleep(500)
        worker.ReportProgress(30)

        System.Threading.Thread.Sleep(500)
        worker.ReportProgress(100)
    End Sub
    Private Function TestConnection() As Boolean
        Dim _connected As Boolean
        Dim connectionString As String = _ConnectionName
        Try
            Dim helper As SqlHelper = New SqlHelper(connectionString)
            If helper.IsConnection Then
                _connected = True
            Else
                _connected = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        Return _connected
    End Function
    Private Function GetUnreadTransCount() As Integer
        Dim _count As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select count(id) as _count  from AttCHECKINOUT where SentToZen =0 or SentToZen is null "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _count = sql.SQLDS.Tables(0).Rows(0).Item("_count")
        Catch ex As Exception
            _count = 0
        End Try
        Return _count
    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Function TransToZen() As Integer
        Dim _rows As Integer
        _rows = 0
        ' Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "     declare @MaxID INT
                          declare @MinId INT
                          Set @MaxID= ( Select Max(ID) from AttCHECKINOUT where SentToZen Is Null  )
                          Set @MinId =( Select Min(ID) from AttCHECKINOUT where SentToZen Is Null  )
                          insert into [dbo].[functions]  (recordDatetime,machineID,cardid,[status],[function] ) 
                          select checktime,SENSORID,USERID,0,CHECKTYPE as checktype from [dbo].[AttCHECKINOUT] 
                          where ID between @MinId and @MaxID;
                          Update AttCHECKINOUT Set SentToZen=1 where ID between @MinId and @MaxID  "
        ' Sql.SqlTrueAccountingRunQuery(sqlstring)


        Try
            Dim constring As String = My.Settings.TrueTimeConnectionString
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(sqlstring, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    _rows = cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return _rows / 2

    End Function
End Class