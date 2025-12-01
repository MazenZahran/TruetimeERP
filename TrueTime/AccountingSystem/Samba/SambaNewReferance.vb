Imports System.Data.SqlClient

Public Class SambaNewReferance
    Private _BranchID As Integer
    Private _ID As Integer
    Private _AccountID As Integer
    Public Sub New(ByVal BranchID As Integer, id As Integer, AccountId As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        _BranchID = BranchID
        _ID = id
        _AccountID = AccountId
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.Properties.BeforePopup

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        AddNewRefToSamba()
    End Sub
    Private Function CheckIfReferanceExist(_Name As String) As Boolean
        Dim _result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " exec sp_executesql N'SELECT 
    CASE WHEN ( EXISTS (SELECT 
        1 AS [C1]
        FROM [dbo].[Entities] AS [Extent1]
        WHERE ([Extent1].[Id] <> @p__linq__0) AND (((LOWER([Extent1].[Name])) = @p__linq__1) OR ((LOWER([Extent1].[Name]) IS NULL) AND (@p__linq__1 IS NULL)))
    )) THEN cast(1 as bit) ELSE cast(0 as bit) END AS [C1]
    FROM  ( SELECT 1 AS X ) AS [SingleRowTable1]',N'@p__linq__0 int,@p__linq__1 nvarchar(4000)',@p__linq__0=0,@p__linq__1=N'" & _Name & "'  "
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                If CBool(sql.SQLDS.Tables(0).Rows(0).Item("C1")) = True Then
                    _result = True
                End If
            End If
        Catch ex As Exception

        End Try
        Return _result
    End Function
    Private Function CheckIfAccountExist(_Name As String, _Mobile As String)
        Dim _result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " 
exec sp_executesql N'SELECT 
    CASE WHEN ( EXISTS (SELECT 
        1 AS [C1]
        FROM [dbo].[Accounts] AS [Extent1]
        WHERE ([Extent1].[Name] = @p__linq__0) OR (([Extent1].[Name] IS NULL) AND (@p__linq__0 IS NULL))
    )) THEN cast(1 as bit) ELSE cast(0 as bit) END AS [C1]
    FROM  ( SELECT 1 AS X ) AS [SingleRowTable1]',N'@p__linq__0 nvarchar(4000)',@p__linq__0=N'" & _Name & "-" & _Mobile & "'  "
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                If CBool(sql.SQLDS.Tables(0).Rows(0).Item("C1")) = True Then
                    _result = True
                End If
            End If
        Catch ex As Exception

        End Try
        Return _result
    End Function
    Private Sub AddNewRefToSamba()
        Dim _Name As String, _Mobile As String
        _Name = txtName.Text
        _Mobile = txtMobile.Text
        If String.IsNullOrEmpty(_Name) Then
            MsgBoxShowError(" الاسم فارغ ")
            txtName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(_Mobile) Then
            MsgBoxShowError(" رقم الموبايل فارغ ")
            txtMobile.Select()
            Exit Sub
        End If
        If SearchReferance.Text = "" Then
            MsgBoxShowError(" يجب ربط الحساب مع النظام المالي ")
            SearchReferance.Select()
            Exit Sub
        End If

        If CheckIfReferanceExist(_Name) = False And CheckIfAccountExist(_Name, _Mobile) = False Then
            Dim sqlstring As String
            Dim sql As New SQLControl
            Dim _AccountID As Integer = 0
            sqlstring = " exec sp_executesql N'INSERT [dbo].[Accounts]([AccountTypeId], [ForeignCurrencyId], [Name])
                            VALUES (@0, @1, @2)
                            SELECT [Id]
                            FROM [dbo].[Accounts]
                            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()',N'@0 int,@1 int,@2 nvarchar(max) ',@0=5,@1=0,@2=N'" & _Name & "-" & _Mobile & "'"
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                _AccountID = sql.SQLDS.Tables(0).Rows(0).Item("Id")
            Else
                MsgBoxShowError(" خطا  ")
                Exit Sub
            End If
            If _AccountID <> 0 Then
                Dim _APIString As String = "[{""Name"":""Phone"",""Value"":""" & txtMobile.Text & """},{""Name"":""Address"",""Value"":""ramallah""}]"
                sqlstring = " exec sp_executesql N'INSERT [dbo].[Entities]([EntityTypeId], [LastUpdateTime], [SearchString], [CustomData], [Notes], [AccountId], [WarehouseId], [Name])
                            VALUES (@0, GetDate(), NULL, @2, NULL, @3, @4, @5)
                            SELECT [Id]
                            FROM [dbo].[Entities]
                            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()',N'@0 int,@2 nvarchar(max) ,@3 int,@4 int,@5 nvarchar(max) ',@0=1,@2=N'" & _APIString & "',@3=" & _AccountID & ",@4=0,@5=N'" & _Name & "' "

                If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                    MsgBoxShowSuccess(" تم تعريف الزبون بنجاح ")
                    Me.Close()
                Else
                    MsgBoxShowError(" خطا ")
                    sqlstring = " delete from Accounts where Id=" & _AccountID
                    sql.SqlPosRunQuery(sqlstring, _BranchID)
                End If
            Else
                MsgBoxShowError(" خطا ")
            End If

        Else
            MsgBoxShowError(" الاسم معرف مسبقا ")
            Exit Sub
        End If
    End Sub
    Private Sub UpdateRefToSamba()
        Dim _Name As String, _Mobile As String
        _Name = txtName.Text
        _Mobile = txtMobile.Text
        If String.IsNullOrEmpty(_Name) Then
            MsgBoxShowError(" الاسم فارغ ")
            txtName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(_Mobile) Then
            MsgBoxShowError(" رقم الموبايل فارغ ")
            txtMobile.Select()
            Exit Sub
        End If
        If SearchReferance.Text = "" Then
            MsgBoxShowError(" يجب ربط الحساب مع النظام المالي ")
            SearchReferance.Select()
            Exit Sub
        End If

        If CheckIfReferanceExist(_Name) = False And CheckIfAccountExist(_Name, _Mobile) = False Then
            Dim sqlstring As String
            Dim sql As New SQLControl
            Dim _AccountID As Integer = 0
            sqlstring = " exec sp_executesql N'Update [dbo].[Accounts] Set [Name]=N'" & _Name & "-" & _Mobile & "' Where id=1)"
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                _AccountID = sql.SQLDS.Tables(0).Rows(0).Item("Id")
            Else
                MsgBoxShowError(" خطا  ")
                Exit Sub
            End If
            If _AccountID <> 0 Then
                Dim _APIString As String = "[{""Name"":""Phone"",""Value"":""" & txtMobile.Text & """},{""Name"":""Address"",""Value"":""ramallah""}]"
                sqlstring = " exec sp_executesql N'Update [dbo].[Entities]([EntityTypeId], [LastUpdateTime], [SearchString], [CustomData], [Notes], [AccountId], [WarehouseId], [Name])
                            VALUES (@0, GetDate(), NULL, @2, NULL, @3, @4, @5)
                            SELECT [Id]
                            FROM [dbo].[Entities]
                            WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()',N'@0 int,@2 nvarchar(max) ,@3 int,@4 int,@5 nvarchar(max) ',@0=1,@2=N'" & _APIString & "',@3=" & _AccountID & ",@4=0,@5=N'" & _Name & "' "

                If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                    MsgBoxShowSuccess(" تم تعريف الزبون بنجاح ")
                    Me.Close()
                Else
                    MsgBoxShowError(" خطا ")
                    sqlstring = " delete from Accounts where Id=" & _AccountID
                    sql.SqlPosRunQuery(sqlstring, _BranchID)
                End If
            Else
                MsgBoxShowError(" خطا ")
            End If

        Else
            MsgBoxShowError(" الاسم معرف مسبقا ")
            Exit Sub
        End If
    End Sub
    Private Sub AccountInsert()
        ' Your connection string
        Dim connectionString As String = "Your_Connection_String"

        ' Your string with double quotation marks
        Dim yourString As String = "Mazen"

        ' SQL query with parameter
        Dim query As String = "INSERT INTO YourTable (YourColumn) VALUES (@YourString)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameter
                command.Parameters.AddWithValue("@YourString", yourString)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Console.WriteLine("String inserted successfully.")
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub SambaNewReferance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SearchReferance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub
End Class