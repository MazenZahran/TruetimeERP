Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class SambaUnMatchAccountsUnMatchedRef
    Private _TextConnectionString As String = ""
    Private _dateFrom As String
    Private _dateTo As String
    Public Sub New(textConnectionString As String, dateFrom As String, dateTo As String)
        _dateFrom = dateFrom
        _dateTo = dateTo
        _TextConnectionString = textConnectionString
        InitializeComponent()
    End Sub
    Private Sub SambaUnMatchAccountsUnMatchedRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetUnMatchReferances()
        Me.RepositoryTTSReferances.DataSource = GetReferences(-1, -1, -1)
    End Sub
    Private Sub GetUnMatchReferances()
        Try
            If _TextConnectionString <> "" Then
                Dim SqlString As String = " select DISTINCT  V.AccountId,A.Name AS AccountName,CASE WHEN V.AccountTransactionTypeId=9 then 'Supplier' when AccountTransactionTypeId=10 then 'Employee' else 'Other' end as AccountTransactionTypeName,0 as RefNo
from AccountTransactionValues V
left join Accounts A on A.Id=V.AccountId
left join AccountsMapWithTTS tts on tts.sambaAccountID=A.Id
where AccountTransactionTypeId in (9,10) and V.AccountTypeId in (7,8) And V.Date Between '" & _dateFrom & "' And '" & _dateTo & "' and ttsRefNo Is Null 
 "
                Dim Con As SqlConnection
                Dim AdapterSupliersPayments As SqlDataAdapter
                Dim dataSet11 As DataSet
                Con = New SqlConnection(_TextConnectionString)
                Con.Open()
                AdapterSupliersPayments = New SqlDataAdapter(SqlString, Con)
                dataSet11 = New System.Data.DataSet()
                AdapterSupliersPayments.Fill(dataSet11, "RefNames")
                Con.Close()
                GridControl1.DataSource = dataSet11.Tables("RefNames")
            End If
        Catch ex As Exception
            MsgBoxShowError("Error " & ex.Message)
        End Try

    End Sub
    Private Sub InsertRefIntoAccountsMapWithTTS(SambaName As String, ttsName As String, ttsAccountNo As String, ttsAccountType As String, ttsRefNo As Integer, Currency As Integer, SambaAccountID As Integer)
        Try
            Dim SqlString As String = "INSERT INTO AccountsMapWithTTS (SambaName, ttsName, ttsAccountNo, ttsAccountType, ttsRefNo, Currency, SambaAccountID) " &
                                      "VALUES (@SambaName, @ttsName, @ttsAccountNo, @ttsAccountType, @ttsRefNo, @Currency, @SambaAccountID)"
            Using Con As New SqlConnection(_TextConnectionString)
                Using Cmd As New SqlCommand(SqlString, Con)
                    Cmd.Parameters.AddWithValue("@SambaName", SambaName)
                    Cmd.Parameters.AddWithValue("@ttsName", ttsName)
                    Cmd.Parameters.AddWithValue("@ttsAccountNo", ttsAccountNo)
                    Cmd.Parameters.AddWithValue("@ttsAccountType", ttsAccountType)
                    Cmd.Parameters.AddWithValue("@ttsRefNo", ttsRefNo)
                    Cmd.Parameters.AddWithValue("@Currency", Currency)
                    Cmd.Parameters.AddWithValue("@SambaAccountID", SambaAccountID)
                    Con.Open()
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBoxShowError("Error " & ex.Message)
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        Dim SambaName As String = GridView1.GetFocusedRowCellValue("AccountName")
        Dim AccountTransactionTypeName As String = GridView1.GetFocusedRowCellValue("AccountTransactionTypeName")
        Dim AccountIdOnSamba As Integer = GridView1.GetFocusedRowCellValue("AccountId")
        Dim RefNo As Integer = Integer.Parse(GridView1.GetFocusedRowCellValue("RefNo"))
        Dim RefData = GetRefranceData(RefNo)
        InsertRefIntoAccountsMapWithTTS(SambaName, RefData.RefName, RefData.RefAccID, AccountTransactionTypeName, RefNo, 1, AccountIdOnSamba)
    End Sub

    Private Sub RepositoryTTSReferances_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles RepositoryTTSReferances.AddNewValue
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = GridView1.GetFocusedRowCellValue("AccountName")
            If GridView1.GetFocusedRowCellValue("AccountTransactionTypeName") = "Supplier" Then
                .LookRefType.EditValue = 1
            ElseIf GridView1.GetFocusedRowCellValue("AccountTransactionTypeName") = "Employee" Then
                .LookRefType.EditValue = 99
            End If
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .TextRefName.Select()
            ._AddNewOrSave = "AddNew"
            .CheckActive.Checked = True
            If .ShowDialog() <> DialogResult.OK Then
                Me.RepositoryTTSReferances.DataSource = GetReferences(-1, -1, -1)
            End If
        End With

    End Sub
End Class