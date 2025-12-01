Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraRichEdit.Model

Public Class AttQuickAddTrans
    Private EmpID As Integer
    Private TransType As String
    Public _PublicTransTime As String
    Private LastInTime As String
    Private LastOutTime As String
    Private InsertOrEdit As String
    Private Sub AttQuickAddTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckIfHasAccessToAddAttendanceTrans() = False Then
            Me.Close()
            Exit Sub
        End If
        Me.CheckTypesTableAdapter.Fill(Me.TrueTimeDataSet.CheckTypes)
        LookUpEdit2.Properties.ValueMember = "CheckType"
        If GlobalVariables._SystemLanguage = "Arabic" Then
            LookUpEdit2.Properties.DisplayMember = "InArabic"
            LookUpEdit2.Properties.Columns("InEnglish").Visible = False
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            LookUpEdit2.Properties.DisplayMember = "InEnglish"
            LookUpEdit2.Properties.Columns("InArabic").Visible = False
        End If
        Me.KeyPreview = True
        TransTime.Select()
    End Sub
    Public Sub New(_EmpID As Integer, _TransType As String, _InsertOrEdit As String)
        InitializeComponent()
        LookUpEdit2.EditValue = _TransType
        TransType = _TransType
        EmpID = _EmpID
        InsertOrEdit = _InsertOrEdit
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            InsertData()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        InsertData()
    End Sub
    Private Sub InsertData()
        If TransTime.Text = "00:00" Then
            MsgBoxShowError(" يجب ادخال الوقت ")
            TransTime.Select()
            Exit Sub
        End If
        Dim _DateTime As String
        _DateTime = Format(TransDate.DateTime, "yyyy-MM-dd") & " " & Format(TransTime.Time, "HH:mm")
        Dim sql As New SQLControl
        Dim sqlstring As String = ""

        Select Case InsertOrEdit
            Case "Insert"
                sqlstring = "Insert Into AttCHECKINOUT 
                                         (USERID,CHECKTIME,CHECKTYPE,EditedDate,
                                          EditedType,Edited,EditNote,EditedUser) 
                              Values
                              (" & EmpID & " , '" & _DateTime & "' , '" & TransType & "',
                              GETDATE() ,'Insert',1,N'" & MemoEdit1.Text & "',
                              " & GlobalVariables.CurrUser & ")"
                'Case "Edit"
                '    sqlstring = " Update [AttCHECKINOUT] set EditedType = 'Update',
                '                               CHECKTIME ='" & _DateTime & "' ,
                '                               CHECKTYPE= '" & TransType & "' ,
                '                               EditNote=N'" & MemoEdit1.Text & "',
                '                               [EditedDate]=GETDATE(), 
                '                               [EditedUser]='" & GlobalVariables.CurrUser & "' 
                '                   where [ID]=" & CType(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ID"), String)
        End Select

        If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
            _PublicTransTime = Format(TransTime.Time, "HH:mm")
            Me.Close()
        Else
            MsgBoxShowError(" خطا ")
        End If
    End Sub
End Class